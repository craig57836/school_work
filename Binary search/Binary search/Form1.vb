Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'clear listboxes
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        'list sorting
        'declare array of numbers and additional variables
        Dim x As Integer
        Dim temp As Integer
        Dim outer As Integer
        Dim inner As Integer
        Dim numbers(15) As Integer

        'generate random numbers between 1 and 100
        Randomize()
        For x = 0 To 15
            numbers(x) = Int(Rnd() * 100) + 1
        Next

        'sort the numbers (Inesertion Sort)
        For outer = 1 To 15
            For inner = outer To 1 Step -1
                If numbers(inner) < numbers(inner - 1) Then
                    temp = numbers(inner)
                    numbers(inner) = numbers(inner - 1)
                    numbers(inner - 1) = temp

                End If
            Next inner
        Next outer

        'display numbers
        For x = 1 To 15
            ListBox1.Items.Add(numbers(x))
        Next x

        'binary search
        Dim middle As Integer 'Middle position in array
        Dim firstPosition As Integer 'first position in array
        Dim lastPoisition As Integer 'last position in array
        Dim searchKey As Integer 'item you are searching for
        Dim passes As Integer 'counts number of times list has been halved
        Dim found As Boolean

        found = False
        passes = 0
        firstPosition = 0
        lastPoisition = 15
        searchKey = InputBox("Input the number you want to find")
        Do while searchKey > numbers(lastPosition)
        searchKey = InputBox("Search Key greater than the highest number in the list, enter a lower number as the search key")
        Loop

        ListBox2.Items.Add("The search key is" & searchKey)

        Do
            passes = passes + 1
            middle = (firstPosition + lastPoisition) / 2 'find middle position
            If numbers(middle) < searchKey Then
                firstPosition = middle + 1  'discard left side of list
            Else
                lastPoisition = middle - 1  'discard right side of list
            End If
            If numbers(middle) = searchKey Then
                found = True
                ListBox3.Items.Add("Search Key " & searchKey & " Found at position " & middle)
                ListBox4.Items.Add("Number of passes required " & passes)
            End If
        Loop Until found = True Or passes > 5
        If passes > 5 Then
            ListBox4.Items.Add("Search Key " & searchKey & " not found!")
        End If
    End Sub
End Class
