Imports System.Net.IPAddress
Imports System.Net.NetworkInformation.PingReply
Imports System.Net.Mail

Public Class clsKirimEmail
    Private mailerNET As System.Net.Mail.SmtpClient

    Private Shared myHost As String = "mailserver.netmedia.co.id"
    Private Shared smtp As New Net.Mail.SmtpClient

    Public Shared Sub Send(ByVal MyMail As Net.Mail.MailMessage, ByVal eMailFrom As String, ByVal eMailPassword As String)
        Dim cred As New Net.NetworkCredential(eMailFrom, eMailPassword)
        Dim credCache As New Net.CredentialCache


        credCache.Add(myHost, "35", "Basic", cred)
        credCache.Add(myHost, "45", "NTLM", cred)

        smtp.Host = myHost

        MyMail.DeliveryNotificationOptions = Net.Mail.DeliveryNotificationOptions.None

        smtp.EnableSsl = True
        smtp.UseDefaultCredentials = False
        smtp.Credentials = credCache.GetCredential(myHost, "45", "NTLM")

        Try
            smtp.Send(MyMail)
        Catch exfailed As SmtpFailedRecipientsException
            Throw exfailed
        End Try
    End Sub

    Public Shared Sub SendEmail(ByVal dsn As String, ByVal ref_id As String, ByVal events As String, ByVal emailFrom As String, ByVal emailFromPassword As String, _
                                ByVal userTo As String, ByVal emailTo As String, ByVal subjectEmail As String, ByVal isiEmail As String, Optional ByVal emailCC As String = "")

        Dim logEmail As clsTrnLogEmail = New clsTrnLogEmail(dsn)
        Dim myMail As New System.Net.Mail.MailMessage
        myMail = New System.Net.Mail.MailMessage
        myMail.From = New Net.Mail.MailAddress(emailFrom)
        myMail.To.Add(emailTo)

        If emailCC <> "" Then
            myMail.CC.Add(emailCC)
        End If

        myMail.Subject = subjectEmail
        myMail.IsBodyHtml = True
        myMail.Body = isiEmail
        clsKirimEmail.Send(myMail, emailFrom, emailFromPassword)

        Try
            logEmail.InsertTrnLogEmail(ref_id, "GAMBA", emailFrom, userTo, emailTo, events)
        Catch ex As Exception
            logEmail.InsertTrnLogEmail(ref_id, "GAMBA", emailFrom, userTo, emailTo, events + " - Gagal Send Email")
            Throw New Exception("Tidak bisa mengirim email ke " + emailTo + " !!" + vbCrLf + "Error Message : " + ex.Message)
        End Try
    End Sub

    Public Shared Function SendEmail_SQL(ByVal DSN As String, ByVal ref_id As String, ByVal events As String, ByVal emailFrom As String, _
                                         ByVal userTo As String, ByVal Email_To As String, ByVal Email_CC As String, Email_BCC As String, _
                                         ByVal subject As String, ByVal body As String) As Boolean
        Dim logEmail As clsTrnLogEmail = New clsTrnLogEmail(DSN)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(DSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = ""

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("to_SendEmail", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_To
            oCm.Parameters.Add("@copy_recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_CC
            oCm.Parameters.Add("@blind_copy_recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_BCC
            oCm.Parameters.Add("@subject", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = subject
            oCm.Parameters.Add("@body", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = body
            oCm.Parameters.Add("@importance", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = ""

            oCm.ExecuteNonQuery()
            oCm.Dispose()

            logEmail.InsertTrnLogEmail(ref_id, "GAMBA", emailFrom, userTo, Email_To, events)
        Catch ex As Exception
            logEmail.InsertTrnLogEmail(ref_id, "GAMBA", emailFrom, userTo, Email_To, events + " - Gagal Send Email")
            MsgBox(ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

    End Function

End Class
