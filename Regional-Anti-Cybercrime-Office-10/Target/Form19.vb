﻿Imports MySql.Data.MySqlClient

Public Class Form19
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Public Property lab_case As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString


                Dim query As String

                query = "insert into case_nature values('" & lab_case & "','" & pili & "',null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader


            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        load_table()
        load_table2()
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

            query = "select law_id as ID , designation as Name, date_passed as Date_Passed, description as Description from law"
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
        Dim adapter2 As New MySqlDataAdapter
        Dim dbDataSet2 As New DataTable
        Dim soure2 As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select law_id as ID, designation as Designation, description as Description from case_nature left join law on case_nature.nature_of_case = law.law_id"
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from case_nature where name like '" & TextBox1.Text & "%' "

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

    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView2.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim query As String

                query = "delete from case_nature where nature_of_case = '" & pili & "' and lab_case_no = '" & lab_case & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader


            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        load_table()
        load_table2()
    End Sub
End Class