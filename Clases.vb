Class ESTRU
    Public KPOS As Short
    Public KLEN As Short
    Public KFLA As Short
    Public KKEY As Integer
    Public CAMP As Short
    Public TIPO As Short
    Public DECI As Short
End Class

Public Structure clsParametrosdeLinea
    'Inherits ArrayList
    Public NOME As String            'TITULO
    Public CAMP As Short          'CAMPO
    Public ANCH As Short          'ANCHO
    Public TIPO As Short          '0=NORMAL/1=NUMERICO/2=CODI/3=FECHA
    Public EXTE As Short          '0=LOCAL/N=REFERENCIA EXTERNA
    Public EDIT As Short          '0=NO EDITABLE / 1=EDITABLE
    Public DECI As Short          'DECIMALES PARA INGRESO
    Public BUSC As Short          '0=NO BUSCA / 1=BUSCA 
End Structure

Public Structure clsParametrosdeFiltro
    'Inherits ArrayList
    Public CAMP As Short
    Public ANCH As Short
    Public ARCH As Short
    Public DATO As String
End Structure


Public Class clsParametrosdeLista
    'PARLGEN
    Public Codi As String          'nuevo Busqueda Inicial
    Public MaximoDeLineas As Short 'cantidad de lineas
    Public CLAV As Short          'CLAVE INICIAL
    Public NCAM As Short          'CANTIDAD DE CAMPOS
    Public PASO As Short          '0 = NORMAL / 1 = PROXIMA CLAVE
    Public PASA As Short          '0 = PASA CODIGO / 1 = NO PASA
    Public FLBU As Short          '0 = NO BUSCA / 1 = BUSCA SEQ. / 2 = BUSCA INDEX
    Public CAMB As Short          'CAMPO DE BUSCA
    Public CAMP As Short          'CAMPO A DEVOLVER
    Public CKEY As Short          '0 = NO CAMBIA CLAVE / 1 = CAMBIA
    Public FILT As Short          'CODIGO DE FILTRO
    Public EDIT As Short          'ADMITE EDITA
    Public Archivo() As clsParametrosdeArchivo
    Public LPAR() As clsParametrosdeLinea
    Public PARAF() As clsParametrosdeFiltro
    Sub New()
        ReDim Archivo(10)
        ReDim LPAR(20)
        ReDim PARAF(20)
    End Sub
    Private PropertyValues As String()
    ' Define the default property.
    Default Public Property Prop1(ByVal Index As Integer) As String
        Get
            Return PropertyValues(Index)
        End Get
        Set(ByVal Value As String)
            If PropertyValues Is Nothing Then
                ' The array contains Nothing when first accessed.
                ReDim PropertyValues(0)
            Else
                ' Re-dimension the array to hold the new element.
                ReDim Preserve PropertyValues(UBound(PropertyValues) + 1)
            End If
            PropertyValues(Index) = Value
        End Set
    End Property
End Class

Public Class clsParametrosdeArchivo
    Public Tabla As String
    Public Archivo As String
    Public DDF As String
    Public Cripto As String
End Class

Public Structure clsParametrosdeLineaBusca
    Public Titulo As String
    Public Ancho As Short
    Public Tipo As Short
    Public Respuesta As String
End Structure

Public Class clsParametrosdeBusca
    Public Titulo As String
    Public ParamB() As clsParametrosdeLineaBusca
    Sub New()
        ReDim ParamB(5)
    End Sub
    Private PropertyValues As String()
    ' Define the default property.
    Default Public Property Prop1(ByVal Index As Integer) As String
        Get
            Return PropertyValues(Index)
        End Get
        Set(ByVal Value As String)
            If PropertyValues Is Nothing Then
                ' The array contains Nothing when first accessed.
                ReDim PropertyValues(0)
            Else
                ' Re-dimension the array to hold the new element.
                ReDim Preserve PropertyValues(UBound(PropertyValues) + 1)
            End If
            PropertyValues(Index) = Value
        End Set
    End Property
End Class

