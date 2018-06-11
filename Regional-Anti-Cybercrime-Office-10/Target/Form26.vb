Imports MySql.Data.MySqlClient

Public Class Form26
    Dim mysqlconn As MySqlConnection
    Dim reader As MySqlDataReader
    Dim command As MySqlCommand

    Public Property lab_case As String

    Dim received_by As String
    Dim claimed_by As String
    Dim investigator As String
    Dim examiner As String
    Dim complainant As String
    Dim agency As String

    Dim received_by_s As String
    Dim claimed_by_s As String
    Dim investigator_s As String
    Dim examiner_s As String
    Dim complainant_s As String
    Dim agency_s As String

    Private Sub Form26_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        ComboBox1.Items.Add("Cellphone")
        ComboBox1.Items.Add("Computer")
        ComboBox1.Items.Add("Audio Visual")
        ComboBox1.Items.Add("Intel")


        Try
            mysqlconn.Open()

            Dim query As String

            query = " select * from laboratory_case where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Form8.lab_case = reader.GetString("lab_case_no")
                Form18.lab_case = reader.GetString("lab_case_no")
                Form19.lab_case = reader.GetString("lab_case_no")
                Label1.Text = reader.GetString("lab_case_no_id")
                ComboBox1.Text = reader.GetString("type")
                agency = reader.GetString("requesting_agency")
                claimed_by = reader.GetString("claimed_by")
                received_by = reader.GetString("released_by")
                TextBox13.Text = reader.GetString("case_status")
                DateTimePicker1.Value = reader.GetString("date_received")
                DateTimePicker3.Value = reader.GetString("date_released")
                DateTimePicker4.Value = reader.GetString("date_examined")
                examiner = reader.GetString("examiner")
                investigator = reader.GetString("investigator")
                complainant = reader.GetString("complainant")

                If reader.GetString("date_informed") = "null" Then
                    DateTimePicker2.Value = DateTime.Now
                Else
                    DateTimePicker2.Value = reader.GetString("date_informed")
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

            query = " select * from evidence where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                ComboBox2.Text = reader.GetString("sim")
                ComboBox3.Text = reader.GetString("tablet")
                ComboBox4.Text = reader.GetString("loptop")
                ComboBox5.Text = reader.GetString("desktop")
                ComboBox6.Text = reader.GetString("cellphone")
                ComboBox7.Text = reader.GetString("flash_drive")
                ComboBox8.Text = reader.GetString("optical_drive")
                ComboBox9.Text = reader.GetString("secure_digital")
                ComboBox10.Text = reader.GetString("external_drive")
                ComboBox11.Text = reader.GetString("video_recorder")
                ComboBox12.Text = reader.GetString("hard_disk_drive")
                ComboBox13.Text = reader.GetString("dc")
                ComboBox14.Text = reader.GetString("dvr")
                TextBox1.Text = reader.GetString("status")
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

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Try
            mysqlconn.Open()

            Dim query As String

            query = "update laboratory_case set type = '" & ComboBox1.Text & "', case_status = '" & TextBox13.Text & "', date_received = '" & DateTimePicker1.Value & "', date_informed = '" & DateTimePicker2.Value & "', date_released = '" & DateTimePicker3.Value & "', date_examined = '" & DateTimePicker4.Value & "' where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "update evidence set sim = '" & ComboBox2.Text & "',tablet = '" & ComboBox3.Text & "', loptop = '" & ComboBox4.Text & "', desktop = '" & ComboBox5.Text & "', cellphone = '" & ComboBox6.Text & "',flash_drive = '" & ComboBox7.Text & "', optical_drive = '" & ComboBox8.Text & "', secure_digital = '" & ComboBox9.Text & "', external_drive = '" & ComboBox10.Text & "', video_recorder = '" & ComboBox11.Text & "', hard_disk_drive = '" & ComboBox12.Text & "', dc = '" & ComboBox13.Text & "', dvr = '" & ComboBox14.Text & "', status = '" & TextBox1.Text & "'  where lab_case_no = '" & lab_case & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successfully Updated")
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
        MessageBox.Show("Successfully Updated")
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Form19.Show()
        Form19.lab_case = lab_case
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Form8.Show()
        Form8.lab_case = lab_case
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Form18.Show()
        Form18.lab_case = lab_case
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Form18.Show()
        Form18.lab_case = lab_case
    End Sub
    Private Sub ListBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDoubleClick
        Form8.Show()
        Form8.lab_case = lab_case
    End Sub
    Private Sub ListBox3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox3.MouseDoubleClick
        Form19.Show()
        Form19.lab_case = lab_case
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub
End Class