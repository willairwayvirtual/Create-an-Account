Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Imports System.Net.Mail
Public Class create_reg
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim conn As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "c:\VisStudioProj\wav web\willairwayvirtual34\willairwayvirtual34\app_data\willairwayvirtualDBv1.accdb"
        connString = provider & dataFile
        conn.ConnectionString = connString

        'check status of connection string
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        Else
            conn.Close()
        End If

        'check password status and continue to create new user
        If new_password.Text.Length < 4 Then
            Msgbox("Minimum Password Length is 4 Characters")
        
        Else
            'add new records
            Dim savenew As String = "INSERT INTO [tblaccessinfo]  (Uname,Pword,Fname,Lname,EMailAdd,HOMEICAO,emailnote,lkey) values('" &
       new_username.Text & "','" &
        new_password.Text & "','" &
        New_fname.Text & "','" &
        new_lname.Text & "','" &
        EMailAdd.Text & "','" &
        HOMEICAO.Text & "','" &
        emailnote.Text & "','" &
        lkeyTextBox1.Text & "');"
            Dim cmd As New OleDbCommand

            With cmd
                .CommandText = savenew
                .Connection = conn
                .ExecuteNonQuery()
            End With
            MessageBox.Show("Welcome on board ")

            conn.Close()
            Dim mail As New MailMessage
            mail.Subject = "Welcome on board"
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader("C:\VisStudioProj\wav login Desktop App23\wav login Desktop App23\email_template.htm")
            Dim smtp As New SmtpClient("smtp-mail.outlook.com")

            mail.To.Add(EMailAdd.Text)
            mail.From = New MailAddress("Wavuserhelpdesk@hotmail.com")
            mail.Body = reader.ReadToEnd
            mail.IsBodyHtml = True

            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential("Wavuserhelpdesk@hotmail.com", "!Spongebob18")
            smtp.Port = "587"
            'smtp.Port = "25"
            smtp.Send(mail)




        End If
    End Sub
