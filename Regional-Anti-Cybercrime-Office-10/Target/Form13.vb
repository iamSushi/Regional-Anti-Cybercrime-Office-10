Imports MySql.Data.MySqlClient

Public Class Form13
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Public Property lab_case As String
    Dim case_id As String
    Dim examiner As String
    Dim investigator As String
    Dim facts As String
    Dim type As String
    Dim status As String
    Dim agency As String
    Dim complainant As String

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;"


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory_case where lab_case_no = " & lab_case & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader


            While reader.Read
                case_id = reader.GetString("lab_case_no_id")
                DateTimePicker1.Value = reader.GetDateTime("date_received")
                Dim d_informed = reader.GetDateTime("date_informed")
                Dim d_released = reader.GetDateTime("date_released")
                Dim d_examined = reader.GetDateTime("date_examined")
                status = reader.GetString("case_status")
                TextBox5.Text = reader.GetString("released_by")
                TextBox6.Text = reader.GetString("claimed_by")
                complainant = reader.GetString("complainant")
                agency = reader.GetString("requesting_agency")
                examiner = reader.GetString("examiner")
                investigator = reader.GetString("investigator")
                Dim d_occur = reader.GetDateTime("date_occur")
                Dim t_occur = reader.GetTimeSpan("time_occur")
                TextBox13.Text = reader.GetString("place_occur")
                type = reader.GetString("type")
                facts = reader.GetString("facts")

            End While

            TextBox14.Text = case_id
            ComboBox3.Text = type
            TextBox9.Text = status


            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from persons where person_id = " & investigator & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name = f + " " + m + " " + s
                TextBox2.Text = name
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
            query = "select * from persons where person_id = " & examiner & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name = f + " " + m + " " + s
                TextBox10.Text = name
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
            query = "select * from persons where person_id = " & complainant & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name = f + " " + m + " " + s
                TextBox3.Text = name
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
            query = "select * from evidence where lab_case_no = " & lab_case & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                ComboBox1.Text = reader.GetString("sim")
                ComboBox2.Text = reader.GetString("tablet")
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
                TextBox15.Text = reader.GetString("status")
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
            query = "select * from agency where agency_id = " & agency & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                TextBox7.Text = reader.GetString("agency_name")

            End While
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try


    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;"

        Try
            mysqlconn.Open()
            Dim query As String
            query = "update laboratory_case set lab_case_no_id = '" & TextBox14.Text & "', date_received = " & DateTimePicker1.Value & ", date_informed = '" & DateTimePicker4.Value & "', date_released = '" & DateTimePicker5.Value & "', date_examined ='" & DateTimePicker6.Value & "', case_status = '" & TextBox9.Text & "', released_by ='" & TextBox5.Text & "', claimed_by ='" & TextBox6.Text & "', date_occur = '" & DateTimePicker2.Value & "', time_occur ='" & DateTimePicker3.Value & "', place_occur = '" & TextBox13.Text & "', type = '" & ComboBox3.Text & "' where lab_case_no = " & lab_case & ""
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            While reader.Read
                TextBox7.Text = reader.GetString("agency_name")

            End While
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class