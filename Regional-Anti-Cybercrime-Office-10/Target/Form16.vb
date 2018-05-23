Imports MySql.Data.MySqlClient

Public Class Form16
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form17.Show()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String

            query = "insert into rank values(null,'" & TextBox2.Text & "','" & TextBox1.Text & "',null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = Command.ExecuteReader
            MessageBox.Show("Successfully added a rank")
            TextBox2.Text = ""


            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class