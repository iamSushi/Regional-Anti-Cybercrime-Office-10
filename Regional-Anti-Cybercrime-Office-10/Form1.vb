﻿Imports MySql.Data.MySqlClient
Public Class Form1
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form7.Show()

        'mysqlconn = New MySqlConnection With {
        '.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        '}
        'Try
        '    mysqlconn.Open()

        '    Dim s As String = TextBox2.Text
        '    Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(s)
        '    Dim sb64 As String = System.Convert.ToBase64String(bArry)


        '    Dim query As String
        '    query = "select * from accounts where username ='" & TextBox1.Text & "' and password ='" & sb64 & "'"
        '    command = New MySqlCommand(query, mysqlconn)
        '    reader = command.ExecuteReader

        '    Dim result As Integer
        '    result = 0
        '    While reader.Read
        '        result = result + 1
        '    End While


        '    If result = 1 Then
        '        mysqlconn.Close()
        '        mysqlconn.Open()

        '        Dim query2 As String
        '        query2 = "UPDATE accounts SET status = 1 WHERE username = '" & TextBox1.Text & "' and password = '" & sb64 & "'"
        '        command = New MySqlCommand(query2, mysqlconn)
        '        reader = command.ExecuteReader

        '        TextBox1.Text = ""
        '        TextBox2.Text = ""
        '        Me.Hide()
        '        Form7.Show()
        '    Else
        '        MessageBox.Show("Username or Password is incorrect!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        TextBox1.Text = ""
        '        TextBox2.Text = ""
        '    End If

        '    mysqlconn.Close()
        'Catch ex As MySqlException
        '    MessageBox.Show("Invalid user input", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    TextBox1.Text = ""
        '    TextBox2.Text = ""
        'Finally
        '    mysqlconn.Dispose()
        'End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

End Class
