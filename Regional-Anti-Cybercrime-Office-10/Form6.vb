﻿Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form6
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If panel_slide.Width = 0 Then
            Do While panel_slide.Width < 109
                panel_slide.Width = panel_slide.Width + 1
            Loop
            Return
        End If
        If panel_slide.Width = 109 Then
            Do While panel_slide.Width > 0
                panel_slide.Width = panel_slide.Width - 1
            Loop
            Return
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            mysqlconn = New MySqlConnection
            mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
            Try
                mysqlconn.Open()
                Dim query2 As String
                query2 = "UPDATE accounts SET status = 0 WHERE status = 1"
                command = New MySqlCommand(query2, mysqlconn)
                reader = command.ExecuteReader

                mysqlconn.Close()
            Catch ex As Exception
                MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try

            Me.Close()
            Form1.Show()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim filesize As UInt32
        Dim mstream As New System.IO.MemoryStream
        PictureBox2.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage() As Byte = mstream.GetBuffer
        filesize = mstream.Length
        mstream.Close()

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(fname.Text) Then
            Me.ErrorProvider1.SetError(Me.fname, "Input firstname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.fname, "")
        End If

        If String.IsNullOrEmpty(sname.Text) Then
            Me.ErrorProvider1.SetError(Me.sname, "Input surname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.sname, "")
        End If

        If String.IsNullOrEmpty(rank.Text) Then
            Me.ErrorProvider1.SetError(Me.rank, "Input rank")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.rank, "")
        End If

        If String.IsNullOrEmpty(office.Text) Then
            Me.ErrorProvider1.SetError(Me.office, "Input office")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.office, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String
                Dim gender As String

                If RadioButton1.Checked = True Then
                    gender = "Male"
                ElseIf RadioButton2.Checked = True Then
                    gender = "Female"
                Else
                    gender = "Not specified"
                End If

                Dim xoxo As String
                xoxo = Nothing
                If DateTimePicker1.Value >= DateTime.Today Then
                    xoxo = DateTime.Today.ToShortDateString
                Else
                    xoxo = DateTimePicker1.Value.ToShortDateString
                End If

                query = "insert into officer values(null,'" & fname.Text & "','" & mname.Text & "','" & sname.Text & "','" & xoxo & "','" + gender + "','" & contact.Text & "','" & email.Text & "','" & rank.Text & "','" & ComboBox2.Text & "','" & office.Text & "',@profile_image,NOW())"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                contact.Text = ""
                email.Text = ""
                ComboBox2.Text = ""
                rank.Text = ""
                office.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Text = ""
                ComboBox1.Text = ""
                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.rank, "")
                Me.ErrorProvider1.SetError(Me.office, "")
                count = 0

                load_table()
                mysqlconn.Close()

            Catch ex As MySqlException
                MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
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

            query = "select officer_id as ID, fname as First, mname as Middle, sname as Surname, dob as Birthday, gender as Gender, contact as Contact, email as Email, rank as Rank , position as Position, agency as Agency, date_created as Created from officer"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

        PictureBox2.ImageLocation = ("C:\Users\iamSushi\Desktop\police.jpg")
        PictureBox2.Load()
    End Sub

    Private Sub profile_image()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Try
            mysqlconn.Open()
            Dim query As String

            query = "SELECT * from officer WHERE officer_id = '" & id.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)


            Dim img() As Byte

            img = table.Rows(0)(11)
            Dim ms As New MemoryStream(img)

            PictureBox2.Image = Image.FromStream(ms)

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub profile_image2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Try
            mysqlconn.Open()
            Dim query As String

            query = "SELECT * from officer WHERE officer_id = '" & id.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)


            Dim img() As Byte

            img = table.Rows(0)(11)
            Dim ms As New MemoryStream(img)

            PictureBox3.Image = Image.FromStream(ms)

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs)
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from officer where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"

        Try
            mysqlconn.Open()

            Dim query2 As String
            query2 = "select * from cybercrime.agency"
            command = New MySqlCommand(query2, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim xagency = reader.GetString("agency_name")
                office.Items.Add(xagency)
            End While

            mysqlconn.Close()
            mysqlconn.Open()

            Dim query3 As String
            query3 = "select * from cybercrime.rank"
            command = New MySqlCommand(query3, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim xxrank = reader.GetString("rank")
                rank.Items.Add(xxrank)
            End While

            mysqlconn.Close()
            mysqlconn.Open()

            Dim query4 As String
            query4 = "select * from cybercrime.position"
            command = New MySqlCommand(query4, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim xxpos = reader.GetString("name")
                ComboBox2.Items.Add(xxpos)
            End While
            mysqlconn.Close()
            mysqlconn.Open()


            Dim query5 As String
            query5 = "select * from cybercrime.rank"
            command = New MySqlCommand(query5, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim xrank = reader.GetString("rank")
                ComboBox1.Items.Add(xrank)
            End While


            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
        DateTimePicker1.Value = Now
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

            query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, dob as Birthday, gender as Gender, contact as Contact, email as Email, rank as Rank , agency as Office,  date_created as DateCreated from officer where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.ImageLocation = OpenFileDialog1.FileName
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim filesize As UInt32
        Dim mstream As New System.IO.MemoryStream
        PictureBox2.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage() As Byte = mstream.GetBuffer
        filesize = mstream.Length
        mstream.Close()

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(fname.Text) Then
            Me.ErrorProvider1.SetError(Me.fname, "Input firstname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.fname, "")
        End If

        If String.IsNullOrEmpty(sname.Text) Then
            Me.ErrorProvider1.SetError(Me.sname, "Input surname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.sname, "")
        End If

        If String.IsNullOrEmpty(rank.Text) Then
            Me.ErrorProvider1.SetError(Me.rank, "Input rank")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.rank, "")
        End If

        If String.IsNullOrEmpty(office.Text) Then
            Me.ErrorProvider1.SetError(Me.office, "Input office")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.office, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String
                Dim gender As String

                If RadioButton1.Checked = True Then
                    gender = "Male"
                ElseIf RadioButton2.Checked = True Then
                    gender = "Female"
                Else
                    gender = "Not specified"
                End If

                query = "UPDATE officer set fname = '" & fname.Text & "', mname = '" & mname.Text & "', sname = '" & sname.Text & "', contact = '" & contact.Text & "',email = '" & email.Text & "',rank = '" & rank.Text & "',agency = '" & office.Text & "', position = '" & ComboBox2.Text & "', dob = '" & DateTimePicker1.Value & "', gender = '" & gender & "', profile_image = @profile_image where officer_id = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                contact.Text = ""
                email.Text = ""
                ComboBox2.Text = ""
                rank.Text = ""
                office.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Text = ""
                ComboBox1.Text = ""
                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.rank, "")
                Me.ErrorProvider1.SetError(Me.office, "")
                count = 0
                load_table()
                mysqlconn.Close()

            Catch ex As MySqlException
                MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            index = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(index)

            id.Text = selectedRow.Cells(0).Value.ToString()
            fname.Text = selectedRow.Cells(1).Value.ToString()
            mname.Text = selectedRow.Cells(2).Value.ToString()
            sname.Text = selectedRow.Cells(3).Value.ToString()
            DateTimePicker1.Value = selectedRow.Cells(4).Value.ToString()

            If selectedRow.Cells(5).Value.ToString() = "Male" Then
                RadioButton1.Checked = True
            ElseIf selectedRow.Cells(5).Value.ToString() = "Female" Then
                RadioButton2.Checked = True
            Else
                Return
            End If


            contact.Text = selectedRow.Cells(6).Value.ToString()
            email.Text = selectedRow.Cells(7).Value.ToString()
            rank.Text = selectedRow.Cells(8).Value.ToString()
            ComboBox2.Text = selectedRow.Cells(9).Value.ToString()
            office.Text = selectedRow.Cells(10).Value.ToString()

            TextBox2.Text = selectedRow.Cells(1).Value.ToString()
            TextBox3.Text = selectedRow.Cells(2).Value.ToString()
            TextBox4.Text = selectedRow.Cells(3).Value.ToString()
            TextBox5.Text = selectedRow.Cells(4).Value.ToString()

            Dim myDateofBirth As Date
            Dim currentDate As Date
            Dim daySpan As TimeSpan
            Dim difference As Double
            Dim age As String

            myDateofBirth = DateTimePicker1.Value.ToShortDateString
            currentDate = Date.Today.ToShortDateString
            daySpan = (currentDate - myDateofBirth)
            difference = daySpan.Days
            age = Str(Int(difference / 365))
            TextBox7.Text = age
        Catch ex As Exception
            Return
        End Try


        profile_image()
        profile_image2()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                mysqlconn = New MySqlConnection
                mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
                Dim query As String
                mysqlconn.Open()
                query = "DELETE FROM officer WHERE officer_id = '" & id.Text & "' and position != 'Examiner'"
                command = New MySqlCommand(query, mysqlconn)

                reader = command.ExecuteReader
                MessageBox.Show("Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                load_table()
                mysqlconn.Close()

                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                contact.Text = ""
                email.Text = ""
                DateTimePicker1.Text = ""
                rank.Text = ""
                office.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                ComboBox2.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                TextBox1.Text = ""
                ComboBox1.Text = ""
                load_table()
            Catch ex As Exception
                MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, dob as Birthday, gender as Gender, contact as Contact, email as Email, rank as Rank , agency as Office, date_created as DateCreated from officer where rank = '" & ComboBox1.Text & "'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Dim myDateofBirth As Date
    Dim currentDate As Date
    Dim daySpan As TimeSpan
    Dim difference As Double
    Dim age As String

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)
        myDateofBirth = DateTimePicker1.Value.ToShortDateString
        currentDate = Date.Today.ToShortDateString
        daySpan = (currentDate - myDateofBirth)
        difference = daySpan.Days
        age = Str(Int(difference / 365))
        TextBox6.Text = age
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        fname.Text = ""
        mname.Text = ""
        sname.Text = ""
        contact.Text = ""
        email.Text = ""
        ComboBox2.Text = ""
        rank.Text = ""
        office.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Text = ""
        ComboBox1.Text = ""
        load_table()
    End Sub

    Private Sub DateTimePicker1_ValueChanged_1(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        myDateofBirth = DateTimePicker1.Value.ToShortDateString
        currentDate = Date.Today.ToShortDateString
        daySpan = (currentDate - myDateofBirth)
        difference = daySpan.Days
        age = Str(Int(difference / 365))
        TextBox6.Text = age
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, dob as Birthday, gender as Gender, contact as Contact, email as Email, rank as Rank , agency as Office, date_created as DateCreated from officer"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
            ComboBox1.Text = ""
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class