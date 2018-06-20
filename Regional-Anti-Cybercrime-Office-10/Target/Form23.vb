Imports MySql.Data.MySqlClient

Public Class Form23
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        Me.DataGridView1.Columns("ID").Visible = False
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

            query = "select agency_id as ID , agency_name as Agency_Name from agency "
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim name_ni = row.Cells("Agency_Name").Value.ToString

                Form3.TextBox7.Text = name_ni
                Form3.agency = pili
                Form4.agency = pili

                Form26.agent_pili = pili
                Form26.TextBox18.Text = name_ni
                MessageBox.Show("You successfully choice Agency")

                Me.Hide()

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select agency_id as ID, agency_name as Agency_Name from agency where Agency_Name like '" & TextBox1.Text & "%' "
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Try
            mysqlconn.Open()
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim name_ni = row.Cells("Agency_Name").Value.ToString

                Form3.TextBox7.Text = name_ni
                Form3.agency = pili
                Form26.agent_pili = pili
                Form26.TextBox18.Text = name_ni
                Form4.agency = pili

                MessageBox.Show("You successfully choice Agency")

                Me.Hide()
            End If

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

End Class