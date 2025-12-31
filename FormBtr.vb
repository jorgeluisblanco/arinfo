Imports System.ComponentModel
Imports System.Environment
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Strings
Imports System.Drawing
Imports System.Drawing.Printing
Imports Infragistics.Win.Misc
Imports System
Imports Microsoft.VisualBasic
Imports Arinfo.Utilidades


Public Class FormBtr
    Private Titulos As ArrayControles(Of Label)
    Private Campos As ArrayControles(Of TextBox)
    Friend WithEvents VBtrvC As Btr
    Friend WithEvents VBtrv As Btr
    Private mFileOpen As Boolean
    Private MenuTop As Short
    Private MenuLeft As Short
    Private parli As clsParametrosdeArchivo
    Dim alstBotones As New ArrayList()
    Dim AnchoPantalla As Short
    Dim Anchors As Short
    Public Esingreso As Boolean = False
    Public EstoyEnMuestra As Boolean = False
    Public IngresadoAutomatico As String = ""
    Dim NewFFont As String = "Arial"
    Dim NewEmSize As Single = 8.75

    ' <System.Runtime.CompilerServices.Extension()> _
    Public Sub EnableDoubleBuferring(ByVal control As Control)
        Dim [property] = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        [property].SetValue(control, True, Nothing)
    End Sub

    Friend Sub New(ByRef ItemPar As clsParametrosdeArchivo)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Opacity = 0
        Me.SuspendLayout()
        Me.Pnl.SuspendLayout()
        Me.GrupoFicha.SuspendLayout()

        Me.DoubleBuffered = True
        For Each control As Control In Me.Controls
            EnableDoubleBuferring(control)
        Next control
        'Add any initialization after the InitializeComponent() call
        'Me.Opacity = 0
        Me.VBtrv = New Btr
        parli = ItemPar

        abrearchivos()

        Campo_0.Font = New System.Drawing.Font(NewFFont, NewEmSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)) ' 9.75
        titulo_0.Font = New System.Drawing.Font(NewFFont, NewEmSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)) ' 9.75
        Dim x As Short = 0
        For X = 1 To (VBtrv.Campos.Count - 0)
            Dim Campo As New TextBox
            Campo.Name = "Campo_" & X
            Campo.AcceptsReturn = True
            Campo.BackColor = System.Drawing.SystemColors.Window
            Campo.Cursor = System.Windows.Forms.Cursors.IBeam
            Campo.Font = New System.Drawing.Font(NewFFont, NewEmSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)) ' 9.75
            Campo.ForeColor = System.Drawing.SystemColors.WindowText
            Campo.Location = New System.Drawing.Point(0, 0)
            Campo.MaxLength = 0
            Campo.RightToLeft = System.Windows.Forms.RightToLeft.No
            Campo.Size = New System.Drawing.Size(0, 0)
            'Campo.TabIndex = X
            Campo.Visible = False
            Me.GrupoFicha.Controls.Add(Campo)

            Dim Titulo As New Label
            Titulo.Name = "Titulo_" & X
            'Titulo.BackColor = System.Drawing.SystemColors.Control ' Color.FromArgb(&HFFEAEAEA)
            Titulo.Cursor = System.Windows.Forms.Cursors.Default
            Titulo.Font = New System.Drawing.Font(NewFFont, NewEmSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Titulo.ForeColor = System.Drawing.SystemColors.ControlText
            Titulo.Location = New System.Drawing.Point(0, 0)
            Titulo.RightToLeft = System.Windows.Forms.RightToLeft.No
            Titulo.Size = New System.Drawing.Size(0, 0)
            Titulo.Visible = False
            Me.GrupoFicha.Controls.Add(Titulo)
        Next

        Me.Pnl.Controls.Add(GrupoFicha)

        Titulos = New ArrayControles(Of Label)("Titulo", Me)
        Campos = New ArrayControles(Of TextBox)("Campo", Me)
        asignarEventos()


        'MuestraForm()

        Me.GrupoBotones.Visible = False
        Me.GrupoFicha.Visible = False

        Dim Paso As Short
        Dim Fila As Short
        Dim Colum As Short
        Dim Ofset As Short
        Dim L As Graphics = Campo_0.CreateGraphics()
        Dim g As Graphics = titulo_0.CreateGraphics()
        Dim sz As SizeF
        Dim text As String
        Dim Grosor As Short = (g.MeasureString("M", Campo_0.Font).Height) + 4
        Dim MaxWidth As Short = 0
        Dim MaxHeight As Short = 0
        With Me
            For x = 1 To (VBtrv.Campos.Count - 2)
                Ofset = 5
                Fila = VBtrv.Campos(x - 1).Fila
                sz = g.MeasureString("M", titulo_0.Font)
                Colum = (VBtrv.Campos(x - 1).Columna * sz.Width) + 2
                Titulos(x).Visible = False
                Campos(x).Visible = False

                'MsgBox(VBtrv.Campos(x - 1).Titulo)

                sz = L.MeasureString(VBtrv.Campos(x - 1).Titulo, Campo_0.Font)
                Titulos(x).Width = CType(sz.Width, Integer) + 2
                Titulos(x).Height = CType(sz.Height, Integer) + 2

                If VBtrv.Campos(x - 1).Numerico = 0 Then
                    text = "M"
                Else
                    text = "0"
                End If
                sz = g.MeasureString(text, titulo_0.Font)
                Campos(x).Width = VBtrv.Campos(x - 1).Ancho * (CType(sz.Width, Integer)) + 2
                Campos(x).Height = (CType(sz.Height, Integer)) + 2

                Paso = (Fila - 3) * (Grosor + 4)

                Titulos(x).Top = Ofset + Paso
                Titulos(x).Text = VBtrv.Campos(x - 1).Titulo
                Titulos(x).Left = Colum

                Campos(x).Top = Titulos(x).Top
                Campos(x).Left = Titulos(x).Left + Titulos(x).Width
                Campos(x).Text = ""
                Campos(x).MaxLength = VBtrv.Campos(x - 1).Ancho

                Titulos(x).Visible = True
                Campos(x).Visible = True
                If (Campos(x).Top + Campos(x).Height) > MaxHeight Then
                    MaxHeight = Campos(x).Top + Grosor
                End If
                If (Campos(x).Left + Campos(x).Width) > MaxWidth Then
                    MaxWidth = Campos(x).Left + Campos(x).Width
                End If
            Next
            Titulos(0).Visible = False
            Campos(0).Visible = False
            Campo_0.Visible = False
            titulo_0.Visible = False
        End With
        If MaxWidth < 450 Then
            MaxWidth = 450
        End If
        GrupoFicha.Top = 5
        GrupoFicha.Left = 5
        GrupoFicha.Height = MaxHeight + 10
        GrupoFicha.Width = MaxWidth + 80 '60

        GrupoBotones.Top = GrupoFicha.Top + GrupoFicha.Height + 5
        GrupoBotones.Left = GrupoFicha.Left
        GrupoBotones.Width = GrupoFicha.Width
        GrupoBotones.Height = 120
        AnchoPantalla = GrupoBotones.Width - 5

        Me.StartPosition = FormStartPosition.Manual

        'Me.Top = 5 '  1
        'Me.Left = 5 ' 1
        'Me.Width = MaxWidth + 100
        'Me.Height = 10 + GrupoFicha.Top + GrupoFicha.Height + 10 + 10 + 5 + 35 + 100

        MenuTop = 5
        MenuLeft = 5

        AddMenu()
        MenuGeneral()

        Me.GrupoFicha.Visible = True
        Me.GrupoBotones.Visible = True
        Me.Pnl.Visible = True

        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.KeyPreview = True

        'Me.Pnl.ResumeLayout()
        'Me.GrupoBotones.ResumeLayout()
        'Me.GrupoFicha.ResumeLayout()

        Me.Top = 5 '  1
        Me.Left = 5 ' 1
        Me.Width = MaxWidth + 100
        Me.Height = 10 + GrupoFicha.Top + GrupoFicha.Height + 10 + 10 + 5 + 35 + 100

        Me.GrupoFicha.ResumeLayout()
        Me.Pnl.ResumeLayout()
        Me.ResumeLayout()

    End Sub

    Private MeTop As Integer
    Private MeLeft As Integer
    Private MeWidth As Integer
    Private MeHeight As Integer

    Private Sub MuestraForm()

    End Sub

    ' Asignar los eventos a los controles
    Private Sub asignarEventos()
        ' Aquí estarán los procedimientos a asignar a cada array de controles
        For Each txt As TextBox In Campos
            AddHandler txt.KeyPress, AddressOf Campos_KeyPress
            AddHandler txt.KeyDown, AddressOf Campos_KeyDown
            AddHandler txt.Click, AddressOf Campos_click
        Next

        'For Each lbl As Label In Titulos
        '    lbl.BackColor = Color.FromArgb(&HFFEAEAEA)
        'Next
    End Sub

    Sub abrearchivos()
        If Btr.Btrs.ContainsKey(parli.Tabla) Then
            VBtrv = Btr.Btrs.Item(parli.Tabla)
        Else
            VBtrv.Tabla = parli.Tabla
            VBtrv.Archivo = parli.Archivo
            VBtrv.DDF = parli.DDF
            VBtrv.Cripto = parli.Cripto
            Dim Status As Integer = VBtrv.AbreArchivos
        End If
        Me.VBtrv.NroFiltro = 0
        Me.VBtrv.Vbtrv1.DirectEdits = True ' No Need for AddNew and Edit
        Me.VBtrv.Vbtrv1.DirtyReads = True  ' D
        Me.Text = UCase(VBtrv.Tabla)
    End Sub

    Private Sub Campos_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = Campos.Index(eventSender)
        If Index <> 0 Then

        End If
    End Sub

    Private Sub FormateaCampos(ByVal Index As Short)
        Select Case VBtrv.Campos(Index - 1).Numerico
            Case 1
                Campos(Index).Text = XFND(QB.SafeToDouble(Campos(Index).Text), VBtrv.Campos(Index - 1).Ancho, VBtrv.Campos(Index - 1).Decimales)
            Case 2, 3
                Campos(Index).Text = XFND0(QB.SafeToDouble(Campos(Index).Text), VBtrv.Campos(Index - 1).Ancho, VBtrv.Campos(Index - 1).Decimales)
            Case Else
        End Select
    End Sub

    Private Sub Campos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Index As Short
        If TypeOf sender Is FormBtr Then
            If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Then
                Index = Campos.Index(Me.ActiveControl)
            Else
                Exit Sub
            End If
        ElseIf TypeOf sender Is System.Windows.Forms.TextBox Then
            Index = Campos.Index(sender)
        Else
            Exit Sub
        End If
        If Index <> 0 Then
            If e.KeyCode = Keys.Up Then
                e.Handled = True
                Call FormateaCampos(Index)
                If Index > 1 Then
                    Campos(Index - 1).Focus()
                End If
            ElseIf e.KeyCode = Keys.Down Then
                e.Handled = True
                Call FormateaCampos(Index)
                If Index < (Campos.Count - 1) Then
                    Campos(Index + 1).Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Campos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If EstoyEnMuestra = True Then
            Dim Index As Short
            If TypeOf sender Is FormBtr Then
                If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Then
                    Index = Campos.Index(Me.ActiveControl)
                Else
                    Exit Sub
                End If
            ElseIf TypeOf sender Is System.Windows.Forms.TextBox Then
                Index = Campos.Index(sender)
            Else
                Exit Sub
            End If
            If Index <> 0 Then
                Campos(Index).Focus()
                MenuCorreccion()
            End If
        End If
    End Sub

    Private Sub Campos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Index As Short
        If TypeOf sender Is FormBtr Then
            If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Then
                Index = Campos.Index(Me.ActiveControl)
            Else
                Exit Sub
            End If
        ElseIf TypeOf sender Is System.Windows.Forms.TextBox Then
            Index = Campos.Index(sender)
        Else
            Exit Sub
        End If
        If Index <> 0 Then
            If e.KeyChar = Convert.ToChar(Keys.Return) Then
                e.Handled = True
                Call FormateaCampos(Index)
                If Index < (Campos.Count - 1) Then
                    Campos(Index + 1).Focus()
                End If
            ElseIf e.KeyChar = Convert.ToChar(Keys.Up) Then
                e.Handled = True
                If Index > 1 Then
                    Campos(Index - 1).Focus()
                End If
            ElseIf e.KeyChar = Convert.ToChar(Keys.Down) Then
                e.Handled = True
                If Index < (Campos.Count - 1) Then
                    Campos(Index + 1).Focus()
                End If
            Else
                Select Case VBtrv.Campos(Index - 1).Numerico
                    Case 0 'string
                        If System.Char.IsLower(e.KeyChar) Then ' convierte a mayusculas
                            e.Handled = True
                            System.Windows.Forms.SendKeys.Send(e.KeyChar.ToString().ToUpper())
                        End If
                    Case 1, 2, 3 ' numerico, codigo , fecha
                        If e.KeyChar <> " " And e.KeyChar <> ChrW(Keys.Back) And e.KeyChar <> "." Then
                            If Not System.Char.IsNumber(e.KeyChar) Then 'e.KeyChar.Is ...
                                e.Handled = True
                            End If
                        End If
                        'If e.KeyChar = "." Then
                        '    e.Handled = True
                        '    System.Windows.Forms.SendKeys.Send(",")
                        'End If
                    Case Else
                End Select
            End If
        End If
    End Sub


    Sub AddMenu()
        AddHandler TxtBuscaPorClave.KeyPress, AddressOf TxtBuscaPorClave_KeyPress
        AddHandler TxtBuscaPorClave.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
        AddHandler Me.KeyPress, AddressOf TxtBuscaPorClave_KeyPress
        AddHandler Me.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
    End Sub
    Sub RemoveMenu()
        RemoveHandler TxtBuscaPorClave.KeyPress, AddressOf TxtBuscaPorClave_KeyPress
        RemoveHandler TxtBuscaPorClave.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
        RemoveHandler Me.KeyPress, AddressOf TxtBuscaPorClave_KeyPress
        RemoveHandler Me.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
    End Sub

    Private Sub AddEdicionIngreso()
        RemoveMenu()
        AddHandler Me.KeyPress, AddressOf Campos_KeyPress
        AddHandler Me.KeyDown, AddressOf Campos_KeyDown
        AddHandler Me.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
    End Sub
    Private Sub RemoveEdicionIngreso()
        RemoveHandler Me.KeyPress, AddressOf Campos_KeyPress
        RemoveHandler Me.KeyDown, AddressOf Campos_KeyDown
        RemoveHandler Me.KeyDown, AddressOf TxtBuscaPorClave_KeyDown
        AddMenu()
    End Sub


    Dim EnEdicion As Boolean
    Dim Actualiza As Boolean
    Private Sub TextBox1_Enter(ByVal sender As Object, _
                    ByVal e As System.EventArgs)
        '
        Dim txt As TextBox = CType(sender, TextBox)
        Dim Index As Integer = txt.Tag
        txt.SelectAll()
        EnEdicion = True
    End Sub
    Private Sub TextBox1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        Dim Index As Integer = txt.Tag
        If EnEdicion = True Then
            Actualiza = True
        End If
        If Actualiza = True Then
            'cmdUpdate.Visible = True
            'CmdAbandona.Visible = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, _
                     ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '
        Dim txt As TextBox = CType(sender, TextBox)
        Dim Index As Integer = txt.Tag
        Dim MaxIndex As Integer = 20

        If e.KeyChar = ChrW(Keys.Escape) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            If Index < MaxIndex Then
                e.Handled = True ' saca el beep
            End If
        End If
    End Sub

    
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        Dim Index As Integer = txt.Tag
        Dim MaxIndex As Integer = 20
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Down, Keys.Tab ', Keys.Menu
                If Index < MaxIndex Then
                    While Campos(Index + 1).Visible = False
                        Index += 1
                    End While
                End If
                If Index = MaxIndex Then
                    'm_TextBox1(0).Focus()
                Else
                    e.Handled = True
                    Campos(Index + 1).Focus()
                End If
            Case Keys.Up
                If Index > 0 Then
                    While Campos(Index - 1).Visible = False
                        Index -= 1
                    End While
                End If
                If Index = 0 Then
                    'm_TextBox1(MaxIndex).Focus()
                Else
                    e.Handled = True
                    Campos(Index - 1).Focus()
                End If
            Case Else
        End Select
    End Sub

    Private Sub LimpiarForm()
        Dim X As Short
        For X = 1 To (VBtrv.Campos.Count - 2)
            Me.Campos(X).Text = " "
        Next
    End Sub

    Sub DisableForm()
        Dim X As Short
        For X = 1 To (VBtrv.Campos.Count - 2)
            Me.Campos(X).Enabled = False
            'Me.Campos(X).BackColor = System.Drawing.SystemColors.InactiveCaptionText 
        Next
    End Sub

    Sub EnableForm()
        Dim X As Short
        For X = 1 To (VBtrv.Campos.Count - 2)
            Me.Campos(X).Enabled = True
            Me.Campos(X).BackColor = System.Drawing.SystemColors.Window
        Next
    End Sub
    Sub LlenarForm()
        Me.Text = UCase(Me.VBtrv.Tabla) & "    " & Me.VBtrv.Keyval & "    " & Me.VBtrv.NameKeyval
        Dim X As Short
        For X = 1 To (VBtrv.Campos.Count - 2)
            Me.Campos(X).Text = VBtrv.Campo(X)
        Next
        If VBtrv.Tabla = "articu2" Then
            Me.Campos(12).Text = XFND(QB.SafeToDouble(Me.Campos(9).Text) + QB.SafeToDouble(Me.Campos(10).Text) - QB.SafeToDouble(Me.Campos(11).Text), 10, 3)
        End If
    End Sub

    Sub LlenarCampos()
        Dim X As Short
        For X = 1 To (VBtrv.Campos.Count - 2)
            VBtrv.Campo(X) = Me.Campos(X).Text
        Next
      
    End Sub


    Sub Primera()
        Dim Bstat As Short = 0
        Bstat = VBtrv.CallBtrv(12)
        If Bstat = 0 Then
            LlenarForm()
        Else
            MsgBox("Btrieve error: " & Bstat, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Sub Anterior()
        Dim Bstat As Short = 0
        Bstat = VBtrv.CallBtrv(7)
        If Bstat = 0 Then
            LlenarForm()
        End If
    End Sub

    Sub Siguiente()
        Dim Bstat As Short = 0
        Bstat = VBtrv.CallBtrv(6)
        If Bstat = 0 Then
            LlenarForm()
        End If
    End Sub

    Sub Ultima()
        Dim Bstat As Short = 0
        Bstat = VBtrv.CallBtrv(13)
        If Bstat = 0 Then
            LlenarForm()
        Else
            MsgBox("Btrieve error: " & Bstat, MsgBoxStyle.OkOnly)
        End If
    End Sub


    Sub Corrige()
        Dim resB As Short
        LlenarCampos()
        resB = VBtrv.CallBtrv(3)
        If resB <> 0 Then
            MsgBox("Error de Actualizacion, Btrieve error: " & resB, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Sub Ingresa()
        Dim resB As Short
        LlenarCampos()
        resB = VBtrv.CallBtrv(2)
        If resB <> 0 Then
            MsgBox("Error de Insercion, Btrieve error: " & resB, MsgBoxStyle.OkOnly)
        End If
    End Sub

    Sub Numera()
        Dim resB As Short
        LlenarCampos()
        Dim Keyval As String = "9999"
        resB = VBtrv.CallBtrv(11, Keyval)
        If resB <> 0 Then
            MsgBox("Error de Insercion, Btrieve error: " & resB, MsgBoxStyle.OkOnly)
        End If
        IngresadoAutomatico = XFND0(QB.SafeToDouble(VBtrv.Campo(1)) + 1, 4, 0)
    End Sub

    Sub Borra()
        Dim stat As Short
        stat = VBtrv.CallBtrv(4)
        If stat <> 0 Then
            MsgBox("Error de Borrado, Btrieve error: " & stat, MsgBoxStyle.OkOnly)
        Else
            LimpiarForm()
            'Dim sender As System.Object
            'Dim e
            Siguiente()
        End If
    End Sub

    Sub Busca(ByVal Retorno As String)
        Dim resB As Short
        resB = VBtrv.CallBtrv(9, Retorno, Me.VBtrv.Vbtrv1.IndexNumber)
        If resB <> 0 Then
            MsgBox("No lo encontre " & Trim(Retorno) & ", Btrieve error: " & resB, MsgBoxStyle.OkOnly)
        Else
            LlenarForm()
        End If
    End Sub

    Sub CambiaClave()
        Dim Keyval As String = ""
        Dim Index As Integer = Me.VBtrv.Vbtrv1.IndexNumber
        If Index + 1 < Me.VBtrv.Vbtrv1.IndexCount Then
            Me.VBtrv.Vbtrv1.IndexNumber = Index + 1
        Else
            Me.VBtrv.Vbtrv1.IndexNumber = 0
        End If
        Index = Me.VBtrv.Vbtrv1.IndexNumber
        LlenarForm()
    End Sub

    'Sub Cierra()
    '    If mFileOpen = True Then
    '        Dim Bstat As Short = 0
    '        Bstat = VBtrv.CallBtrv(1)
    '        Dim Opcode As Short = 28
    '        Try
    '            Bstat = VBtrv.CallBtrv(Opcode)
    '            If Bstat <> 0 Then
    '                MsgBox("Error Calling Btrieve Reset. Btrieve error:  " & Bstat, MsgBoxStyle.OkOnly)
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
    '            Bstat = 0
    '        Finally
    '        End Try
    '        VBtrv = Nothing
    '    End If
    'End Sub


    Dim NroMenu As Integer

    Sub Menustext(ByVal Entrada As String)
        Select Case NroMenu
            Case 2
                Busca(Entrada)
                TxtBuscaPorClave.Text = ""
                TxtBuscaPorClave.Focus()
            Case 5
                'MenuCorreccion()
                RemoveMenu()
                AddEdicionIngreso()
                Select Case Entrada
                    Case "XX"
                        'Borra()
                        RemoveEdicionIngreso()
                        MenuSeguroSioNo()
                    Case Else
                        Dim Index As Short = QB.SafeToShort(Entrada)
                        Campos(Index).Focus()
                        MenuCorreccion()
                End Select
            Case 4
                'HfrmBusca
                CampoDeBusqueda = QB.SafeToInteger(Entrada)
                MenuQueBuscas()
            Case 8
                Busqueda = Entrada
                Busquedadesde = -1
                RutBusca()
                MenuSioNo()
            Case Else
        End Select
    End Sub

    Dim Busqueda As String
    Dim CampoDeBusqueda As Integer
    Dim Busquedadesde As Integer

    Sub MenusKeys(ByVal Retorno As String)
        Select Case NroMenu
            Case 1
                HfrmMG(Retorno)
            Case 2
                HfrmMuestra(Retorno)
            Case 3
                HfrmIngreso(Retorno)
            Case 4
                HfrmBusca(Retorno)
            Case 5
                HfrmCorrige(Retorno)
            Case 6
                HfrmCorreccion(Retorno)
            Case 7
                Informes()
            Case 8
                HfrmQBuscas(Retorno)
            Case 9
                hfrmSioNo(Retorno)
            Case 10
                HfrmQhacemos(Retorno)
            Case 11
                hfrmSeguroSioNo(Retorno)
            Case Else
        End Select
    End Sub

    Private Sub MenuGeneral()
        'HfrmMG
        LimpiarForm()
        DisableForm()
        NroMenu = 1
        IniciarMenu()
        AgregarBoton("F1 - Muestra")
        AgregarBoton("F2 - Ingresa")
        AgregarBoton("F3 - Busca")
        AgregarBoton("F4 - Informes")
        AgregarBoton("F10 - Menu Anterior")
        Mostrar()
    End Sub
    Sub HfrmMG(ByVal Retorno As String)
        'HfrmMG
        EstoyEnMuestra = False
        EnableForm()
        Select Case Retorno
            Case "F1"
                EstoyEnMuestra = True
                Primera()
                MenuMuestra()
            Case "F2"
                MenuIngresa()
            Case "F3"
                MenuBusca()
            Case "F4"
                MenuInformes()
            Case "F10"
                Me.Close()
            Case Else
                MenuGeneral()
        End Select
    End Sub

    Private Sub MenuMuestra()
        'HfrmMuestra
        NroMenu = 2
        IniciarMenu()
        AgregarTitulo("Codigo")
        AgregarTexto("MMMMMMMM")
        AgregarBoton("F1 - Siguiente")
        AgregarBoton("F2 - Anterior")
        AgregarBoton("F3 - Imprime")
        AgregarBoton("F4 - Primera")
        AgregarBoton("F5 - Ultima")
        AgregarBoton("F8 - Cambia Clave")
        AgregarBoton("F9 - Corrige")
        AgregarBoton("F10 - Menu")
        Mostrar()
    End Sub

    Sub HfrmMuestra(ByVal Retorno As String)
        Select Case Retorno
            Case "F1"
                Siguiente()
            Case "F2"
                Anterior()
            Case "F3"
                'Imprime()
            Case "F4"
                Primera()
            Case "F5"
                Ultima()
            Case "F8"
                CambiaClave()
            Case "F9"
                enBusqueda = False
                MenuCorrige()
            Case "F10"
                MenuGeneral()
            Case "F5", "F6", "F7"
                MenuMuestra()
            Case Else
                MenuMuestra()
        End Select
    End Sub

    Sub MenuIngresa()
        'HfrmIngreso
        NroMenu = 3
        IniciarMenu()
        AgregarTitulo("Arriba Abajo - Posiciona")
        AgregarBoton("F1 - Numeracion Automatica")
        AgregarBoton("F10 - Graba Ingreso")
        AgregarBoton("ESC - Abandona Ingreso")
        Mostrar()

        RemoveMenu()
        AddEdicionIngreso()
        LimpiarForm()
        If IngresadoAutomatico <> "" Then
            Me.Campos(1).Text = IngresadoAutomatico
            'IngresadoAutomatico = ""
        End If
        Me.Campos(1).Focus()
    End Sub

    'Sub HfrmIngreso(ByVal Retorno As String)
    '    Select Case Retorno
    '        Case "F10"
    '            Ingresa()
    '            RemoveEdicionIngreso()
    '            MenuGeneral()
    '        Case "ESC"
    '            RemoveEdicionIngreso()
    '            MenuGeneral()
    '        Case Else
    '            MenuIngresa()
    '    End Select
    'End Sub

    Sub HfrmIngreso(ByVal Retorno As String)
        Select Case Retorno
            Case "F1"
                Numera()
                MenuIngresa()
            Case "F10"
                IngresadoAutomatico = ""
                Ingresa()
                RemoveEdicionIngreso()
                If Esingreso Then
                    Me.Close()
                Else
                    MenuGeneral()
                End If
            Case "ESC"
                RemoveEdicionIngreso()
                If Esingreso Then
                    Me.Close()
                Else
                    MenuGeneral()
                End If
            Case Else
                MenuIngresa()
        End Select
    End Sub

    Sub MenuBusca()
        'HfrmBusca
        NroMenu = 4
        IniciarMenu()
        AgregarTitulo("Busca en Campo Numero ..?")
        AgregarTexto("00")
        AgregarBoton("F10 - Menu")
        Mostrar()
    End Sub

    Sub HfrmBusca(ByVal Retorno As String)
        Select Case Retorno
            Case "F10"
                MenuGeneral()
            Case Else
                MenuBusca()
        End Select
    End Sub

    Sub MenuCorrige()
        'HfrmCorrige
        NroMenu = 5
        IniciarMenu()
        AgregarTitulo("Corrige Campo Numero ..?")
        AgregarTexto("XX")
        AgregarBoton("XX - Borra la Ficha")
        AgregarBoton("F10 - Menu")
        Mostrar()
    End Sub

    Sub HfrmCorrige(ByVal Retorno As String)
        Select Case Retorno
            Case "F10"
                MenuMuestra()
            Case "XX"
                Borra()
            Case Else
                MenuCorrige()
        End Select
    End Sub

    Sub MenuCorreccion()
        'HfrmCorreccion
        NroMenu = 6
        IniciarMenu()
        AgregarTitulo("Arriba Abajo - Posiciona")
        AgregarBoton("F10 - Graba Correccion")
        AgregarBoton("ESC - Abandona Correccion")
        Mostrar()
    End Sub

    Sub HfrmCorreccion(ByVal Retorno As String)
        Select Case Retorno
            Case "F10"
                Corrige()
                RemoveEdicionIngreso()
                If enBusqueda = False Then
                    MenuMuestra()
                Else
                    MenuQhacemos()
                End If
            Case "ESC"
                RemoveEdicionIngreso()
                If enBusqueda = False Then
                    MenuMuestra()
                Else
                    MenuQhacemos()
                End If
            Case Else
                MenuCorreccion()
        End Select
    End Sub

    Sub MenuInformes()
        'Informes
        NroMenu = 7
        Informes()
    End Sub
    Sub Informes()
        MenuGeneral()
    End Sub

    Sub MenuQueBuscas()
        'HfrmQBuscas
        NroMenu = 8
        IniciarMenu()
        AgregarTitulo("Que Buscas ..?")
        AgregarTexto("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM")
        AgregarBoton("F10 - Menu")
        Mostrar()
    End Sub
    Sub HfrmQBuscas(ByVal Retorno As String)
        Select Case Retorno
            Case "F10"
                MenuGeneral()
            Case Else
                MenuQueBuscas()
        End Select
    End Sub
    Dim EstaEnBusqueda As Boolean = False
    Dim FuerzaSalida As Boolean = False
    Dim Adelante As Integer = 6

    Sub RutBusca()
        'rutina de Busqueda
        EstaEnBusqueda = True
        FuerzaSalida = False
        Dim Status As Integer
        Dim Funcion As Short
        If Busquedadesde = -1 Then 'desde inicio
            Funcion = 12
        Else
            VBtrv.Vbtrv1.BtrievePosition = Busquedadesde
            Funcion = Adelante
        End If
        Status = 0
        While Status <> 9
            Select Case Funcion
                Case 12
                    Status = VBtrv.Vbtrv1.MoveFirst
                Case 6
                    Status = VBtrv.Vbtrv1.MoveNext
                Case 7
                    Status = VBtrv.Vbtrv1.MovePrevious
            End Select
            'If InStr(Campo(CampoDeBusqueda), Busqueda) <> 0 Then
            If Status = 0 Then
                If InStr(VBtrv.Campo(CampoDeBusqueda), Busqueda) <> 0 Then
                    Busquedadesde = VBtrv.Vbtrv1.BtrievePosition
                    LlenarForm()
                    EstaEnBusqueda = False
                    Exit Sub
                End If
                Funcion = Adelante
            End If
            'If Not GetInputState = 0 Then Application.DoEvents()
            If FuerzaSalida = True Then
                FuerzaSalida = False
                Exit While
            End If
        End While
        EstaEnBusqueda = False
    End Sub

    Sub MenuSioNo()
        'hfrmSioNo
        NroMenu = 9
        IniciarMenu()
        AgregarTitulo("Es esta ..?")
        AgregarBoton("F1 - Si")
        AgregarBoton("F10 - No")
        Mostrar()
    End Sub
    Sub hfrmSioNo(ByVal Retorno As String)
        Select Case Retorno
            Case "F1"
                MenuQhacemos()
            Case "F10"
                RutBusca()
                MenuSioNo()
            Case Else
                MenuSioNo()
        End Select
    End Sub

    Sub MenuSeguroSioNo()
        'hfrmSeguroSioNo
        NroMenu = 11
        IniciarMenu()
        AgregarTitulo("Seguro ..?")
        AgregarBoton("F1 - Si")
        AgregarBoton("F10 - No")
        Mostrar()
    End Sub
    Sub hfrmSeguroSioNo(ByVal Retorno As String)
        Select Case Retorno
            Case "F1"
                Borra()
                MenuMuestra()
            Case "F10"
                MenuMuestra()
            Case Else
                MenuSeguroSioNo()
        End Select
    End Sub

    Sub MenuQhacemos()
        'HfrmQhacemos
        NroMenu = 10
        IniciarMenu()
        AgregarBoton("F1 - Sigue Buscando")
        AgregarBoton("F9 - Corrige")
        AgregarBoton("F10 - Menu Anterior")
        Mostrar()
    End Sub
    Sub HfrmQhacemos(ByVal Retorno As String)
        Select Case Retorno
            Case "F1"
                RutBusca()
                MenuSioNo()
            Case "F9"
                enBusqueda = True
                MenuCorrige()
            Case "F10"
                MenuGeneral()
            Case Else
                MenuQhacemos()
        End Select
    End Sub

    Dim enBusqueda As Boolean = False
    Sub IniciarMenu()
        alstBotones.Clear()
        If Me.GrupoBotones.Controls.Count > 0 Then
            For x As Integer = Me.GrupoBotones.Controls.Count - 1 To 0 Step -1
                If Me.GrupoBotones.Controls.Item(x).Tag = "XX" Then
                    Me.GrupoBotones.Controls.RemoveAt(x)
                End If
            Next
        End If
        Titulou.Width = 0
        TxtBuscaPorClave.Width = 0
        TxtBuscaPorClave.CharacterCasing = CharacterCasing.Upper
        Anchors = 0
    End Sub
    Public Sub AgregarTitulo(ByVal Cadena As String)
        Titulou.Text = Cadena
        Dim LObj As Object = Titulou
        Titulou.Height = 30
        Dim L As Graphics = LObj.CreateGraphics()
        Titulou.Width = 200
        Titulou.Font = UltraButton.Font
        Dim sz As SizeF
        sz = L.MeasureString(Cadena, Titulou.Font)
        Titulou.Width = CType(sz.Width, Integer) + 10
    End Sub

    Public Sub AgregarTexto(ByVal Cadena As String)
        TxtBuscaPorClave.Text = Cadena
        Dim LObj As Object = TxtBuscaPorClave
        TxtBuscaPorClave.Height = 30
        TxtBuscaPorClave.Font = UltraButton.Font
        Dim L As Graphics = LObj.CreateGraphics()
        TxtBuscaPorClave.Width = 200
        Dim sz As SizeF
        sz = L.MeasureString(Cadena, TxtBuscaPorClave.Font)
        TxtBuscaPorClave.Width = CType(sz.Width, Integer) + 10
        TxtBuscaPorClave.Text = ""
    End Sub

    Public Sub AgregarBoton(ByVal Cadena As String)
        Dim cmdBoton As New UltraButton()
        Dim LObj As Object = UltraButton
        UltraButton.Height = 30
        Dim L As Graphics = LObj.CreateGraphics()
        cmdBoton.BackColor = UltraButton.BackColor
        cmdBoton.ButtonStyle = UltraButton.ButtonStyle
        cmdBoton.UseOsThemes = UltraButton.UseOsThemes
        cmdBoton.Text = Cadena
        cmdBoton.Height = UltraButton.Height
        cmdBoton.Font = UltraButton.Font
        cmdBoton.Width = 200
        cmdBoton.TabStop = False
        cmdBoton.TabIndex = 0
        Dim sz As SizeF
        sz = L.MeasureString(Cadena, cmdBoton.Font)
        If Anchors < CType(sz.Width, Integer) Then
            Anchors = CType(sz.Width, Integer) + 5 ' + 20
        End If
        alstBotones.Add(cmdBoton)
    End Sub

    Public Sub AgregarMensaje(ByVal cadena As String)
        UltraButton.Text = cadena
    End Sub

    Sub Mostrar()
        Dim cmdBoton As New Infragistics.Win.Misc.UltraButton()
        Dim intContador As Integer = alstBotones.Count
        Dim intI As Integer
        Dim AnchoTotal As Short = 5
        Dim Posmenu As Short = 10
        Dim Otralinea As Short = 5

        If Titulou.Width <> 0 Then
            Otralinea = 35
            Titulou.Location = New System.Drawing.Point(AnchoTotal, Posmenu)
            Titulou.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Titulou.UseOsThemes = UltraButton.UseOsThemes
            Titulou.BackColor = Color.FromArgb(&HFFEAEAEA)
            Titulou.Height = 30
            Titulou.Visible = True
            AnchoTotal += Titulou.Width + 5
        Else
            Titulou.Visible = False
        End If
        If TxtBuscaPorClave.Width <> 0 Then
            Otralinea = 35
            TxtBuscaPorClave.Location = New System.Drawing.Point(AnchoTotal, Posmenu + 5)
            TxtBuscaPorClave.UseOsThemes = UltraButton.UseOsThemes
            TxtBuscaPorClave.Visible = True
            AnchoTotal += TxtBuscaPorClave.Width + 5
        Else
            TxtBuscaPorClave.Visible = False
        End If
        Me.GrupoBotones.Controls.Add(Titulou)
        Me.GrupoBotones.Controls.Add(TxtBuscaPorClave)
        If Otralinea <> 0 Then
            AnchoTotal = 5
        End If
        For intI = 0 To intContador - 1
            cmdBoton = CType(alstBotones(intI), Infragistics.Win.Misc.UltraButton)
            cmdBoton.Width = Anchors + 10
            cmdBoton.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            If AnchoTotal + cmdBoton.Width + 5 > AnchoPantalla Then
                Otralinea += 35
                AnchoTotal = 5
            End If
            cmdBoton.Location = New System.Drawing.Point(AnchoTotal, Posmenu + Otralinea)
            AnchoTotal += cmdBoton.Width + 5
            AddHandler cmdBoton.Click, AddressOf EventoClick
            cmdBoton.Tag = "XX"
            Me.GrupoBotones.Controls.Add(cmdBoton)
        Next
        UltraButton.Visible = False
    End Sub

    Private Sub TxtBuscaPorClave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then   ' fin
            e.Handled = True
            TxtBuscaPorClave.Text = ""
            TxtBuscaPorClave.Focus()
        End If
        If TxtBuscaPorClave.Text <> "" Then
            If e.KeyChar = Convert.ToChar(Keys.Return) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
                e.Handled = True
                Menustext(TxtBuscaPorClave.Text)
                'TxtBuscaPorClave.Text = ""
                'TxtBuscaPorClave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtBuscaPorClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Key As String = ""
        Select Case e.KeyCode
            Case Keys.Escape
                Key = "ESC"
            Case Keys.F1
                Key = "F1"
            Case Keys.F2
                Key = "F2"
            Case Keys.F3
                Key = "F3"
            Case Keys.F4
                Key = "F4"
            Case Keys.F5
                Key = "F5"
            Case Keys.F6
                Key = "F6"
            Case Keys.F7
                Key = "F7"
            Case Keys.F8
                Key = "F8"
            Case Keys.F9
                Key = "F9"
            Case Keys.F10
                Key = "F10"
            Case Else
                Key = ""
        End Select
        If Len(Key) Then
            e.Handled = True
            Dim cmdBoton As New Infragistics.Win.Misc.UltraButton()
            Dim intI As Integer
            For intI = 0 To alstBotones.Count - 1
                cmdBoton = CType(alstBotones(intI), Infragistics.Win.Misc.UltraButton)
                If Mid(cmdBoton.Text, 1, Len(Key)) = Key Then
                    cmdBoton.Focus()
                    EventoClick(cmdBoton, e)
                    Exit For
                End If
            Next
        Else
            If TxtBuscaPorClave.Width <> 0 Then
                TxtBuscaPorClave.Focus()
                Dim x As Integer = TxtBuscaPorClave.Location.X - 3
                Dim y As Integer = TxtBuscaPorClave.Location.Y + 10
                Dim PuntoInicio As Point = Me.PointToScreen(New Point(x, y))
                System.Windows.Forms.Cursor.Position = PuntoInicio
            End If
        End If
    End Sub

    Private Sub EventoClick(ByVal Sender As System.Object, ByVal e As EventArgs)
        Dim Key As String = ""
        Dim Variable As String = CType(Sender, UltraButton).Text
        If InStr(Variable, "-") Then
            Key = Trim(Mid(Variable, 1, InStr(Variable, "-") - 1))
        End If
        MenusKeys(Key)
        If TxtBuscaPorClave.Width <> 0 Then
            TxtBuscaPorClave.Focus()
        End If
    End Sub

    Private Sub FormBtr_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub FormBtr_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'MessageBox.Show("You are in the Form.Shown event.")
        Me.Opacity = 100 'agregue

        'Me.Top = MeTop
        'Me.Left = MeLeft
        'Me.Width = MeWidth
        'Me.Height = MeHeight
        If Esingreso Then
            EnableForm()
            Numera()
            MenuIngresa()
        End If
    End Sub
End Class

Public Class Archivos
    Public Overloads Shared Function Show(ByRef Archivo As clsParametrosdeArchivo) As Integer
        Dim L As FormBtr = New FormBtr(Archivo)
        L.TopMost = True
        L.Focus()
        If L.ShowDialog() = DialogResult.OK Then
            Return True
        Else
            Return True
        End If
    End Function
    Public Overloads Shared Function Show(ByRef Archivo As clsParametrosdeArchivo, ByVal EsIngreso As Boolean, ByRef Ingresado As String) As Integer
        Dim L As FormBtr = New FormBtr(Archivo)
        L.Esingreso = True
        L.TopMost = True
        L.Focus()
        If L.ShowDialog() = DialogResult.OK Then
            Ingresado = L.IngresadoAutomatico
            Return True
        Else
            Ingresado = L.IngresadoAutomatico
            Return True
        End If
    End Function
End Class


