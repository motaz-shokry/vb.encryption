Imports System.IO

Public Class Form1
    Dim hiddenFile() As Byte ' لتخزين الملف المخفي
    Dim carrierFile() As Byte ' لتخزين الملف الذي سيتم الإخفاء بداخله
    Dim marker As Byte() = System.Text.Encoding.UTF8.GetBytes("[HIDDEN_FILE]") ' علامة لتحديد بداية الملف المخفي

    ' زر إخفاء الملف
    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim openFileDialog2 As New OpenFileDialog()
        Dim saveFileDialog As New SaveFileDialog()

        ' تحديد الملف المخفي
        openFileDialog1.Title = "حدد الملف الذي تريد إخفاءه"
        If openFileDialog1.ShowDialog() <> DialogResult.OK Then Exit Sub
        hiddenFile = My.Computer.FileSystem.ReadAllBytes(openFileDialog1.FileName)

        ' تحديد الملف الحامل
        openFileDialog2.Title = "حدد الملف الذي سيتم الإخفاء بداخله"
        If openFileDialog2.ShowDialog() <> DialogResult.OK Then Exit Sub
        carrierFile = My.Computer.FileSystem.ReadAllBytes(openFileDialog2.FileName)

        ' Dim hiddenFileExtension As Byte() = System.Text.Encoding.UTF8.GetBytes("|EXT|" & Path.GetExtension(openFileDialog1.FileName)) ' استخراج الامتداد بالبايت
        ' Dim hiddenFileData As Byte() = marker.Concat(hiddenFile).Concat(hiddenFileExtension).ToArray() ' في حال كنت تريذ حفظ امتذاذ الملف المخفي
        Dim hiddenFileData As Byte() = marker.Concat(hiddenFile).ToArray()
        Dim finalData As Byte() = carrierFile.Concat(hiddenFileData).ToArray()

        ' حفظ الملف الجديد
        saveFileDialog.Title = "حفظ الملف بعد الإخفاء"
        saveFileDialog.Filter = "All Files|*.*"
        saveFileDialog.FileName = "hostFile" & Path.GetExtension(openFileDialog2.FileName)
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllBytes(saveFileDialog.FileName, finalData, False)
            MessageBox.Show("تم إخفاء الملف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        Dim openFileDialog As New OpenFileDialog()
        Dim saveFileDialog As New SaveFileDialog()

        ' اختيار الملف الذي يحتوي على الملف المخفي
        openFileDialog.Title = "حدد الملف الذي يحتوي على الملف المخفي"
        If openFileDialog.ShowDialog() <> DialogResult.OK Then Exit Sub
        Dim allBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(openFileDialog.FileName)

        ' البحث عن العلامة
        Dim indexMarker As Integer = FindMarker(allBytes, marker)
        If indexMarker = -1 Then
            MessageBox.Show("لم يتم العثور على ملف مخفي في هذا الملف!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim startIndex As Integer = indexMarker + marker.Length

        ' استخراج الامتداد
        ' Dim extMarker As Byte() = System.Text.Encoding.UTF8.GetBytes("|EXT|")
        ' Dim extIndex As Integer = FindMarker(allBytes, extMarker, startIndex)

        ' If extIndex = -1 Then
        '   MessageBox.Show("الامتداد غير موجود!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '   Exit Sub
        ' End If

        ' Dim extension As String = System.Text.Encoding.UTF8.GetString(allBytes.Skip(extIndex + extMarker.Length).TakeWhile(Function(b) b <> 0).ToArray())

        ' استخراج الملف المخفي
        ' Dim extractedBytes As Byte() = allBytes.Skip(startIndex).Take(extIndex - startIndex).ToArray() ' في حال كنت اضفت امتذاذ الملف المخفي
        Dim extractedBytes As Byte() = allBytes.Skip(startIndex).ToArray()

        ' حفظ الملف المستخرج
        saveFileDialog.Title = "حفظ الملف المستخرج"
        saveFileDialog.Filter = "All Files|*.*"
        saveFileDialog.FileName = "extractedFile"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllBytes(saveFileDialog.FileName, extractedBytes, False)
            MessageBox.Show("تم استخراج الملف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' دالة للبحث عن العلامة في مصفوفة البايت
    Private Function FindMarker(data As Byte(), marker As Byte(), Optional startIndex As Integer = 0) As Integer
        For i As Integer = startIndex To data.Length - marker.Length
            If data.Skip(i).Take(marker.Length).SequenceEqual(marker) Then
                Return i
            End If
        Next
        Return -1
    End Function

End Class

