Imports System.ComponentModel
Imports System.IO.Compression
Public Class Welcome

    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.GameOver = False
        My.Settings.Save()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ifs-tune.zip") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ifs-tune.zip")
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ifs-tune.wav") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ifs-tune.wav")
        End If
        savefromresources(Application.StartupPath & "\ifs-tune.zip", My.Resources.ifs_tune)
        ZipFile.ExtractToDirectory(Application.StartupPath & "\ifs-tune.zip", Application.StartupPath & "\")
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ifs-tune.zip") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ifs-tune.zip")
        End If
        My.Computer.Audio.Play(Application.StartupPath & "\ifs-tune.wav")
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        TetrisGame.Show()
        TetrisGame.Button1_Click(sender, e)
        Me.Close()
    End Sub

    Public Sub savefromresources(ByVal FilePath As String, ByVal File As Object)
        Dim FByte() As Byte = File
        My.Computer.FileSystem.WriteAllBytes(FilePath, FByte, True)
    End Sub

    Private Sub Welcome_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ifs-tune.wav") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ifs-tune.wav")
        End If
    End Sub
End Class