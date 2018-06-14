Imports MySql.Data.MySqlClient


Public Class Form18

    Dim mysqlconn As MySqlConnection
    Dim reader As MySqlDataReader
    Dim command As MySqlCommand
    Dim reader2 As MySqlDataReader
    Dim command2 As MySqlCommand
    Public Property lab_case As String

    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table2()
        load_table()


        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select lab_case_no_id from laboratory_case where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim lab_name = reader.GetString("lab_case_no_id")
                Label3.Text = lab_name
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
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
                Dim x As Int16
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim query2 As String
                query2 = "select * from suspect where person_id = '" & pili & "' and lab_case_no = '" & lab_case & "'"
                command2 = New MySqlCommand(query2, mysqlconn)
                reader2 = command2.ExecuteReader

                While reader2.Read
                    x = x + 1
                End While

                mysqlconn.Dispose()
                mysqlconn.Open()

                If x > 0 Then
                    load_table2()
                Else
                    Dim query As String

                    query = "insert into suspect values('" & lab_case & "','" & pili & "',null)"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Successful")

                End If

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select persons.person_id as ID, persons.fname as Firstname, persons.mname as Middlename, persons.sname as Surname, suspect.date_created as Date from suspect inner join persons on suspect.person_id = persons.person_id where lab_case_no = '" & lab_case & "' Order by Date desc"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("Firstname")
                Dim m = reader.GetString("Middlename")
                Dim s = reader.GetString("Surname")
                Dim nameni = f + " " + m + " " + s
                Form3.TextBox11.Text = nameni
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


        load_table2()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                Dim x As Int16
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim query2 As String
                query2 = "select * from suspect where person_id = '" & pili & "' and lab_case_no = '" & lab_case & "'"
                command2 = New MySqlCommand(query2, mysqlconn)
                reader2 = command2.ExecuteReader

                While reader2.Read
                    x = x + 1
                End While

                mysqlconn.Dispose()
                mysqlconn.Open()

                If x > 0 Then
                    load_table2()
                Else
                    Dim query As String

                    query = "insert into suspect values('" & lab_case & "','" & pili & "',null)"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Successful")

                End If

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select persons.person_id as ID, persons.fname as Firstname, persons.mname as Middlename, persons.sname as Surname, suspect.date_created as Date from suspect inner join persons on suspect.person_id = persons.person_id where lab_case_no = '" & lab_case & "' Order by Date desc"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("Firstname")
                Dim m = reader.GetString("Middlename")
                Dim s = reader.GetString("Surname")
                Dim nameni = f + " " + m + " " + s
                Form3.TextBox11.Text = nameni
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


        load_table2()
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

            query = "select person_id as ID ,fname as Firstname ,mname as Middlename ,sname as Surname from persons where category = 'suspect'"
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

    Private Sub load_table2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false;  convert zero datetime=True"

        Dim adapter2 As New MySqlDataAdapter
        Dim dbDataSet2 As New DataTable
        Dim soure2 As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id as ID, persons.fname as Firstname, persons.mname as Middlename, persons.sname as Surname from suspect inner join persons on suspect.person_id = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            adapter2.SelectCommand = command
            adapter2.Fill(dbDataSet2)
            soure2.DataSource = dbDataSet2
            DataGridView2.DataSource = soure2
            adapter2.Update(dbDataSet2)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView2.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim query As String

                query = "delete from suspect where person_id = '" & pili & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


        load_table2()
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView2.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim query As String

                query = "delete from suspect where person_id = '" & pili & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


        load_table2()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            If TextBox1.Text = "" Then
                query = "select person_id as ID ,fname as Firstname ,mname as Middlename ,sname as Surname, category as Category from persons where category = 'suspect'"
            Else
                query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname, category as Category from persons where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%' and category = 'suspect'"
            End If



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