Public Class QB
    'Note: The data types 'Currency' and 'Variant' are not supported

    'Type-safe declarations because 'As Any' is not supported in .NET
    Private Declare Sub CopyMemoryMKD Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByVal hDest As String, ByRef hSource As Double, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryCVD Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByRef hDest As Double, ByVal hSource As String, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryMKS Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByVal hDest As String, ByRef hSource As Single, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryCVS Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByRef hDest As Single, ByVal hSource As String, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryMKL Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByVal hDest As String, ByRef hSource As Integer, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryCVL Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByRef hDest As Integer, ByVal hSource As String, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryMKI Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByVal hDest As String, ByRef hSource As Short, ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryCVI Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByRef hDest As Short, ByVal hSource As String, ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryMKDt Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByVal hDest As String, ByRef hSource As Double, _
        ByVal iBytes As Integer)
    Private Declare Sub CopyMemoryCVDt Lib "Kernel32" Alias "RtlMoveMemory" _
        (ByRef hDest As Double, ByVal hSource As String, _
        ByVal iBytes As Integer)

    'Convert from Double to String.
    Shared Function MKD(ByRef Value As Double) As String
        Dim sTemp As String = Space(8)
        CopyMemoryMKD(sTemp, Value, 8I)
        Return sTemp
    End Function

    'Convert from String to Double.
    Shared Function CVD(ByRef Argument As String) As Double
        Dim dTemp As Double = 0.0R
        If Len(Argument) <> 8 Then
            Return Double.NaN
        End If
        CopyMemoryCVD(dTemp, Argument, 8I)
        Return dTemp
    End Function

    'Convert from Single to String.
    Shared Function MKS(ByRef Value As Single) As String
        Dim sTemp As String = Space(4)
        CopyMemoryMKS(sTemp, Value, 4I)
        Return sTemp
    End Function

    'Convert from String to Single.
    Shared Function CVS(ByRef Argument As String) As Single
        Dim sTemp As Single = 0.0F
        If Len(Argument) <> 4 Then
            Return Single.NaN
        End If
        CopyMemoryCVS(sTemp, Argument, 4I)
        Return sTemp
    End Function

    'Convert from (QB)Long to String.
    'QB/VB Long (4 bytes) => .NET Integer (Int32)
    Shared Function MKL(ByRef Value As Integer) As String
        Dim sTemp As String = Space(4)
        CopyMemoryMKL(sTemp, Value, 4I)
        Return sTemp
    End Function

    'Convert from String to (QB)Long.
    'QB/VB Long (4 bytes) => .NET Integer (Int32)
    Shared Function CVL(ByRef Argument As String) As Long
        Dim lTemp As Integer = 0I
        If Len(Argument) <> 4 Then
            Return Long.MinValue
        End If
        CopyMemoryCVL(lTemp, Argument, 4I)
        Return CLng(lTemp)  'Cast Integer into Long
    End Function

    'Convert from (QB)Integer to String.
    'QB/VB Integer (2 bytes) => .NET Short (Int16)
    Shared Function MKI(ByRef Value As Short) As String
        Dim sTemp As String = Space(2)
        CopyMemoryMKI(sTemp, Value, 2I)
        Return sTemp
    End Function

    'Convert from String to (QB)Integer.
    'QB/VB Integer (2 bytes) => .NET Short (Int16)
    Shared Function CVI(ByRef Argument As String) As Integer
        Dim iTemp As Short = 0S
        If Len(Argument) <> 2 Then
            Return Integer.MinValue
        End If
        CopyMemoryCVI(iTemp, Argument, 2I)
        Return CInt(iTemp)  'Cast Short into Integer
    End Function

    'Convert from Date (OLE Automation-compatible [Double]) to String
    Shared Function MKDt(ByRef Value As Double) As String
        Dim sTemp As String = Space(8)
        CopyMemoryMKDt(sTemp, Value, 8I)
        Return sTemp
    End Function

    'Convert from String to Date
    Shared Function CVDt(ByRef Argument As String) As DateTime
        Dim dTemp As Double = 0.0R
        If Len(Argument) <> 8 Then
            Return DateTime.MinValue
        End If
        CopyMemoryCVDt(dTemp, Argument, 8I)
        Return Date.FromOADate(dTemp)   'Cast Double into Date
    End Function

    'Shared Function Xfnd(ByVal Valor As Double, ByVal Largo As Short, ByVal Decimales As Short) As String
    '    Dim Temp As String
    '    Dim Temps As String
    '    If Decimales <> 0 Then
    '        Temp = "0." & New String(CType("0", Char), Decimales)
    '    Else
    '        Temp = "0"
    '    End If
    '    Temp = New String(CType("#", Char), Largo - Len(Temp)) + Temp
    '    Temps = Space(Largo)
    '    Temps = RSet(Format(Valor, Temp), Len(Temps))
    '    Return Temps
    'End Function

    'Shared Function Xfnd0(ByVal Valor As Double, ByVal Largo As Short, ByVal Decimales As Short) As String
    '    Dim Temp As String
    '    If Decimales <> 0 Then
    '        Temp = "0." & New String(CType("0", Char), Decimales)
    '    Else
    '        Temp = ""
    '    End If
    '    Temp = New String(CType("0", Char), Largo - Len(Temp)) + Temp
    '    Temp = Format(Valor, Temp)
    '    Return Temp
    'End Function

    Public Shared Function XFND(ByRef valor As Double, ByRef largo As Short, ByRef decimales As Short) As String
        Return Math.Round(valor, decimales).ToString("N" & decimales.ToString).Replace(",", ".").PadLeft(largo)
    End Function

    Public Shared Function XFND0(ByRef valor As Double, ByRef largo As Short, ByRef decimales As Short) As String
        Return Math.Round(valor, decimales).ToString("N" & decimales.ToString).Replace(",", ".").PadLeft(largo, "0")
    End Function
    Shared Function XFnfecha(ByVal Fecha As String) As String
        Dim Temp As String
        Temp = Fecha
        Return Microsoft.VisualBasic.Strings.Left(Temp, 2) + "-" + Mid(Temp, 3, 2) + "-" + Microsoft.VisualBasic.Strings.Right(Temp, 2)
    End Function

    Shared Function XFninv(ByVal Fecha As String) As String
        If Len(Fecha) <> 0 Then
            If Len(Fecha) = 6 Then
                Return Microsoft.VisualBasic.Strings.Right(Fecha, 2) + Mid(Fecha, 3, 2) + Microsoft.VisualBasic.Strings.Left(Fecha, 2)
            Else
                If Microsoft.VisualBasic.Strings.Right(Fecha, 4) >= "1980" And Microsoft.VisualBasic.Strings.Right(Fecha, 4) <= "2100" Then
                    '01011999->19990101
                    XFninv = Microsoft.VisualBasic.Strings.Right(Fecha, 4) + Mid(Fecha, 3, 2) + Microsoft.VisualBasic.Strings.Left(Fecha, 2)
                Else
                    '19990101->01011999
                    XFninv = Microsoft.VisualBasic.Strings.Right(Fecha, 2) + Mid(Fecha, 5, 2) + Microsoft.VisualBasic.Strings.Left(Fecha, 4)
                End If
            End If
        Else
            XFninv = Fecha
        End If
    End Function

    Shared Function XFnkdos(ByVal Fecha As String) As String
        If Len(Fecha) = 6 Then
            If Microsoft.VisualBasic.Strings.Left(Fecha, 2) >= "00" And Microsoft.VisualBasic.Strings.Left(Fecha, 2) <= "80" Then
                XFnkdos = "20" + Fecha
            Else
                XFnkdos = "19" + Fecha
            End If
        Else
            XFnkdos = Fecha
        End If
    End Function

    Shared Function XFntrun(ByVal Fecha As String) As String
        If Len(Fecha) = 6 Or Len(Fecha) = 0 Then
            XFntrun = Fecha
        Else
            If Microsoft.VisualBasic.Strings.Right(Fecha, 4) >= "1980" And Microsoft.VisualBasic.Strings.Right(Fecha, 4) <= "2100" Then
                '01011999->010199
                XFntrun = Microsoft.VisualBasic.Strings.Left(Fecha, 4) + Microsoft.VisualBasic.Strings.Right(Fecha, 2)
            Else
                '19990101->990101
                XFntrun = Mid(Fecha, 3)
            End If
        End If
    End Function

    Function miLeft(ByVal Cadena As String, ByVal Largo As Short) As String
        Return Mid(Cadena, 1, Largo)
    End Function

    Shared Function left(ByVal cadena As String, ByVal largo As Short) As String
        Return Mid(cadena, 1, largo)
    End Function
End Class


