<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBtr
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Pnl = New System.Windows.Forms.Panel
        Me.UltraButton = New Infragistics.Win.Misc.UltraButton
        Me.TxtBuscaPorClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Titulou = New Infragistics.Win.Misc.UltraLabel
        Me.GrupoFicha = New System.Windows.Forms.GroupBox
        Me.Campo_0 = New System.Windows.Forms.TextBox
        Me.titulo_0 = New System.Windows.Forms.Label
        Me.GrupoBotones = New System.Windows.Forms.GroupBox
        Me.Pnl.SuspendLayout()
        CType(Me.TxtBuscaPorClave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoFicha.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.UltraButton)
        Me.Pnl.Controls.Add(Me.TxtBuscaPorClave)
        Me.Pnl.Controls.Add(Me.Titulou)
        Me.Pnl.Controls.Add(Me.GrupoFicha)
        Me.Pnl.Controls.Add(Me.GrupoBotones)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(0, 0)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(128, 0)
        Me.Pnl.TabIndex = 0
        Me.Pnl.Visible = False
        '
        'UltraButton
        '
        Me.UltraButton.AcceptsFocus = False
        Me.UltraButton.BackColorInternal = System.Drawing.SystemColors.Control
        Me.UltraButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button
        Me.UltraButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButton.Location = New System.Drawing.Point(184, 88)
        Me.UltraButton.Name = "UltraButton"
        Me.UltraButton.Size = New System.Drawing.Size(93, 24)
        Me.UltraButton.TabIndex = 55
        Me.UltraButton.TabStop = False
        Me.UltraButton.Text = "Button"
        Me.UltraButton.Visible = False
        '
        'TxtBuscaPorClave
        '
        Appearance2.FontData.BoldAsString = "True"
        Me.TxtBuscaPorClave.Appearance = Appearance2
        Me.TxtBuscaPorClave.Location = New System.Drawing.Point(88, 88)
        Me.TxtBuscaPorClave.Name = "TxtBuscaPorClave"
        Me.TxtBuscaPorClave.Size = New System.Drawing.Size(88, 21)
        Me.TxtBuscaPorClave.TabIndex = 56
        Me.TxtBuscaPorClave.Visible = False
        '
        'Titulou
        '
        Me.Titulou.Location = New System.Drawing.Point(8, 88)
        Me.Titulou.Name = "Titulou"
        Me.Titulou.Size = New System.Drawing.Size(72, 23)
        Me.Titulou.TabIndex = 58
        Me.Titulou.Text = "Titulo"
        Me.Titulou.Visible = False
        '
        'GrupoFicha
        '
        Me.GrupoFicha.Controls.Add(Me.Campo_0)
        Me.GrupoFicha.Controls.Add(Me.titulo_0)
        Me.GrupoFicha.Location = New System.Drawing.Point(15, 8)
        Me.GrupoFicha.Name = "GrupoFicha"
        Me.GrupoFicha.Size = New System.Drawing.Size(262, 57)
        Me.GrupoFicha.TabIndex = 54
        Me.GrupoFicha.TabStop = False
        Me.GrupoFicha.Visible = False
        '
        'Campo_0
        '
        Me.Campo_0.AcceptsReturn = True
        Me.Campo_0.BackColor = System.Drawing.SystemColors.Window
        Me.Campo_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Campo_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo_0.Location = New System.Drawing.Point(134, 20)
        Me.Campo_0.MaxLength = 0
        Me.Campo_0.Name = "Campo_0"
        Me.Campo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Campo_0.Size = New System.Drawing.Size(108, 22)
        Me.Campo_0.TabIndex = 50
        Me.Campo_0.Visible = False
        '
        'titulo_0
        '
        Me.titulo_0.BackColor = System.Drawing.SystemColors.Control
        Me.titulo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.titulo_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titulo_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.titulo_0.Location = New System.Drawing.Point(12, 20)
        Me.titulo_0.Name = "titulo_0"
        Me.titulo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.titulo_0.Size = New System.Drawing.Size(93, 25)
        Me.titulo_0.TabIndex = 49
        Me.titulo_0.Visible = False
        '
        'GrupoBotones
        '
        Me.GrupoBotones.Location = New System.Drawing.Point(15, 129)
        Me.GrupoBotones.Name = "GrupoBotones"
        Me.GrupoBotones.Size = New System.Drawing.Size(262, 33)
        Me.GrupoBotones.TabIndex = 57
        Me.GrupoBotones.TabStop = False
        Me.GrupoBotones.Visible = False
        '
        'FormBtr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(128, 0)
        Me.Controls.Add(Me.Pnl)
        Me.DoubleBuffered = True
        Me.Name = "FormBtr"
        Me.Opacity = 0
        Me.Text = "FormBtr"
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        CType(Me.TxtBuscaPorClave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoFicha.ResumeLayout(False)
        Me.GrupoFicha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl As System.Windows.Forms.Panel
    Friend WithEvents UltraButton As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtBuscaPorClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Titulou As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GrupoFicha As System.Windows.Forms.GroupBox
    Public WithEvents Campo_0 As System.Windows.Forms.TextBox
    Public WithEvents titulo_0 As System.Windows.Forms.Label
    Friend WithEvents GrupoBotones As System.Windows.Forms.GroupBox
End Class
