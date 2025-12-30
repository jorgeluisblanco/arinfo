<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Info
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.BtnEjecuta = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SkinEngine1 = New Sunisoft.IrisSkin.SkinEngine(CType(Me, System.ComponentModel.Component))
        Me.BtnFin = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cbox1 = New System.Windows.Forms.ListBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCarga = New System.Windows.Forms.Button
        Me.BtnGraba = New System.Windows.Forms.Button
        Me.CBox2 = New System.Windows.Forms.ListBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Crep = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DataSet1 = New System.Data.DataSet
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cmbox = New System.Windows.Forms.ComboBox
        Me.BtnTodo = New System.Windows.Forms.Button
        Me.BtnArchivos = New System.Windows.Forms.Button
        Me.BtnBorra = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnActualiza = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnEjecuta
        '
        Me.BtnEjecuta.Location = New System.Drawing.Point(402, 58)
        Me.BtnEjecuta.Name = "BtnEjecuta"
        Me.BtnEjecuta.Size = New System.Drawing.Size(94, 28)
        Me.BtnEjecuta.TabIndex = 127
        Me.BtnEjecuta.Text = "F5-Ejecuta"
        '
        'SkinEngine1
        '
        Me.SkinEngine1.SerialNumber = ""
        Me.SkinEngine1.SkinFile = Nothing
        '
        'BtnFin
        '
        Me.BtnFin.Location = New System.Drawing.Point(607, 58)
        Me.BtnFin.Name = "BtnFin"
        Me.BtnFin.Size = New System.Drawing.Size(90, 28)
        Me.BtnFin.TabIndex = 128
        Me.BtnFin.Text = "F10-Fin"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(97, 255)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(967, 169)
        Me.TextBox1.TabIndex = 129
        '
        'cbox1
        '
        Me.cbox1.FormattingEnabled = True
        Me.cbox1.Location = New System.Drawing.Point(97, 89)
        Me.cbox1.Name = "cbox1"
        Me.cbox1.Size = New System.Drawing.Size(404, 160)
        Me.cbox1.TabIndex = 131
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(97, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(967, 20)
        Me.TextBox2.TabIndex = 132
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Que hacemos?"
        '
        'BtnCarga
        '
        Me.BtnCarga.Location = New System.Drawing.Point(97, 58)
        Me.BtnCarga.Name = "BtnCarga"
        Me.BtnCarga.Size = New System.Drawing.Size(94, 28)
        Me.BtnCarga.TabIndex = 134
        Me.BtnCarga.Text = "Carga"
        '
        'BtnGraba
        '
        Me.BtnGraba.Location = New System.Drawing.Point(198, 58)
        Me.BtnGraba.Name = "BtnGraba"
        Me.BtnGraba.Size = New System.Drawing.Size(94, 28)
        Me.BtnGraba.TabIndex = 135
        Me.BtnGraba.Text = "Graba"
        '
        'CBox2
        '
        Me.CBox2.FormattingEnabled = True
        Me.CBox2.Location = New System.Drawing.Point(522, 89)
        Me.CBox2.Name = "CBox2"
        Me.CBox2.Size = New System.Drawing.Size(542, 160)
        Me.CBox2.TabIndex = 136
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(97, 430)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(967, 80)
        Me.TextBox3.TabIndex = 137
        '
        'Crep
        '
        Me.Crep.ActiveViewIndex = -1
        Me.Crep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Crep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Crep.Location = New System.Drawing.Point(3, 3)
        Me.Crep.Name = "Crep"
        Me.Crep.Size = New System.Drawing.Size(1065, 510)
        Me.Crep.TabIndex = 139
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ItemSize = New System.Drawing.Size(52, 26)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1079, 550)
        Me.TabControl1.TabIndex = 140
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.UltraButton1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Cmbox)
        Me.TabPage1.Controls.Add(Me.BtnTodo)
        Me.TabPage1.Controls.Add(Me.BtnArchivos)
        Me.TabPage1.Controls.Add(Me.BtnBorra)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.CBox2)
        Me.TabPage1.Controls.Add(Me.BtnGraba)
        Me.TabPage1.Controls.Add(Me.BtnCarga)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.cbox1)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.BtnFin)
        Me.TabPage1.Controls.Add(Me.BtnEjecuta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1071, 516)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Informes"
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(320, 4)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(74, 26)
        Me.UltraButton1.TabIndex = 143
        Me.UltraButton1.Text = "Client2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Archivos?"
        '
        'Cmbox
        '
        Me.Cmbox.FormattingEnabled = True
        Me.Cmbox.Location = New System.Drawing.Point(97, 6)
        Me.Cmbox.Name = "Cmbox"
        Me.Cmbox.Size = New System.Drawing.Size(174, 21)
        Me.Cmbox.TabIndex = 141
        '
        'BtnTodo
        '
        Me.BtnTodo.Location = New System.Drawing.Point(706, 58)
        Me.BtnTodo.Name = "BtnTodo"
        Me.BtnTodo.Size = New System.Drawing.Size(94, 28)
        Me.BtnTodo.TabIndex = 140
        Me.BtnTodo.Text = "Todo"
        '
        'BtnArchivos
        '
        Me.BtnArchivos.Location = New System.Drawing.Point(504, 58)
        Me.BtnArchivos.Name = "BtnArchivos"
        Me.BtnArchivos.Size = New System.Drawing.Size(94, 28)
        Me.BtnArchivos.TabIndex = 139
        Me.BtnArchivos.Text = "F9-Archivo"
        '
        'BtnBorra
        '
        Me.BtnBorra.Location = New System.Drawing.Point(300, 58)
        Me.BtnBorra.Name = "BtnBorra"
        Me.BtnBorra.Size = New System.Drawing.Size(94, 28)
        Me.BtnBorra.TabIndex = 138
        Me.BtnBorra.Text = "Borra"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1071, 516)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edita"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UltraGrid1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1065, 510)
        Me.TableLayoutPanel1.TabIndex = 139
        '
        'UltraGrid1
        '
        Appearance2.BackColor = System.Drawing.Color.DarkGray
        UltraGridBand1.Override.ActiveCellAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.Silver
        Appearance3.ForeColor = System.Drawing.Color.Black
        UltraGridBand1.Override.ActiveRowAppearance = Appearance3
        Appearance1.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance1.ForeColor = System.Drawing.Color.Black
        UltraGridBand1.Override.CellAppearance = Appearance1
        Appearance4.BackColor = System.Drawing.SystemColors.ControlDark
        Appearance4.ForeColor = System.Drawing.Color.Black
        UltraGridBand1.Override.RowAppearance = Appearance4
        Appearance5.ForeColor = System.Drawing.Color.Black
        UltraGridBand1.Override.SelectedCellAppearance = Appearance5
        Appearance6.ForeColor = System.Drawing.Color.Black
        UltraGridBand1.Override.SelectedRowAppearance = Appearance6
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance14.BackColor2 = System.Drawing.SystemColors.Control
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance16
        Me.UltraGrid1.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance17
        Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance18
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Appearance19.BackColor = System.Drawing.SystemColors.Control
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance19
        Appearance20.TextHAlignAsString = "Center"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance20
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(3, 43)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(1059, 434)
        Me.UltraGrid1.TabIndex = 139
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnActualiza)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1059, 34)
        Me.Panel1.TabIndex = 140
        '
        'BtnActualiza
        '
        Me.BtnActualiza.Location = New System.Drawing.Point(22, 3)
        Me.BtnActualiza.Name = "BtnActualiza"
        Me.BtnActualiza.Size = New System.Drawing.Size(91, 30)
        Me.BtnActualiza.TabIndex = 0
        Me.BtnActualiza.Text = "Actualiza"
        Me.BtnActualiza.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Crep)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1071, 516)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Reportes"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 567)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Info"
        Me.Text = "Informes de Archivos (Arinfo) 1.01"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnEjecuta As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SkinEngine1 As Sunisoft.IrisSkin.SkinEngine
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cbox1 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCarga As System.Windows.Forms.Button
    Friend WithEvents BtnGraba As System.Windows.Forms.Button
    Friend WithEvents CBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Crep As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataSet1 As System.Data.DataSet
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents BtnBorra As System.Windows.Forms.Button
    Friend WithEvents BtnArchivos As System.Windows.Forms.Button
    Friend WithEvents BtnTodo As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnActualiza As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmbox As System.Windows.Forms.ComboBox
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
End Class
