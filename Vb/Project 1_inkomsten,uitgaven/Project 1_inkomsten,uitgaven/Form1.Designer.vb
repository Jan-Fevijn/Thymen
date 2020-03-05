<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnInvoegen = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblLijn = New System.Windows.Forms.Label()
        Me.dtgDataveld = New System.Windows.Forms.DataGridView()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bedrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uitgave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpTijd = New System.Windows.Forms.DateTimePicker()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.cbAdmin = New System.Windows.Forms.CheckBox()
        Me.numBedrag = New System.Windows.Forms.TextBox()
        Me.lblBedrag = New System.Windows.Forms.Label()
        Me.lblNieweC = New System.Windows.Forms.Label()
        Me.btnCodesWeergeven = New System.Windows.Forms.Button()
        Me.btnCodeMaken = New System.Windows.Forms.Button()
        Me.txtCodeNaam = New System.Windows.Forms.TextBox()
        Me.txtCodeID = New System.Windows.Forms.TextBox()
        Me.cbUitgave = New System.Windows.Forms.CheckBox()
        Me.lblCodeID = New System.Windows.Forms.Label()
        Me.lblNaam = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.dtgDataveld, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInvoegen
        '
        Me.btnInvoegen.Location = New System.Drawing.Point(197, 35)
        Me.btnInvoegen.Name = "btnInvoegen"
        Me.btnInvoegen.Size = New System.Drawing.Size(75, 23)
        Me.btnInvoegen.TabIndex = 0
        Me.btnInvoegen.Text = "Invoegen"
        Me.btnInvoegen.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(184, 12)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(88, 20)
        Me.txtCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Code:"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(175, 61)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 4
        Me.btnImport.Text = "Importeren"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(94, 61)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Exporteren"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'lblLijn
        '
        Me.lblLijn.AutoSize = True
        Me.lblLijn.Location = New System.Drawing.Point(1, 87)
        Me.lblLijn.Name = "lblLijn"
        Me.lblLijn.Size = New System.Drawing.Size(283, 13)
        Me.lblLijn.TabIndex = 6
        Me.lblLijn.Text = "______________________________________________"
        '
        'dtgDataveld
        '
        Me.dtgDataveld.AllowUserToAddRows = False
        Me.dtgDataveld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDataveld.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Datum, Me.Bedrag, Me.Uitgave, Me.Code})
        Me.dtgDataveld.Location = New System.Drawing.Point(12, 115)
        Me.dtgDataveld.Name = "dtgDataveld"
        Me.dtgDataveld.ReadOnly = True
        Me.dtgDataveld.Size = New System.Drawing.Size(443, 150)
        Me.dtgDataveld.TabIndex = 8
        '
        'Datum
        '
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        '
        'Bedrag
        '
        Me.Bedrag.HeaderText = "Bedrag"
        Me.Bedrag.Name = "Bedrag"
        Me.Bedrag.ReadOnly = True
        '
        'Uitgave
        '
        Me.Uitgave.HeaderText = "Uitgave"
        Me.Uitgave.Name = "Uitgave"
        Me.Uitgave.ReadOnly = True
        '
        'Code
        '
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'dtpTijd
        '
        Me.dtpTijd.Location = New System.Drawing.Point(13, 35)
        Me.dtpTijd.Name = "dtpTijd"
        Me.dtpTijd.Size = New System.Drawing.Size(167, 20)
        Me.dtpTijd.TabIndex = 9
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(13, 271)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 10
        Me.btnRefresh.Text = "Herladen"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(13, 61)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(75, 23)
        Me.btnOpslaan.TabIndex = 11
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'cbAdmin
        '
        Me.cbAdmin.AutoSize = True
        Me.cbAdmin.Location = New System.Drawing.Point(256, 65)
        Me.cbAdmin.Name = "cbAdmin"
        Me.cbAdmin.Size = New System.Drawing.Size(32, 17)
        Me.cbAdmin.TabIndex = 12
        Me.cbAdmin.Text = "+"
        Me.cbAdmin.UseVisualStyleBackColor = True
        '
        'numBedrag
        '
        Me.numBedrag.Location = New System.Drawing.Point(62, 12)
        Me.numBedrag.Name = "numBedrag"
        Me.numBedrag.Size = New System.Drawing.Size(75, 20)
        Me.numBedrag.TabIndex = 13
        '
        'lblBedrag
        '
        Me.lblBedrag.AutoSize = True
        Me.lblBedrag.Location = New System.Drawing.Point(12, 15)
        Me.lblBedrag.Name = "lblBedrag"
        Me.lblBedrag.Size = New System.Drawing.Size(44, 13)
        Me.lblBedrag.TabIndex = 14
        Me.lblBedrag.Text = "Bedrag:"
        '
        'lblNieweC
        '
        Me.lblNieweC.AutoSize = True
        Me.lblNieweC.Location = New System.Drawing.Point(291, 6)
        Me.lblNieweC.Name = "lblNieweC"
        Me.lblNieweC.Size = New System.Drawing.Size(126, 13)
        Me.lblNieweC.TabIndex = 15
        Me.lblNieweC.Text = "Nieuwe code aanmaken:"
        '
        'btnCodesWeergeven
        '
        Me.btnCodesWeergeven.Location = New System.Drawing.Point(294, 87)
        Me.btnCodesWeergeven.Name = "btnCodesWeergeven"
        Me.btnCodesWeergeven.Size = New System.Drawing.Size(159, 23)
        Me.btnCodesWeergeven.TabIndex = 16
        Me.btnCodesWeergeven.Text = "Bestaande codes Weergeven"
        Me.btnCodesWeergeven.UseVisualStyleBackColor = True
        '
        'btnCodeMaken
        '
        Me.btnCodeMaken.Location = New System.Drawing.Point(378, 64)
        Me.btnCodeMaken.Name = "btnCodeMaken"
        Me.btnCodeMaken.Size = New System.Drawing.Size(75, 22)
        Me.btnCodeMaken.TabIndex = 17
        Me.btnCodeMaken.Text = "Code maken"
        Me.btnCodeMaken.UseVisualStyleBackColor = True
        '
        'txtCodeNaam
        '
        Me.txtCodeNaam.Location = New System.Drawing.Point(345, 22)
        Me.txtCodeNaam.Name = "txtCodeNaam"
        Me.txtCodeNaam.Size = New System.Drawing.Size(108, 20)
        Me.txtCodeNaam.TabIndex = 18
        '
        'txtCodeID
        '
        Me.txtCodeID.Location = New System.Drawing.Point(345, 43)
        Me.txtCodeID.Name = "txtCodeID"
        Me.txtCodeID.Size = New System.Drawing.Size(108, 20)
        Me.txtCodeID.TabIndex = 19
        '
        'cbUitgave
        '
        Me.cbUitgave.AutoSize = True
        Me.cbUitgave.Location = New System.Drawing.Point(294, 65)
        Me.cbUitgave.Name = "cbUitgave"
        Me.cbUitgave.Size = New System.Drawing.Size(73, 17)
        Me.cbUitgave.TabIndex = 20
        Me.cbUitgave.Text = "uitgaven?"
        Me.cbUitgave.UseVisualStyleBackColor = True
        '
        'lblCodeID
        '
        Me.lblCodeID.AutoSize = True
        Me.lblCodeID.Location = New System.Drawing.Point(291, 46)
        Me.lblCodeID.Name = "lblCodeID"
        Me.lblCodeID.Size = New System.Drawing.Size(46, 13)
        Me.lblCodeID.TabIndex = 21
        Me.lblCodeID.Text = "CodeID:"
        '
        'lblNaam
        '
        Me.lblNaam.AutoSize = True
        Me.lblNaam.Location = New System.Drawing.Point(291, 25)
        Me.lblNaam.Name = "lblNaam"
        Me.lblNaam.Size = New System.Drawing.Size(38, 13)
        Me.lblNaam.TabIndex = 22
        Me.lblNaam.Text = "Naam:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 300)
        Me.Controls.Add(Me.lblNaam)
        Me.Controls.Add(Me.lblCodeID)
        Me.Controls.Add(Me.cbUitgave)
        Me.Controls.Add(Me.txtCodeID)
        Me.Controls.Add(Me.txtCodeNaam)
        Me.Controls.Add(Me.btnCodeMaken)
        Me.Controls.Add(Me.btnCodesWeergeven)
        Me.Controls.Add(Me.lblNieweC)
        Me.Controls.Add(Me.lblBedrag)
        Me.Controls.Add(Me.numBedrag)
        Me.Controls.Add(Me.cbAdmin)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtpTijd)
        Me.Controls.Add(Me.dtgDataveld)
        Me.Controls.Add(Me.lblLijn)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.btnInvoegen)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dtgDataveld, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInvoegen As Button
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents lblLijn As Label
    Friend WithEvents dtgDataveld As DataGridView
    Friend WithEvents dtpTijd As DateTimePicker
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnOpslaan As Button
    Friend WithEvents Datum As DataGridViewTextBoxColumn
    Friend WithEvents Bedrag As DataGridViewTextBoxColumn
    Friend WithEvents Uitgave As DataGridViewTextBoxColumn
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents cbAdmin As CheckBox
    Friend WithEvents numBedrag As TextBox
    Friend WithEvents lblBedrag As Label
    Friend WithEvents lblNieweC As Label
    Friend WithEvents btnCodesWeergeven As Button
    Friend WithEvents btnCodeMaken As Button
    Friend WithEvents txtCodeNaam As TextBox
    Friend WithEvents txtCodeID As TextBox
    Friend WithEvents cbUitgave As CheckBox
    Friend WithEvents lblCodeID As Label
    Friend WithEvents lblNaam As Label
    Friend WithEvents lblAuto As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
