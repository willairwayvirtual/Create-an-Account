# Create-an-Account
Imports System.Data.OleDb
Public Class create_reg
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim conn As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "C:\VisStudioProj\wav web\willairwayvirtual34\willairwayvirtual34\app_data\willairwayvirtualDBv1.accdb"
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
            Dim savenew As String = "INSERT INTO [tblaccessinfo]  (Uname,Pword,Fname,Lname,EMailAdd,HOMEICAO) values('" &
        new_username.Text & "','" &
        new_password.Text & "','" &
        New_fname.Text & "','" &
        new_lname.Text & "','" &
        EMailAdd.Text & "','" &
        HOMEICAO.Text & "');"


            Dim cmd As New OleDbCommand

            With cmd
                .CommandText = savenew
                .Connection = conn
                .ExecuteNonQuery()
            End With
            MessageBox.Show("Welcome on board ")

            conn.Close()
        End If
    End Sub
