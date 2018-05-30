Imports MySql.Data.MySqlClient

Public Class Form12
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(factname.Text) Then
            Me.ErrorProvider2.SetError(Me.factname, "Input name")
            count += 1
        Else
            Me.ErrorProvider2.SetError(Me.factname, "")
        End If

        If String.IsNullOrEmpty(facts.Text) Then
            Me.ErrorProvider2.SetError(Me.facts, "Input facts")
            count += 1
        Else
            Me.ErrorProvider2.SetError(Me.facts, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String

                query = "insert into facts values(null,'" & factname.Text & "','" & facts.Text & "',null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successfullu added Facts")
                factname.Text = ""
                facts.Text = ""
                load_table()


                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try
        End If

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

            query = "select fact_no as ID, name as Name, remarks as Facts  from facts"
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

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles Me.Load
        load_table()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)

        id.Text = selectedRow.Cells(0).Value.ToString()
        factname.Text = selectedRow.Cells(1).Value.ToString()
        facts.Text = selectedRow.Cells(2).Value.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(factname.Text) Then
            Me.ErrorProvider2.SetError(Me.factname, "Input name")
            count += 1
        Else
            Me.ErrorProvider2.SetError(Me.factname, "")
        End If

        If String.IsNullOrEmpty(facts.Text) Then
            Me.ErrorProvider2.SetError(Me.facts, "Input facts")
            count += 1
        Else
            Me.ErrorProvider2.SetError(Me.facts, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String

                query = "UPDATE facts set name = '" & factname.Text & "', remarks = '" & facts.Text & "' where fact_no = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successfullu added Facts")
                factname.Text = ""
                facts.Text = ""
                load_table()


                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            Dim query As String
            mysqlconn.Open()
            query = "DELETE FROM facts WHERE fact_no = '" & id.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            factname.Text = ""
            facts.Text = ""
            load_table()
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class