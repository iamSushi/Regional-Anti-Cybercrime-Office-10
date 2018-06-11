Imports MySql.Data.MySqlClient

Public Class Form24
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim pili As String
    Dim index As Integer
    Public Property lab_case As String
    Private Sub Form24_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname from persons"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim f = row.Cells("Firstname").Value.ToString
                Dim m = row.Cells("Middlename").Value.ToString
                Dim s = row.Cells("Surname").Value.ToString
                Dim name = f + " " + m + " " + s
                Form3.TextBox3.Text = name
                Form3.complainant = pili
                MessageBox.Show("Successful")

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim f = row.Cells("Firstname").Value.ToString
                Dim m = row.Cells("Middlename").Value.ToString
                Dim s = row.Cells("Surname").Value.ToString
                Dim name = f + " " + m + " " + s
                Form3.TextBox3.Text = name
                Form4.TextBox4.Text = name
                Form3.complainant = pili
                Form4.complainant = pili
                MessageBox.Show("Successful")
                Me.Hide()
            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname from persons where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class