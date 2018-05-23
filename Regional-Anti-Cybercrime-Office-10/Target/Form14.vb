Imports MySql.Data.MySqlClient

Public Class Form14
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            query = "select * from nature"
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