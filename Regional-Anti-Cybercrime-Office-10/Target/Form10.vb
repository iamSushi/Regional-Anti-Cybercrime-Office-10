Imports MySql.Data.MySqlClient

Public Class Form10
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form13.Show()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String

            query = "insert into agency values(null,'" & TextBox2.Text & "','" & TextBox6.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox5.Text & "',null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successfully Add an Agency")
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""



            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class