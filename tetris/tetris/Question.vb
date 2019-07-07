Imports System.ComponentModel

Public Class Question
    Public userClose As Boolean = True
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Dim RealAnswer As Decimal
        Dim TheirAnswer As Integer
        Select Case symbol
            Case 1
                RealAnswer = partOne + partTwo
            Case 2
                RealAnswer = partOne - partTwo
            Case 3
                RealAnswer = partOne * partTwo
            Case 4
                RealAnswer = partOne / partTwo
            Case 5
                RealAnswer = partOne * partTwo
            Case 6
                RealAnswer = partOne / partTwo
        End Select
        RealAnswer = Math.Round(RealAnswer)
        Try
            TheirAnswer = Int(answer.Text)
            If TheirAnswer = RealAnswer Then
                My.Settings.askingQuestion = False
                My.Settings.Save()
                TetrisGame.Show()
                userClose = False
                Me.Close()
            Else
                response.Text = "Your answer is incorrect"
            End If
        Catch ex As Exception
            response.Text = "Please enter a valid answer"
        End Try
    End Sub

    Dim symbol As Integer
    Dim partOne As Integer
    Dim partTwo As Integer

    Private Sub Question_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        symbol = CInt(Int((6 * Rnd()) + 1))
        Randomize()
        partOne = CInt(Math.Floor(((Int(TetrisGame.lblScore.Text) + 25)) * Rnd())) + 1
        partTwo = CInt(Math.Floor(((Int(TetrisGame.lblScore.Text) + 25)) * Rnd())) + 1
        Dim symbolAsString As String
        Select Case symbol
            Case 1
                symbolAsString = "+"
            Case 2
                symbolAsString = "-"
            Case 3
                symbolAsString = "×"
            Case 4
                symbolAsString = "÷"
            Case 5
                symbolAsString = "×"
            Case 6
                symbolAsString = "÷"
        End Select
        Label1.Text = partOne.ToString + " " + symbolAsString + " " + partTwo.ToString
    End Sub

    Private Sub Question_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If userClose = True Then
            Application.Exit()
        End If
        TetrisGame.game.timerStart()
    End Sub
End Class