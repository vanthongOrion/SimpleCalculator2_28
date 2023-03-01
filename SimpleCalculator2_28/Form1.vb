Imports System.Text

Public Class Form1

    Private NumClicked As Boolean = False
    Private ButtonClicked As Boolean = False
    Private PlusOn As Boolean = False
    Private AbstractOn As Boolean = False
    Private MultipleOn As Boolean = False
    Private DivideOn As Boolean = False


    Private InputNum1 As String = "0"
    Private InputNum2 As String = "0"
    Private Result As Integer

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
    Private Sub Plus_Click(sender As Object, e As EventArgs) Handles Plus.Click
        If Not (InputNum1 = "0" OrElse Result = 0) Then
            PlusOn = True
            If InputNum2 <> 0 Then
                Result = Calc(Integer.Parse(InputNum1), Integer.Parse(InputNum2))
            End If
        End If
    End Sub

    Private Sub Abstract_Click(sender As Object, e As EventArgs) Handles Abstract.Click
        If Not (InputNum1 = "0" OrElse Result = 0) Then
            AbstractOn = True
        End If
    End Sub
    Private Sub Multiple_Click(sender As Object, e As EventArgs) Handles Multiple.Click
        If Not (InputNum1 = "0" OrElse Result = 0) Then
            MultipleOn = True
        End If
    End Sub
    Private Sub Divide_Click(sender As Object, e As EventArgs) Handles Divide.Click
        If Not (InputNum1 = "0" OrElse Result = 0) Then
            DivideOn = True
        End If
    End Sub

    Private Sub Equal_Click(sender As Object, e As EventArgs) Handles Equal.Click
        Result = Calc(Integer.Parse(InputNum1), Integer.Parse(InputNum2))
    End Sub

    Private Sub Update(num As String)
        Debug.Write("out" & vbCrLf)
        If Result = Nothing Then
            Debug.Write("in" & vbCrLf)
            If PlusOn OrElse AbstractOn OrElse MultipleOn OrElse DivideOn Then
                Debug.Write("First Block" & vbCrLf)
                InputNum2 += num
                Show(InputNum2.TrimStart("0"))
            Else
                Debug.Write("Second Block" & vbCrLf)
                InputNum1 += num
                Show(InputNum1.TrimStart("0"))
            End If
        Else
            If PlusOn OrElse AbstractOn OrElse MultipleOn OrElse DivideOn Then
                InputNum1 = Result.ToString()
                Result = 0
                InputNum2 += num
                Show(InputNum2.TrimStart("0"))
            Else
                InputNum1 += num
                Show(InputNum1.TrimStart("0"))
            End If
        End If

    End Sub

    Private Sub Show(result As String)
        Display.Text = result
    End Sub

    Private Function Calc(Number1 As Integer, Number2 As Integer) As Integer
        Dim Result As Integer
        If PlusOn Then
            Result = Number1 + Number2
            PlusOn = False
        End If

        If AbstractOn Then
            Result = Number1 - Number2
            AbstractOn = False
        End If

        If MultipleOn Then
            Result = Number1 * Number2
            MultipleOn = False
        End If

        If DivideOn Then
            Result = Number1 / Number2
            DivideOn = False
        End If

        InputNum1 = ""
        InputNum2 = ""
        Show(Result)
        Return Result
    End Function




End Class
