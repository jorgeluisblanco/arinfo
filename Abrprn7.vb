Option Strict On
Option Explicit On
Imports System
Imports System.Text
Imports System.IO
Imports System.Collections

Module ABREPRM
    Public Empresa As String = "Adicol"
    'Public UDisco As String = "H:" '
    'Public UDirectorio As String = "\ADICOL\VENTAS\ADICOL\"
    'Public UReportPath As String = "\NET\REPORTES\"

    Public UDisco As String = "C:"
    Public UDirectorio As String = "\CLIENTES\ADICOL\VENTAS\ADICOL\"
    Public UReportPath As String = UDisco + "\clientes\adicol\arinfo3\"

    Public ApretaronEscape As Boolean = False
    Public ArchivosAbiertos As Boolean = False
    Public CodCli As String
    Public Rsocial As String

    Const TotAr As Short = 9
    Const TotCmp As Short = 55

    Public Arbtr(TotAr) As Btr
    Public Arprm As Btr
    Public Ar As Short

    Public NC(TotAr) As Short
    Public LT(TotAr) As Short

    Public Ofs(TotAr, TotCmp) As Short
    Public T(TotAr, TotCmp) As String
    Public FIL(TotAr, TotCmp) As Short
    Public COL(TotAr, TotCmp) As Short
    Public ANC(TotAr, TotCmp) As Short
    Public NUM(TotAr, TotCmp) As Short
    Public DEC(TotAr, TotCmp) As Short

    Public CA(TotAr) As String
    Public NA(TotAr) As String

    Public DSK1, DSK2, DSK3 As String

    Public ArCon, ArCli, ArArt, ArInf, Cantar As Short

    Public Art As Btr
    Public Tal As Btr
    Public Ren As Btr

    Public Opa As Btr
    Public Mov As Btr
    Public Chp As Btr
    Public Cht As Btr
    Public Pro As Btr

    Public Deci As Short = 2
    Public DDF As String = ""
    Public DBF As String = ""
    Public SND As String = ""
    Public RCV As String = ""

    Public Dsk As String = DBF
    Public UnidadDsk As String = DBF
    Public BaseDatosDDF As String = DDF
    Public BaseDatos As String = Dsk
    Public NroCaptura As String = ""

    Public Disco As String = ""
    Public AppPath As String = ""
    Public PathFtp As String = ""

    Public TablaCab As String = "movin5"
    Public TablaRen As String = "rengv6"
    Public BackC As Color = Color.FromArgb(&HFFEAEAEA)

    Enum CamposPresu
        Codigo
        Talle
        Descripcion
        Cantidad
        Precio
        Total
        Comprobante
        Bookmark
        Row
    End Enum

    Enum CamposCabe
        Codloc
        Local
        Numero
        Comprobante
        Fecha
        Bookmark
    End Enum

    Sub abre()
        Dim Status As Short
        Dim DskDB As String = DSK1

        Dim TableName As String
        Dim FileName As String

        For Ar As Integer = 1 To Cantar
            Arbtr(Ar) = New Btr
            If CA(Ar) <> "" Then
