Imports System.ComponentModel

Public Class Question
    Public userClose As Boolean = True

    Dim wrongcounter As Integer = 0

    ' checks to see if the answer given is correct, if it isnt then adds one to the wrong counter and if that counter reaches 5 then displays the game over form
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        ' converts the answer to a whole number
        RealAnswer = Math.Round(RealAnswer)

        Try
            TheirAnswer = Int(answer.Text)
            If TheirAnswer = RealAnswer Then
                If wrongcounter >= 5 Then
                    userClose = False
                    GameOver.Show()
                    Me.Close()
                End If
                My.Settings.askingQuestion = False
                My.Settings.Save()
                TetrisGame.Show()
                userClose = False
                Me.Close()
            Else
                Dim score As String = Int(Int(TetrisGame.lblScore.Text) - 10)
                response.Text = "Your answer is incorrect. You have lost 10 points from your score"
                wrongcounter = wrongcounter + 1
                If Int(TetrisGame.lblScore.Text) - 10 < 0 Then
                    response.Text = "Your answer is incorrect."
                Else
                    If score.Length = 0 Then
                        Debug.WriteLine("00000" + score)
                        TetrisGame.lblScore.Text = "00000" + score
                    ElseIf score.Length = 1 Then
                        Debug.WriteLine("0000" + score)
                        TetrisGame.lblScore.Text = "0000" + score
                    ElseIf score.Length = 2 Then
                        Debug.WriteLine("000" + score)
                        TetrisGame.lblScore.Text = "000" + score
                    ElseIf score.Length = 3 Then
                        Debug.WriteLine("00" + score)
                        TetrisGame.lblScore.Text = "00" + score
                    ElseIf score.Length = 4 Then
                        Debug.WriteLine("0" + score)
                        TetrisGame.lblScore.Text = "0" + score
                    ElseIf score.Length = 5 Then
                        Debug.WriteLine(score)
                        TetrisGame.lblScore.Text = score
                    End If
                End If
            End If
        Catch ex As Exception
            response.Text = "Please enter a valid answer"
        End Try
        If wrongcounter >= 5 Then
            userClose = False
            GameOver.Show()
            Me.Close()
        End If
    End Sub

    Dim symbol As Integer
    Dim partOne As Integer
    Dim partTwo As Integer
    Dim symbolAsString As String

    ' randomly genorates the question. the higher the score the bigger the values the question is. (upper bound of the randomisers are the score + 25)
    Private Sub Question_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        symbol = CInt(Int((6 * Rnd()) + 1))
        Randomize()
        symbol = 4
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
        Do
            partOne = CInt(Math.Floor(((Int(TetrisGame.lblScore.Text) + 25)) * Rnd())) + 1
            partTwo = CInt(Math.Floor(((Int(TetrisGame.lblScore.Text) + 25)) * Rnd())) + 1
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
            Debug.WriteLine(RealAnswer)
            Label1.Text = partOne.ToString + " " + symbolAsString + " " + partTwo.ToString
        Loop Until Math.Round(RealAnswer) = RealAnswer
    End Sub

    ' if the user closes the form end the program. Or if the question has been answered resume the game.
    Private Sub Question_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If userClose = True Then
            Application.Exit()
        End If
        TetrisGame.game.timerStart()
    End Sub

    Dim RealAnswer As Decimal
    Dim TheirAnswer As Integer
End Class