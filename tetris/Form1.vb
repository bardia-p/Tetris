Public Class Form1
    Dim board(9, 19)
    Dim indicator As Integer
    Dim tx As Integer = 0
    Dim pos(4, 1) As Integer
    Dim spos(4, 1) As Integer
    Dim sy(3) As Integer
    Dim s1, s2 As Integer
    Dim newx(3) As Integer
    Dim newy(3) As Integer
    Dim speed As Integer = 1
    Dim t As Integer = 0
    Dim r As Integer = 1
    Dim col As Color
    Dim max_y As Integer = 19
    Dim flag As Integer = 0
    Dim flag2 As Integer = 0
    Dim flag3 As Integer = 0
    Dim flag4 As Integer = 0
    Dim flag5 As Integer = 0
    Dim flag6 As Integer = 0
    Dim flag7 As Integer = 0
    Dim flag8 As Integer = 0
    Dim flag9 As Integer = 0
    Dim flag10 As Integer = 0
    Dim k As Integer = 0
    Dim score As Integer = 0
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim myboard As Label
        For x = 0 To 9
            For y = 0 To 19
                myboard = New Label
                myboard.AutoSize = False
                myboard.Top = 30 + y * 30
                myboard.Left = 30 + x * 30
                myboard.Height = 30
                myboard.Width = 30
                myboard.BackColor = Color.LightGreen
                myboard.BorderStyle = BorderStyle.FixedSingle
                Controls.Add(myboard)
                board(x, y) = myboard
            Next
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Left And pos(0, 0) > 0 And pos(1, 0) > 0 And pos(2, 0) > 0 And pos(3, 0) > 0 Then
            For i = 0 To 3
                If board(pos(i, 0) - 1, pos(i, 1)).tag = 1 Then
                    flag2 = 1
                End If
            Next
            If flag2 = 0 And k = 0 Then
                For i = 0 To 4
                    spos(i, 0) = pos(i, 0)
                    spos(i, 1) = pos(i, 1) - 1
                    pos(i, 0) -= 1
                Next
            End If
            k = 1
        ElseIf e.KeyCode = Keys.Right And pos(0, 0) < 9 And pos(1, 0) < 9 And pos(2, 0) < 9 And pos(3, 0) < 9 Then
            For i = 0 To 3
                If board(pos(i, 0) + 1, pos(i, 1)).tag = 1 Then
                    flag3 = 1
                End If
            Next
            If flag3 = 0 And k = 0 Then
                For i = 0 To 4
                    spos(i, 0) = pos(i, 0)
                    spos(i, 1) = pos(i, 1) - 1
                    pos(i, 0) += 1
                Next
            End If
            k = 2
        ElseIf e.KeyCode = Keys.Down And Timer1.Interval > 1 And flag = 0 And pos(0, 1) > 3 Then
            flag5 = 1
            Timer1.Interval /= 2
        ElseIf e.KeyCode = Keys.Up Then
            r += 1
            If r > 4 Then
                r = 1
            End If
            If indicator <> 3 And pos(0, 1) > 1 Then
                For i = 0 To 3
                    s1 = pos(i, 1) - pos(4, 1)
                    s2 = pos(4, 0) - pos(i, 0)
                    newx(i) = pos(4, 0) - s1
                    newy(i) = pos(4, 1) - s2
                    If newx(i) < 0 Then
                        If 0 - newx(i) > flag9 Then
                            flag9 = 0 - newx(i)
                        End If
                    ElseIf newx(i) > 9 Then
                        If newx(i) - 9 > flag10 Then
                            flag10 = newx(i) - 9
                        End If
                    End If
                        If newy(i) < 0 Or newy(i) > 19 Then
                        flag6 = 1
                    ElseIf flag9 = 0 And flag10 = 0 Then
                        If board(newx(i), newy(i)).tag = 1 Then
                            flag6 = 1
                        End If
                    End If
                Next
                If flag6 = 0 Then
                    If flag9 <> 0 Then
                        For i = 0 To 3
                            newx(i) += flag9
                            If board(newx(i), newy(i)).tag = 1 Then
                                flag6 = 1
                            End If
                        Next
                        flag9 = 0
                    ElseIf flag10 <> 0 Then
                        For i = 0 To 3
                            newx(i) -= flag10
                            If board(newx(i), newy(i)).tag = 1 Then
                                flag6 = 1
                            End If
                        Next
                        flag10 = 0
                    End If
                End If
                If flag6 = 0 Then
                    For i = 0 To 3
                        pos(i, 0) = newx(i)
                        pos(i, 1) = newy(i)
                    Next
                ElseIf flag6 = 1 Then
                    flag6 = 0
                End If
            End If
        End If
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Randomize()
        Label5.Text = t
        Label6.Text = score
        If t Mod 2 = 0 Then
            k = 0
            If pos(0, 1) > 0 Then
                For i = 0 To 3
                    board(spos(i, 0), spos(i, 1)).backcolor = Color.LightGreen
                Next
            ElseIf flag2 = 1 Or flag3 = 1 Then
                flag2 = 0
                flag3 = 0
            End If
            If pos(0, 1) = 0 Then
                flag5 = 0
                Timer1.Interval = 250
                tx = Int(Rnd() * 7)
                indicator = Int(Rnd() * 7)
                While indicator = 7
                    indicator = Int(Rnd() * 7)
                End While
                If indicator = 0 Then
                    col = Color.Red
                    pos(0, 0) = tx
                    pos(0, 1) = 0
                    pos(1, 0) = tx + 1
                    pos(1, 1) = 0
                    pos(2, 0) = tx + 2
                    pos(2, 1) = 0
                    pos(3, 0) = tx + 3
                    pos(3, 1) = 0
                    pos(4, 0) = tx + 1
                    pos(4, 1) = 0
                ElseIf indicator = 1 Then
                    col = Color.Purple
                    pos(0, 0) = tx + 2
                    pos(0, 1) = 0
                    pos(1, 0) = tx
                    pos(1, 1) = 1
                    pos(2, 0) = tx + 1
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 2
                    pos(3, 1) = 1
                    pos(4, 0) = tx + 2
                    pos(4, 1) = 1
                ElseIf indicator = 2 Then
                    col = Color.Green
                    pos(0, 0) = tx
                    pos(0, 1) = 0
                    pos(1, 0) = tx
                    pos(1, 1) = 1
                    pos(2, 0) = tx + 1
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 2
                    pos(3, 1) = 1
                    pos(4, 0) = tx
                    pos(4, 1) = 0
                ElseIf indicator = 3 Then
                    col = Color.Pink
                    pos(0, 0) = tx
                    pos(0, 1) = 0
                    pos(1, 0) = tx + 1
                    pos(1, 1) = 0
                    pos(2, 0) = tx
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 1
                    pos(3, 1) = 1
                ElseIf indicator = 4 Then
                    col = Color.Orange
                    pos(0, 0) = tx + 1
                    pos(0, 1) = 0
                    pos(1, 0) = tx + 2
                    pos(1, 1) = 0
                    pos(2, 0) = tx
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 1
                    pos(3, 1) = 1
                    pos(4, 0) = tx + 1
                    pos(4, 1) = 0
                ElseIf indicator = 5 Then
                    col = Color.Yellow
                    pos(0, 0) = tx
                    pos(0, 1) = 0
                    pos(1, 0) = tx + 1
                    pos(1, 1) = 0
                    pos(2, 0) = tx + 1
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 2
                    pos(3, 1) = 1
                    pos(4, 0) = tx + 1
                    pos(4, 1) = 0
                ElseIf indicator = 6 Then
                    col = Color.LightCoral
                    pos(0, 0) = tx + 1
                    pos(0, 1) = 0
                    pos(1, 0) = tx
                    pos(1, 1) = 1
                    pos(2, 0) = tx + 1
                    pos(2, 1) = 1
                    pos(3, 0) = tx + 2
                    pos(3, 1) = 1
                    pos(4, 0) = tx + 1
                    pos(4, 1) = 1
                End If
            End If
            For i = 0 To 3
                board(pos(i, 0), pos(i, 1)).backcolor = col
            Next
            If pos(0, 1) = max_y Or pos(1, 1) = max_y Or pos(2, 1) = max_y Or pos(3, 1) = max_y Then
                flag = 1
            Else
                For j = 0 To 3
                    If board(pos(j, 0), pos(j, 1) + 1).tag = 1 Then
                        flag = 1
                        j = 3
                    End If
                Next
            End If
            If flag = 1 Then
                flag2 = 1
                flag3 = 1
                If pos(0, 1) = 0 Then
                    If flag8 = 0 Then
                        Timer1.Stop()
                        MsgBox("Game over!" + vbCrLf + "Your score is:" + Str(score))
                        Me.Close()
                        flag8 = 1
                    End If
                End If
                For i = 0 To 3
                    board(pos(i, 0), pos(i, 1)).tag = 1
                    sy(i) = pos(i, 1)
                    pos(i, 1) = 0
                Next
                For l = sy(0) To 19
                    For jj = 0 To 9
                        If board(jj, l).tag = 0 Then
                            flag4 = 1
                            jj = 9
                        End If
                    Next
                    If flag4 = 0 Then
                        score += 1
                        If score Mod 2 = 0 And Timer1.Interval > 10 Then
                            Timer1.Interval -= 10
                        End If
                        For j = 0 To 9
                            If board(j, l).tag = 1 Then
                                board(j, l).tag = 0
                                board(j, l).backcolor = Color.LightGreen
                            End If
                        Next

                        For i = l To 1 Step -1
                            For j = 0 To 9
                                If board(j, i - 1).tag = 1 Then
                                    board(j, i).tag = 1
                                    board(j, i).backcolor = board(j, i - 1).backcolor
                                    board(j, i - 1).tag = 0
                                    board(j, i - 1).backcolor = Color.LightGreen
                                End If
                            Next
                        Next
                    Else
                        flag4 = 0
                    End If
                Next
                flag = 0
            ElseIf flag = 0 Then
                For i = 0 To 4
                    spos(i, 0) = pos(i, 0)
                    spos(i, 1) = pos(i, 1)
                    pos(i, 1) += speed
                Next
            End If
            t += 1
        ElseIf t Mod 2 = 1 Then
            t += 1
        End If
    End Sub

End Class
