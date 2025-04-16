<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        btnDecrypt = New Button()
        btnEncrypt = New Button()
        SuspendLayout()
        ' 
        ' btnDecrypt
        ' 
        btnDecrypt.Anchor = AnchorStyles.None
        btnDecrypt.BackColor = Color.FromArgb(CByte(235), CByte(219), CByte(178))
        btnDecrypt.ForeColor = Color.FromArgb(CByte(27), CByte(27), CByte(27))
        btnDecrypt.Location = New Point(58, 144)
        btnDecrypt.Name = "btnDecrypt"
        btnDecrypt.Size = New Size(164, 36)
        btnDecrypt.TabIndex = 3
        btnDecrypt.Text = "فك التشفير"
        btnDecrypt.UseVisualStyleBackColor = False
        ' 
        ' btnEncrypt
        ' 
        btnEncrypt.Anchor = AnchorStyles.None
        btnEncrypt.BackColor = Color.FromArgb(CByte(235), CByte(219), CByte(178))
        btnEncrypt.ForeColor = Color.FromArgb(CByte(27), CByte(27), CByte(27))
        btnEncrypt.Location = New Point(58, 90)
        btnEncrypt.Name = "btnEncrypt"
        btnEncrypt.Size = New Size(164, 35)
        btnEncrypt.TabIndex = 2
        btnEncrypt.Text = "تشفير الملفات"
        btnEncrypt.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ClientSize = New Size(284, 261)
        Controls.Add(btnDecrypt)
        Controls.Add(btnEncrypt)
        Name = "Form2"
        Text = "تشفير ملفات"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnDecrypt As Button
    Friend WithEvents btnEncrypt As Button
End Class
