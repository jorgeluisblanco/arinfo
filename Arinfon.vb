Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.Text
Imports System.Xml
Imports System.IO
Imports qb4 = Microsoft.VisualBasic.Strings

Module Arinfon
    'Dim sw As New System.IO.StringWriter
    'Dim XMLHess As New XmlTextWriter(sw)b


    Dim sb As New StringBuilder
    Dim XMLHess As New XmlTextWriter(New EncodedStringWriter(sb, Encoding.UTF8))
    Dim sCleanXML As String
    Dim strXML As String

    Dim newDataSet As DataSet
    Dim Pxp As Integer = 89
    Dim DeviceXML As String = ""
    Dim IndiceCampo As Integer
    Dim Funcion As Integer = 0
    Dim Status As Integer = 0
    Dim Keynum As Integer = 0
    Dim Keyval As String = Space(50)
    Dim LetraGrande As String = Chr(18)
    Dim LetraChica As String = Chr(15)
    Dim Separador As String = Chr(124)
    Dim SeparadorComillas As String = Chr(34)
    Dim SeparadorComa As String = " , "
    Dim MascaraNumerica As String = "#############.00" + Separador
    Dim BuscoSeparador As String = "+-*/%^=' :;.,()HVBSCZK"
    Dim Tiq() As String = {"", "Generador de Informes", "Que hacemos ?", "Que ... ?", "Dale de nuevo ..."}
    Dim Archivo As String = ""
    Dim NombreArchivo As String = ""
    Dim Pxt As Integer = 88
    Dim ClaveBusqueda As String = ""
    Dim CantidadCamposBusqueda As Integer = 0
    Dim CantidadInstrucciones As Integer = 0
    Dim CantidadCampos As Integer = 0
    Dim CantidadCamposeInstruccionesaBuscar As Integer = 0
    Dim FS As Integer = 0
    Dim QQ As Integer = 0
    Dim ArchivodeInstrucciones As String
    Dim NroInstruccionesArchivadas As Integer = 0
    Dim FlgOrdenInverso As Integer = 0
    Dim Device As String = ""
    Dim Archi As String = ""
    Dim Memrec As Integer
    Dim PtrEdicion(28) As Integer
    Dim A2 As String
    Dim IndiceOrden As Integer
    Dim OrdenA As Integer
    Dim OrdenZ As Integer
    Dim DireccionOrden As Integer
    Dim Exiti As Integer
    Dim BA As String

    Dim TabCentrado As Boolean
    Dim FechaEmision As String
    Dim TituloInforme As String
    Dim BB$
    Dim RTEM$
    Dim NroPagina As Integer
    Dim T1%
    Dim N%
    Dim M As Integer ' indice de campo del archivo
    Dim YM#
    Dim Ar As Integer
    Dim ultimotab As Integer

    Dim LargoLinea As Integer
    Dim T%
    Dim NroLinea As Integer
    Dim FlgSubrayado As Integer = 0
    Dim FlgExcell As Integer = 0
    Dim AE As String
    Dim FlgEdicion As Integer
    Dim FlgImpresion As Integer
    Dim FlgOrdenAlfa As Integer
    Dim FlgOrdenNume As Integer
    Dim PTR%
    Dim LC%
    Public B As String = "ALGO "
    Dim A As String
    Dim X7%
    Dim YSS#
    Dim FlagSubTotal As Integer

    Dim YS#
    Dim AL$
    Dim SeparadorNumerico As String
    Dim DD$

    Dim Nul As String = Chr(0)
    Dim KF As Integer
    Dim Y#
    Dim VUELTA%
    Dim GG%

    Dim RR%
    Dim AAA$
    Dim L%
    Dim ZM%
    Dim ZN As Double
    Dim IX%
    Dim ZX%
    Dim HH As Integer
    Dim OrdenxCampo As Integer
    Dim FA%
    Dim LargoCampoOrden As Integer
    Dim DeciCampoOrden As Integer

    Dim EE$
    Dim E$

    Dim Geti As Integer = 0
    Dim YA%
    Dim DS As String



    Dim NN(60) As String
    Dim CamposdeBusqueda(60) As String
    Dim Instrucciones(75) As String
    Dim AnchoDeCampo(60) As Integer
    Dim AnchoDeColumna(60) As Integer
    Dim TipoDeCampo(60) As Integer
    Dim DeciDeCampo(60) As Integer
    Dim SubtDeCampo(60) As Integer
    Dim InstruccionesArchivadas(10) As String
    Dim FLG%(9, 3)
    Dim CL$(9)
    Dim G%(60)
    Dim P%(60)
    Dim Q%(60)
    Dim R%(60)
    Dim COLU%(60)
    Dim ASIGX%(60)
    Dim Z#(60)
    Dim ZZ#(60)
    Dim ZZA$(60)
    Dim SCLA%(60)
    Dim SCAM%(60)

    Dim ArraySort As New List(Of String)
    Dim porXML As Integer

    'Dim Campos As New List(Of Btr.ClsCampo)


    Sub Asignavariables()
