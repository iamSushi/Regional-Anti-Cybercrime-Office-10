﻿Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form25
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Public Property lab_case As String
    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form25_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select CP,TAB,DT,LT,SIM,ED,OD,HDD,DC,DVR,Evidence_Status from laboratory"
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

        Try
            mysqlconn.Open()

            Dim query As String

            query = " select * from laboratory_case where lab_case_no = " & lab_case & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Label1.Text = reader.GetString("lab_case_no_id")
                Label5.Text = reader.GetString("type")
                Label10.Text = reader.GetString("requesting_agency")


                Label18.Text = reader.GetString("case_status")
                Label19.Text = reader.GetString("date_received")

                Label21.Text = reader.GetString("date_released")
                Label24.Text = reader.GetString("date_examined")
                If reader.IsDBNull("claimed_by") Then
                    Label11.Text = ""
                Else
                    Label11.Text = reader.GetString("claimed_by")
                End If

                If reader.IsDBNull(reader.GetString("released_by")) Then
                    Label15.Text = ""
                Else
                    Label15.Text = reader.GetString("released_by")
                End If

                If reader.IsDBNull(reader.GetString("date_informed")) Then
                    Label20.Text = ""
                Else
                    Label15.Text = reader.GetString("date_informed")
                End If
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id, persons.fname as f, persons.mname as m, persons.sname as s from suspect left join persons on suspect.person_id = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim suspect = fname + " " + mname + " " + sname

                ListBox1.Items.Add(suspect)
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select  designation as D from case_nature left join law on case_nature.nature_of_case = law.law_id"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim data = reader.GetString("D")


                ListBox3.Items.Add(data)
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id, persons.fname as f, persons.mname as m, persons.sname as s from victim inner join persons on victim.person_id = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim suspect = fname + " " + mname + " " + sname

                ListBox2.Items.Add(suspect)
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id, persons.fname as f, persons.mname as m, persons.sname as s from laboratory_case inner join persons on laboratory_case.complainant = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                Label26.Text = name

            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id, persons.fname as f, persons.mname as m, persons.sname as s from laboratory_case inner join persons on laboratory_case.examiner = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                Label2.Text = name

            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
        Try
            mysqlconn.Open()

            Dim query As String

            query = "select persons.person_id, persons.fname as f, persons.mname as m, persons.sname as s from laboratory_case inner join persons on laboratory_case.investigator = persons.person_id where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                Label3.Text = name

            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then

        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub
End Class