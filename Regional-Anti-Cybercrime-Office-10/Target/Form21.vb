﻿Imports MySql.Data.MySqlClient

Public Class Form21
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub Form21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, rank as Rank, position as Position from Officer where position = 'examiner' "
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
                Dim f = row.Cells("Firstname").Value.ToString
                Dim m = row.Cells("Middlename").Value.ToString
                Dim s = row.Cells("Surname").Value.ToString
                Dim name_ni = f + " " + m + " " + s


                Form3.TextBox5.Text = name_ni
                Form3.releasedby = pili
                Form26.releasedby_pili = pili
                Form26.TextBox11.Text = name_ni
                Form4.TextBox5.Text = name_ni
                Form4.released_by = pili
                MessageBox.Show("Successful")
                Me.Hide()
            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Dim name_ni = f + " " + m + " " + s
                Form3.TextBox5.Text = name_ni
                Form3.releasedby = pili
                Form4.TextBox5.Text = name_ni
                Form4.released_by = pili
                Form26.releasedby_pili = pili
                Form26.TextBox11.Text = name_ni
                MessageBox.Show("Successful")
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
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String
            If TextBox1.Text = "" Then
                query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, rank as Rank, Position as Position from Officer where position = 'examiner' "
            Else
                query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, rank as Rank , Position as Position from Officer where fname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' and position = 'examiner'"
            End If

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
End Class