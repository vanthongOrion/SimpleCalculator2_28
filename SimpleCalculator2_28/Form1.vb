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
    Private PreviousKey As Char
    Private PreviousNum2 As Integer
    Private CountEqual As Integer = 0
    Private Result As Integer

    Private Sub NumberClick(sender As Object, e As KeyPressEventArgs) Handles Num0.Click, Num1.Click, Num2.Click, Num3.Click,
            Num4.Click, Num5.Click, Num6.Click, Num7.Click, Num8.Click, Num9.Click, MyBase.KeyPress
        Debug.WriteLine(e.KeyChar)

        If sender Is Num0 OrElse e.KeyChar = "0" Then
            Update("0")

        ElseIf sender Is Num1 OrElse e.KeyChar = "1" Then
            Update("1")

        ElseIf sender Is Num2 OrElse e.KeyChar = "2" Then
            Update("2")

        ElseIf sender Is Num3 OrElse e.KeyChar = "3" Then
            Update("3")

        ElseIf sender Is Num4 OrElse e.KeyChar = "4" Then
            Update("4")

        ElseIf sender Is Num5 OrElse e.KeyChar = "5" Then
            Update("5")

        ElseIf sender Is Num6 OrElse e.KeyChar = "6" Then
            Update("6")

        ElseIf sender Is Num7 OrElse e.KeyChar = "7" Then
            Update("7")

        ElseIf sender Is Num8 OrElse e.KeyChar = "8" Then
            Update("8")

        ElseIf sender Is Num9 OrElse e.KeyChar = "9" Then
            Update("9")

        End If

    End Sub

    Private Sub CalcButtonClick(sender As Object, e As KeyPressEventArgs) Handles Plus.Click, Abstract.Click, Multiple.Click, Divide.Click
        CountEqual = 0
        ' Input Number 1 があった場合　
        If IntNum1 <> 0 Then
            ' 2回目のNumberはすでに入力された場合
            If IntNum2 <> 0 Then
                ' 続けて計算する
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            ' Turn On スイッチ
            TurnOn(sender, e)

            ' Equal Event 計算後に続けて計算する
        ElseIf Result <> 0 Then
            ' Turn On スイッチ
            TurnOn(sender, e)
            ' Num1 は　前の結果に代入する
            IntNum1 = Result
        End If
    End Sub

    Private Sub Equal_Click(sender As Object, e As EventArgs) Handles Equal.Click
        '　結果を出す
        CountEqual += 1
        If CountEqual = 2 AndAlso Result <> 0 Then
            IntNum1 = Result
            IntNum2 = PreviousNum2
            CountEqual -= 1

            Select Case PreviousKey
                Case "P"
                    PlusOn = True

                Case "A"
                    AbstractOn = True

                Case "M"
                    MultipleOn = True

                Case "D"
                    DivideOn = True

                Case Else
                    Debug.WriteLine("Invalid Previous Key Value At Line 155")
            End Select

            Result = Calc(IntNum1, IntNum2)
        Else
            Result = Calc(IntNum1, IntNum2)
        End If
    End Sub
    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        IntNum1 = 0
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""
        Result = 0
        PreviousKey = ""
        PreviousNum2 = 0

        PlusOn = False
        AbstractOn = False
        MultipleOn = False
        DivideOn = False
        Show(0)
    End Sub

    Private Sub Update(num As String)
        ' いずれのスイッチはONにした場合
        If PlusOn OrElse AbstractOn OrElse MultipleOn OrElse DivideOn Then
            StringNum2 += num
            IntNum2 = Integer.Parse(StringNum2)
            Show(IntNum2)

            ' そうではなかった場合
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
        ' スイッチPlusはONした場合
        If PlusOn Then
            Result = Number1 + Number2
            PreviousKey = "P"
            PlusOn = False
        End If

        ' スイッチAbstractはONした場合
        If AbstractOn Then
            Result = Number1 - Number2
            PreviousKey = "A"
            AbstractOn = False
        End If

        ' スイッチMultipleはONした場合
        If MultipleOn Then
            Result = Number1 * Number2
            PreviousKey = "M"
            MultipleOn = False
        End If

        ' スイッチDivideはONした場合
        If DivideOn Then
            Result = Number1 / Number2
            PreviousKey = "D"
            DivideOn = False
        End If

        ' 初期化する
        IntNum1 = 0
        StringNum1 = ""

        PreviousNum2 = IntNum2
        IntNum2 = 0
        StringNum2 = ""

        Show(Result)
        Return Result
    End Function
    Private Function ContinueCalc(Number1 As Integer, Number2 As Integer) As Integer
        Dim Result As Integer
        ' スイッチPlusはONにした場合
        If PlusOn Then
            Result = Number1 + Number2
            PlusOn = False
        End If

        ' スイッチAbstractはONにした場合
        If AbstractOn Then
            Result = Number1 - Number2
            AbstractOn = False
        End If

        ' スイッチMultipleはONにした場合
        If MultipleOn Then
            Result = Number1 * Number2
            MultipleOn = False
        End If

        ' スイッチDivideはONにした場合
        If DivideOn Then
            Result = Number1 / Number2
            DivideOn = False
        End If

        ' Num1は結果に代入する、それ以外は初期化する
        IntNum1 = Result
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""

        Show(Result)
        Return Result
    End Function

    Private Sub TurnOn(s As Object, e As KeyPressEventArgs)
        If s Is Plus OrElse e.KeyChar = "+" Then
            PlusOn = True

        ElseIf s Is Abstract OrElse e.KeyChar = "-" Then
            AbstractOn = True

        ElseIf s Is Multiple OrElse e.KeyChar = "*" Then
            MultipleOn = True

        ElseIf s Is Divide OrElse e.KeyChar = "/" Then
            DivideOn = True
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

End Class