ABREBTR:
                If NA(Ar) <> "" Then
                    Mid(NA(Ar), 3, 6) = ""
                    TableName = CA(Ar)
                    FileName = DSK1 & NA(Ar)
                Else
                    TableName = CA(Ar)
                    FileName = DSK1 & CA(Ar)
                End If
                Arbtr(Ar).Tabla = TableName
                Arbtr(Ar).Archivo = FileName
                Arbtr(Ar).DDF = DDF & "FILE.DDF"
                Arbtr(Ar).Cripto = "{"
                Status = CShort(Arbtr(Ar).AbreArchivos)
            End If
        Next
    End Sub


    Public Function XFND(ByRef valor As Double, ByRef largo As Short, ByRef decimales As Short) As String
        Dim temp As String = Math.Round(valor, decimales).ToString("N" & decimales.ToString) '.Replace(".", "")
        Return temp.Replace(",", ".").PadLeft(largo)
    End Function

    Public Function XFND0(ByRef valor As Double, ByRef largo As Short, ByRef decimales As Short) As String
        Dim temp As String = Math.Round(valor, decimales).ToString("N" & decimales.ToString).Replace(".", "")
        Return temp.Replace(",", ".").PadLeft(largo, "0"c)
        'Return Math.Round(valor, decimales).ToString("N" & decimales.ToString).Replace(",", ".").PadLeft(largo, "0"c)
    End Function
    Public Function XFNFECHA(ByRef valor As String) As String
        'implementar
        Return Left(valor, 2) + "-" + Mid(valor, 3, 2) + "-" + Right(valor, 2)
    End Function

    Public Function XFNINV(ByRef valor As String) As String
        Return Right(valor, 2) + Mid(valor, 3, 2) + Left(valor, 2)
        'If Len(valor) <> 0 Then
        '    If Len(valor) = 6 Then
        '        Return Right(valor, 2) + Mid(valor, 3, 2) + Left(valor, 2)
        '    Else
        '        If Right(valor, 4) >= "1980" And Right(valor, 4) <= "2100" Then
        '            '01011999->19990101
        '            Return Right(valor, 4) + Mid(valor, 3, 2) + Left(valor, 2)
        '        Else
        '            'IF LEFT$(Valor, 4) >= "1980" AND LEFT$(Valor, 4) <= "2100" THEN
        '            '19990101->01011999
        '            Return Right(valor, 2) + Mid(valor, 5, 2) + Left(valor, 4)
        '        End If
        '    End If
        'Else
        '    Return valor
        'End If
    End Function

    Function XFNKDOS(ByVal Fecha As String) As String
        If Len(Fecha) = 6 Then
            If Left(Fecha, 2) >= "00" And Left(Fecha, 2) <= "80" Then
                Return "20" + Fecha
            Else
                Return "19" + Fecha
            End If
        Else
            Return Fecha
        End If
    End Function

    Function XFNTRUN(ByVal Fecha As String) As String
        If Len(Fecha) = 6 Or Len(Fecha) = 0 Then
            Return Fecha
        Else
            If Right(Fecha, 4) >= "1980" And Right(Fecha, 4) <= "2100" Then
                '01011999->010199
                Return Left(Fecha, 4) + Right(Fecha, 2)
            Else
                'IF LEFT$(FECHA$, 4) >= "1980" AND LEFT$(FECHA$, 4) <= "2100" THEN
                '19990101->990101
                Return Mid(Fecha, 3)
            End If
        End If
    End Function




    Sub MuestraArt(ByVal Articulo As String, ByRef Descripcion As String, ByRef Precio As String)
        Art = Arbtr(ArArt)
        Art.Vbtrv1.IndexNumber = 0
        Dim Status As Integer = Art.Bseek(">=", Articulo)
        If Status = 0 And Mid(Art.Keyval, 1, Len(Articulo)) = Articulo Then
            Descripcion = CStr(Art.Vbtrv1.FieldValue(-1 + 2))
            Precio = CStr(Art.Vbtrv1.FieldValue(-1 + 4))
        Else
            Descripcion = ""
            Precio = ""
        End If
    End Sub

    Sub CambioArt(ByVal Articulo As String, ByRef Precio As String)
        Art = Arbtr(ArArt)
        Art.Vbtrv1.IndexNumber = 0
        Dim Status As Integer = Art.Bseek(">=", Articulo)
        If Status = 0 And Mid(Art.Keyval, 1, Len(Articulo)) = Articulo Then
            Art.Vbtrv1.Edit()
            Art.Vbtrv1.FieldValue(-1 + 4) = Precio
            Art.Vbtrv1.Update()
        End If
    End Sub


    'Dim Par As BtrvoleproLib.BtrvOlePro
    Function Abre(ByRef x As BtrvoleproLib.BtrvOlePro, ByVal NombreArchivo As String) As Short
        Dim Ret As Short
        x = New BtrvoleproLib.BtrvOlePro
        x.DatabaseName = DDF
        x.RecordSource = NombreArchivo
        x.FilePathName = DBF & NombreArchivo & ".btr"
        x.DisplayErrors = False
        x.OpenMode = BtrvoleproLib.BTRV_OPENMODES.btrOpenModeNormal
        Ret = x.Open
        Return Ret
    End Function
    Sub Cierra(ByVal x As BtrvoleproLib.BtrvOlePro)
        x.Close()
    End Sub
    '    Function TomarPar() As String
    '        Dim NombreArchivo As String = "param2"
    '        Dim Status As Short = abre(Par, NombreArchivo)
    'OtroPar:
    '        Par.IndexNumber = 0
    '        Par.Seek(">=", "006")
    '        Status = Par.LastError
    '        If Status = 9 Then
    '            Par.DirectEdits = True
    '            Par.Field(-1 + 1) = "006"
    '            Par.Field(-1 + 2) = "006"
    '            Par.Field(-1 + 2) = "000001"
    '            Par.InsertRecord()
    '            GoTo Otropar
    '        End If
    '        Dim Remito As String = ""
    '        If Status = 0 Then
    '            Remito = (XFND0(Val(Par.Field(-1 + 3)), 6, 0))
    '        End If
    '        Return Remito
    '        Cierra(Par)
    '    End Function

    '    Sub GrabaPar(ByVal Actualizo As Boolean)
    '        If Actualizo = True Then
    '            Dim NombreArchivo As String = "param2"
    '            Dim Status As Short = abre(Par, NombreArchivo)

    '            Par.DirectEdits = True
    '            Par.IndexNumber = 0
    '            Par.Seek(">=", "006")
    '            Status = Par.LastError
    '            If Status = 0 Then
    '                Par.Field(-1 + 3) = XFND0(Val(Par.Field(-1 + 3)) + 1, 6, 0)
    '                Par.Update()
    '            End If

    '            Cierra(Par)
    '            Actualizo = False
    '        End If
    '    End Sub


    Public Class MyObject
        Implements IComparable
        Public StrAComparar As String
        Public StrObjeto As Object

        Public Function CompareTo(ByVal obj As Object) As Integer _
           Implements System.IComparable.CompareTo
            If Not TypeOf obj Is MyObject Then
                Throw New Exception("El Objeto no es tipo MyObject")
            End If
            Dim Compare As MyObject = CType(obj, MyObject)
            Dim result As Integer = Me.StrAComparar.CompareTo(Compare.StrAComparar)

            If result = 0 Then
                result = Me.StrAComparar.CompareTo(Compare.StrAComparar)
            End If
            Return result
        End Function
    End Class

End Module


