Public Class clsProc


    Public Shared Function SetLocalization() As Boolean
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Function

    Public Shared Function IsEmptyText(ByVal value As String, ByVal value_if_empty As String) As String
        If value <> "" Then
            Return value
        Else
            Return value_if_empty
        End If
    End Function

    Public Shared Function IsNol(ByVal value As Decimal, ByVal value_if_nol As Decimal) As Decimal
        If value > 0 Then
            Return value
        Else
            Return value_if_nol
        End If
    End Function


    Public Shared Function IsDbNull(ByRef value As Object, ByVal value_if_null As Object) As Object
        If value IsNot Nothing Then
            If value Is DBNull.Value Then
                Return value_if_null
            Else
                Return value
            End If
        Else
            Return value_if_null
        End If
    End Function
    Public Shared Function Terbilang(ByVal x As Double) As String
        Dim xstr, major, minor, negatifsign As String
        Dim axstr(2) As String
        Dim t As String

        If x = 0 Then
            Return "nol"
        End If


        negatifsign = ""

        If x < 0 Then
            x = -1 * x
            negatifsign = "Negatif "
        Else
            negatifsign = ""
        End If

        x = Math.Round(x, 2)
        xstr = CType(x, String)
        axstr = xstr.Split(".")
        major = axstr(0)


        If axstr.Length > 1 Then
            minor = axstr(1)
            t = negatifsign & " " & Num2Word(CType(major, Long)) & " koma " & Num2Word(CType(minor, Long))
        Else
            t = negatifsign & " " & Num2Word(CType(major, Long))
        End If

        Return t

    End Function


    Public Shared Function Num2Word(ByVal x As Long) As String
        Dim bilangan As String() = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}
        Dim temp As String = ""


        If x < 12 Then
            temp = " " + bilangan(x)
        ElseIf x < 20 Then
            temp = Num2Word(x - 10).ToString + " belas"
        ElseIf x < 100 Then
            temp = Num2Word(Math.Floor(x / 10)) + " puluh" + Num2Word(x Mod 10)
        ElseIf x < 200 Then
            temp = " seratus" + Num2Word(x - 100)
        ElseIf x < 1000 Then
            temp = Num2Word(Math.Floor(x / 100)) + " ratus" + Num2Word(x Mod 100)
        ElseIf x < 2000 Then
            temp = " seribu" + Num2Word(x - 1000)
        ElseIf x < 1000000 Then
            temp = Num2Word(Math.Floor(x / 1000)) + " ribu" + Num2Word(x Mod 1000)
        ElseIf x < 1000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000)) + " juta" + Num2Word(x Mod 1000000)
        ElseIf x < 1000000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000000)) + " milyard" + Num2Word(x Mod 1000000000)
        End If

        Return temp

    End Function


    Public Shared Function RefParser(ByVal txtField As String, ByVal txtSearchRef As TextBox) As String
        Dim i, j As Integer
        Dim txtTempLineSearchText As String
        Dim txtTempSearchText As String
        Dim txtSearchCriteria As String = ""
        Dim arrSearchText() As String
        Dim txtSQLSearch As String = ""


        For i = 0 To txtSearchRef.Lines.Length - 1
            txtTempLineSearchText = txtSearchRef.Lines(i)
            arrSearchText = Nothing
            arrSearchText = txtTempLineSearchText.Split(";")
            For j = 0 To arrSearchText.Length - 1
                txtTempSearchText = Trim(arrSearchText(j))
                If txtTempSearchText <> "" Then
                    txtSearchCriteria = txtTempSearchText & ";" & txtSearchCriteria
                End If
            Next
        Next

        arrSearchText = Nothing
        arrSearchText = txtSearchCriteria.Split(";")



        For i = 0 To arrSearchText.Length - 1
            If i > 0 Then
                If arrSearchText(i) <> "" Then
                    txtSearchCriteria = txtSearchCriteria & " OR " & txtField & " = '" & arrSearchText(i) & "' "
                End If
            Else
                txtSearchCriteria = txtField & " = '" & arrSearchText(0) & "' "
            End If
        Next


        Return txtSearchCriteria

        'If txtSQLSearch = "" Then
        '    txtSQLSearch = " (" & txtSearchCriteria & ") "
        'Else
        '    txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
        'End If
    End Function



End Class
