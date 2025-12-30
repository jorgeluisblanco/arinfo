Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Xml
Imports System.IO
Public Class Info
    Dim ArchivoArc As String
    Dim Filenum As Integer
    Dim dsk As String
    Friend Ds As DataSet
    Friend x As Btr
    Friend Todo As String
    Friend P(50) As Integer
    Dim overwriteMode As Boolean
    Dim UltimaTeclaApretada As Integer
    Private Sub Info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' cultura para xfnd    
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.NumberDecimalSeparator = "."
        r.NumberFormat.NumberGroupSeparator = ""
        System.Threading.Thread.CurrentThread.CurrentCulture = r

        'ArchivoArc = UDisco + "\DEVICER.ARC"

        'Filenum = FreeFile()
        'FileClose(Filenum)
        'Try
        '    FileOpen(Filenum, ArchivoArc, OpenMode.Input, , OpenShare.Shared)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        'Finally

        'End Try
        'Input(Filenum, dsk)
        'FileClose(Filenum)

        dsk = UDisco + UDirectorio
        SkinEngine1.SkinFile = dsk + "\royale.ssk"
        SkinEngine1.SerialNumber = "rSPiC0oULL4nOhFbi2UktIfC2k5TZMT/5wPZQ1X+mCpQhq4i5bqTCQ=="
        SkinEngine1.Active = True

        'myXmlDataDocument = New XmlDataDocument()
        'ParseSchema(myLoadSchema)
        'DisplayTableStructure()
        ''myXmlDataDocument.Load(ARCHIVOXML)
        'DisplayTables(myXmlDataDocument.DataSet)
        'MsgBox("TERMINE")

        Dim x As BtrvoleproLib.BtrvOlePro

        Dim DDF As String = dsk
        Dim Ret As Short
        Dim NombreArchivo As String = "x$file"
        Cmbox.Sorted = True
        
        x = New BtrvoleproLib.BtrvOlePro
        x.DatabaseName = DDF
        x.RecordSource = NombreArchivo
        x.DisplayErrors = False
        x.OpenMode = BtrvoleproLib.BTRV_OPENMODES.btrOpenModeNormal
        Ret = x.Open
        Ret = x.MoveFirst
        Do While Ret = 0
            Dim NombredeArchivo As String = UCase(x.Field(1).ToString)
            If Mid(NombredeArchivo, 1, 2) <> "X$" Then
                Cmbox.Items.Add(NombredeArchivo)
            End If
            Ret = x.MoveNext
        Loop
        x.Close()

        Comienza()
    End Sub

    Private Const myLoadSchema As String = "E:\INFO1.xsd"
    Private myXmlDataDocument As XmlDataDocument


    ' Loads a specified schema into the DataSet
    Public Sub ParseSchema(ByVal schema As String)
        Dim myStreamReader As StreamReader = Nothing
        Try
            myStreamReader = New StreamReader(schema)
            Console.WriteLine("Reading Schema file ...")
            myXmlDataDocument.DataSet.ReadXmlSchema(myStreamReader)
        Catch e As Exception
            Console.WriteLine("Exception: " & e.ToString())
        Finally
            If Not myStreamReader Is Nothing Then
                myStreamReader.Close()
            End If
        End Try
    End Sub


    ' Displays the contents of the DataSet tables
    Private Sub DisplayTables(ByVal myDataset As DataSet)

        ' Navigate Dataset
        Console.WriteLine()
        Console.WriteLine("Content of Tables ...")

        Dim table As DataTable
        For Each table In myDataset.Tables

            Console.WriteLine("TableName = " & table.TableName.ToString())
            Console.WriteLine("---------")
            Console.WriteLine("Columns ...")

            Dim column As DataColumn
            For Each column In table.Columns

                Console.Write("{0,-22}", column.ColumnName.ToString())
            Next
            Console.WriteLine()
            Console.WriteLine("Number of rows = {0}", table.Rows.Count.ToString())
            Console.WriteLine("Rows ...")

            Dim row As DataRow
            For Each row In table.Rows

                Dim value As Object
                For Each value In row.ItemArray
                    Console.Write("{0,-22}", value.ToString())
                Next
                Console.WriteLine()
            Next
            Console.WriteLine()
        Next
    End Sub

    ' Displays the DataSet tables structure
    Private Sub DisplayTableStructure()
        Console.WriteLine()
        Console.WriteLine("Table structure")
        Console.WriteLine()
        Console.WriteLine("Tables count=" & myXmlDataDocument.DataSet.Tables.Count.ToString())

        Dim i, j As Integer

        For i = 0 To (myXmlDataDocument.DataSet.Tables.Count - 1)

            Console.WriteLine("TableName='" & myXmlDataDocument.DataSet.Tables(i).TableName & "'.")
            Console.WriteLine("Columns count=" & myXmlDataDocument.DataSet.Tables(i).Columns.Count.ToString())
           
            For j = 0 To (myXmlDataDocument.DataSet.Tables(i).Columns.Count - 1)
                Dim dc As DataColumn = myXmlDataDocument.DataSet.Tables(i).Columns(j)
                Dim props As System.Data.PropertyCollection = dc.ExtendedProperties
                Console.WriteLine(Strings.Chr(9) & "ColumnName='" & _
                                  myXmlDataDocument.DataSet.Tables(i).Columns(j).ColumnName & "', type = " & myXmlDataDocument.DataSet.Tables(i).Columns(j).DataType.ToString())
                For jj = 0 To props.Count - 1
                    Console.WriteLine(Strings.Chr(9) & "ColumnName='" & _
                                  myXmlDataDocument.DataSet.Tables(i).Columns(j).ColumnName & "   " & props.Keys(jj) & "   " & props.Values(jj))
                Next
                'Dim extended As DataColumn.ex
            Next
            Console.WriteLine()
        Next
    End Sub


    Sub Comienza()

        'Empresa = "Oficenter"
        'ArchivoArc = "H:\DEVICER.ARC"
        'Me.Text = Empresa + " - " + Me.Text

        'Filenum = FreeFile()
        'FileClose(Filenum)
        'Try
        '    FileOpen(Filenum, ArchivoArc, OpenMode.Input, , OpenShare.Shared)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        'Finally

        'End Try
        'Input(Filenum, DDF)
        'Input(Filenum, DBF)
        'FileClose(Filenum)
        dsk = UDisco + UDirectorio
        DDF = dsk
        DBF = dsk

        Disco = DBF
        UnidadDsk = Mid(DBF, 1, 2)
        BaseDatosDDF = Disco
        BaseDatos = Disco


        AppPath = Disco

        Me.KeyPreview = True

        With cbox1
            .Enabled = True 'if the listox is enable or disabled
            .Sorted = False ' rue ' if you want ti list sorted
            .BorderStyle = BorderStyle.Fixed3D ' the border style
            .Visible = True
            .ScrollAlwaysVisible = True 'presence of scroll all time
            .MultiColumn = False 'add a new column if number of items reach max height 
            .SelectionMode = SelectionMode.One
        End With
        With CBox2
            .Enabled = True 'if the listox is enable or disabled
            .Sorted = False ' rue ' if you want ti list sorted
            .BorderStyle = BorderStyle.Fixed3D ' the border style
            .Visible = True
            .ScrollAlwaysVisible = True 'presence of scroll all time
            .MultiColumn = False 'add a new column if number of items reach max height 
            .SelectionMode = SelectionMode.One
        End With
        'Mov = New Btr
        'With Mov
        '    .Tabla = "Client2"
        '    .DDF = Disco + "FILE.DDF"
        '    .Archivo = Disco & .Tabla
        '    .Cripto = "{"
        '    .AbreArchivos()
        'End With
        DSK1 = Disco
        'Cantar = 1
        'CA(1) = "Client2"
        'abre()
        Timer1.Interval = 1
        Timer1.Enabled = True
    End Sub


    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.F5
                e.Handled = True
                BtnEjecuta.PerformClick()
            Case Keys.F10
                e.Handled = True
                BtnFin.PerformClick()
            Case Else
        End Select
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Dim Msg As String = "Seguro que queres salir ...? ( S o N ) "
        Dim Title As String
        Dim Buttons As Integer
        Dim Ans As MsgBoxResult
        Title = "Fin de Programa"
        Buttons = MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2
        Ans = MsgBox(Msg, Buttons, Title)
        If Ans = MsgBoxResult.Yes Then
            Me.Close()
        ElseIf Ans = MsgBoxResult.No Then
        ElseIf Ans = MsgBoxResult.Cancel Then
        End If
    End Sub

  


    Private Sub BtnEjecuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEjecuta.Click
        If TextBox2.Text.Trim <> "" Then
            ARINFO(1, 1)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCarga.Click
        ARINFO(1, 0)
    End Sub

    Private Sub cbox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbox1.SelectedIndexChanged
        TextBox2.Text = TextBox2.Text + " " + cbox1.SelectedItem
        cbox1.SelectedItems.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGraba.Click
        GrabaArchivoListados()
    End Sub

    Private Sub CBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CBox2.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = CBox2.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                CBox2.Items.Remove(CBox2.Items(index))
            End If
        End If

        'CBox2.SelectedIndex = CBox2.IndexFromPoint(New Point(e.X, e.Y))
        'CBox2.Items(CBox2.SelectedIndex)

    End Sub

    Private Sub CBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBox2.SelectedIndexChanged
        TextBox2.Text = TextBox2.Text + " " + CBox2.SelectedItem
        CBox2.SelectedItems.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnArchivos.Click
        'MenuDeArchivos()
        Dim ArchivoElegido As String = Cmbox.SelectedItem
        If ArchivoElegido.Trim <> "" Then
            Dim Parchivo As New clsParametrosdeArchivo
            With Parchivo
                .Tabla = ArchivoElegido
                .DDF = Disco & "FILE.DDF"
                .Cripto = "{"
            End With
            Parchivo.Archivo = Disco & Parchivo.Tabla
            Dim iT As Integer = Archivos.Show(Parchivo)
        End If
    End Sub

    Private Sub BtnBorra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorra.Click
        TextBox2.Text = ""
    End Sub

    Private Sub BtnTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTodo.Click
        TextBox2.Text = Todo
    End Sub

    Sub inicializa()


        ResourceWinGrid()

        Dim Band As UltraGridBand = UltraGrid1.DisplayLayout.Bands(0)
        For i As Integer = 0 To Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            Band.Columns(i).PerformAutoResize(PerformAutoSizeType.VisibleRows)
        Next

        Band.Layout.UseFixedHeaders = True

        ' Enable the the filter row user interface by setting the FilterUIType to FilterRow.
        Band.Layout.Override.FilterUIType = FilterUIType.FilterRow

        ' FilterEvaluationTrigger specifies when UltraGrid applies the filter criteria typed 
        ' into a filter row. Default is OnCellValueChange which will cause the UltraGrid to
        ' re-filter the data as soon as the user modifies the value of a filter cell.
        Band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange

        ' By default UltraGrid displays user interface for selecting the filter operator. 
        ' You can set the FilterOperatorLocation to hide this user interface. This
        ' property is available on column as well so it can be controlled on a per column
        ' basis. Default is WithOperand. This property is exposed off the column as well.
        Band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand

        ' By default the UltraGrid uses StartsWith as the filter operator. You use
        ' the FilterOperatorDefaultValue property to specify a different filter operator
        ' to use. This is the default or the initial filter operator value of the cells
        ' in filter row. If filter operator user interface is enabled (FilterOperatorLocation
        ' is not set to None) then that ui will be initialized to the value of this
        ' property. The user can then change the operator as he/she chooses via the operator
        ' drop down.
        Band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith

        ' By default UltraGrid displays a clear button in each cell of the filter row
        ' as well as in the row selector of the filter row. When the user clicks this
        ' button the associated filter criteria is cleared. You can use the 
        ' FilterClearButtonLocation property to control if and where the filter clear
        ' buttons are displayed.
        Band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell

        ' Appearance of the filter row can be controlled using the FilterRowAppearance proeprty.
        Band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        ' You can use the FilterRowPrompt to display a prompt in the filter row. By default
        ' UltraGrid does not display any prompt in the filter row.
        Band.Layout.Override.FilterRowPrompt = "Clickee aqui para filtrar los datos..."

        ' You can use the FilterRowPromptAppearance to change the appearance of the prompt.
        ' By default the prompt is transparent and uses the same fore color as the filter row.
        ' You can make it non-transparent by setting the appearance' BackColorAlpha property 
        ' or by setting the BackColor to a desired value.
        Band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque


        ' Display a separator between the filter row other rows. SpecialRowSeparator property 
        ' can be used to display separators between various 'special' rows, including for the
        ' filter row. This property is a flagged enum property so it can take multiple values.
        Band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow

        ' You can control the appearance of the separator using the SpecialRowSeparatorAppearance
        ' property.
        Band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        ' ----------------------------------------------------------------------------------

        'Band.Columns("Bookmark").Hidden = True

        Band.Layout.Override.FixedHeaderAppearance.BackColor = Color.LightYellow
        Band.Layout.Override.FixedHeaderAppearance.ForeColor = Color.Green
        Band.Layout.Override.FixedCellAppearance.BackColor = Color.LightYellow
        Band.Layout.Bands(0).Layout.Override.FixedCellAppearance.ForeColor = Color.Green

        Band.Layout.Override.FixedCellSeparatorColor = Color.Green

    End Sub

    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'UltraGrid1.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        'e.Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        'e.Layout.Override.SelectTypeRow = SelectType.Single
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Hidden = True
        'inicializa()

        UltraGrid1.DisplayLayout.Override.AllowAddNew = DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Bands(0).Override.AllowAddNew = DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Bands(0).Override.AllowUpdate = DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
        ResourceWinGrid()
        e.Layout.AddNewBox.Hidden = True
        e.Layout.GroupByBox.Hidden = True
        UltraGrid1.DisplayLayout.Scrollbars = Scrollbars.None
        Me.UltraGrid1.DisplayLayout.Override.DefaultRowHeight = 25
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance.TextVAlign = VAlign.Middle
        UltraGrid1.UseOsThemes = DefaultableBoolean.False
        With e.Layout.Bands(0)
            .ColHeaderLines = 1
        End With
        UltraGrid1.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.None

    End Sub

    Private Sub UltraGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyDown
        ' Perform action needed to move cursor
        Select Case e.KeyValue
            Case Keys.Up
                Me.UltraGrid1.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Me.UltraGrid1.PerformAction(UltraGridAction.AboveCell, False, False)
                e.Handled = True
                Me.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.Down
                Me.UltraGrid1.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Me.UltraGrid1.PerformAction(UltraGridAction.BelowCell, False, False)
                e.Handled = True
                Me.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.Right, Keys.Enter
                Me.UltraGrid1.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Me.UltraGrid1.PerformAction(UltraGridAction.NextCellByTab, False, False)
                e.Handled = True
                Me.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.Left
                Me.UltraGrid1.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Me.UltraGrid1.PerformAction(UltraGridAction.PrevCellByTab, False, False)
                e.Handled = True
                Me.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode, False, False)
            Case Keys.F7
                Dim aRow As Infragistics.Win.UltraWinGrid.UltraGridRow = UltraGrid1.ActiveRow
                If aRow IsNot Nothing Then
                    'borra
                    Dim dt As DataTable = Ds.Tables(0)
                    Dim Fila As Integer = aRow.Cells(0).Row.Index
                    If Fila < dt.Rows.Count Then
                        Dim dtr As DataRow = dt.Rows(Fila)
                        If Trim(dt.Rows(Fila)("Bookmark").ToString()) <> "" Then
                            x.Vbtrv1.BtrievePosition = dt.Rows(Fila)("Bookmark")
                            x.Vbtrv1.Delete()
                        End If
                        dt.Rows.Remove(dtr)
                        aRow.Delete(False)
                    End If
                    aRow = UltraGrid1.ActiveRow
                    If aRow Is Nothing Then
                    Else
                        UltraGrid1.ActiveCell = UltraGrid1.ActiveRow.Cells(1)
                        UltraGrid1.PerformAction(EnterEditMode, False, False)
                    End If

                End If
        End Select
    End Sub

    Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress
        'para modo insersion
        If UltraGrid1.ActiveCell IsNot Nothing Then
            If overwriteMode And e.KeyChar >= ChrW(Keys.Space) Then
                If UltraGrid1.ActiveCell.IsInEditMode Then
                    If UltraGrid1.ActiveCell.SelLength = 0 Then
                        UltraGrid1.ActiveCell.SelLength = 1
                    End If
                End If
            End If
            'Dim _utext As String = UltraGrid1.ActiveCell.Text
            'Dim Indice As Integer = Me.UltraGrid1.ActiveCell.Column.Index
            'Dim Columna As DataColumn = Ds.Tables(0).Columns(Indice)
            'Select Case Columna.ExtendedProperties("Tipo")
            '    Case 2
            '        If ((Char.IsDigit(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) <> True)) Then
            '            e.Handled = True
            '        End If
            '    Case 1
            '        If Columna.ExtendedProperties("Decimales") = 0 Then
            '            If ((Char.IsDigit(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) <> True) And (e.KeyChar <> "-"c)) Then
            '                e.Handled = True
            '            End If
            '            If ((_utext <> String.Empty) And (e.KeyChar = "-"c)) Then
            '                e.Handled = True
            '            End If
            '        Else
            '            If ((Char.IsDigit(e.KeyChar) = False) And (Char.IsControl(e.KeyChar) <> True) And (e.KeyChar <> "."c) And (e.KeyChar <> "-"c)) Then
            '                e.Handled = True
            '            End If
            '            'If ((_utext.Contains("."c) = True) And (e.KeyChar = "."c)) Then
            '            '    e.Handled = True
            '            'End If
            '            'If ((_utext = String.Empty) And (e.KeyChar = "."c)) Then
            '            '    e.Handled = True
            '            'End If
            '            If ((_utext <> String.Empty) And (e.KeyChar = "-"c)) Then
            '                e.Handled = True
            '            End If
            '        End If
            '    Case 0
            '        'If ((Char.IsLetterOrDigit(e.KeyChar) = False) And ((e.KeyChar <> Chr(32))) And (Char.IsControl(e.KeyChar) <> True)) Then
            '        '    e.Handled = True
            '        'End If
            'End Select
        End If
    End Sub

    Private Sub UltraGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseUp
        ' declare objects to get value from cell and display
        Dim mouseupUIElement As Infragistics.Win.UIElement
        Dim mouseupCell As Infragistics.Win.UltraWinGrid.UltraGridCell
        UltimaTeclaApretada = Keys.Up
        ' retrieve the UIElement from the location of the MouseUp
        mouseupUIElement = UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        If Not mouseupUIElement Is Nothing Then
            ' retrieve the Cell from the UIElement
            mouseupCell = mouseupUIElement.GetContext(GetType(Infragistics.Win.UltraWinGrid.UltraGridCell))
            If Not mouseupCell Is Nothing Then
                If mouseupCell.IsActiveCell Then
                    UltraGrid1.ActiveCell = mouseupCell
                    'UltraGrid1.ActiveCell.SelectAll()
                    UltraGrid1.PerformAction(EnterEditMode, False, False)
                End If
            End If
        End If
    End Sub

    Private Sub UltraGrid1_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterExitEditMode
        'Dim Indice As Integer = Me.UltraGrid1.ActiveCell.Column.Index
        'Dim Columna As DataColumn = Ds.Tables(0).Columns(Indice)
        'If Columna.ExtendedProperties("Tipo") = 1 Then
        '    UltraGrid1.ActiveCell.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'End If
    End Sub

    Private Sub UBupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualiza.Click
        UpdateRengprAdapter()
    End Sub

    '       With Ultragrid1
    '           .Focus()
    '           If Not .ActiveCell Is Nothing Then
    '               .ActiveCell = .Rows(0).Cells(0)
    '               .PerformAction(UltraGridAction.EnterEditMode, False, False)
    '           End If
    '       End With

    Public Sub UpdateRengprAdapter()
        Dim Clav As String = ""
        Dim rc As Integer = 0
        If Not Ds.HasChanges Then
            Exit Sub
        End If
        Dim dt As DataTable = Ds.Tables(0).GetChanges(DataRowState.Added Or DataRowState.Modified)
        If Not dt Is Nothing Then
            Dim rowcount As Integer = dt.Rows.Count
            For i As Integer = 0 To dt.Rows.Count - 1
                Debug.Print(dt.Rows(i)("Bookmark").ToString())
                x.Vbtrv1.BtrievePosition = dt.Rows(i)("Bookmark")
                x.Vbtrv1.Edit()
                For j As Integer = 1 To dt.Columns.Count - 1
                    x.Vbtrv1.Field(P(j) - 1) = dt.Rows(i)((j)).ToString()
                    Debug.Print(x.Vbtrv1.Field(P(j) - 1).ToString)
                    Debug.Print(dt.Rows(i)((j)).ToString())
                Next
                rc = x.Vbtrv1.Update
            Next
            dt.AcceptChanges()
        End If
    End Sub

    Private Sub UltraGrid1_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterCellActivate
        If UltraGrid1.ActiveCell IsNot Nothing Then
            If Not UltraGrid1.ActiveCell Is Nothing AndAlso Not UltraGrid1.ActiveCell.IsInEditMode AndAlso UltraGrid1.ActiveCell.CanEnterEditMode Then
                UltraGrid1.PerformAction(UltraGridAction.EnterEditMode)
            End If
            Dim editor As EmbeddableEditorBase = Me.UltraGrid1.ActiveCell.EditorResolved
            If UltraGrid1.ActiveCell.IsInEditMode Then
                editor.SelectionStart = 0
                editor.SelectionLength = 0
            End If
            overwriteMode = True
            'Dim Indice As Integer = Me.UltraGrid1.ActiveCell.Column.Index
            'Dim Columna As DataColumn = Ds.Tables(0).Columns(Indice)
            'If Columna.ExtendedProperties("Tipo") = 1 Then
            '    UltraGrid1.ActiveCell.Value = UltraGrid1.ActiveCell.Text.Trim
            '    UltraGrid1.ActiveCell.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            'End If
        End If
    End Sub




    Private Sub ResourceWinGrid()
        Dim rc As Infragistics.Shared.ResourceCustomizer
        rc = Infragistics.Win.UltraWinGrid.Resources.Customizer
        'rc.SetCustomizedString("Resource", "String Name Default Value")
        rc.SetCustomizedString("AccessibleActionPush", "Push")
        rc.SetCustomizedString("AccessibleName_AddNewBoxArea", "AddNew Area")
        rc.SetCustomizedString("AccessibleName_AddRow", "Add Row")
        rc.SetCustomizedString("AccessibleName_Caption", "Caption")
        rc.SetCustomizedString("AccessibleName_ChildBands", "Child Rows")
        rc.SetCustomizedString("AccessibleName_ColumnHeaders", "Column Headers")
        rc.SetCustomizedString("AccessibleName_DataArea", "Data Area")
        rc.SetCustomizedString("AccessibleName_FilterRow", "Filter Row")
        rc.SetCustomizedString("AccessibleName_GroupByBox", "GroupBy Box")
        rc.SetCustomizedString("AccessibleName_Row", "{0} row {1}")
        rc.SetCustomizedString("AccessibleName_RowColRegion", "Scrolling Region")
        rc.SetCustomizedString("AccessibleName_TemplateAddRow", "Template Add Row")
        rc.SetCustomizedString("AddNewBoxDefaultPrompt", "Add ...")
        rc.SetCustomizedString("AllRowsFilteredOut", "0 Items.")
        rc.SetCustomizedString("ColumnChooserButtonToolTip", "Click here to show Field Chooser.")
        rc.SetCustomizedString("ColumnChooserDialogCaption", "Field Chooser")
        rc.SetCustomizedString("ColumnsUITypeEditorList_None_Entry", "None")
        rc.SetCustomizedString("DataErrorCellUpdateDateNotInMinMaxRange", "Illegal Data Value: Specified date value does not fall within MinDate and MaxDate constraints")
        rc.SetCustomizedString("DataErrorCellUpdateEmptyValueNotAllowed", "Empty cell value not allowed in column {0}.")
        rc.SetCustomizedString("DataErrorCellUpdateInvalidDataValue", "Illegal data value")
        rc.SetCustomizedString("DataErrorCellUpdateInvalidDateFormat", "Illegal Date Format")
        rc.SetCustomizedString("DataErrorCellUpdateUnableToConvert", "Unable to convert from '{0}' to '{1}'")
        rc.SetCustomizedString("DataErrorCellUpdateUnableToUpdateValue", "Unable to update the data value: {0}")
        rc.SetCustomizedString("DataErrorDeleteRowUnableToDelete", "Unable to delete the row: {0}")
        rc.SetCustomizedString("DataErrorMessageTitle", "Data Error")
        rc.SetCustomizedString("DataErrorRowAddMessage", "Unable to add a row: {0}")
        rc.SetCustomizedString("DataErrorRowUpdateUnableToUpdateRow", "Unable to update the row: {0}")
        rc.SetCustomizedString("DefaultAction_Cell", "Activate")
        rc.SetCustomizedString("DefaultAction_Cell_Editable", "Edit")
        rc.SetCustomizedString("DefaultAction_Collapse", "Collapse")
        rc.SetCustomizedString("DefaultAction_Expand", "Expand")
        rc.SetCustomizedString("DefaultAction_Row", "Activate")
        rc.SetCustomizedString("DefaultAction_RowColRegion", "Activate")
        rc.SetCustomizedString("DefaultAction_SortColumn", "Sort")
        rc.SetCustomizedString("DeleteMultipleRowsPrompt", "You have selected {0} rows for deletion. Choose Yes to delete the rows or No to exit.")
        rc.SetCustomizedString("DeleteRowsMessageTitle", "Delete Rows")
        rc.SetCustomizedString("DeleteSingleRowMessageTitle", "Delete Row")
        rc.SetCustomizedString("DeleteSingleRowPrompt", "You have selected 1 row for deletion. Choose Yes to delete the row or No to exit.")
        rc.SetCustomizedString("ErrMSgEditorValNotValid", "Value in the editor is not valid.")
        rc.SetCustomizedString("Error_Cell_ReadOnly", "'{0}' cell is read-only.")
        rc.SetCustomizedString("FilterClearButtonToolTip_FilterCell", "Click here to clear filter criteria for {0}.")
        rc.SetCustomizedString("FilterClearButtonToolTip_RowSelector", "Click here to clear all filter criteria.")
        rc.SetCustomizedString("FilterDialogAddConditionButtonText", "&Add a conditio&n")
        rc.SetCustomizedString("FilterDialogAndRadioText", "And conditions")
        rc.SetCustomizedString("FilterDialogCancelButtonText", "&Cancel")
        rc.SetCustomizedString("FilterDialogDeleteButtonText", "Delete Condition")
        rc.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "N&o filters")
        rc.SetCustomizedString("FilterDialogOkButtonText", "&OK")
        rc.SetCustomizedString("FilterDialogOrRadioText", "Or conditions")
        rc.SetCustomizedString("FixedHeaders_FixHeaderSwapItem", "[Fix Header]")
        rc.SetCustomizedString("FixedHeaders_UnfixAllHeadersSwapItem", "[Unfix All Headers]")
        rc.SetCustomizedString("FixedHeaders_UnfixHeaderSwapItem", "[Unfix Header]")
        rc.SetCustomizedString("GroupByBoxDefaultPrompt", "Arrastra un encabezado para agrupar por esa columna ...")
        rc.SetCustomizedString("GroupByBoxDefaultPromptMultiBandCardView", "Drag a column header or card label here to group by that column.")
        rc.SetCustomizedString("GroupByBoxDefaultPromptSingleBandCardView", "Drag a card label here to group by that column.")
        rc.SetCustomizedString("GroupByButtonToolTip", "Click to toggle sort direction")
        rc.SetCustomizedString("LDR_Column_AllowRowFiltering", "Indicates whether row filtering is allowed on the column. Setting this to a non-default value will override settings on band's and layout's override objects.")
        rc.SetCustomizedString("LDR_Column_AllowRowSummaries", "Indicates whether summaries are allowed on this column. Setting this to a non-default value will override any settings on band's and layout's override objects.")
        rc.SetCustomizedString("LDR_Column_P_UseEditorMaskSettings", "Specifies whether to use the editor's mask related settings instead of column's mask related settings.")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Add", "&Add")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Cancel", "Cancel")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Members", "&Members")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_OK", "OK")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Properties", "&Properties")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Remove", "&Remove")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Reset", "Reset")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_ShowDescription", "Show Description")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_ShowToolBar", "Show ToolBar")
        rc.SetCustomizedString("LDR_ColumnEditorDialog_Title", "Columns Collection Editor")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_CellAppearance", "Appearance applied to cells of empty rows.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_EmptyAreaAppearance", "Appearance applied to cells of empty rows.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_RowAppearance", "Appearance applied to empty rows.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_RowSelectorAppearance", "Appearance applied to row selectors of empty rows.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_RowSelectors", "Specifies whether the row selectors of empty rows are displayed.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_ShowEmptyRows", "Specifies whether to fill the empty area after the last row with empty rows.")
        rc.SetCustomizedString("LDR_EmptyRowSettings_P_Style", "Specifies how the empty rows are displayed.")
        rc.SetCustomizedString("LDR_FilterDropDownButtonImage", "Filter drop-down button image shown on the column headers with row filtering enabled.")
        rc.SetCustomizedString("LDR_FilterDropDownButtonImageActive", "Filter drop-down button image shown on the column headers with row filtering enabled and has active row filters.")
        rc.SetCustomizedString("LDR_FixedHeaderOffImage", "The image that's used to draw the fixed header indicator when the header is not fixed.")
        rc.SetCustomizedString("LDR_FixedHeaderOnImage", "The image that's used to draw the fixed header indicator when the header is fixed.")
        rc.SetCustomizedString("LDR_FixedRowOffImage", "The image that's used to draw the fixed row indicator when the row is not fixed.")
        rc.SetCustomizedString("LDR_FixedRowOnImage", "The image that's used to draw the fixed row indicator when the row is fixed.")
        rc.SetCustomizedString("LDR_Groups_AddViaCustomProps", "(add via 'Custom Property Pages')")
        rc.SetCustomizedString("LDR_Layout_mask", "[caption] : [value] ([count] [count,items,item,items])")
        rc.SetCustomizedString("LDR_Override_P_AllowRowLayoutCellSizing", "Whether the user is allowed to resize the cells in row-layout mode.")
        rc.SetCustomizedString("LDR_Override_P_AllowRowLayoutLabelSizing", "Whether the user is allowed to resize the labels in row-layout mode.")
        rc.SetCustomizedString("LDR_Override_P_BorderStyleRowSelector", "Border style of row selectors.")
        rc.SetCustomizedString("LDR_Override_P_RowSelectorWidth", "Width of the row selectors.")
        rc.SetCustomizedString("LDR_RowLayout_P_ColumnInfos", "Contains row-layout info objects for all the columns.")
        rc.SetCustomizedString("LDR_RowLayout_P_RowLayoutLabelPosition", "Specifies where the column labels are displayed.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_AllowCellSizing", "Whether the user is allowed to resize the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_AllowLabelSizing", "Whether the user is allowed to resize the label.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_CellInsets", "Specifies the insets around the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_Column", "Returns the associated column.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_LabelInsets", "Specifies the insets around the label.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_LabelPosition", "Specifies where the label is displayed.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_MinimumCellSize", "Minimum size of the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_MinimumLabelSize", "Minimum size of the label.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_OriginX", "Horizontal coordinate in the row layout.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_OriginY", "Vartical coordinate in the row layout.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_PreferredCellSize", "Preferred size of the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_PreferredLabelSize", "Preferred size of the label.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_SpanX", "Horizontal span of the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_SpanY", "Vertical span of the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_WeightX", "Horizontal weight of the cell.")
        rc.SetCustomizedString("LDR_RowLayoutColumnInfo_P_WeightY", "Vertical weight of the cell.")
        rc.SetCustomizedString("LDR_SelectSummaries", "Select Summaries")
        rc.SetCustomizedString("LDR_SummaryButtonImage", "Summary button image shown on the column headers with summaries enabled.")
        rc.SetCustomizedString("LDR_SummarySettings_P_ShowCalculatingText", "Specifies whether a '#Calculating' message is shown in summaries that are calculating with an UltraCalcManager Component.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterBandHiddenChanged", "Occurs after the user hides a band via the column chooser dialog.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterCardCompressedStateChanged", "Occurs after a Card Row is Expanded or Compressed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterCardsScroll", "Occurs when user scrolls card area.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterPerformAction", "Event fired after a key action is performed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterRowFilterChanged", "fired after the user has modified row filters for a column.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterRowLayoutItemResized", "Gets fired after the user resizes a header or a cell in the Row-Layout mode.")
        rc.SetCustomizedString("LDR_UltraGrid_E_AfterSummaryDialog", "Occurs after summary rows dialog is closed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeBandHiddenChanged", "Occurs when the user hides a band via the column chooser dialog.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeCardCompressedStateChanged", "Occurs before a Card Row is Expanded or Compressed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeDisplayDataErrorTooltip", "Fired before the data error tooltip is displayed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeMultiCellOperation", "Occurs before the user performs a multi-cell operation.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforePerformAction", "Event fired before a key action is about to be performed.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeRowFilterChanged", "Fired when the user modifies row filters for a column.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeRowFilterDropDownPopulate", "Fired before the filter drop down is populated by the UltraGrid.")
        rc.SetCustomizedString("LDR_UltraGrid_E_BeforeRowLayoutItemResized", "Gets fired when the user resizes a header or a cell in the Row-Layout mode.")
        rc.SetCustomizedString("LDR_UltraGrid_E_InitializeTemplateAddRow", "Occurs when a template add-row is initialized.")
        rc.SetCustomizedString("LDR_UltraGrid_P_ExitEditModeOnLeave", "Indicates whether grid will exit edit mode when left.")
        rc.SetCustomizedString("LDR_UltraGridBand_P_RowLayoutLabelPosition", "Specifies where the column labels are displayed.")
        rc.SetCustomizedString("LDR_UltraGridBand_P_RowLayouts", "Collection of row-layouts.")
        rc.SetCustomizedString("LDR_UltraGridBand_P_UseRowLayout", "Enables row-layout functionality.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_ColumnChooserCaption", "Caption displayed in the column chooser.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_ExcludeFromColumnChooser", "Specifies whether to exclude the column from the column chooser.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_IgnoreMultiCellOperation", "Specifies whether to ignore multi-cell operations on cells of this column.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_ShowCalculatingText", "Specifies whether a '#Calculating' message is shown in cells that are calculating with an UltraCalcManager Component.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_ShowInkButton", "Specifies whether ink editor buttons get shown in cells.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_SpellChecker", "Gets/sets the component that will perform spell checking for cells of this column.")
        rc.SetCustomizedString("LDR_UltraGridColumn_P_TabIndex", "Specifies the order in which cells are tabbed.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_ClipboardCellDelimiter", "Specifies the cell value delimiter when copying to the clipboard.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_ClipboardCellSeparator", "Specifies the cell value separator when copying to the clipboard.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_ClipboardRowSeparator", "Specifies the logical row separator when copying to the clipboard.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_ColumnChooserEnabled", "Provides a hint to the UltraGrid that the column chooser user interface is enabled.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_EmptyRowSettings", "Contains properties for the Empty Rows functionality.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_LoadStyle", "Indicates whether to pre-load rows or load rows as they are needed.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_NewBandLoadStyle", "Specifies how to load new bands in data source.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_NewColumnLoadStyle", "Specifies how to load new columns in data source.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_ScrollBounds", "Specifies whether to stop scrolling further down once the last row becomes visible.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_SplitterBarHorizontalAppearance", "Determines the appearance of horizontal splitter bar and the split box.")
        rc.SetCustomizedString("LDR_UltraGridLayout_P_SplitterBarVerticalAppearance", "Determines the appearance of vertical splitter bar and the split box.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_AddRowAppearance", "Determines the appearance of add-rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_AddRowCellAppearance", "Determines the appearance of cells of add-rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_AllowMultiCellOperations", "Specifies if and which of the multi-cell operations the user is allowed to perform.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_DataErrorCellAppearance", "Determines the appearance of cells with data error (as indicated by IDataErrorInfo).")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_DataErrorRowAppearance", "Determines the appearance of rows with data error (as indicated by IDataErrorInfo).")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_DataErrorRowSelectorAppearance", "Determines the appearance of row selectors of rows with data error (as indicated by IDataErrorInfo).")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterCellAppearance", "Determines the appearance of cells in filter row.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterCellAppearanceActive", "Determines the appearance of cells in filter row that have active filters.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterClearButtonAppearance", "Determines the appearance of clear filter buttons in filter row.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilteredInCellAppearance", "Determines the appearance of cells of filtered in rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilteredInRowAppearance", "Determines the appearance of filtered in rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilteredOutCellAppearance", "Determines the appearance of cells of filtered out rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilteredOutRowAppearance", "Determines the appearance of filtered out rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterOperatorAppearance", "Determines the appearance of operator indicators in filter row.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterRowAppearance", "Determines the appearance of filter rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterRowAppearanceActive", "Determines the appearance of filter rows that have active filters.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterRowPromptAppearance", "Determines the appearance of the prompt in filter row.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FilterRowSelectorAppearance", "Determines the appearance of the row selectors of filter rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedCellAppearance", "Determines the appearance of cells associated with headers that are fixed.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedCellSeparatorColor", "The color of the separator line that separates the fixed header cells and non-fixed header cells.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedHeaderAppearance", "Determines the appearance of headers that are fixed.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedHeaderIndicator", "Specifies whether the user is allowed to fix or unfix headers.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedRowAppearance", "Determines the appearance of fixed rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedRowCellAppearance", "Determines the appearance of cells of fixed rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FixedRowSelectorAppearance", "Determines the appearance of row selectors of fixed rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_FormulaErrorAppearance", "Determines the appearance of cells with formula errors.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_GroupBySummaryValueAppearance", "Determines the appearance of summaries in group-by rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HeaderPlacement", "Specifies if and how headers are displayed.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HotTrackCellAppearance", "Appearance applied to the cell that's currently being hot-tracked.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HotTrackHeaderAppearance", "Appearance applied to the header that's currently being hot-tracked.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HotTrackRowAppearance", "Appearance applied to the row that's currently being hot-tracked.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HotTrackRowCellAppearance", "Appearance applied to the cells of the row that's currently being hot-tracked.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_HotTrackRowSelectorAppearance", "Appearance applied to the row selector of the row that's currently being hot-tracked.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_InvalidValueBehavior", "Specifies the behavior when the user attempts to leave a cell after entering an invalid value.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MergedCellAppearance", "Determines the appearance of merged cells.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MergedCellContentArea", "Specifies whether to position the contents of a merged cell in the visible area of the merged cell or the virtual area of the merged cell.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MergedCellEvaluationType", "Specifies whether to merge cells based on their values or display text.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MergedCellStyle", "Specifies how cell merging is performed.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MinRowHeight", "Specifies the minimum row height.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_MultiCellSelectionMode", "Specifies how multiple cells are range selected using mouse and keyboard.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_RowFilterAction", "Specifies the action to take on filtered out rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_RowLayoutCellNavigationVertical", "Specifies how cells are navigated when using up and down arrow keys.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_ShowCalculatingText", "Specifies whether a '#Calculating' message is shown in cells or summaries that are calculating with an UltraCalcManager Component.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_ShowInkButton", "Specifies whether ink editor buttons get shown in cells.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_SpecialRowSeparatorAppearance", "Determines the appearance of special row separator elements.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_SupportDataErrorInfo", "Whether to make use of IDataErrorInfo to display data error icons.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_TemplateAddRowAppearance", "Determines the appearance of template add-rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_TemplateAddRowCellAppearance", "Determines the appearance of cells of template add-rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_TemplateAddRowPromptAppearance", "Determines the appearance of prompts in template add-rows.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_TemplateAddRowSpacingAfter", "The amount of spacing (in pixels) rendered before a template add-row.")
        rc.SetCustomizedString("LDR_UltraGridOverride_P_TemplateAddRowSpacingBefore", "The amount of spacing (in pixels) rendered after a template add-row.")
        rc.SetCustomizedString("LDR_UseFixedHeaders", "Enables the fixed headers functionality.")
        rc.SetCustomizedString("MultiCell_Copy_Error_MsgBox_Message", "Error performing Copy operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Copy_Error_MsgBox_Title", "Copy Error")
        rc.SetCustomizedString("MultiCell_Cut_Error_MsgBox_Message", "Error performing Cut operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Cut_Error_MsgBox_Title", "Cut Error")
        rc.SetCustomizedString("MultiCell_Delete_Error_MsgBox_Message", "Error performing Delete operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Delete_Error_MsgBox_Title", "Delete Error")
        rc.SetCustomizedString("MultiCell_Paste_Error_MsgBox_Message", "Error performing Paste operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Paste_Error_MsgBox_Title", "Paste Error")
        rc.SetCustomizedString("MultiCell_Paste_Error_TooManyColumns", "Contents being pasted have more columns than what's available starting from the anchor cell. Paste contents have {0} columns where as the available columns starting from the anchor cell are {1}.")
        rc.SetCustomizedString("MultiCell_Paste_Error_TooManyRows", "Contents being pasted have more rows than what's available starting from the anchor cell. Paste contents have {0} rows where as the available rows starting from the anchor cell are {1}.")
        rc.SetCustomizedString("MultiCell_Redo_Error_MsgBox_Message", "Error performing redo operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Redo_Error_MsgBox_Title", "Redo Error")
        rc.SetCustomizedString("MultiCell_Undo_Error_MsgBox_Message", "Error performing Undo operation. {0} {1}")
        rc.SetCustomizedString("MultiCell_Undo_Error_MsgBox_Title", "Undo Error")
        rc.SetCustomizedString("MultiCellOperation_Error_ConversionError", "Unable to convert the value '{0}' to the column's data type: {1}")
        rc.SetCustomizedString("MultiCellOperation_Error_CrossParentSelection", "The operation can not be performed on cross-parent selection.")
        rc.SetCustomizedString("MultiCellOperation_Error_MsgBox_ContinueQuestion", "Continue with the remaining cells?")
        rc.SetCustomizedString("MultiCellOperation_Error_MsgBox_FurtherInformation", "Further information: {0}")
        rc.SetCustomizedString("MultiCellOperation_Error_NoCellsSelected", "No cells are selected.")
        rc.SetCustomizedString("MultiCellOperation_Error_NonRectangularSelection", "Invalid selection. The selection must be rectangular.")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_BeyondNextMonth", "Beyond Next Month")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_DayOfWeekFormatString", "{0:dddd}")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_EarlierThisMonth", "Earlier this Month")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_LastMonth", "Last Month")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_LastWeek", "Last Week")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_LaterThisMonth", "Later this Month")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_NextMonth", "Next Month")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_NextWeek", "Next Week")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_None", "None")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_Older", "Older")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_ThreeWeeksAgo", "Three Weeks Ago")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_ThreeWeeksAway", "Three Weeks Away")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_Today", "Today")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_TwoWeeksAgo", "Two Weeks Ago")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_TwoWeeksAway", "Two Weeks Away")
        rc.SetCustomizedString("Outlook_GroupByMode_Description_Yesterday", "Yesterday")
        rc.SetCustomizedString("PropertyPageCaptionGroupsAndColumns", "Groups And Columns")
        rc.SetCustomizedString("RowFilterDialogBlanksItem", "(Blanks)")
        rc.SetCustomizedString("RowFilterDialogDBNullItem", "(DBNull)")
        rc.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Empty Text)")
        rc.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "Operand")
        rc.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operator")
        rc.SetCustomizedString("RowFilterDialogTitlePrefix", "Ingresa el Criterio del Filtro ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_Contains", "Contiene ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "No Contiene ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "No Termina con ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "No es Igual")
        rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "No Comienza con ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Termina con ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_Equals", "=")
        rc.SetCustomizedString("RowFilterDropDown_Operator_GreaterThan", ">")
        rc.SetCustomizedString("RowFilterDropDown_Operator_GreaterThanOrEqualTo", ">=")
        rc.SetCustomizedString("RowFilterDropDown_Operator_LessThan", "<")
        rc.SetCustomizedString("RowFilterDropDown_Operator_LessThanOrEqualTo", "<=")
        rc.SetCustomizedString("RowFilterDropDown_Operator_Like", "Igual a ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_Match", "Igual")
        rc.SetCustomizedString("RowFilterDropDown_Operator_NotEquals", "!=")
        rc.SetCustomizedString("RowFilterDropDown_Operator_NotLike", "No Igual a ...")
        rc.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Comienza con ...")
        rc.SetCustomizedString("RowFilterDropDownAllItem", "(Todos)")
        rc.SetCustomizedString("RowFilterDropDownBlanksItem", "(Blanks)")
        rc.SetCustomizedString("RowFilterDropDownCustomItem", "(Custom)")
        rc.SetCustomizedString("RowFilterDropDownEquals", "Igual a ...")
        rc.SetCustomizedString("RowFilterDropDownGreaterThan", "Mayor a ...")
        rc.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Mayor o Igual a ...")
        rc.SetCustomizedString("RowFilterDropDownLessThan", "Menor a ...")
        rc.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor o Igual a ...")
        rc.SetCustomizedString("RowFilterDropDownLike", "Parecido a")
        rc.SetCustomizedString("RowFilterDropDownMatch", "Matches Regular Expression")
        rc.SetCustomizedString("RowFilterDropDownNonBlanksItem", "(NonBlanks)")
        rc.SetCustomizedString("RowFilterDropDownNotEquals", "No Igual a ...")
        rc.SetCustomizedString("RowFilterLogicalOperator_And", " y ")
        rc.SetCustomizedString("RowFilterLogicalOperator_Or", " o ")
        rc.SetCustomizedString("RowFilterPatternCaption", "Invalid search pattern")
        rc.SetCustomizedString("RowFilterPatternError", "Error parsing pattern {0}. Please enter a valid search pattern.")
        rc.SetCustomizedString("RowFilterPatternException", "Invalid search pattern {0}.")
        rc.SetCustomizedString("RowFilterRegexError", "Error parsing regular expression {0}. Please enter a valid regular expression.")
        rc.SetCustomizedString("RowFilterRegexErrorCaption", "Invalid regular expression")
        rc.SetCustomizedString("RowFilterRegexException", "Invalid regular expression {0}.")
        rc.SetCustomizedString("SummaryDialog_Button_Cancel", "&Cancel")
        rc.SetCustomizedString("SummaryDialog_Button_OK", "&OK")
        rc.SetCustomizedString("SummaryDialogAverage", "Average")
        rc.SetCustomizedString("SummaryDialogCount", "Count")
        rc.SetCustomizedString("SummaryDialogMaximum", "Maximum")
        rc.SetCustomizedString("SummaryDialogMinimum", "Minimum")
        rc.SetCustomizedString("SummaryDialogNone", "None")
        rc.SetCustomizedString("SummaryDialogSum", "Sum")
        rc.SetCustomizedString("SummaryFooterCaption_ChildBandNonGroupByRows", "Summaries for [BANDHEADER]: [SCROLLTIPFIELD]")
        rc.SetCustomizedString("SummaryFooterCaption_GroupByChildRows", "Summaries for [GROUPBYROWVALUE]")
        rc.SetCustomizedString("SummaryFooterCaption_RootRows", "Grand Summaries")
        rc.SetCustomizedString("SummaryTypeAverage", "Average")
        rc.SetCustomizedString("SummaryTypeCount", "Count")
        rc.SetCustomizedString("SummaryTypeCustom", "Custom")
        rc.SetCustomizedString("SummaryTypeMaximum", "Maximum")
        rc.SetCustomizedString("SummaryTypeMinimum", "Minimum")
        rc.SetCustomizedString("SummaryTypeSum", "Sum")
        rc.SetCustomizedString("SummaryValueInvalidDisplayFormat", "Invalid DisplayFormat: {0}. More info: {1}")
    End Sub

    Private Sub Cmbox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbox.SelectedIndexChanged
        Dim ArchivoElegido As String = Cmbox.SelectedItem
        Ejecuta(ArchivoElegido)
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Dim ArchivoElegido As String = "client2"
        Cmbox.Text = ArchivoElegido
        Ejecuta(ArchivoElegido)
    End Sub
    Sub Ejecuta(ByVal ArchivoElegido)
        Cantar = 1
        CA(1) = ArchivoElegido
        abre()
        TextBox2.Text = ""
        cbox1.Items.Clear()
        CBox2.Items.Clear()
        BtnCarga.PerformClick()
    End Sub
   
End Class