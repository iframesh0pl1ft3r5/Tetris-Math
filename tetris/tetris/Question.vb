Imports System.ComponentModel

Public Class Question
    Dim userClose As Boolean = True
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        My.Settings.askingQuestion = False
        My.Settings.Save()
        TetrisGame.Show()
        userClose = False
        Me.Close()
    End Sub

    Private Sub Question_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Question_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If userClose = True Then
            Application.Exit()
        End If
        TetrisGame.game.timerStart()
    End Sub
End Class