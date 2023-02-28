Imports System.Text

Public Class Form1

    Private NumClicked As Boolean = False
    Private ButtonClicked As Boolean = False

    Private NumBuild As StringBuilder = New StringBuilder()

    Private Sub Num1_Click(sender As Object, e As EventArgs) Handles Num1.Click
        NumClicked = True
        Update(1)
    End Sub

    Private Sub Num2_Click(sender As Object, e As EventArgs) Handles Num2.Click
        NumClicked = True
        Update(2)
    End Sub

    Private Sub Num3_Click(sender As Object, e As EventArgs) Handles Num3.Click
        NumClicked = True
        Update(3)
    End Sub
    Private Sub Num4_Click(sender As Object, e As EventArgs) Handles Num4.Click
        NumClicked = True
        Update(4)
    End Sub
    Private Sub Num5_Click(sender As Object, e As EventArgs) Handles Num5.Click
        NumClicked = True
        Update(5)
    End Sub
    Private Sub Num6_Click(sender As Object, e As EventArgs) Handles Num6.Click
        NumClicked = True
        Update(6)
    End Sub
    Private Sub Num7_Click(sender As Object, e As EventArgs) Handles Num7.Click
        NumClicked = True
        Update(7)
    End Sub
    Private Sub Num8_Click(sender As Object, e As EventArgs) Handles Num8.Click
        NumClicked = True
        Update(8)
    End Sub
    Private Sub Num9_Click(sender As Object, e As EventArgs) Handles Num9.Click
        NumClicked = True
        Update(9)
    End Sub
    Private Sub Num0_Click(sender As Object, e As EventArgs) Handles Num0.Click
        NumClicked = True
        Update(0)
    End Sub
    Private Sub Comma_Click(sender As Object, e As EventArgs) Handles Comma.Click
        NumClicked = True
        Update(",")
    End Sub


    Private Sub Update(num As String)
        NumBuild.Append(num)

        Display.Text = NumBuild.ToString().TrimStart("0")



    End Sub

End Class
