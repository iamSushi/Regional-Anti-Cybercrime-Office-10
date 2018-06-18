Imports MySql.Data.MySqlClient

Public Class Form12
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String

            query = "insert into position values(null,'" & TextBox2.Text & "',NOW())"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")

            TextBox2.Text = ""


            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            load_table()
            mysqlconn.Dispose()
        End Try
    End Sub
    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"

        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select position_id as ID, name as Position from position"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles Me.Load
        load_table()
        Me.DataGridView1.Columns("ID").Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            index = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(index)

            TextBox2.Text = selectedRow.Cells(1).Value.ToString()
            TextBox1.Text = selectedRow.Cells(0).Value.ToString()
        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            Dim query As String
            mysqlconn.Open()
            query = "DELETE FROM position WHERE position_id = '" & TextBox1.Text & "'"
            command = New MySqlCommand(query, mysqlconn)

            reader = command.ExecuteReader
            MessageBox.Show("Successful")

            TextBox1.Text = ""
            TextBox2.Text = ""

            load_table()
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            mysqlconn.Dispose()
            load_table()

        End Try
    End Sub
End Class