50245:
        CantidadCampos = Arbtr(Ar).NumerodeCamposVisibles - 2
        Instrucciones(0) = "| Campos de Referencia |"
        Dim Desde As Integer = 0
        Dim Hasta As Integer = 0
        For IndicedeCampo = 1 To CantidadCampos ' asigna campos
            Dim Campo As Btr.ClsCampo = Arbtr(Ar).Campos(IndicedeCampo - 1)
            AnchoDeCampo(IndicedeCampo) = Campo.Ancho
            TipoDeCampo(IndicedeCampo) = Campo.Numerico
            DeciDeCampo(IndicedeCampo) = Campo.Decimales
            Desde = InStr(Campo.Titulo, "- ")
            If Desde <> 0 Then
                Desde = Desde + 2
            Else
                Desde = 1
            End If
            Hasta = InStr(Campo.Titulo, ":")
            If Hasta <> 0 Then
            Else
                Hasta = Len(Campo.Titulo)
            End If
            If Hasta <> 0 Then
                CamposdeBusqueda(IndicedeCampo) = UCase(Mid(Campo.Titulo, Desde, Hasta - Desde)) ' mayusculas
            End If
            Instrucciones(IndicedeCampo) = Mid(CamposdeBusqueda(IndicedeCampo), 1, Len(Instrucciones(0)))
            ' *** titulos de columna para XML
            NN(IndicedeCampo) = REPLACE(CamposdeBusqueda(IndicedeCampo))
            ' ***
        Next
        CamposdeBusqueda(CantidadCampos + 1) = "TOTAL"                '19
        CamposdeBusqueda(CantidadCampos + 2) = "ORDEN|CLASIF|SORT"    '20
        CamposdeBusqueda(CantidadCampos + 3) = "IMPRINT"              '21
        CamposdeBusqueda(CantidadCampos + 4) = "SUME|SUMA|TOTAL"      '22
        CamposdeBusqueda(CantidadCampos + 5) = "PROMED|AVERAG"        '23
        CamposdeBusqueda(CantidadCampos + 6) = ""                     '24
        Instrucciones(CantidadCampos + 1) = "TOTAL"
        Instrucciones(CantidadCampos + 2) = "ORDENADO"
        Instrucciones(CantidadCampos + 3) = "SUMA"
        Instrucciones(CantidadCampos + 4) = "PROMEDIA"
        Instrucciones(CantidadCampos + 5) = "NO"
        Instrucciones(CantidadCampos + 6) = "SIN"
        Instrucciones(CantidadCampos + 7) = "ORDEN INVER"
        Instrucciones(CantidadCampos + 8) = "ORDEN ALFAB"
        Instrucciones(CantidadCampos + 9) = "EDITA"
        CantidadInstrucciones = CantidadCampos + 9
        CantidadCamposeInstruccionesaBuscar = CantidadCampos + 7
        Info.cbox1.Items.Clear()
        For Item As Integer = 1 To CantidadCampos
            Info.Todo = Info.Todo + CamposdeBusqueda(Item) + " "
        Next
        For Item As Integer = 1 To CantidadInstrucciones
            Info.cbox1.Items.Add(Instrucciones(Item))
        Next
        Info.CBox2.Items.Clear()
        Archivo = Arbtr(Ar).Archivo
        NombreArchivo = Arbtr(Ar).Tabla
        ArchivodeInstrucciones = Archivo & ".inf"

        If Not System.IO.File.Exists(ArchivodeInstrucciones) Then
            ' Si no existe, lo creamos con 0 instrucciones
            Try
                System.IO.File.WriteAllText(ArchivodeInstrucciones, "0" & Environment.NewLine, System.Text.Encoding.Default)
                NroInstruccionesArchivadas = 0
                AppLogger.LogDebug("Creado archivo de instrucciones vacío: {0}", ArchivodeInstrucciones)
            Catch ex As Exception
                AppLogger.LogError("No se pudo crear el archivo de instrucciones {0}: {1}", ArchivodeInstrucciones, ex.Message)
            End Try
        End If

        Try
            Using parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(ArchivodeInstrucciones, System.Text.Encoding.Default)
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                parser.SetDelimiters(",")
                parser.HasFieldsEnclosedInQuotes = True

                If Not parser.EndOfData Then
                    Dim firstLine As String() = parser.ReadFields()
                    If firstLine IsNot Nothing AndAlso firstLine.Length > 0 Then
                        NroInstruccionesArchivadas = QB.SafeToShort(firstLine(0))
                    End If
                End If

                Dim i As Integer = 1
                While Not parser.EndOfData AndAlso i <= NroInstruccionesArchivadas
                    Dim fields As String() = parser.ReadFields()
                    If fields IsNot Nothing AndAlso fields.Length > 0 Then
                        InstruccionesArchivadas(i) = fields(0)
                        Info.CBox2.Items.Add(fields(0))
                    End If
                    i += 1
                End While
            End Using
            
            AppLogger.LogDebug("Instrucciones cargadas: {0} de {1}", Info.CBox2.Items.Count, ArchivodeInstrucciones)

        Catch ex As Exception
            AppLogger.LogError("Error al leer instrucciones de {0}: {1}", ArchivodeInstrucciones, ex.Message)
            MsgBox("Error al cargar informes guardados: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Sub ARINFO(ByVal ARx As Integer, ByVal accion As Integer)
        Info.TextBox1.Text = ""
        Ar = ARx
        ' ejemplo de orden directa
        'B$ = "ORDEN POR LETRA CODI"
        'Call Deco1()
        'If FlgImpresion Then
        TituloInforme = "TITULO"
        Y# = 45
        Call Impresora()
        'End If
        'Call Deco2()

        Tiq(1) = "Generador de Informes"
        Tiq(2) = "Que hacemos ?"
        Tiq(3) = "Que ... ?"
        Tiq(4) = "Dale de nuevo ..."


        Dim F%
        Dim FE%


        Dim M$
        Dim ARRI%
        Dim VARI$ = ""
        Dim C$
        If accion = 0 Then
            Asignavariables()
            Exit Sub
        End If
        Dim repetirArinfo As Boolean = True
        Do While repetirArinfo
            repetirArinfo = False ' Por defecto no repetimos a menos que se indique explícitamente

            ' --- 50490: Mostrar informes guardados ---
            KF = 0
            F% = 1
            Debug.Print(Tiq$(F%))
            FE% = F%
            Dim IndiceInstruccion As Integer
            For IndiceInstruccion = 1 To NroInstruccionesArchivadas
                Debug.Print(Str(IndiceInstruccion) + "- " + InstruccionesArchivadas(IndiceInstruccion))
            Next

            Dim leerComando As Boolean = True
            Do While leerComando
                leerComando = False ' Por defecto salimos de la lectura del comando

                ' --- 50511: Ingreso de informe ---
                M$ = "Ingresa el informe ...    [F1]- Campos  [F10]- Abandona  [F6]Cambia clave(" + Str$(Keynum%) + ")"
                B$ = Info.TextBox2.Text ' "IMPRIMI ORDEN CODIGO RAZON SOCIAL 'CONS' INVERS"
                
                If ARRI% = 20 Then
                    Exit Sub
                End If

                ' Cambio de clave
                If ARRI% = 16 Then
                    Keynum = Keynum + 1
                    Status = Arbtr(Ar).CallBtrv(12, Keyval, Keynum)
                    If (Status <> 0) And (Status <> 6) Then
                        Debug.Print("STAT: " & Status)
                        AppLogger.LogError("Error inesperado al cambiar clave Btrieve. Status: {0}, Keynum: {1}", Status, Keynum)
                        MsgBox("Error al cambiar clave: " & Status.ToString(), MsgBoxStyle.Exclamation)
                        Keynum = 0 ' Reset a la clave por defecto
                    End If
                    If Status = 6 Then
                        Keynum = 0
                    End If
                    leerComando = True ' Equivale a GoTo 50511
                    Continue Do
                End If

                Y# = QB.SafeToDouble(B$)
                If Y# > 0 And Y# <= NroInstruccionesArchivadas Then
                    B$ = InstruccionesArchivadas(CInt(Y#))
                    Debug.Print(B$)
                End If

                If Y# < 0 Then
                    ' borra instruccion
                    For IndiceInstruccion = (CInt(Y#) * -1) To NroInstruccionesArchivadas
                        InstruccionesArchivadas(IndiceInstruccion) = InstruccionesArchivadas(IndiceInstruccion + 1)
                    Next
                    NroInstruccionesArchivadas = NroInstruccionesArchivadas - 1
                    repetirArinfo = True ' Equivale a GoTo 50490
                    Exit Do
                End If

                If qb4.Left(B$, 4) = "GRAB" Then
                    C$ = "-=< Grabando >=-"  'graba en secuencial
                    Debug.Print(C$)
                    GrabaArchivoListados()
                    repetirArinfo = True ' Equivale a GoTo 50490
                    Exit Do
                End If

                C$ = " sale ..!"
                Debug.Print(C$)
                VUELTA% = 0
                Call Deco1()
                If VUELTA% <> 0 Then
                    repetirArinfo = True ' Equivale a GoTo 50490
                    Exit Do
                End If

                ConfirmaImpresora()
                If VUELTA% <> 0 Then
                    repetirArinfo = True ' Equivale a GoTo 50490
                    Exit Do
                End If
            Loop
        Loop
        Call Deco2()
        'otro info ? o fin de info
        If GG% <> 0 Then
            'Print(Pxt, TAB(1), GG.ToString & " Registros ")
        Else
            'Print(Pxt, "No Encontre '" & ClaveBusqueda & "'...")
        End If
        'If FlgImpresion Then
        '    FlgImpresion = 0
        '    CortedePagina()
        '    Print(Pxt, "-=<Fin>=-")
        'End If
        'If FlgExcell Then
        '    FlgImpresion = 0
        'End If
        If porXML = -1 Then
            ' *** fin de XML
            'Print(Pxp, TAB(1), "</archivo>")
            'Print(Pxp, TAB(1), "")
            'FileClose(Pxp)
            'Info.TextBox3.Text = System.IO.File.ReadAllText(DeviceXML)

            With XMLHess
                .WriteEndElement()
                .WriteEndDocument()
                .Close()
                strXML = sb.ToString
                sCleanXML = SanitizeXmlString(strXML)
                File.WriteAllText("e:\impre2.xml", sCleanXML) ' sb.ToString)
            End With

        End If


        newDataSet = New DataSet
        'newDataSet.ReadXml("e:\impre2.xml")

        'Dim buffer As Byte() = Encoding.UTF8.GetBytes(sCleanXML)
        'Dim stream As MemoryStream = New MemoryStream(buffer)
        'Dim Reader As XmlReader = XmlReader.Create(stream)

        Dim stream = New StringReader(sCleanXML)
        Dim reader = New XmlTextReader(stream)

        newDataSet.ReadXml(Reader)
        newDataSet.AcceptChanges()

        If newDataSet.Tables.Count > 0 Then
            Info.Ds = newDataSet
            Info.x = Arbtr(Ar)
            'Dim Tab As Integer = 1
            'For i = 0 To newDataSet.Tables(0).Columns.Count - 1
            '    Dim colwork As DataColumn = newDataSet.Tables(0).Columns(i)
            '    colwork.ExtendedProperties.Add("Titulo", CamposdeBusqueda(P(i)))
            '    MsgBox(CamposdeBusqueda(P(i)))
            '    colwork.ExtendedProperties.Add("Ancho", AnchoDeColumna(P(i)))
            '    colwork.ExtendedProperties.Add("Tipo", TipoDeCampo(P(i)))
            '    colwork.ExtendedProperties.Add("Decimales", DeciDeCampo(P(i)))
            '    colwork.ExtendedProperties.Add("Visible", "True")
            '    colwork.ExtendedProperties.Add("Subtotal", SubtDeCampo(P(i)))
            '    colwork.ExtendedProperties.Add("Tab", Tab)
            '    Tab = Tab + AnchoDeColumna(P(i)) + 1
            'Next
            Info.UltraGrid1.DataSource = newDataSet.Tables(0)
            For i = 1 To newDataSet.Tables(0).Columns.Count - 1
                'MsgBox(P%(i))
                'Info.P(i) = P%(i)
            Next
            'newDataSet.Tables(0).Columns(1).MaxLength = 3

            '' create and add articulo
            'colWork = New DataColumn("Articulo", GetType(String))
            'colWork.MaxLength = 5
            'colWork.ExtendedProperties.Add("Titulo", "Codigo")
            'colWork.ExtendedProperties.Add("Ancho", 5)
            'colWork.ExtendedProperties.Add("Tipo", 0)
            'colWork.ExtendedProperties.Add("Decimales", 0)
            'colWork.ExtendedProperties.Add("Visible", "True")
            'DataTable.Columns.Add(colWork)

            Dim DefineXDS As Boolean = False
            If DefineXDS = True Then
                newDataSet.Tables(0).WriteXmlSchema("E:\INFO.XSD")
            End If
            'Info.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            For i = 1 To newDataSet.Tables(0).Columns.Count - 1
                Info.UltraGrid1.DisplayLayout.Bands(0).Columns(i).Header.Caption = CamposdeBusqueda(P(i))
                Info.UltraGrid1.DisplayLayout.Bands(0).Columns(i).Width = AnchoDeColumna((i)) * 10
                Select Case TipoDeCampo(P(i))
                    Case 0, 2
                        Info.UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Alignment.LeftAlign
                    Case 1
                        Info.UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Alignment.RightAlign
                    Case 2
                        Info.UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Alignment.LeftAlign
                    Case Else
                End Select
            Next

            IniReport()

            Dim strReportName As String = "Reporte"
            Dim strReportPath As String = UReportPath + "vertical.rpt" ' Application.StartupPath & _                          "\" & strReportName & ".rpt"

            'Dim largodelinea As Integer = 0
            'For i = 1 To newDataSet.Tables(0).Columns.Count - 1
            '    largodelinea = Q(i) + AnchoDeColumna(i)
            '    If largodelinea > 80 Then
            '        strReportPath = "E:\Arean\Arinfo\horizontal.rpt"
            '    End If
            'Next

            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Unable to locate report file:" & _
                 vbCrLf & strReportPath))
            End If

            Dim cr As New ReportDocument
            cr.Load(strReportPath)
            Info.Crep.ReportSource = cr
            'MsgBox("XXX")
            Dim MyText As TextObject
            Dim FldName As FieldObject
            Dim fields(60) As String
            Dim Margenes As PageMargins = cr.PrintOptions.PageMargins
            Dim Papelsize As PaperSize = cr.PrintOptions.PaperSize
            Margenes.topMargin = CInt(0.1 * 1440)
            Margenes.bottomMargin = CInt(0.1 * 1440)
            Margenes.leftMargin = CInt(0.1 * 1440)
            Margenes.rightMargin = CInt(0.1 * 1440)
            Dim PageContentWidth As Integer = 0
            Dim Anchodevuelto As Integer
            Dim MedidaFont As Single
            Dim Entro As Boolean = False
            cr.PrintOptions.PaperSize = PaperSize.PaperA4
            cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            For MedidaFont = 10 To 7 Step -1
                cr.PrintOptions.ApplyPageMargins(Margenes)
                PageContentWidth = cr.PrintOptions.PageContentWidth
                Anchodevuelto = VerificaSiEntra(cr, MedidaFont)
                'MsgBox(MedidaFont.ToString + "  " + Anchodevuelto.ToString + "  " + PageContentWidth.ToString)
                If Anchodevuelto < PageContentWidth Then
                    Entro = True
                    Exit For
                End If
            Next
            If Entro = False Then
                cr.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                For MedidaFont = 10 To 7 Step -1
                    cr.PrintOptions.ApplyPageMargins(Margenes)
                    PageContentWidth = cr.PrintOptions.PageContentWidth
                    Anchodevuelto = VerificaSiEntra(cr, MedidaFont)
                    'MsgBox(MedidaFont.ToString + "  " + Anchodevuelto.ToString + "  " + PageContentWidth.ToString)
                    If Anchodevuelto < PageContentWidth Then
                        Entro = True
                        Exit For
                    End If
                Next
            End If
            If Entro = False Then
                cr.PrintOptions.PaperSize = PaperSize.PaperLegal
                cr.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                For MedidaFont = 10 To 7 Step -1
                    cr.PrintOptions.ApplyPageMargins(Margenes)
                    PageContentWidth = cr.PrintOptions.PageContentWidth
                    Anchodevuelto = VerificaSiEntra(cr, MedidaFont)
                    'MsgBox(MedidaFont.ToString + "  " + Anchodevuelto.ToString + "  " + PageContentWidth.ToString)
                    If Anchodevuelto < PageContentWidth Then
                        Entro = True
                        Exit For
                    End If
                Next
            End If
            'MsgBox("Fin " + MedidaFont.ToString + "  " + Anchodevuelto.ToString + "  " + PageContentWidth.ToString)
            Dim Ofset As Integer = 0
            If PageContentWidth - Anchodevuelto > 0 Then
                Ofset = CInt((PageContentWidth - Anchodevuelto) / 2)
            End If

            'Do 

            Dim ReportSectionss As CrystalDecisions.CrystalReports.Engine.Sections = cr.ReportDefinition.Sections
            For Each CurSection As CrystalDecisions.CrystalReports.Engine.Section In ReportSectionss
                For Each RepObj As CrystalDecisions.CrystalReports.Engine.ReportObject In CurSection.ReportObjects
                    ''MsgBox(RepObj.Name + RepObj.Kind.ToString)
                    'If RepObj.Kind = ReportObjectKind.FieldObject Then
                    '    Select Case qb4.Left(RepObj.Name, 6)
                    '        Case "FmRese", "FmSuma", "FmDisp", "FmTisp"
                    '            Dim Var As Integer = 1
                    '            Dim Dec As Integer = 0
                    '            Dim FmDisplay As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "Replace(ToText(x" + Var.ToString + ", " + Dec.ToString + "), ',', '.')"
                    '            Dim FmReset As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "x" + Var.ToString + ":=0;"
                    '            Dim FmSuma As String = "WhilePrintingRecords;" + Chr(13) + Chr(10) + "If NumericText(Trim(Replace({DataTable1.DataColumn" + Var.ToString + "},' ',''))) then " + Chr(13) + Chr(10) + "numbervar x" + Var.ToString + ":= x" + Var.ToString + " + cdbl(Trim(Replace(replace({DataTable1.DataColumn" + Var.ToString + "},'.',','),' ',''))) " + Chr(13) + Chr(10) + "Else " + Chr(13) + Chr(10) + "numbervar x" + Var.ToString + ":= x" + Var.ToString + " + 0;"
                    '            Dim FmTisplay As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "Replace(ToText(x" + Var.ToString + ", " + Dec.ToString + "), ',', '.')"
                    '            FmDisplay.Replace("'", Chr(34))
                    '            FmReset.Replace("'", Chr(34))
                    '            FmSuma.Replace("'", Chr(34))
                    '            FmTisplay.Replace("'", Chr(34))
                    '            FldName = CType(cr.ReportDefinition.ReportObjects(RepObj.Name), FieldObject)
                    '            Dim Formula As FormulaFieldDefinition = FldName.DataSource
                    '            Select Case qb4.Left(RepObj.Name, 6)
                    '                Case "FmRese"
                    '                    Formula.Text = FmReset
                    '                Case "FmSuma"
                    '                    Formula.Text = FmSuma
                    '                Case "FmDisp"
                    '                    Formula.Text = FmDisplay
                    '                Case "FmTisp"
                    '                    Formula.Text = FmTisplay
                    '                Case Else
                    '            End Select
                    '            FldName.ObjectFormat.EnableSuppress = True 'elimina totales
                    '            'MsgBox(RepObj.Name + " " + Formula.Text)
                    '            'Formula.Text = ""
                    '        Case Else
                    '    End Select
                    'End If

                    If RepObj.Kind = ReportObjectKind.TextObject Then
                        If RepObj.Name = "Titulo" Then
                            MyText = CType(cr.ReportDefinition.ReportObjects("Titulo"), TextObject)
                            MyText.Text = TituloInforme.Trim
                        End If
                        ' EmailSubject = CType(RepObj, CrystalDecisions.CrystalReports.Engine.TextObject).Text
                    End If

                Next
            Next

            'Loop
            Dim TMPbmp As New Bitmap(1, 1)
            Dim TMPgfx As Graphics = Graphics.FromImage(TMPbmp)
            Dim TxtSize As SizeF
            ' las medidas del Cr son en Twips ->  1 inch = 1440 twips
            TMPgfx.PageUnit = GraphicsUnit.Inch
            Dim pText As String = New String("L"c, 1)
            Dim PFont As Font = New System.Drawing.Font("Arial", MedidaFont, System.Drawing.FontStyle.Regular)
            TxtSize = TMPgfx.MeasureString(pText, PFont)
            Dim AnchoSeparador As Integer = CInt(TxtSize.Width * 1440)
            Dim Ancho As Integer = 0
            Dim Ancholinea As Integer = AnchoSeparador
            Dim Tabs(50) As Integer
            Tabs(1) = 0
            For i = 1 To 50
                MyText = CType(cr.ReportDefinition.ReportObjects("Text" & (i).ToString), TextObject)
                'MsgBox(MyText.Name)
                FldName = CType(cr.ReportDefinition.ReportObjects("DataColumn" & (i).ToString & "1"), FieldObject)
                If i < QQ + 1 Then
                    fields(i) = CamposdeBusqueda(P(i))
                    MyText.Text = fields(i).ToString()
                    'pText = New String("L", AnchoDeColumna((i)))
                    'TxtSize = TMPgfx.MeasureString(pText, PFont)
                    'Ancho = TxtSize.Width * 1440
                    Ancho = AnchoDeColumna((i)) * AnchoSeparador
                    MyText.Width = Ancho
                    FldName.Width = Ancho
                    MyText.ApplyFont(PFont)
                    FldName.ApplyFont(PFont)
                    Ancholinea = Q((i)) * AnchoSeparador
                    FldName.Left = Ancholinea + Ofset ' (Q((i)) * 140) + 100
                    MyText.Left = Ancholinea + Ofset ' (Q((i)) * 140) + 100
                    'Ancholinea = Ancholinea + Ancho + AnchoSeparador
                    Select Case TipoDeCampo(P(i))
                        Case 0, 2
                            FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                        Case 1
                            FldName.ObjectFormat.HorizontalAlignment = Alignment.RightAlign
                        Case 2
                            FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                        Case Else
                    End Select
                Else
                    MyText.Text = ""
                    MyText.Left = 20000
                    MyText.Width = 0
                    FldName.Width = 0
                    FldName.Left = 20000
                End If
            Next
            TMPbmp.Dispose()
            TMPgfx.Dispose()

            Dim Var As Integer = 0
            For i = 0 To newDataSet.Tables(0).Columns.Count - 1
                Dim colwork As DataColumn = newDataSet.Tables(0).Columns(i)
                If CInt(colwork.ExtendedProperties.Item("Subtotal")) = 1 Then
                    Var = Var + 1
                    Dim Dec As Integer = CInt(colwork.ExtendedProperties.Item("Decimales"))
                    Dim FmDisplay As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "Replace(ToText(x" + Var.ToString + ", " + Dec.ToString + "), ',', '.')"
                    Dim FmReset As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "x" + Var.ToString + ":=0;"
                    Dim FmSuma As String = "WhilePrintingRecords;" + Chr(13) + Chr(10) + "If NumericText(Trim(Replace({DataTable1.DataColumn" + i.ToString + "},' ',''))) then " + Chr(13) + Chr(10) + "numbervar x" + Var.ToString + ":= x" + Var.ToString + " + cdbl(Trim(Replace(replace({DataTable1.DataColumn" + i.ToString + "},'.',','),' ',''))) " + Chr(13) + Chr(10) + "Else " + Chr(13) + Chr(10) + "numbervar x" + Var.ToString + ":= x" + Var.ToString + " + 0;"
                    Dim FmTisplay As String = "NumberVar x" + Var.ToString + ";" + Chr(13) + Chr(10) + "WhilePrintingRecords;" + Chr(13) + Chr(10) + "Replace(ToText(x" + Var.ToString + ", " + Dec.ToString + "), ',', '.')"
                    FmDisplay.Replace("'", Chr(34))
                    FmReset.Replace("'", Chr(34))
                    FmSuma.Replace("'", Chr(34))
                    FmTisplay.Replace("'", Chr(34))
                    Dim FormulaName As String
                    Dim FormulaContents As String
                    FormulaName = "FmReset" + Var.ToString : FormulaContents = FmReset
                    SetReportFormulaContents(cr, FormulaName, FormulaContents)
                    SetReportObject(cr, FormulaName, colwork, AnchoSeparador, PFont, Ofset)
                    FormulaName = "FmDisplay" + Var.ToString : FormulaContents = FmDisplay
                    SetReportFormulaContents(cr, FormulaName, FormulaContents)
                    SetReportObject(cr, FormulaName, colwork, AnchoSeparador, PFont, Ofset)
                    FormulaName = "FmTisplay" + Var.ToString : FormulaContents = FmTisplay
                    SetReportFormulaContents(cr, FormulaName, FormulaContents)
                    SetReportObject(cr, FormulaName, colwork, AnchoSeparador, PFont, Ofset)
                    FormulaName = "FmSuma" + Var.ToString : FormulaContents = FmSuma
                    SetReportFormulaContents(cr, FormulaName, FormulaContents)
                    SetReportObject(cr, FormulaName, colwork, AnchoSeparador, PFont, Ofset)
                End If
            Next

            cr.SetDataSource(newDataSet.Tables(0))
            Info.Crep.ReportSource = cr

            'Dim RptDoc As New ReportDocument
            'Dim _fldName As FieldObject
            '_fldName = RptDoc.ReportDefinition.ReportObjects("fieldObjectName")
            '_fldName.Width = 0
            '_fldName.Height = 0
        End If
        'otro informe
        'MsgBox("Otro Informe")
        Info.TabControl1.SelectedIndex = 2

        'Simplificado: Exit Sub directo ya que RR% siempre es 0\n        Exit Sub
    End Sub
    Function VerificaSiEntra(ByVal Cr As ReportDocument, ByVal MedidaFont As Single) As Integer
        Dim MyText As TextObject
        Dim FldName As FieldObject
        Dim fields(60) As String
        Dim TMPbmp As New Bitmap(1, 1)
        Dim TMPgfx As Graphics = Graphics.FromImage(TMPbmp)
        Dim TxtSize As SizeF
        ' las medidas del Cr son en Twips ->  1 inch = 1440 twips
        TMPgfx.PageUnit = GraphicsUnit.Inch
        Dim pText As String = New String("L"c, 1)
        Dim PFont As Font = New System.Drawing.Font("Arial", MedidaFont, System.Drawing.FontStyle.Regular)
        TxtSize = TMPgfx.MeasureString(pText, PFont)
        Dim AnchoSeparador As Integer = CInt(TxtSize.Width * 1440)
        Dim Ancho As Integer = 0
        Dim Ancholinea As Integer = AnchoSeparador
        Dim Tabs(50) As Integer
        Tabs(1) = 0
        For i = 1 To 50
            MyText = CType(Cr.ReportDefinition.ReportObjects("Text" & (i).ToString), TextObject)
            FldName = CType(Cr.ReportDefinition.ReportObjects("DataColumn" & (i).ToString & "1"), FieldObject)
            If i < QQ + 1 Then
                fields(i) = CamposdeBusqueda(P(i))
                MyText.Text = fields(i).ToString()
                'pText = New String("L", AnchoDeColumna((i)))
                'TxtSize = TMPgfx.MeasureString(pText, PFont)
                'Ancho = TxtSize.Width * 1440
                Ancho = AnchoDeColumna((i)) * AnchoSeparador
                MyText.Width = Ancho
                FldName.Width = Ancho
                MyText.ApplyFont(PFont)
                FldName.ApplyFont(PFont)
                Ancholinea = Q((i)) * AnchoSeparador
                FldName.Left = Ancholinea ' (Q((i)) * 140) + 100
                MyText.Left = Ancholinea ' (Q((i)) * 140) + 100

                Select Case TipoDeCampo(P(i))
                    Case 0, 2
                        FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                    Case 1
                        FldName.ObjectFormat.HorizontalAlignment = Alignment.RightAlign
                    Case 2
                        FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                    Case Else
                End Select
            Else
                MyText.Text = ""
                MyText.Left = 20000
                MyText.Width = 0
                FldName.Width = 0
                FldName.Left = 20000
            End If
        Next
        TMPbmp.Dispose()
        TMPgfx.Dispose()
        Ancholinea = Ancholinea + Ancho
        Return Ancholinea
    End Function

    Public Sub SetReportObject(ByRef Report As ReportDocument, ByVal FormulaName As String, ByVal ColWork As DataColumn, ByVal AnchoSeparador As Integer, ByVal pfont As Font, ByVal Ofset As Integer)
        Dim FldName As FieldObject
        Dim ReportSectionss As CrystalDecisions.CrystalReports.Engine.Sections = Report.ReportDefinition.Sections
        For Each CurSection As CrystalDecisions.CrystalReports.Engine.Section In ReportSectionss
            For Each RepObj As CrystalDecisions.CrystalReports.Engine.ReportObject In CurSection.ReportObjects
                If RepObj.Kind = ReportObjectKind.FieldObject Then
                    If RepObj.Name = FormulaName Then
                        FldName = CType(Report.ReportDefinition.ReportObjects(RepObj.Name), FieldObject)
                        FldName.ObjectFormat.EnableSuppress = False
                        FldName.Width = CInt(CInt(ColWork.ExtendedProperties.Item("Ancho")) * AnchoSeparador)
                        FldName.ApplyFont(PFont)
                        FldName.Left = CInt(CInt(ColWork.ExtendedProperties.Item("Tab")) * AnchoSeparador) + Ofset
                        Select Case CInt(ColWork.ExtendedProperties.Item("Tipo"))
                            Case 0, 2
                                FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                            Case 1
                                FldName.ObjectFormat.HorizontalAlignment = Alignment.RightAlign
                            Case 2
                                FldName.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign
                            Case Else
                        End Select
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub SetReportFormulaContents(ByRef Report As ReportDocument, ByVal FormulaName As String, ByVal FormulaContents As String)
        Dim Formula As FormulaFieldDefinition = Nothing
        If TypeOf (Report.DataDefinition.FormulaFields.Item(FormulaName)) Is CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinition Then
            Formula = Report.DataDefinition.FormulaFields.Item(FormulaName)
            Formula.Text = FormulaContents
        End If
    End Sub

    '1.Public Function StrXml2Table(ByVal StrXML As String) As DataTable
    '2.       Dim ms As MemoryStream
    '3.       Dim returnMs As New DataTable()
    '4.       Try
    '5.           Dim buf() As Byte
    '6.           Dim ds As New DataSet
    '7. 
    '8.           buf = System.Text.UTF8Encoding.ASCII.GetBytes(StrXML)
    '9.           ms = New MemoryStream(buf)
    '10. 
    '11.           ds.ReadXml(ms)
    '12.           Return ds.Tables(0)
    '13.       Catch ex As Exception
    '14.           ' Hacer algo o mostrar mensaje de error
    '15.           Return returnMs
    '16.       Finally
    '17.           If Not ms Is Nothing Then
    '18.               ms.Close()
    '19.           End If
    '20.       End Try
    '21.   End Function

    '  // Function to convert passed XML data to dataset
    'public DataSet ConvertXMLToDataSet(string xmlData)
    '{
    ' StringReader stream = null;
    ' XmlTextReader reader = null;
    ' try
    ' {
    '  DataSet xmlDS = new DataSet() ;
    '  stream = new StringReader(xmlData);
    '  // Load the XmlTextReader from the stream
    '  reader = new XmlTextReader(stream);
    '  xmlDS.ReadXml(reader);
    '  return xmlDS;
    ' }
    ' catch
    ' {
    '  return null;
    ' }
    ' finally
    ' {
    '  if(reader != null) reader.Close();
    ' }
    '}// Use this function to get XML string from a dataset

    '// Function to convert passed dataset to XML data
    'public string ConvertDataSetToXML(DataSet xmlDS)
    '{
    ' MemoryStream stream = null;
    ' XmlTextWriter writer = null;
    ' try
    ' {
    '  stream = new MemoryStream();
    '  // Load the XmlTextReader from the stream
    '  writer = new XmlTextWriter(stream, Encoding.Unicode);
    '  // Write to the file with the WriteXml method.
    '  xmlDS.WriteXml(writer);
    '  int count = (int) stream.Length;
    '  byte[] arr = new byte[count];
    '  stream.Seek(0, SeekOrigin.Begin);
    '  stream.Read(arr, 0, count);
    '  UnicodeEncoding utf = new UnicodeEncoding();
    '  return utf.GetString(arr).Trim();
    ' }
    ' catch
    ' {
    '  return String.Empty ;
    ' }
    ' finally
    ' {
    '  if(writer != null) writer.Close();
    ' }
    '}
    'Why not xmlDS.GetXml()? 


    ''Now, read the entire file into a string
    'Dim sXML As String = objStreamReader.ReadToEnd()
    'Dim sCleanXML As String = SanitizeXmlString(sXML)
    Public Function SanitizeXmlString(ByVal xml As String) As String
        If xml Is Nothing Then
            Throw New ArgumentNullException("xml")
        End If

        Dim buffer As New StringBuilder(xml.Length)

        For Each c As Char In xml
            If IsLegalXmlChar(Microsoft.VisualBasic.AscW(c)) Then
                buffer.Append(c)
            End If
        Next

        Return buffer.ToString()
    End Function


    Public Function IsLegalXmlChar(ByVal character As Integer) As Boolean
        ' == '\t' == 9   
        ' == '\n' == 10  
        ' == '\r' == 13  
        If character = Asc("|") Then character = &H0
        Return (character = &H9 OrElse character = &HA OrElse character = &HD OrElse (character >= &H20 AndAlso character <= &HD7FF) OrElse (character >= &HE000 AndAlso character <= &HFFFD) OrElse (character >= &H10000 AndAlso character <= &H10FFFF))
    End Function
    'Public Function procesSQL() As String
    '    Dim sql As String
    '    Dim inSql As String
    '    Dim firstPart As String
    '    Dim lastPart As String
    '    Dim selectStart As Integer
    '    Dim fromStart As Integer
    '    Dim fields As String()
    '    Dim i As Integer
    '    Dim MyText As TextObject

    '    inSql = TextBox1.Text
    '    inSql = inSql.ToUpper

    '    selectStart = inSql.IndexOf("SELECT")
    '    fromStart = inSql.IndexOf("FROM")
    '    selectStart = selectStart + 6
    '    firstPart = inSql.Substring(selectStart, (fromStart - selectStart))
    '    lastPart = inSql.Substring(fromStart, inSql.Length - fromStart)

    '    fields = firstPart.Split(",")
    '    firstPart = ""
    '    For i = 0 To fields.Length - 1
    '        If i > 0 Then
    '            firstPart = firstPart & " , " _
    '& fields(i).ToString() & "  AS COLUMN" & i + 1
    '            MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" _
    '& i + 1), TextObject)
    '            MyText.Text = fields(i).ToString()
    '        Else
    '            firstPart = firstPart & fields(i).ToString() & _
    '"  AS COLUMN" & i + 1
    '            MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & _
    ' i + 1), TextObject)
    '            MyText.Text = fields(i).ToString()
    '        End If
    '    Next
    '    sql = "SELECT " & firstPart & " " & lastPart
    '    Return sql
    'End Function


    Sub IniReport()
        With Info.Crep
            .ShowPageNavigateButtons = True
            .ShowGotoPageButton = False
            .ShowCloseButton = False
            .ShowPrintButton = True
            .ShowRefreshButton = False
            .ShowExportButton = True
            .ShowGroupTreeButton = False
            .ShowZoomButton = False
            .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            .ShowTextSearchButton = False
            .DisplayStatusBar = True
            .ShowParameterPanelButton = False
            .ShowLogo = False
            .Zoom(1)
            'saca titulo
            Dim I As Integer
            Do While I < .Controls.Count
                If TypeOf (.Controls(I)) Is CrystalDecisions.Windows.Forms.PageView Then
                    Dim J As Integer
                    Do While J < .Controls(I).Controls.Count
                        If CType(.Controls(I).Controls(J), System.Windows.Forms.TabControl).TabPages.Count > 0 Then
                            'cambia titulo
                            CType(.Controls(I).Controls(J), System.Windows.Forms.TabControl).TabPages.Item(0).Text = Empresa
                            If Empresa = "" Then
                                CType(.Controls(I).Controls(J), System.Windows.Forms.TabControl).ItemSize = New Size(0, 1)
                                CType(.Controls(I).Controls(J), System.Windows.Forms.TabControl).SizeMode = TabSizeMode.Fixed
                            End If
                            Exit Do
                        End If
                    Loop
                    Exit Do
                End If
            Loop
        End With
    End Sub

    Sub IniciaOrden()
50790:
        Debug.Print("Estoy leyendo" & "(Un Momento)")
        AAA$ = ""
        L% = 0
        ZM = 0
        ZX = 0.1
        ZN = 1
        FichaPrimera()
        If TipoDeCampo(OrdenxCampo) = 0 Then
            FA% = 1 'ALFA
        Else
            FA% = 0 ' testea el campo para ver si es numerico
        End If
        If FlgOrdenAlfa Then
            FA% = 1 ' obligo a que los campos numericos se lean alfabeticos
        End If
        If FlgOrdenNume Then
            FA% = 0 ' 
        End If
        If FA = 1 Then
            LargoCampoOrden = AnchoDeCampo(OrdenxCampo)
        Else
            LargoCampoOrden = AnchoDeCampo(OrdenxCampo)
            DeciCampoOrden = DeciDeCampo(OrdenxCampo)
        End If
    End Sub

    Sub FichaPrimera()
        Status = Arbtr(Ar).CallBtrv(12, Keyval, Keynum)
        If (Status <> 0) And (Status <> 9) Then
            Debug.Print("STAT: " & Status) : Stop
        End If
        Funcion = 6
    End Sub

    Sub FichaSiguiente()
        Status = Arbtr(Ar).CallBtrv(6, Keyval, Keynum)
        If (Status <> 0) And (Status <> 9) Then
            Debug.Print("STAT: " & Status) : Stop
        End If
    End Sub

    Sub LeeOrdena()
        IndiceOrden = IndiceOrden + 1
        If FA% = 0 Then
            YA = QB.SafeToDouble(Arbtr(Ar).Campo(OrdenxCampo))
            DD = XFND0(YA, LargoCampoOrden, DeciCampoOrden)
        Else
            DD = Arbtr(Ar).Campo(OrdenxCampo)
        End If
        ArraySort.Add(DD.PadRight(LargoCampoOrden) + Arbtr(Ar).Vbtrv1.BtrievePosition.ToString)

        DD$ = Arbtr(Ar).Campo(1)
        If TipoDeCampo(1) = 3 Then
            DD$ = XFNINV$(DD$)
        End If
        Debug.Print(DD$)
    End Sub

    Sub Swap(ByRef a As Object, ByRef b As Object)
        Dim temp As Object = a
        a = b
        b = temp
    End Sub

    Sub LeeImprime()
        Dim IndH As Integer
        If FlgSubrayado Then ' agregue para subrayar
            NroLinea = NroLinea + 1
            A$ = Space(LargoLinea) 'String(LargoLinea, "-")
            T% = 0
            PrintDeCampo()
        End If
        Call SigoInforme()
        If FlgEdicion Then
            PTR% = PTR% + 1
            PtrEdicion(PTR%) = Arbtr(Ar).Vbtrv1.BtrievePosition.ToString
        End If
        Y# = 0
        'A$ = "    ": RSET A$ = mid(STR$(K%), 2): T% = 0: PrintDeCampo
        For IndH = 1 To QQ ' cantidad de campos del informe
            M% = P%(IndH) 'indice del campo en el archivos
            T% = Q%(IndH) ' tabulador del campo en el informe
            If ZZ#(IndH) Then
                YM# = ZZ#(IndH)
            Else
                'If TipoDeCampo(M%) Then
                YM# = QB.SafeToDouble(Arbtr(Ar).Campo(M%))
                'End If
            End If
            Select Case R%(IndH) ' operador
                Case 1
                    Y# = Y# + YM#
                Case 2
                    Y# = Y# - YM#
                Case 3
                    Y# = Y# * YM#
                Case 4
                    Y# = Y# / YM#
                Case 5
                    Y# = Y# + Y# * YM# / 100
                Case 6
                    'Y# = SQR(ABS(Y#))
                Case 7 ' cambio o SUSTITUCION?
                    If SCAM%(IndH) Then
                        E$ = Arbtr(Ar).Campo(SCAM%(IndH)) ' por campo
                    ElseIf SCLA%(IndH) Then
                        E$ = ZZA$(IndH) ' por clave
                    Else
                        E$ = Str$(Int(Y# * 100 + 0.5))
                        E$ = qb4.Left(E$, Len(E$) - 2) + "." + qb4.Right(E$, 2)
                    End If
                    DD$ = E$
                    If TipoDeCampo(M%) = 3 Then
                        DD$ = XFNINV$(DD$) ' fecha
                    End If
                    If Y# Then
                        Arbtr(Ar).Campo(M%) = DD$
                    Else
                        Arbtr(Ar).Campo(M%) = DD$
                    End If
                    Status = Arbtr(Ar).CallBtrv(3, Keyval, Keynum)
                    If Status <> 0 Then
                        Debug.Print("STAT: " & Status)
                    End If
                    Y# = 0.0#
                Case Else
            End Select
            If FlagSubTotal And IndH = 1 Then
                If AAA$ = Arbtr(Ar).Campo(M%) Then
                    A$ = Separador + Space(AnchoDeCampo(M%))
                    FS% = 1
                Else
                    AAA$ = Arbtr(Ar).Campo(M%)
                    If M% Then ' indice del campo en el archivo
                        DD$ = Arbtr(Ar).Campo(M%) ' campo del archivo
                        If TipoDeCampo(M%) = 3 Then
                            DD$ = XFNINV(DD$) ' si fecha lo invierte
                        End If
                        A$ = Separador + DD$
                    Else
                        A$ = ""
                    End If
                End If
            Else
                If M% Then ' indice del campo en el archivo
                    DD$ = Arbtr(Ar).Campo(M%) ' campo del archivo
                    If TipoDeCampo(M%) = 3 Then
                        DD$ = XFNINV(DD$) ' si fecha lo invierte
                    End If
                    A$ = Separador + DD$
                Else
                    A$ = ""
                End If
            End If
            IndiceCampo = IndH
            PrintDeCampo() ' imprime el campo
50721:
        Next
        '
        N% = N% + 1
        If X7% = 0 Then
            ImprimeSubtot()
            Exit Sub
        Else
            YS# = YS# + Y#
            If FlagSubTotal = 0 Then
                ImprimeSubtot()
                Exit Sub
            End If
        End If
        YSS# = YSS# + Y#
        If IndiceOrden < OrdenZ Then
            'Geti = Val(qb4.Right(ArraySort(IndiceOrden + 1), 4))
            Geti = ArraySort(IndiceOrden + 1)
            Arbtr(Ar).Vbtrv1.BtrievePosition = Geti
            If AAA$ = Arbtr(Ar).Campo(P%(1)) Then
                Exit Sub
            End If
        End If
        If FS% Then
            Swap(YSS#, Y#)
            FS% = 0
            T% = T1%
            A$ = Space(Len(MascaraNumerica)) ' STRING(, 45)
            PrintDeCampo()
            A$ = " "
            PrintDeCampo()
            NroLinea = NroLinea + 2
        End If
        ImprimeSubtot()
    End Sub
    Public Function foo(ByVal valToStore As Object) As String
        Dim RetVal As String = String.Empty
        If TypeOf valToStore Is String Then
            RetVal = DirectCast(valToStore, String)
        ElseIf TypeOf valToStore Is Integer Then
            RetVal = DirectCast(valToStore, Integer).ToString
        End If
        RetVal = RetVal.Trim.PadLeft(Len(MascaraNumerica) + 1, " "c)
        Return RetVal
    End Function
    Sub Pregunta()
50220:
        LC% = QB.SafeToInteger(B$) ' pregunta
        Debug.Print("              " & Mid(B$, 2) & "..? ")
        B$ = ""
        RutinaInput()
    End Sub

    Sub Cabezapantalla()
50425:
        'Print(Pxt, TAB(1), "Archivo: " + NombreArchivo)
        'Print(Pxt, TAB(LargoLinea - 7), "Hoja " + NroPagina.ToString)
        'Print(Pxt, "")
        'Print(Pxt, TAB(TabCentrado), TituloInforme)
        'Print(Pxt, TAB(1),BA)
        'Print(Pxt, TAB(1),AE)
        'Print(Pxt, TAB(1),BA)
        OtraPantalla()
    End Sub
    Sub OtraPantalla()
50215:
        Debug.Print(Chr(12) & AE) ' mensaje cabecera
        If FlgEdicion Then
            ReDim PtrEdicion(28)
            PTR% = 0
        End If
    End Sub
    Sub SigoInforme()
50430:
        Dim Tecla As String = ""
        'Tecla = INKEY$
        If Tecla = Chr(27) Or Tecla = " " Then
            Call Sigo()
        End If
        'If FlgImpresion < 1 And FlgExcell = 0 Then ' pagina informe por pantalla
        '    Call Sigo()
        'End If
        CortedePagina()
    End Sub
    Sub CortedePagina()
50435:
        NroLinea = NroLinea + 1
        If NroLinea < KF Then
            Exit Sub
        Else
            NroPagina = NroPagina + 1
            'Print(Pxt, BA)
            'Print(Pxt, TAB(1), FechaEmision)
            'Print(Pxt, TAB(LargoLinea - 8), TimeOfDay.ToString)
            'If FlgImpresion Then
            'Print(Pxt, "///...")
            NroLinea = 1 '0
            'Cabezapantalla()
            'End If
        End If
        If NroLinea < 50 Then
            Exit Sub
        Else
            'Print(Pxt, TAB(1), "")
            'FileClose(Pxt)
            'Info.TextBox1.Text = System.IO.File.ReadAllText(Device)
            'Application.DoEvents()
            'FileOpen(Pxt, Device, Microsoft.VisualBasic.OpenMode.Append, , OpenShare.Shared)
            NroLinea = 1
        End If
    End Sub
    Sub ConfirmaImpresora()
50570:
        Debug.Print("Correcto")
        Call SiNo()
        If RR% < 1 Then
            VUELTA% = 1
            Exit Sub
        End If
        If Y# = 0 And NroInstruccionesArchivadas < 10 Then
            NroInstruccionesArchivadas = NroInstruccionesArchivadas + 1
            InstruccionesArchivadas(NroInstruccionesArchivadas) = RTEM$ 'BB$
        End If
        'FlgExcell = InStr(B$, " LOTUS") 'FLAG de lotus
        'If FlgExcell Then
        '    B$ = "8Nombre de Archivo"
        '    Pregunta()
        '    If B$ = "" Then
        '        ConfirmaImpresora()
        '    Else
        '        Archi$ = B$
        '    End If
        '    Device$ = Archi$
        '    FlgImpresion = 0
        '    NroLinea = 0
        '    NroPagina = 1
        '    Y# = 12
        '    KF = 9999
        '    FileClose(Pxt)
        '    FileOpen(Pxt, Device, Microsoft.VisualBasic.OpenMode.Output, , OpenShare.Shared)
        '    Exit Sub
        'End If
        'If FlgImpresion Then
        '    B$ = "0Encabezado"
        '    Pregunta()
        '    If B$ = "" Then
        TituloInforme = BB$
        '    Else
        '        TituloInforme = B$
        '    End If
        '    If FechaEmision = "" Then
        '        B$ = "8Fecha (dd/mm/aa)"
        '        Pregunta()
        '        FechaEmision = B$
        '    End If
        '    B$ = "2Renglones"
        '    Pregunta()
            Call Impresora()
        'End If
    End Sub
    Sub Delay()
50190:
        For Indice As Integer = 1 To 2000
        Next ' delay
    End Sub

    Sub Impresora()
50575:
        KF = Y# - 12
        If KF < 18 Then
            KF = 9999
        End If
        'If FlgImpresion Then
        '    Device$ = "E:\IMPRE.TXT" ' "LPT1:" ' DEVICEX$
        'End If

        Dim HuboExcept As Boolean = False
        'FileClose(Pxt)
        'Try
        '    FileOpen(Pxt, Device, Microsoft.VisualBasic.OpenMode.Output, , OpenShare.Shared)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        '    HuboExcept = True
        'Finally
        '    If HuboExcept Then
        '        Stop
        '    End If
        'End Try
        'If FlgImpresion Then
        '    'PRINT #Pxt, LetraGrande ' letra normal
        '    If LargoLinea > 80 Then
        '        Debug.Print("Letra chica")
        '        Call SiNo()
        '        If RR% Then
        '            'PRINT #Pxt, LetraChica
        '        End If
        '    End If
        'End If

        porXML = -1
        ' *** inicia XML
        If porXML = -1 Then
            'DeviceXML = "E:\IMPRE.XML"
            'FileClose(Pxp)
            'Try
            '    FileOpen(Pxp, DeviceXML, Microsoft.VisualBasic.OpenMode.Output, , OpenShare.Shared)
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            '    HuboExcept = True
            'Finally
            '    If HuboExcept Then
            '        Stop
            '    End If
            'End Try
            'Print(Pxp, TAB(1), "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " encoding=" + Chr(34) + "iso-8859-1" + Chr(34) + " ?>") '"utf-8"
            'Print(Pxp, TAB(1), "<archivo>")
            sb = New StringBuilder
            XMLHess = New XmlTextWriter(New EncodedStringWriter(sb, Encoding.UTF8))
            With XMLHess
                .Formatting = Formatting.Indented
                .Indentation = 2
                .WriteStartDocument()
                .WriteStartElement("archivo")
            End With
        End If
        ' ***

        NroLinea = 0
        NroPagina = 1
        'FileWidth(Pxt, LargoLinea + 2) ' WIDTH
        BA = Space(LargoLinea) ' String(61,LargoLinea)
        TabCentrado = (LargoLinea - Len(TituloInforme)) \ 2
        Cabezapantalla()
    End Sub
    Sub Deco2()
50650:
        Dim IndH As Integer = 0
        Dim Columna As Integer = 0
        Dim AnchoCampo As Integer = 0
        Dim Ymax As Integer = 0

        If FlgEdicion Then
            Columna = 1
            Ymax = 0
            For IndH = 1 To 10
                ASIGX%(IndH) = P%(IndH)
                AnchoCampo = AnchoDeCampo(ASIGX%(IndH - 1))
                'IF AnchoCampo < LEN(CamposdeBusqueda(ASIGX%(IndH - 1))) THEN AnchoCampo = LEN(CamposdeBusqueda(ASIGX%(IndH - 1)))
                Columna = Columna + AnchoCampo + 1
                COLU%(IndH) = Columna
                If Ymax = 0 Then
                    If ASIGX%(IndH) = 0 Then
                        Ymax = IndH - 1
                    End If
                End If
            Next
        End If
        If OrdenxCampo Then
            IniciaOrden()
        Else
            Call OtraPantalla() ' mensaje cabecera
        End If
        Exiti = 0
        Dim K As Integer = 1
        Funcion% = 12
        While Exiti = 0
            Application.DoEvents()
            If Funcion% = 12 Then
                FichaPrimera()
            Else
                FichaSiguiente()
            End If
            If Status% = 9 Then
                Exiti = 1
                Continue While
            End If

            Dim pasaFiltro As Boolean = False
            If HH < 0 Then
                pasaFiltro = True
            Else
                Dim indH_eval As Integer = 0
                Do While indH_eval <= HH
                    DD$ = Arbtr(Ar).Campo(FLG%(indH_eval, 1))
                    If TipoDeCampo(FLG%(indH_eval, 1)) = 3 Then
                        DD$ = XFNINV(DD$) ' fecha
                    End If

                    Dim cumpleCondicion As Boolean = (Math.Sign(InStr(DD$, CL$(indH_eval))) Xor FLG%(indH_eval, 2) Or FLG%(indH_eval, 0) = 2 + Math.Sign(QB.SafeToDouble(DD$) - Z#(indH_eval)))

                    If cumpleCondicion Then
                        ' Salta filtros OR consecutivos si ya se cumplió el bloque
                        While indH_eval < HH AndAlso FLG%(indH_eval + 1, 3) <> 0
                            indH_eval += 1
                        End While
                        ' Si llegamos al final de los filtros, este registro es válido
                        If indH_eval >= HH Then
                            pasaFiltro = True
                            Exit Do
                        End If
                    Else
                        ' Si no cumple, solo tiene otra oportunidad si la siguiente condición es un 'O' (flag 3)
                        If indH_eval < HH AndAlso FLG%(indH_eval + 1, 3) <> 0 Then
                            ' sigue el bucle para evaluar el siguiente OR
                        Else
                            ' no cumple y no hay OR alternativo: descarta registro
                            pasaFiltro = False
                            Exit Do
                        End If
                    End If
                    indH_eval += 1
                Loop
            End If

            If pasaFiltro Then
                If OrdenxCampo Then
                    LeeOrdena()
                Else
                    LeeImprime()
                End If
            End If
        End While
        OrdenA = 0
        OrdenZ = IndiceOrden - 1
        If OrdenxCampo Then
            ArraySort.Sort() ' OrdenZ)
            Debug.Print("Estoy leyendo" & "(Un Momento)")
            OtraPantalla()
            If FlgOrdenInverso Then
                Swap(OrdenZ, OrdenA)
                DireccionOrden = -1
            Else
                DireccionOrden = 1
            End If
            For Indice = OrdenA To OrdenZ Step DireccionOrden
                Arbtr(Ar).Vbtrv1.BtrievePosition = Mid(ArraySort(Indice).ToString(), LargoCampoOrden + 1)
                LeeImprime()
            Next
        End If
        GG% = N%
        ClaveBusqueda = CL$(0)
        If G%(4) Then
            Y# = YS#
        ElseIf G%(5) Then
            Y# = YS# / N%
        Else
            Exit Sub
        End If
        porXML = 0
        T% = T1%
        A$ = Space(Len(MascaraNumerica)) ' String(61,Len(MascaraNumerica))
        Call PrintDeCampo()
        'PRINT 
        T% = T1% - 9
        A$ = A2
        PrintDeCampo()
        ImprimeSubtot()
        porXML = -1
    End Sub
    Sub ImprimeSubtot()
50735:
        If X7% <> 0 Then
            YSS# = 0
            'PRINT USING MascaraNumerica; Y#;
            'If FlgImpresion Then
            '    Print(Pxt, foo(Format(Y#, MascaraNumerica)))
            'End If
            'If FlgExcell Then
            '    Print(Pxt, Format(Y#, MascaraNumerica))
            'End If
            If porXML = -1 Then
                ' *** escribo fila XML
                'Print(Pxp, TAB(1), "<" + NN(M) + ">")
                algo = algo + 1
                'MsgBox(algo.ToString)
                'Print(Pxp, TAB(1), "<DataColumn" + algo.ToString + ">")
                A = foo(Format(Y#, MascaraNumerica))
                Dim ZZ As String = A.Replace("|", "")
                ZZ = ZZ.Replace(Chr(22), " ")
                Dim Temp As String = ZZ
                Dim strg1 As String = "&"
                Dim strg2 As String = "y" ' &amp;
                If InStr(Temp, strg1$) Then
                    For A As Integer = 1 To Len(Temp)
                        If Mid(Temp, A, 1) = strg1 Then
                            Mid(Temp, A, 1) = strg2
                        End If
                    Next
                End If
                ZZ = Temp
                'Print(Pxp, ZZ)
                'Print(Pxp, "</" + NN(M) + ">")
                'ZZ = A
                'MsgBox(algo.ToString + ZZ)
                With XMLHess
                    .WriteElementString("DataColumn" + algo.ToString, ZZ)
                End With
                'Print(Pxp, "</DataColumn" + algo.ToString + ">")
                ' ***
            End If
        Else
            'If FlgImpresion Then
            '    Print(Pxt, TAB(ultimotab), "|") ' TAB(LargoLinea + 1), "|")
            'End If
            'If FlgExcell Then
            '    Print(Pxt, "")
            'End If
        End If
        Debug.Print("")
        'If FlgImpresion Then
        '    Print(Pxt, TAB(LargoLinea + 1), "|")
        'End If
        'If FlgExcell Then
        '    Print(Pxt, "")
        'End If

        If porXML = -1 Then
            'If IndiceCampo = QQ Then
            ' *** fin fila XML
            'Print(Pxp, TAB(1), "</fila>")
            ' ***
            With XMLHess
                .WriteEndElement()
            End With
            'End If
        End If
    End Sub
    Sub Deco1()
50520:
        ' inicializa
        Dim Kx As Integer = 0
        Dim Uc As Integer = 0
        Dim SCLAC As Integer = 0
        Dim SCAMC As Integer = 0
        Dim SCMPC As Integer = 0
        Dim Indice As Integer = 0
        Dim SIndice As Integer = 0
        Dim FI As Integer = 0
        Dim ISS As Integer = 0
        Dim UU As Integer = 0
        Dim IndH As Integer = 0

        N% = 0

        QQ = 0
        YS# = 0
        YSS# = 0

        For Indice = 0 To 11
            P%(Indice) = 0
            R%(Indice) = 0
            Z#(Indice) = 0
            G%(Indice) = 0
            ZZ#(Indice) = 0
        Next

        For Indice = 0 To 5
            For SIndice = 0 To 3
                FLG%(Indice, SIndice) = 0
            Next
        Next
        For Indice = 0 To 11
            ZZA$(Indice) = ""
            SCLA%(Indice) = 0
            SCAM%(Indice) = 0
        Next

        A2 = ""
        AAA$ = ""
        AE = ""
        ' AE = "NUM "
        IndiceOrden = 0
        LC% = 0
        FS% = 0
        ClaveBusqueda = ""
        FlgImpresion = 0
        BB$ = B$
        B$ = " " + B$
        L% = Len(B$)
        RTEM$ = B$
        Dim Temp As String = ""
        Dim IndiceDeFrase As Integer
        For IndiceDeFrase = 1 To L%    ' IndiceDeFrase es el puntero sobre la frase a decodificar
            ISS = InStr(BuscoSeparador, Mid(B$, IndiceDeFrase, 1)) ' "+-*/%^=' :;.,()HVBSCZK"
            'MsgBox(Mid(B$, IndiceDeFrase, 1))
            If ISS < 1 Then
                Continue For ' avanza el puntero
            Else
                UU% = 4 ' precision en la busqueda
            End If
            If InStr(IndiceDeFrase, B$, " '?'") = IndiceDeFrase Then 'funcion pregunta
                Temp = B$
                B$ = "0" + CamposdeBusqueda(P%(QQ))
                Pregunta() ' pregunta
                B$ = qb4.Left(Temp, IndiceDeFrase) + B$ + Mid(Temp, IndiceDeFrase + 4)
                L% = Len(B$)
                BB$ = B$
            End If
            If InStr(IndiceDeFrase, B$, " '") = IndiceDeFrase Then 'comienzo de clave
                FI = IndiceDeFrase + 2
                CL$(IndH) = Mid(B$, FI, InStr(FI, B$, "'") - FI) ' clave alfanumerica
                FLG%(IndH, 0) = InStr("<=>)", qb4.Left(CL$(IndH), 1)) 'menor igual mayor
                Z#(IndH) = QB.SafeToDouble(Mid(CL$(IndH), 2)) ' clave numerica
                IndiceDeFrase = IndiceDeFrase + Len(CL$(IndH)) + 2
                FLG%(IndH, 1) = P%(QQ) ' campo clave
                IndH = IndH + 1
                SCLAC% = 1
                SCMPC% = 0
                Continue For ' avanza el puntero
            End If
            If InStr(" NO | NI | SIN ", Mid(B$, IndiceDeFrase, UU%)) Then
                FLG%(IndH, 2) = 1 ' flag de exclusion
            ElseIf Mid(B$, IndiceDeFrase, 3) = " O " Then
                FLG%(IndH, 3) = 1 ' flag de inclusion
            End If
            If ISS <= 7 Then 'claves matematicas o de sustitucion
                R%(QQ + 1) = ISS
                G%(6) = 1
                If R%(QQ) < 1 Then R%(QQ) = 1
                ZZ#(QQ + 1) = QB.SafeToDouble(Mid(B$, IndiceDeFrase + 1))
                If ZZ#(QQ + 1) Then
                    QQ = QQ + 1
                    IndiceDeFrase = IndiceDeFrase + 2
                End If
                'rutina para sustitucion
                If ISS = 7 And ZZ#(QQ + 1) = 0 Then ' igual(=) y no numerica
                    If SCLAC% Then ' si antes una 'clave'
                        IndH = IndH - 1
                        ZZA$(QQ + 1) = CL$(IndH)
                        CL$(IndH) = ""
                        FLG%(IndH, 0) = 0
                        Z#(IndH) = 0
                        FLG%(IndH, 1) = 0
                        FLG%(IndH, 2) = 0
                        FLG%(IndH, 3) = 0
                        SCLA%(QQ + 1) = 1
                        SCLAC% = 0
                    ElseIf SCAMC% Then ' si antes un campo
                        SCAM%(QQ + 1) = P%(QQ)
                        SCAMC% = 0
                    End If
                Else
                    SCLAC% = 0
                    SCAMC% = 0
                End If
                'ElseIf ISS = 8 Then
                '    'subtotal
                '    SubtDeCampo(P%(QQ)) = 1 ' flag de subtotal
            End If
            'verifica campos + palabras claves
            Dim NroCampoInstruccion As Integer = 0
            For NroCampoInstruccion = 1 To CantidadCamposeInstruccionesaBuscar 'busca la palabra
                Uc% = UU%
                If NroCampoInstruccion = CantidadCampos + 1 Then
                    NroCampoInstruccion = CantidadCampos + 2 ' analiza palabras claves menos TOTAL
                End If
                Do
                    AAA$ = LTrim(Mid(B$, IndiceDeFrase + 1, Uc%))
                    If InStr(CamposdeBusqueda(NroCampoInstruccion), AAA$) And Len(AAA$) = Uc% Then
                        Uc% = Uc% + 1
                    Else
                        If Uc% > UU% Then
                            UU% = Uc%
                            Kx = NroCampoInstruccion
                        End If
                        Exit Do
                    End If
                Loop
            Next
            If Kx Then
                IndiceDeFrase = IndiceDeFrase + Uc% - 2
                NroCampoInstruccion = Kx
                Kx = 0
                If NroCampoInstruccion > CantidadCampos Then
                    GG% = NroCampoInstruccion - CantidadCampos
                    G%(GG%) = QQ + 1
                Else
                    QQ = QQ + 1
                    P%(QQ) = NroCampoInstruccion
                    SCAMC% = 1
                    SCLAC% = 0
                End If
            End If
            'WRITE G%(4): INPUT AAA
            ' 50565: - Etiqueta eliminada al usar Continue For
        Next

        HH = IndH - 1
        If QQ < 1 Then
            If IndH Then
                QQ = 1
                P%(QQ) = 1
            Else
                VUELTA% = 1
            End If
        End If
        G%(3) = 1 ' fuerzo impresion
        OrdenxCampo = P%(G%(2))
        FlgImpresion = G%(3)
        X7% = G%(4) + G%(5) + G%(6) 'total o promedio o claves matematicas o de sustitucion
        If X7% Then
            R%(X7% - G%(6)) = 1 'total o promedio
            QQ = QQ + 1
            P%(QQ) = CantidadCampos + 1
            AnchoDeCampo(CantidadCampos + 1) = Len(MascaraNumerica)
            TipoDeCampo(CantidadCampos + 1) = 1
        End If
        If X7% Then
            If G%(4) Then
                A2 = "Total ..."
            ElseIf G%(5) Then
                A2 = "Promedio."
            ElseIf InStr(B$, "=") Then
                A2 = "Cambio"
                X7% = 0
                QQ = QQ - 1
            ElseIf G%(6) Then
                A2 = CamposdeBusqueda(CantidadCampos + 1) ' ant 19
            End If
        End If
        For IndH = 1 To QQ
            IndiceDeFrase = P%(IndH)
            L% = AnchoDeCampo(IndiceDeFrase) - Len(CamposdeBusqueda(IndiceDeFrase))
            If L% < 0 Then
                L% = 0
            End If
            'LPRINT CamposdeBusqueda(IndiceDeFrase), L%, IndiceDeFrase
            Q%(IndH) = Len(AE) + 1
            AE = AE + Separador + CamposdeBusqueda(IndiceDeFrase) + Space(L%)
            AnchoDeColumna(IndH) = Len(CamposdeBusqueda(IndiceDeFrase) + Space(L%))
        Next
        '
        LargoLinea = Len(AE)
        ultimotab = LargoLinea + 1
        AE = AE + Separador
        'If FlgImpresion Then
        '    Print(Pxt, TAB(LargoLinea + 1), "|")
        'End If
        'If FlgExcell Then
        '    Print(Pxt, "")
        'End If
        T1% = LargoLinea - Len(MascaraNumerica) + 1
        FlagSubTotal = Math.Sign(G%(4)) And Not Math.Sign(OrdenxCampo - P%(1))
        FlgOrdenInverso = OrdenxCampo * InStr(B$, " INVER")  'flag de invertido
        FlgOrdenAlfa = OrdenxCampo * InStr(B$, " ALFAB") 'flag de orede creciente
        FlgOrdenNume = OrdenxCampo * InStr(B$, " NUMER") 'flag de orede creciente
        FlgSubrayado = InStr(B$, " SUBRA") 'FLAG de subrayado
        FlgEdicion = InStr(B$, " EDITA") 'FLAG de edicion
        'FlgExcell = InStr(B$, " LOTUS") 'FLAG de lotus
        OtraPantalla()
        Debug.Print(New String("*", LargoLinea) & Chr(24) & Chr(13) & LargoLinea & "Columnas")
        If LargoLinea > 80 Then
            Debug.Print("No entra en la Pantalla ...")
        Else
            LargoLinea = 80
        End If
        Debug.Print("Pediste:" & B$)
        Debug.Print("Entonces,")
        For IndH = 0 To HH
            If FLG%(IndH, 2) Then
                Debug.Print("Salteo ")
            Else
                Debug.Print("Busco ")
            End If
            Debug.Print(CamposdeBusqueda(FLG%(IndH, 1)) & " '" & CL$(IndH) & "'")
        Next
        If Len(A2) Then
            Debug.Print("Calculo " & A2)
        End If
        If OrdenxCampo Then
            Debug.Print("Ordenado por " & CamposdeBusqueda(OrdenxCampo))
            If FlgOrdenInverso Then
                Debug.Print(" (Inv)")
            Else
                Debug.Print("")
            End If
        End If
        Debug.Print("Sale por ")
        'If FlgExcell Then
        '    Debug.Print("Archivo")
        'ElseIf FlgImpresion Then
        '    Debug.Print("Impresora")
        'Else
        '    Debug.Print("Pantalla")
        'End If
    End Sub
    Sub Sigo()
        'fin de pantalla, o interupcion
        Do
            Debug.Print("Sigo")
            Call SiNo()
            If RR% <> 2 Then Exit Do
            'Correcion()
        Loop
        If RR% Then
            OtraPantalla()
        Else
            VUELTA% = 1
            ' otro informe
        End If
    End Sub

    Sub SiNo()
        ' si o no
        Debug.Print("..? (s/n) ")
        RR% = -1
        Do While RR% < 0
            Y# = 0
            RutinaInput()
            A = "S"
            If A$ = "N" Then
                RR% = 0
            ElseIf A$ = "S" Then
                RR% = 1
            ElseIf A$ = "E" And FlgEdicion = 1 Then
                RR% = 2
            End If
        Loop
    End Sub

    Sub RutinaInput()
        'rutina input
50310:
        'retorna ARRI%, B$, Y#        
        Y# = QB.SafeToDouble(B$)
        LC% = 0
    End Sub

    Sub GrabaArchivoListados()
        'graba archivo de listados
        
        If String.IsNullOrEmpty(ArchivodeInstrucciones) Then
            AppLogger.LogError("No se definió el archivo de instrucciones.")
            Return
        End If

        Try
            Using writer As New System.IO.StreamWriter(ArchivodeInstrucciones, False, System.Text.Encoding.Default)
                Info.CBox2.Items.Clear()
                
                ' Escribimos el número de instrucciones
                writer.WriteLine(NroInstruccionesArchivadas)
                
                For i As Integer = 1 To NroInstruccionesArchivadas
                    Dim instruccion As String = InstruccionesArchivadas(i).ToString().Trim()
                    writer.WriteLine("""" & instruccion & """") ' Formato compatible con Input/Read (envuelto en comillas)
                    Info.CBox2.Items.Add(instruccion)
                Next
            End Using
            
            AppLogger.LogOperation("Grabación de listados", "Archivo: {0}, Instrucciones: {1}", ArchivodeInstrucciones, NroInstruccionesArchivadas)

        Catch ex As Exception
            AppLogger.LogError("Error al grabar archivo de listados {0}: {1}", ArchivodeInstrucciones, ex.Message)
            MsgBox("Error al grabar listados: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Dim algo As Integer
    Sub PrintDeCampo()
50225:
        'MsgBox("PRINT TAB(" + T.ToString + "); " + A$ + ";") ' print y lprint de campo
        If porXML = -1 Then
            If IndiceCampo = 1 Then
                'Print(Pxp, TAB(1), "<fila>")
                algo = 0
                With XMLHess
                    .WriteStartElement("fila")
                End With
                With XMLHess
                    .WriteElementString("Bookmark", Arbtr(Ar).Vbtrv1.BtrievePosition)
                End With
            End If
        End If

        'If FlgImpresion Then
        '    Print(Pxt, TAB(T%), A$)
        'End If
        'If FlgExcell Then
        '    Print(Pxt, AL$)
        'End If

        If porXML = -1 Then
            If M% <= CantidadCampos Then
                ' *** escribo fila XML
                'Print(Pxp, TAB(1), "<" + NN(M) + ">")
                algo = algo + 1
                'Print(Pxp, TAB(1), "<DataColumn" + algo.ToString + ">")

                Dim ZZ As String = A.Replace("|", "")
                ZZ = ZZ.Replace(Chr(22), " ")
                Dim Temp As String = ZZ
                Dim strg1 As String = "&"
                Dim strg2 As String = "y" ' &amp;
                If InStr(Temp, strg1$) Then
                    For A As Integer = 1 To Len(Temp)
                        If Mid(Temp, A, 1) = strg1 Then
                            Mid(Temp, A, 1) = strg2
                        End If
                    Next
                End If
                ZZ = Temp
                'Print(Pxp, ZZ)
                'Print(Pxp, "</" + NN(M) + ">")
                ZZ = A
                'MsgBox(algo.ToString + ZZ)
                With XMLHess
                    .WriteElementString("DataColumn" + algo.ToString, ZZ)
                End With
                'Print(Pxp, "</DataColumn" + algo.ToString + ">")
                ' ***
            End If
        End If

        'If porXML = -1 Then
        '    If IndiceCampo = QQ Then
        '        ' *** fin fila XML
        '        Print(Pxp, TAB(1), "</fila>")
        '        ' ***
        '        With XMLHess
        '            .WriteEndElement()
        '        End With
        '    End If
        'End If
    End Sub

    Function REPLACE(ByVal Temp As String) As String
        'entra Temp
        'primero limpio espacios al principio y al final
        Temp = Trim(Temp)
        If Temp = "" Then
            Return Temp
            Exit Function
        End If

        'sustituyo espacios intermedios
        Dim strg1 As String = " "
        Dim strg2 As String = "_"
        If InStr(Temp, strg1) Then
            For a As Integer = 1 To Len(Temp)
                If Mid(Temp, a, 1) = strg1 Then
                    Mid(Temp, a, 1) = strg2
                End If
            Next
        End If
        For a As Integer = 1 To Len(Temp)
            If Asc(Mid(Temp, a, 1)) >= 58 And Asc(Mid(Temp, a, 1)) <= 64 Then
                Mid(Temp, a, 1) = "_"
            End If
            If Asc(Mid(Temp, a, 1)) >= 33 And Asc(Mid(Temp, a, 1)) <= 47 Then
                Mid(Temp, a, 1) = "_"
            End If
        Next
        'agrego caracter a ilegales
        If Asc(Mid(Temp, 1, 1)) >= 48 And Asc(Mid(Temp, 1, 1)) <= 57 Then
            Temp = "_" + Temp
        End If
        If Temp = "" Then
            Temp = "_"
        End If
        REPLACE = Temp
    End Function
   
End Module
Public Class EncodedStringWriter
    Inherits StringWriter

    'Private property setter
    Private _Encoding As Encoding

    '      ''<summary>Default constructor for the EncodedStringWriter class.</summary>
    '   ''<param name=“sb“>The formatted result to output.</param>
    '        ''<param name=“Encoding“>A member of the System.Text.Encoding class.</param>
    Public Sub New(ByVal sb As StringBuilder, ByVal Encoding As Encoding)
        MyBase.New(sb)
        _Encoding = Encoding
    End Sub

    '        ''<summary>Gets the Encoding in which the output is written.</summary>
    '  ''<param name=“Encoding“>The Encoding in which the output is written.</param>
    '       ''<remarks>This property is necessary for some XML scenarios where a header must be written containing the encoding used by the StringWriter. This allows the XML code to consume an arbitrary StringWriter and generate the correct XML header.</remarks>
    Public Overrides ReadOnly Property Encoding() As Encoding
        Get
            Return _Encoding
        End Get
    End Property

End Class

