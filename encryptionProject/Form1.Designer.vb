<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnHide = New Button()
        btnExtract = New Button()
        SuspendLayout()
        ' 
        ' btnHide
        ' 
        btnHide.Anchor = AnchorStyles.None
        btnHide.BackColor = Color.FromArgb(CByte(235), CByte(219), CByte(178))
        btnHide.ForeColor = Color.FromArgb(CByte(27), CByte(27), CByte(27))
        btnHide.Location = New Point(69, 91)
        btnHide.Name = "btnHide"
        btnHide.Size = New Size(164, 32)
        btnHide.TabIndex = 0
        btnHide.Text = "حدد الملف المرفق والمضيف"
        btnHide.UseVisualStyleBackColor = False
        ' 
        ' btnExtract
        ' 
        btnExtract.Anchor = AnchorStyles.None
        btnExtract.BackColor = Color.FromArgb(CByte(235), CByte(219), CByte(178))
        btnExtract.ForeColor = Color.FromArgb(CByte(27), CByte(27), CByte(27))
        btnExtract.Location = New Point(69, 144)
        btnExtract.Name = "btnExtract"
        btnExtract.Size = New Size(164, 30)
        btnExtract.TabIndex = 1
        btnExtract.Text = "جلب الملف المرفق وحفظه"
        btnExtract.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ClientSize = New Size(284, 261)
        Controls.Add(btnExtract)
        Controls.Add(btnHide)
        Name = "Form1"
        Text = "إخفاء ملف"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnHide As Button
    Friend WithEvents btnExtract As Button

End Class
