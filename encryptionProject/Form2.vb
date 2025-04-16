Imports System.IO

Public Class Form2
    Dim encryptionKey() As Byte ' مفتاح التشفير

    ' زر تشفير الملفات
    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        Dim openKeyDialog As New OpenFileDialog()
        Dim openFilesDialog As New OpenFileDialog()

        ' اختيار ملف مفتاح التشفير
        openKeyDialog.Title = "حدد ملف مفتاح التشفير"
        If openKeyDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
        encryptionKey = My.Computer.FileSystem.ReadAllBytes(openKeyDialog.FileName)

        ' اختيار الملفات للتشفير
        openFilesDialog.Title = "حدد الملفات للتشفير"
        openFilesDialog.Multiselect = True
        If openFilesDialog.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each filePath In openFilesDialog.FileNames
            Dim fileBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(filePath)
            Dim encryptedBytes As Byte() = XORCipher(fileBytes, encryptionKey)
            Dim newFilePath As String = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) & "2" & Path.GetExtension(filePath))
            My.Computer.FileSystem.WriteAllBytes(newFilePath, encryptedBytes, False)
        Next

        MessageBox.Show("تم تشفير الملفات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' زر فك تشفير الملفات
    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        Dim openKeyDialog As New OpenFileDialog()
        Dim openFilesDialog As New OpenFileDialog()

        ' اختيار ملف مفتاح التشفير
        openKeyDialog.Title = "حدد ملف مفتاح التشفير"
        If openKeyDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
        encryptionKey = My.Computer.FileSystem.ReadAllBytes(openKeyDialog.FileName)

        ' اختيار الملفات لفك التشفير
        openFilesDialog.Title = "حدد الملفات المشفرة"
        openFilesDialog.Multiselect = True
        If openFilesDialog.ShowDialog() <> DialogResult.OK Then Exit Sub

        For Each filePath In openFilesDialog.FileNames
            Dim fileBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(filePath)
            Dim decryptedBytes As Byte() = XORCipher(fileBytes, encryptionKey)
            Dim newFilePath As String = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) & "3" & Path.GetExtension(filePath))
            My.Computer.FileSystem.WriteAllBytes(newFilePath, decryptedBytes, False)
        Next

        MessageBox.Show("تم فك تشفير الملفات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' دالة XOR للتشفير وفك التشفير
    Private Function XORCipher(data() As Byte, key() As Byte) As Byte()
        Dim output(data.Length - 1) As Byte
        For i As Integer = 0 To data.Length - 1
            output(i) = data(i) Xor key(i Mod key.Length)
        Next
        Return output
    End Function

End Class