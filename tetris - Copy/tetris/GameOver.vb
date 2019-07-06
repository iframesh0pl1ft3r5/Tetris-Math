Imports System.ComponentModel

Public Class GameOver

    Dim score As String

    Private Sub GameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        score = TetrisGame.lblScore.Text
        YourScore.Text = score
        If Int(score) > Int(My.Settings.HighScore) Then
            My.Settings.HighScore = score
            My.Settings.Save()
        End If
        payerHighscore.Text = My.Settings.HighScore
        TetrisGame.Close()
    End Sub

    Private Sub GameOver_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.GameOver = False
        My.Settings.Save()
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles PlayAgain.Click
        TetrisGame.Show()
        TetrisGame.Button1_Click(sender, e)
        Me.Close()
    End Sub
End Class