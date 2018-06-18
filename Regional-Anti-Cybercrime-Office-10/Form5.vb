Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class Form5
    Dim trylang As String
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form6.Show()
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

        If String.IsNullOrEmpty(category.Text) Then
            Me.ErrorProvider1.SetError(Me.category, "Input category")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.category, "")
        End If

        If String.IsNullOrEmpty(status.Text) Then
            Me.ErrorProvider1.SetError(Me.status, "Input status")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.status, "")
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

                query = "insert into persons values(null,'" & fname.Text & "','" & mname.Text & "','" & sname.Text & "','" & nickname.Text & "','" & xoxo & "','" & gender & "','" & status.Text & "','" & contact.Text & "','" & email.Text & "','" & category.Text & "',@profile_image,NOW())"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                nickname.Text = ""
                contact.Text = ""
                email.Text = ""
                status.Text = ""
                category.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Text = ""
                ComboBox2.Text = ""
                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.category, "")
                Me.ErrorProvider1.SetError(Me.status, "")
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

            query = "SELECT person_id as ID, fname as Firstname, mname as Middlename, sname as Surname, nname as Nickname, dob as Birthdate, gender as Gender, status as Status, contact as Contact, email as Email, category as Category, date_created as DateCreated FROM persons"
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

        PictureBox2.ImageLocation = ("C:\Users\iamSushi\Desktop\user.jpg")
        PictureBox2.Load()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        DateTimePicker1.Value = Now
        category.Items.Add("Complainant")
        category.Items.Add("Suspect")
        category.Items.Add("Victim")
        category.Items.Add("Witness")

        status.Items.Add("Single")
        status.Items.Add("Married")
        status.Items.Add("Widowed")
        status.Items.Add("Divorced")

        ComboBox2.Items.Add("Complainant")
        ComboBox2.Items.Add("Suspect")
        ComboBox2.Items.Add("Victim")
        ComboBox2.Items.Add("Witness")

        Me.DataGridView1.Columns("ID").Visible = False
    End Sub

    Private Sub profile_image()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Try
            mysqlconn.Open()
            Dim query As String

            query = "SELECT * from persons WHERE person_id = '" & id.Text & "'"
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

            query = "SELECT * from persons WHERE person_id = '" & id.Text & "'"
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

            query = "select * from persons where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname, nname as Nickname, dob as Birthdate, gender as Gender, status as Status, contact as Contact, email as Email, category as Category, date_created as DateCreated FROM persons WHERE fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname, nname as Nickname, dob as Birthdate, gender as Gender, status as Status, contact as Contact, email as Email, category as Category, date_created as DateCreated FROM persons WHERE category LIKE '" & ComboBox2.Text & "%'"

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

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.ImageLocation = OpenFileDialog1.FileName
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
            nickname.Text = selectedRow.Cells(4).Value.ToString()
            DateTimePicker1.Value = selectedRow.Cells(5).Value.ToString()

            If selectedRow.Cells(6).Value.ToString() = "Male" Then
                RadioButton1.Checked = True
            ElseIf selectedRow.Cells(6).Value.ToString() = "Female" Then
                RadioButton2.Checked = True
            End If


            contact.Text = selectedRow.Cells(8).Value.ToString()
            email.Text = selectedRow.Cells(9).Value.ToString()
            category.Text = selectedRow.Cells(10).Value.ToString()
            status.Text = selectedRow.Cells(7).Value.ToString()

            TextBox2.Text = selectedRow.Cells(1).Value.ToString()
            TextBox3.Text = selectedRow.Cells(2).Value.ToString()
            TextBox4.Text = selectedRow.Cells(3).Value.ToString()
            TextBox5.Text = selectedRow.Cells(5).Value.ToString()

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

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
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

        If String.IsNullOrEmpty(category.Text) Then
            Me.ErrorProvider1.SetError(Me.category, "Input category")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.category, "")
        End If

        If String.IsNullOrEmpty(status.Text) Then
            Me.ErrorProvider1.SetError(Me.status, "Input status")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.status, "")
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

                query = "UPDATE persons set fname = '" & fname.Text & "', mname = '" & mname.Text & "', sname = '" & sname.Text & "', contact = '" & contact.Text & "',email = '" & email.Text & "',category = '" & category.Text & "',status = '" & status.Text & "', dob = '" & DateTimePicker1.Value & "', profile_image = @profile_image, nname = '" & nickname.Text & "' where person_id = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                nickname.Text = ""
                contact.Text = ""
                email.Text = ""
                status.Text = ""
                category.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Text = ""
                ComboBox2.Text = ""
                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.category, "")
                Me.ErrorProvider1.SetError(Me.status, "")
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

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Try
                Dim query As String
                mysqlconn.Open()
                query = "DELETE FROM persons WHERE person_id = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)

                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                load_table()
                mysqlconn.Close()

                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                nickname.Text = ""
                contact.Text = ""
                email.Text = ""
                status.Text = ""
                category.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                TextBox1.Text = ""
                ComboBox2.Text = ""
                load_table()
            Catch ex As Exception
                MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Dim myDateofBirth As Date
    Dim currentDate As Date
    Dim daySpan As TimeSpan
    Dim difference As Double
    Dim age As String

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
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
        nickname.Text = ""
        contact.Text = ""
        email.Text = ""
        status.Text = ""
        category.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Text = ""
        ComboBox2.Text = ""
        load_table()
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
            query = "select person_id as ID, fname as Firstname, mname as Middlename, sname as Surname, nname as Nickname, dob as Birthday, gender as Gender, status as Status, contact as Contact, email as Email, category as Category, date_created as DateCreated FROM persons"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
            ComboBox2.Text = ""
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
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
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try

            Me.Close()
            Form1.Show()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub
End Class