Imports MySql.Data.MySqlClient


Public Class Form1

    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Try
            mysqlconn.Open()
            Dim query As String
            query = "select * from accounts where username ='" & TextBox1.Text & "' and password ='" & TextBox2.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim result As Integer
            result = 0
            While reader.Read
                result = result + 1
            End While

            If result = 1 Then
                Form2.Show()
                Me.Hide()
            Else
                MessageBox.Show("You Wrong")
            End If



            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()



    End Sub
End Class
