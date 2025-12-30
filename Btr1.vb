Option Strict Off
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
        Dim TempCampo As ClsCampo
        Dim Filenum As Integer
        Dim Dummy As Integer
        Dim HuboExcept As Boolean = False
        Dim File As String = Me.Archivo & ".prm"

        Filenum = FreeFile()
        FileClose(Filenum)
        Try
            FileOpen(Filenum, File, Microsoft.VisualBasic.OpenMode.Input, , OpenShare.Shared)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            HuboExcept = True
        Finally
            If HuboExcept Then
                Stop
            End If
        End Try
        NumerodeCamposVisibles = 0
        Input(Filenum, Dummy)
        Input(Filenum, NumerodeCampos)
        Dim LargodeRegistro As Short = 0
        Dim IndicedeCampo As Short
        For IndicedeCampo = 1 To NumerodeCampos
            TempCampo = New ClsCampo()
            TempCampo.Ofset = 1 + LargodeRegistro
            TempCampo.CampoNumero = IndicedeCampo
            Input(Filenum, TempCampo.Titulo)
            Input(Filenum, TempCampo.Fila)
            Input(Filenum, TempCampo.Columna)
            Input(Filenum, TempCampo.Ancho)
            Input(Filenum, TempCampo.Numerico)
            Input(Filenum, TempCampo.Decimales)
            Input(Filenum, Dummy)
            LargodeRegistro = LargodeRegistro + TempCampo.Ancho
            If TempCampo.Ancho > 0 Then
                NumerodeCamposVisibles = NumerodeCamposVisibles + 1
                Campos.Add(TempCampo)
            End If
        Next IndicedeCampo
        FileClose(Filenum)
    End Sub

    Property Campo(ByVal iT As Short) As String
        Get
            Return Vbtrv1.Field(iT - 1)
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
        Dim CantidadDeSegmentos As Integer = Vbtrv1.SegmentCountOnIndex(Index)
        Dim ValoresClave(CantidadDeSegmentos) As String
        Dim Offset As Integer = 1
        For Segment As Integer = 1 To CantidadDeSegmentos
            ValoresClave(Segment) = Mid(ValorClave, Offset, Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1)))
            Offset = Offset + Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1))
            MsgBox(ValoresClave(Segment))
        Next
    End Sub

    Public Function Bseek(ByVal Comparacion As String, ByVal ValorClave As String) As Integer
        Dim Index As Integer = Vbtrv1.IndexNumber
        Dim CantidadDeSegmentos As Integer = Vbtrv1.SegmentCountOnIndex(Index)
        Dim ValoresClave(CantidadDeSegmentos) As String
        Dim Offset As Integer = 1
        For Segment As Integer = 1 To CantidadDeSegmentos
            ValoresClave(Segment) = Mid(ValorClave, Offset, Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1)))
            Offset = Offset + Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1))
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
                Stop
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
                    Status = Bseek("=", ValorClave)
                Case 8
                    Status = Bseek(">", ValorClave)
                Case 9
                    Status = Bseek(">=", ValorClave)
                Case 10
                    Status = Bseek("<", ValorClave)
                Case 11
                    Status = Bseek("<=", ValorClave)
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
                            Stop
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
                    Status = Bseek("=", ValorClave)
                Case 8
                    Status = Bseek(">", ValorClave)
                Case 9
                    Status = Bseek(">=", ValorClave)
                Case 10
                    Status = Bseek("<", ValorClave)
                Case 11
                    Status = Bseek("<=", ValorClave)
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
                            Stop
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
                    Status = Bseek("=", ValorClave)
                Case 8
                    Status = Bseek(">", ValorClave)
                Case 9
                    Status = Bseek(">=", ValorClave)
                Case 10
                    Status = Bseek("<", ValorClave)
                Case 11
                    Status = Bseek("<=", ValorClave)
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
                            Stop
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
        NameKeyval = Vbtrv1.IndexNumber & " |"
        Dim Index As Integer = Vbtrv1.IndexNumber
        Dim CantidadDeSegmentos As Integer = Vbtrv1.SegmentCountOnIndex(Index)
        Dim Keyvalor As String = ""
        For Segment As Integer = 1 To CantidadDeSegmentos
            Dim Variable As String = Mid(Vbtrv1.Field(Vbtrv1.SegmentName(Index, Segment - 1)) + Space(Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1))), 1, Vbtrv1.FieldSize(Vbtrv1.SegmentName(Index, Segment - 1)))
            Keyvalor = Keyvalor + Variable
            NameKeyval = NameKeyval & Vbtrv1.SegmentName(Index, Segment - 1) & "|"
        Next
        Return Keyvalor
        Me.NameKeyval = NameKeyval
    End Function
End Class

