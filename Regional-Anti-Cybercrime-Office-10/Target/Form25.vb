Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form25
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Public Property lab_case As String

    Dim received_by As String
    Dim claimed_by As String
    Dim investigator As String
    Dim examiner As String
    Dim complainant As String
    Dim agency As String


    Private Sub Label25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form25_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource



        Try
            mysqlconn.Open()

            Dim query As String

            query = "select cellphone as CP, tablet as TAB, desktop as DT, loptop as LT, sim as SIM, external_drive as ED, optical_drive as OD, hard_disk_drive as HDD, dc as DC, dvr as DVR, status as Evidence_Status from evidence where lab_Case_no = '" & lab_case & "'"
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
                Form26.lab_case = reader.GetString("lab_case_no")
                Label1.Text = reader.GetString("lab_case_no_id")
                TextBox10.Text = reader.GetString("type")
                agency = reader.GetString("requesting_agency")
                claimed_by = reader.GetString("claimed_by")
                received_by = reader.GetString("released_by")
                TextBox13.Text = reader.GetString("case_status")
                TextBox14.Text = reader.GetString("date_received")
                TextBox15.Text = reader.GetString("date_informed")
                TextBox16.Text = reader.GetString("date_released")
                TextBox17.Text = reader.GetString("date_examined")
                examiner = reader.GetString("examiner")
                investigator = reader.GetString("investigator")
                complainant = reader.GetString("complainant")

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

            query = "select  designation as D from case_nature inner join law on case_nature.nature_of_case = law.law_id where lab_case_no = '" & lab_case & "'"
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

            query = "select fname as f , mname as m, sname as s from officer where officer_id = '" & investigator & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                TextBox9.Text = name

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

            query = "select fname as f , mname as m, sname as s from officer where officer_id = '" & examiner & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                TextBox8.Text = name

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

            query = "select agency_name as f from agency where agency_id = '" & agency & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")

                TextBox18.Text = fname

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

            query = "select fname as f , mname as m, sname as s from officer where officer_id = '" & claimed_by & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                TextBox12.Text = name

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

            query = "select fname as f , mname as m, sname as s from officer where officer_id = '" & received_by & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                TextBox11.Text = name

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

            query = "select fname as f , mname as m, sname as s from persons where person_id = '" & complainant & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim fname = reader.GetString("f")
                Dim mname = reader.GetString("m")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + mname + " " + sname

                TextBox7.Text = name

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

            query = " select * from facts where lab_case_no = " & lab_case & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                TextBox1.Text = reader.GetString("what")
                TextBox2.Text = reader.GetString("how")
                TextBox6.Text = reader.GetString("date_occur")
                TextBox4.Text = reader.GetString("time_occur")
                TextBox5.Text = reader.GetString("place_occur")
                TextBox3.Text = reader.GetString("why")


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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form26.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseClick

    End Sub
End Class