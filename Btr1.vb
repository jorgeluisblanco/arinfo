Option Strict On
Option Explicit On
Public Class Btr
    Inherits System.Windows.Forms.Form

    Class ClsCampo
        Public CampoNumero As Short
        Public Titulo As String
        Public Fila As Short
        Public Columna As Short
        Public Ancho As Short
        Public Numerico As Short
        Public Decimales As Short
        Public Ofset As Short
        Public Campo As String
    End Class


    Private CurNroFiltro As Short = 0
    Private pDDF As String = DDF & "FILE.DDF"

    Public Tabla As String = "provedo1"
    Public Archivo As String = DBF & "provedo1"


    Public Property DDF() As String
        Get
            DDF = pDDF
        End Get
        Set(ByVal Value As String)
            pDDF = Value
        End Set
    End Property

    'Public DDF As String = DDF & "FILE.DDF"
    Public Cripto As String = "{"
    Public NameKeyval As String
    Public Campos As New List(Of ClsCampo)
    Public NumerodeCampos As Integer
    Public NumerodeCamposVisibles As Integer
    Public Shared Btrs As New SortedList 'Collection()

    Public Property NroFiltro() As Short
        Get
            NroFiltro = CurNroFiltro
        End Get
        Set(ByVal Value As Short)
            CurNroFiltro = Value
        End Set
    End Property

    Public Event Filtros(ByRef Habilitacion As Short, ByVal Parametros As Object, ByVal Filtro As Short)

    Public Function AbreArchivos() As Integer
        Dim File As String = Me.Archivo
        Dim Filebtr As String = File & ".prm"
        Dim Fileprm As String = File & ".btr"
        BtAbrePrm()
        Dim Status As Integer = BtAbreBtr()
        Return Status
    End Function

    Function BtAbreBtr() As Integer
        Vbtrv1.DatabaseName = pDDF ' Me.DDF
        Vbtrv1.RecordSource = Me.Tabla
        Vbtrv1.FilePathName = Me.Archivo & ".btr"
        Vbtrv1.OwnerName = Me.Cripto
        Dim Status As Integer = Vbtrv1.Open
        If Status = 0 Then
            If Btr.Btrs.ContainsKey(Me.Tabla) = False Then
                Btrs.Add(Me.Tabla, Me)
            End If
            'For Each bt As System.Collections.DictionaryEntry In Btrs
            'MsgBox(bt.Key.ToString)
            'Next
        End If
        Vbtrv1.DirectEdits = True
        Return Status
    End Function

    Sub BtAbrePrm()
        Dim pathPrm As String = Me.Archivo & ".prm"
        
        If Not System.IO.File.Exists(pathPrm) Then
            AppLogger.LogWarn("No se encontró el archivo PRM en: {0}. Intentando cargar esquema vacío.", pathPrm)
            Return
        End If

        Try
            ' Usamos TextFieldParser para manejar correctamente los campos delimitados por comas y comillas
            Using parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(pathPrm)
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                parser.SetDelimiters(",")
                parser.HasFieldsEnclosedInQuotes = True

                If Not parser.EndOfData Then
                    Dim firstLine As String() = parser.ReadFields()
                    If firstLine IsNot Nothing AndAlso firstLine.Length >= 2 Then
                        ' firstLine(0) es Dummy, firstLine(1) es NumerodeCampos
                        NumerodeCampos = CInt(Val(firstLine(1)))
                    End If
                End If

                NumerodeCamposVisibles = 0
                Campos.Clear()
                Dim LargodeRegistro As Short = 0

                Dim i As Integer = 1
                While Not parser.EndOfData AndAlso i <= NumerodeCampos
                    Dim line As String() = parser.ReadFields()
                    If line IsNot Nothing AndAlso line.Length >= 6 Then
                        Dim TempCampo As New ClsCampo()
                        TempCampo.Ofset = CShort(1 + LargodeRegistro)
                        TempCampo.CampoNumero = CShort(i)
                        
                        TempCampo.Titulo = line(0).Trim()
                        TempCampo.Fila = CShort(Val(line(1)))
                        TempCampo.Columna = CShort(Val(line(2)))
                        TempCampo.Ancho = CShort(Val(line(3)))
                        TempCampo.Numerico = CShort(Val(line(4)))
                        TempCampo.Decimales = CShort(Val(line(5)))
                        ' line(6) sería el Dummy si existiera en esa línea

                        LargodeRegistro = CShort(LargodeRegistro + TempCampo.Ancho)
                        
                        If TempCampo.Ancho > 0 Then
                            NumerodeCamposVisibles += 1
                            Campos.Add(TempCampo)
                        End If
                    End If
                    i += 1
                End While
            End Using
            
            AppLogger.LogDebug("Archivo PRM cargado exitosamente: {0}. Campos: {1}", pathPrm, NumerodeCampos)

        Catch ex As Exception
            AppLogger.LogError("Error al leer el archivo PRM {0}: {1}", pathPrm, ex.Message)
            MsgBox("Error al leer configuración: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Property Campo(ByVal iT As Short) As String
        Get
            Return CStr(Vbtrv1.Field(iT - 1))
        End Get
        Set(ByVal Value As String)
            Vbtrv1.Field(iT - 1) = Value
        End Set
    End Property

    'Public Function Campo(ByVal Indice As Integer) As String
    ''ajusta campo del ocx con el prm
    '    Return Me.Field(Indice - 1)
    'End Function

    Sub DivideValorClave(ByVal ValorClave As String)
        Dim Index As Integer = Vbtrv1.IndexNumber
        Dim CantidadDeSegmentos As Integer = CInt(Vbtrv1.SegmentCountOnIndex(CShort(Index)))
        Dim ValoresClave(CantidadDeSegmentos) As String
        Dim Offset As Integer = 1
        For Segment As Integer = 1 To CantidadDeSegmentos
            Dim fieldSize As Integer = CInt(Vbtrv1.FieldSize(Vbtrv1.SegmentName(CShort(Index), CShort(Segment - 1))))
            ValoresClave(Segment) = Mid(ValorClave, Offset, fieldSize)
            Offset = Offset + fieldSize
            MsgBox(ValoresClave(Segment))
        Next
    End Sub

    Public Function Bseek(ByVal Comparacion As String, ByVal ValorClave As String) As Integer
        Dim Index As Integer = Vbtrv1.IndexNumber
        Dim CantidadDeSegmentos As Integer = CInt(Vbtrv1.SegmentCountOnIndex(CShort(Index)))
        Dim ValoresClave(CantidadDeSegmentos) As String
        Dim Offset As Integer = 1
        For Segment As Integer = 1 To CantidadDeSegmentos
            Dim fieldSize As Integer = CInt(Vbtrv1.FieldSize(Vbtrv1.SegmentName(CShort(Index), CShort(Segment - 1))))
            ValoresClave(Segment) = Mid(ValorClave, Offset, fieldSize)
            Offset = Offset + fieldSize
            'MsgBox(ValoresClave(Segment))
        Next
        Select Case CantidadDeSegmentos
            Case 0
                Vbtrv1.Seek(Comparacion, ValoresClave)
            Case 1
                Vbtrv1.Seek(Comparacion, ValoresClave(1))
            Case 2
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2))
            Case 3
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2), ValoresClave(3))
            Case 4
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2), ValoresClave(3), ValoresClave(4))
            Case 5
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2), ValoresClave(3), ValoresClave(4), ValoresClave(5))
            Case 6
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2), ValoresClave(3), ValoresClave(4), ValoresClave(5), ValoresClave(6))
            Case 7
                Vbtrv1.Seek(Comparacion, ValoresClave(1), ValoresClave(2), ValoresClave(3), ValoresClave(4), ValoresClave(5), ValoresClave(6), ValoresClave(6))
            Case Else
                ' OpCode no soportado: más de 7 segmentos de clave
                AppLogger.LogError("Bseek: Cantidad de segmentos no soportada: {0}", CantidadDeSegmentos)
                Return 22 ' Error: operación no soportada
        End Select
        Dim Status As Integer = Vbtrv1.LastError
        Return Status
    End Function


    Public Function aBseek(ByVal Comparacion As String, ByVal ValorClave As String) As Integer
        Vbtrv1.Seek(Comparacion, ValorClave)
        Dim Status As Integer = Vbtrv1.LastError
        Return Status
    End Function

    Public Function CallBtrv(ByRef OpCode As Short, ByVal ValorClave As String) As Short
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim Adelante As Short
        Dim Atras As Short
        Dim Habilitacion As Short
        Dim Parametros As New Object
        If OpCode = 0 Then

        ElseIf OpCode = 2 Or OpCode = 3 Then
            'insersion correcion

        Else

        End If
        Dim Status As Short = 666
        Dim continueLoop As Boolean = True
        Do While continueLoop
            continueLoop = False
            Select Case OpCode
                Case 2
                    'inserta
                    Status = Vbtrv1.InsertRecord
                Case 3
                    'corrige
                    Status = Vbtrv1.UpdateRecord
                Case 4
                    'borra
                    Status = Vbtrv1.Delete
                Case 6
                    Status = Vbtrv1.MoveNext()
                Case 7
                    Status = Vbtrv1.MovePrevious()
                Case 12
                    Status = Vbtrv1.MoveFirst()
                Case 13
                    Status = Vbtrv1.MoveLast()
                Case 5
                    Status = CShort(Bseek("=", ValorClave))
                Case 8
                    Status = CShort(Bseek(">", ValorClave))
                Case 9
                    Status = CShort(Bseek(">=", ValorClave))
                Case 10
                    Status = CShort(Bseek("<", ValorClave))
                Case 11
                    Status = CShort(Bseek("<=", ValorClave))
                Case Else
            End Select
            If Status = 0 Then
                If CurNroFiltro <> 0 Then
                    RaiseEvent Filtros(Habilitacion, Parametros, CurNroFiltro)
                End If
                If Habilitacion = 1 Then
                    If OpCode = 8 Or OpCode = 10 Then
                        Adelante = 8
                        Atras = 10
                    Else
                        Adelante = 6
                        Atras = 7
                    End If
                    Select Case OpCode
                        Case 0
                        Case 12, 9, 6, 8
                            OpCode = Adelante
                            continueLoop = True
                        Case 13, 11, 7, 10
                            OpCode = Atras
                            continueLoop = True
                        Case Else
                            ' OpCode no esperado en el contexto de filtrado
                            AppLogger.LogError("CallBtrv: OpCode no válido para filtrado: {0}", OpCode)
                            Status = 999 ' Error: operación no válida
                    End Select
                ElseIf Habilitacion = 2 Then
                    Status = 9
                End If
            End If
        Loop
        System.Windows.Forms.Cursor.Current = Cursors.Default
        Return Status
    End Function

    Public Function CallBtrv(ByRef OpCode As Short, ByVal ValorClave As String, ByVal Clave As Integer) As Short
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim Adelante As Short
        Dim Atras As Short
        Dim Habilitacion As Short
        Dim Parametros As New Object
        If OpCode = 0 Then

        ElseIf OpCode = 2 Or OpCode = 3 Then
            'insersion correcion

        Else

        End If
        Dim Status As Short = 666
        Dim continueLoop As Boolean = True
        Do While continueLoop
            continueLoop = False
            Select Case OpCode
                Case 2
                    'inserta
                    Status = Vbtrv1.InsertRecord
                Case 3
                    'corrige
                    Status = Vbtrv1.UpdateRecord
                Case 4
                    'borra
                    Status = Vbtrv1.Delete
                Case 6
                    Status = Vbtrv1.MoveNext()
                Case 7
                    Status = Vbtrv1.MovePrevious()
                Case 12
                    Status = Vbtrv1.MoveFirst()
                Case 13
                    Status = Vbtrv1.MoveLast()
                Case 5
                    Status = CShort(Bseek("=", ValorClave))
                Case 8
                    Status = CShort(Bseek(">", ValorClave))
                Case 9
                    Status = CShort(Bseek(">=", ValorClave))
                Case 10
                    Status = CShort(Bseek("<", ValorClave))
                Case 11
                    Status = CShort(Bseek("<=", ValorClave))
                Case Else
            End Select
            If Status = 0 Then
                If CurNroFiltro <> 0 Then
                    RaiseEvent Filtros(Habilitacion, Parametros, CurNroFiltro)
                End If
                If Habilitacion = 1 Then
                    If OpCode = 8 Or OpCode = 10 Then
                        Adelante = 8
                        Atras = 10
                    Else
                        Adelante = 6
                        Atras = 7
                    End If
                    Select Case OpCode
                        Case 0
                        Case 12, 9, 6, 8
                            OpCode = Adelante
                            continueLoop = True
                        Case 13, 11, 7, 10
                            OpCode = Atras
                            continueLoop = True
                        Case Else
                            ' OpCode no esperado en el contexto de filtrado
                            AppLogger.LogError("CallBtrv: OpCode no válido para filtrado: {0}", OpCode)
                            Status = 999 ' Error: operación no válida
                    End Select
                ElseIf Habilitacion = 2 Then
                    Status = 9
                End If
            End If
        Loop
        System.Windows.Forms.Cursor.Current = Cursors.Default
        Return Status
    End Function

    Public Function CallBtrv(ByRef OpCode As Short) As Short
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim Adelante As Short
        Dim Atras As Short
        Dim Habilitacion As Short
        Dim Parametros As New Object
        Dim ValorClave As String = ""
        If OpCode = 0 Then

        ElseIf OpCode = 2 Or OpCode = 3 Then
            'insersion correcion

        Else

        End If
        Dim Status As Short = 666
        Dim continueLoop As Boolean = True
        Do While continueLoop
            continueLoop = False
            Select Case OpCode
                Case 2
                    'inserta
                    Status = Vbtrv1.InsertRecord
                Case 3
                    'corrige
                    Status = Vbtrv1.UpdateRecord
                Case 4
                    'borra
                    Status = Vbtrv1.Delete
                Case 6
                    Status = Vbtrv1.MoveNext()
                Case 7
                    Status = Vbtrv1.MovePrevious()
                Case 12
                    Status = Vbtrv1.MoveFirst()
                Case 13
                    Status = Vbtrv1.MoveLast()
                Case 5
                    Status = CShort(Bseek("=", ValorClave))
                Case 8
                    Status = CShort(Bseek(">", ValorClave))
                Case 9
                    Status = CShort(Bseek(">=", ValorClave))
                Case 10
                    Status = CShort(Bseek("<", ValorClave))
                Case 11
                    Status = CShort(Bseek("<=", ValorClave))
                Case Else
            End Select
            If Status = 0 Then
                If CurNroFiltro <> 0 Then
                    RaiseEvent Filtros(Habilitacion, Parametros, CurNroFiltro)
                End If
                If Habilitacion = 1 Then
                    If OpCode = 8 Or OpCode = 10 Then
                        Adelante = 8
                        Atras = 10
                    Else
                        Adelante = 6
                        Atras = 7
                    End If
                    Select Case OpCode
                        Case 0
                        Case 12, 9, 6, 8
                            OpCode = Adelante
                            continueLoop = True
                        Case 13, 11, 7, 10
                            OpCode = Atras
                            continueLoop = True
                        Case Else
                            ' OpCode no esperado en el contexto de filtrado
                            AppLogger.LogError("CallBtrv: OpCode no válido para filtrado: {0}", OpCode)
                            Status = 999 ' Error: operación no válida
                    End Select
                ElseIf Habilitacion = 2 Then
                    Status = 9
                End If
            End If
        Loop
        System.Windows.Forms.Cursor.Current = Cursors.Default
        Return Status
    End Function
    Public Function Keyval() As String
        NameKeyval = Vbtrv1.IndexNumber.ToString() & " |"
        Dim Index As Short = CShort(Vbtrv1.IndexNumber)
        Dim CantidadDeSegmentos As Integer = CInt(Vbtrv1.SegmentCountOnIndex(Index))
        Dim Keyvalor As String = ""
        For Segment As Integer = 1 To CantidadDeSegmentos
            Dim segName As String = Vbtrv1.SegmentName(Index, CShort(Segment - 1))
            Dim fieldSize As Integer = CInt(Vbtrv1.FieldSize(segName))
            Dim fieldValue As String = CStr(Vbtrv1.Field(segName))
            Dim Variable As String = Mid(fieldValue & Space(fieldSize), 1, fieldSize)
            Keyvalor = Keyvalor & Variable
            NameKeyval = NameKeyval & segName & "|"
        Next
        Return Keyvalor
    End Function
End Class

