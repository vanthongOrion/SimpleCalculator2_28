Imports System.Text

Public Class Form1

    Private PlusOn As Boolean = False
    Private AbstractOn As Boolean = False
    Private MultipleOn As Boolean = False
    Private DivideOn As Boolean = False


    Private StringNum1 As String = ""
    Private StringNum2 As String = ""
    Private IntNum1 As Integer
    Private IntNum2 As Integer
    Private Result As Integer

    Private Sub Num1_Click(sender As Object, e As EventArgs) Handles Num1.Click
        Update("1")
    End Sub

    Private Sub Num2_Click(sender As Object, e As EventArgs) Handles Num2.Click
        Update("2")
    End Sub

    Private Sub Num3_Click(sender As Object, e As EventArgs) Handles Num3.Click
        Update("3")
    End Sub
    Private Sub Num4_Click(sender As Object, e As EventArgs) Handles Num4.Click
        Update("4")
    End Sub
    Private Sub Num5_Click(sender As Object, e As EventArgs) Handles Num5.Click
        Update("5")
    End Sub
    Private Sub Num6_Click(sender As Object, e As EventArgs) Handles Num6.Click
        Update("6")
    End Sub
    Private Sub Num7_Click(sender As Object, e As EventArgs) Handles Num7.Click
        Update("7")
    End Sub
    Private Sub Num8_Click(sender As Object, e As EventArgs) Handles Num8.Click
        Update("8")
    End Sub
    Private Sub Num9_Click(sender As Object, e As EventArgs) Handles Num9.Click
        Update("9")
    End Sub
    Private Sub Num0_Click(sender As Object, e As EventArgs) Handles Num0.Click
        Update("0")
    End Sub
    Private Sub Plus_Click(sender As Object, e As EventArgs) Handles Plus.Click
        If IntNum1 <> 0 Then
            If IntNum2 <> 0 Then
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            PlusOn = True

        ElseIf Result <> 0 Then
            PlusOn = True
            IntNum1 = Result
        End If
    End Sub

    Private Sub Abstract_Click(sender As Object, e As EventArgs) Handles Abstract.Click
        If IntNum1 <> 0 Then
            If IntNum2 <> 0 Then
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            AbstractOn = True

        ElseIf Result <> 0 Then
            AbstractOn = True
            IntNum1 = Result
        End If
    End Sub
    Private Sub Multiple_Click(sender As Object, e As EventArgs) Handles Multiple.Click
        If IntNum1 <> 0 Then
            If IntNum2 <> 0 Then
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            MultipleOn = True

        ElseIf Result <> 0 Then
            MultipleOn = True
            IntNum1 = Result
        End If
    End Sub
    Private Sub Divide_Click(sender As Object, e As EventArgs) Handles Divide.Click
        If IntNum1 <> 0 Then
            If IntNum2 <> 0 Then
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            DivideOn = True

        ElseIf Result <> 0 Then
            DivideOn = True
            IntNum1 = Result
        End If
    End Sub

    Private Sub Equal_Click(sender As Object, e As EventArgs) Handles Equal.Click
        Result = Calc(IntNum1, IntNum2)
    End Sub
    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        IntNum1 = 0
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""
        Result = 0
        PlusOn = False
        AbstractOn = False
        MultipleOn = False
        DivideOn = False
        Show(0)
    End Sub

    Private Sub Update(num As String)
        If PlusOn OrElse AbstractOn OrElse MultipleOn OrElse DivideOn Then
            StringNum2 += num
            IntNum2 = Integer.Parse(StringNum2)
            Show(IntNum2)
        Else
            StringNum1 += num
            IntNum1 = Integer.Parse(StringNum1)
            Show(IntNum1)
        End If
    End Sub

    Private Sub Show(result As Integer)
        Display.Text = result
        Debug.WriteLine("Plus On = " & PlusOn)
        Debug.WriteLine("Abstract On = " & AbstractOn)
        Debug.WriteLine("Multiple On = " & MultipleOn)
        Debug.WriteLine("Divide On = " & DivideOn)
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

        IntNum1 = 0
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""
        Show(Result)
        Return Result
    End Function
    Private Function ContinueCalc(Number1 As Integer, Number2 As Integer) As Integer
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

        IntNum1 = Result
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""
        Show(Result)
        Return Result
    End Function


End Class
