Imports System.Text

Public Class Form1

    Private AddOn As Boolean = False
    Private SubtractOn As Boolean = False
    Private MultiplyOn As Boolean = False
    Private DivideOn As Boolean = False

    Private StringNum1 As String = ""
    Private StringNum2 As String = ""
    Private IntNum1 As Integer
    Private IntNum2 As Integer
    Private PreviousKey As Char
    Private PreviousNum2 As Integer
    Private CountEqual As Integer = 0
    Private Result As Integer

    Private Sub Input_Hander(sender As Object, e As EventArgs) Handles MyBase.KeyDown, Num0.Click, Num1.Click, Num2.Click, Num3.Click,
            Num4.Click, Num5.Click, Num6.Click, Num7.Click, Num8.Click, Num9.Click, Add.Click, Subtract.Click, Multiply.Click,
            Divide.Click, Comma.Click, Equal.Click, Clear.Click

        Me.ActiveControl = Nothing
        Dim InputKey As Char

        If TypeOf e Is KeyEventArgs Then
            Dim K As KeyEventArgs = CTypeDynamic(Of KeyEventArgs)(e)

            Select Case K.KeyCode

                Case Keys.NumPad0, Keys.D0
                    InputKey = "0"

                Case Keys.NumPad1, Keys.D1
                    InputKey = "1"

                Case Keys.NumPad2, Keys.D2
                    InputKey = "2"

                Case Keys.NumPad3, Keys.D3
                    InputKey = "3"

                Case Keys.NumPad4, Keys.D4
                    InputKey = "4"

                Case Keys.NumPad5, Keys.D5
                    InputKey = "5"

                Case Keys.NumPad6, Keys.D6
                    InputKey = "6"

                Case Keys.NumPad7, Keys.D7
                    InputKey = "7"

                Case Keys.NumPad8, Keys.D8
                    InputKey = "8"

                Case Keys.NumPad9, Keys.D9
                    InputKey = "9"

                Case Keys.Delete, Keys.Back
                    InputKey = "C"

                Case Keys.Decimal
                    InputKey = "K"

                Case Keys.Add
                    InputKey = "A"

                Case Keys.Subtract
                    InputKey = "S"

                Case Keys.Multiply
                    InputKey = "M"

                Case Keys.Divide
                    InputKey = "D"

                Case Keys.Return
                    InputKey = "E"

            End Select

        End If

        If TypeOf e Is MouseEventArgs Then

            If sender Is Num0 Then
                InputKey = "0"

            ElseIf sender Is Num1 Then
                InputKey = "1"

            ElseIf sender Is Num2 Then
                InputKey = "2"

            ElseIf sender Is Num3 Then
                InputKey = "3"

            ElseIf sender Is Num4 Then
                InputKey = "4"

            ElseIf sender Is Num5 Then
                InputKey = "5"

            ElseIf sender Is Num6 Then
                InputKey = "6"

            ElseIf sender Is Num7 Then
                InputKey = "7"

            ElseIf sender Is Num8 Then
                InputKey = "8"

            ElseIf sender Is Num9 Then
                InputKey = "9"

            ElseIf sender Is Add Then
                InputKey = "A"

            ElseIf sender Is Subtract Then
                InputKey = "S"

            ElseIf sender Is Multiply Then
                InputKey = "M"

            ElseIf sender Is Divide Then
                InputKey = "D"

            ElseIf sender Is Comma Then
                InputKey = "K"

            ElseIf sender Is Equal Then
                InputKey = "E"

            ElseIf sender Is Clear Then
                InputKey = "C"

            End If

        End If

        If Not (InputKey = Nothing) Then
            Update(InputKey)
        End If

    End Sub

    Private Sub Update(key As Char)
        Select Case key
            Case "C"
                Clear_All()

            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "K"
                Build_Num(key)

            Case "A", "S", "M", "D"
                Execute_Calc(key)

            Case "E"
                Execute_Equal()

        End Select
    End Sub

    Private Sub Clear_All()
        IntNum1 = 0
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""
        Result = 0
        PreviousKey = ""
        PreviousNum2 = 0

        TurnOff("A")
        TurnOff("S")
        TurnOff("M")
        TurnOff("D")
        Show(0)

    End Sub

    Private Sub Build_Num(key As String)

        If AddOn OrElse SubtractOn OrElse MultiplyOn OrElse DivideOn Then
            StringNum2 += key
            IntNum2 = Convert.ToInt32(StringNum2)
            Show(IntNum2)

        Else
            StringNum1 += key
            IntNum1 = Convert.ToInt32(StringNum1)
            Show(IntNum1)

        End If

    End Sub

    Private Sub Execute_Calc(key As Char)
        CountEqual = 0
        ' Input Number 1 があった場合　
        If IntNum1 <> 0 Then
            ' 2回目のNumberはすでに入力された場合
            If IntNum2 <> 0 Then
                ' 続けて計算する
                Result = ContinueCalc(IntNum1, IntNum2)
            End If
            ' Turn On スイッチ
            TurnOn(key)

            ' Equal Event 計算後に続けて計算する
        ElseIf Result <> 0 Then
            ' Turn On スイッチ
            TurnOn(key)
            ' Num1 は　前の結果に代入する
            IntNum1 = Result
        End If

    End Sub

    Private Sub Execute_Equal()
        '　結果を出す
        CountEqual += 1
        If CountEqual = 2 AndAlso Result <> 0 Then
            IntNum1 = Result
            IntNum2 = PreviousNum2
            CountEqual -= 1

            Select Case PreviousKey
                Case "A"
                    TurnOn("A")

                Case "S"
                    TurnOn("S")

                Case "M"
                    TurnOn("M")

                Case "D"
                    TurnOn("D")

                Case Else
                    Debug.WriteLine("Invalid Previous Key Value At Line 242")
            End Select

            Result = Calc(IntNum1, IntNum2)
        Else
            Result = Calc(IntNum1, IntNum2)
        End If

    End Sub

    Private Function ContinueCalc(Number1 As Integer, Number2 As Integer) As Integer
        Dim Result As Integer
        ' スイッチAddはONにした場合
        If AddOn Then
            Result = Number1 + Number2
            TurnOff("A")
        End If

        ' スイッチSubtractはONにした場合
        If SubtractOn Then
            Result = Number1 - Number2
            TurnOff("S")
        End If

        ' スイッチMultiplyはONにした場合
        If MultiplyOn Then
            Result = Number1 * Number2
            TurnOff("M")
        End If

        ' スイッチDivideはONにした場合
        If DivideOn Then
            Result = Number1 / Number2
            TurnOff("D")
        End If

        ' Num1は結果に代入する、それ以外は初期化する
        IntNum1 = Result
        StringNum1 = ""
        IntNum2 = 0
        StringNum2 = ""

        Show(Result)
        Return Result
    End Function

    Private Function Calc(Number1 As Integer, Number2 As Integer) As Integer
        Dim Result As Integer
        ' スイッチAddはONした場合
        If AddOn Then
            Result = Number1 + Number2
            PreviousKey = "A"
            TurnOff("A")
        End If

        ' スイッチSubtractはONした場合
        If SubtractOn Then
            Result = Number1 - Number2
            PreviousKey = "S"
            TurnOff("S")
        End If

        ' スイッチMultiplyはONした場合
        If MultiplyOn Then
            Result = Number1 * Number2
            PreviousKey = "M"
            TurnOff("M")
        End If

        ' スイッチDivideはONした場合
        If DivideOn Then
            Result = Number1 / Number2
            PreviousKey = "D"
            TurnOff("D")
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
    Private Sub Show(num As Integer)

        Display.Text = num

    End Sub

    Private Sub TurnOn(key As Char)
        Select Case key

            Case "A"
                AddOn = True

            Case "S"
                SubtractOn = True

            Case "M"
                MultiplyOn = True

            Case "D"
                DivideOn = True

        End Select
    End Sub

    Private Sub TurnOff(key As Char)
        Select Case key

            Case "A"
                AddOn = False

            Case "S"
                SubtractOn = False

            Case "M"
                MultiplyOn = False

            Case "D"
                DivideOn = False

        End Select
    End Sub

End Class
