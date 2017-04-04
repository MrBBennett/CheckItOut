Public Class frmLylCrdCheck

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        Dim CardNumber As String = txtCardNumber.Text
        Dim ANumber As UShort = 0
        Dim Total As UShort = 0
        Dim CustomerName As String = txtCustomerName.Text

        CardNumber = CardNumber.Replace(" ", "")

        If CustomerName = "" Then
            MsgBox("Please enter the customer name", MsgBoxStyle.OkOnly, "Error!")
            txtCustomerName.Focus()
            txtCustomerName.BackColor = Color.Yellow
        ElseIf txtPostcode.Text = "" Then
            MsgBox("Please enter the customer's postcode", MsgBoxStyle.OkOnly, "Error!")
            txtPostcode.Focus()
            txtPostcode.BackColor = Color.Yellow
        ElseIf (CardNumber = "") Or (IsNumeric(CardNumber) = False) Or (Len(CardNumber) <> 8) Then
            MsgBox("Please enter a valid card number", MsgBoxStyle.OkOnly, "Error!")
            txtCardNumber.Focus()
            txtCardNumber.BackColor = Color.Yellow
        ElseIf dtpExpiry.Value < Today.Date Then
            MsgBox("Sorry " & CustomerName & "  your card has expired", MsgBoxStyle.OkOnly, "Expired Card!")
        Else
            CardNumber = Mid(CardNumber, 1, 7)
            CardNumber = StrReverse(CardNumber) & "0"
            For i = 0 To 6 Step 2
                ANumber = Val(CardNumber(i))
                ANumber = ANumber * 2
                If ANumber > 9 Then
                    ANumber = ANumber - 9
                End If
                Total = Total + ANumber + Val(CardNumber(i + 1))
            Next
            Total = Total + Val(txtCardNumber.Text(7))
            If Total Mod 10 = 0 Then
                MsgBox(CustomerName & " your loyalty card is valid. Enjoy your 10% discount!", MsgBoxStyle.OkOnly, "Valid Card")
            Else
                MsgBox("Sorry " & CustomerName & " that loyalty card number is invalid", MsgBoxStyle.OkOnly, "Invalid Card")
                txtCardNumber.Focus()
                txtCardNumber.BackColor = Color.Yellow
            End If

        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCardNumber.Text = ""
        txtCustomerName.Text = ""
        txtPostcode.Text = ""
        dtpExpiry.Value = Today.Date
        txtCardNumber.BackColor = Color.White
        txtCustomerName.BackColor = Color.White
        txtPostcode.BackColor = Color.White
    End Sub

    Private Sub txtCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerName.TextChanged
        txtCustomerName.BackColor = Color.White
    End Sub

    Private Sub txtCardNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardNumber.TextChanged
        txtCardNumber.BackColor = Color.White
    End Sub

    Private Sub frmLylCrdCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpExpiry.Value = DateAdd(DateInterval.Day, -1, dtpExpiry.Value)
    End Sub

    Private Sub txtPostcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostcode.TextChanged
        txtPostcode.BackColor = Color.White
    End Sub
End Class
