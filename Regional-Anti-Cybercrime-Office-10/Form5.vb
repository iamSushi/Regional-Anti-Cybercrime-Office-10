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
        Do While panel_slide.Width < 109
            panel_slide.Width = panel_slide.Width + 1
        Loop
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Do While panel_slide.Width > 0
            panel_slide.Width = panel_slide.Width - 1
        Loop
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
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

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

        If String.IsNullOrEmpty(mname.Text) Then
            Me.ErrorProvider1.SetError(Me.mname, "Input middlename")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.mname, "")
        End If

        If String.IsNullOrEmpty(sname.Text) Then
            Me.ErrorProvider1.SetError(Me.sname, "Input surname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.sname, "")
        End If

        If String.IsNullOrEmpty(contact.Text) Then
            Me.ErrorProvider1.SetError(Me.contact, "Input contact")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.contact, "")
        End If

        If String.IsNullOrEmpty(email.Text) Then
            Me.ErrorProvider1.SetError(Me.email, "Input email")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.email, "")
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
                    gender = "male"
                Else
                    gender = "female"
                End If

                query = "insert into persons values(null,'" & fname.Text & "','" & mname.Text & "','" & sname.Text & "','null','" & DateTimePicker1.Text & "','" & gender & "','" & status.Text & "','" & contact.Text & "','" & email.Text & "','" & category.Text & "',@profile_image,null)"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                contact.Text = ""
                email.Text = ""
                DateTimePicker1.Text = ""
                status.Text = ""
                category.Text = ""
                PictureBox2.Image = Nothing

                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.mname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.contact, "")
                Me.ErrorProvider1.SetError(Me.email, "")
                Me.ErrorProvider1.SetError(Me.category, "")
                Me.ErrorProvider1.SetError(Me.status, "")
                count = 0
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

            query = "select person_id as ID,fname as Firstname, mname as Middlename, sname as Surname, dob as Birthdate, gender as Gender, status as Status, contact as ContactNo, email as EmailAddress, category as Category, date_created as DateCreated from persons"
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

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()

    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
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
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            mysqlconn = New MySqlConnection
            mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
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

            Application.ExitThread()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from persons where category = '" & ComboBox2.Text & "'"

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select fname as First, mname as Middle, sname as Surname, dob as Birthday, gender as Gender, status as Status, contact as Contact, email as Email, category as Category, date_created as Created from persons where fname like '" & TextBox1.Text & "%' or mname like '" & TextBox1.Text & "%' or sname like '" & TextBox1.Text & "%'"

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from persons where category = '" & ComboBox2.Text & "'"

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

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.ImageLocation = OpenFileDialog1.FileName
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)

        id.Text = selectedRow.Cells(0).Value.ToString()
        fname.Text = selectedRow.Cells(1).Value.ToString()
        mname.Text = selectedRow.Cells(2).Value.ToString()
        sname.Text = selectedRow.Cells(3).Value.ToString()
        contact.Text = selectedRow.Cells(7).Value.ToString()
        email.Text = selectedRow.Cells(8).Value.ToString()
        category.Text = selectedRow.Cells(9).Value.ToString()
        status.Text = selectedRow.Cells(6).Value.ToString()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        'dim newdatarow as datagridviewrow
        'newdatarow = datagridview1.rows(index)

        'newdatarow.cells(1).value = fname.text
        'newdatarow.cells(2).value = mname.text
        'newdatarow.cells(3).value = sname.text
        'newdatarow.cells(7).value = contact.text
        'newdatarow.cells(8).value = email.text
        'newdatarow.cells(9).value = category.text
        'newdatarow.cells(6).value = status.text

        'msgbox("successfully updated!")
        'fname.text = ""
        'mname.text = ""
        'sname.text = ""
        'contact.text = ""
        'email.text = ""
        'category.text = ""
        'status.text = ""

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

        If String.IsNullOrEmpty(mname.Text) Then
            Me.ErrorProvider1.SetError(Me.mname, "Input middlename")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.mname, "")
        End If

        If String.IsNullOrEmpty(sname.Text) Then
            Me.ErrorProvider1.SetError(Me.sname, "Input surname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.sname, "")
        End If

        If String.IsNullOrEmpty(contact.Text) Then
            Me.ErrorProvider1.SetError(Me.contact, "Input contact")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.contact, "")
        End If

        If String.IsNullOrEmpty(email.Text) Then
            Me.ErrorProvider1.SetError(Me.email, "Input email")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.email, "")
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
                    gender = "male"
                Else
                    gender = "female"
                End If

                query = "UPDATE persons set fname = '" & fname.Text & "', mname = '" & mname.Text & "', sname = '" & sname.Text & "', contact = '" & contact.Text & "',email = '" & email.Text & "',category = '" & category.Text & "',status = '" & status.Text & "' where person_id = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)
                command.Parameters.AddWithValue("@profile_image", arrImage)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                fname.Text = ""
                mname.Text = ""
                sname.Text = ""
                contact.Text = ""
                email.Text = ""
                DateTimePicker1.Text = ""
                status.Text = ""
                category.Text = ""
                PictureBox2.Image = Nothing

                Me.ErrorProvider1.SetError(Me.fname, "")
                Me.ErrorProvider1.SetError(Me.mname, "")
                Me.ErrorProvider1.SetError(Me.sname, "")
                Me.ErrorProvider1.SetError(Me.contact, "")
                Me.ErrorProvider1.SetError(Me.email, "")
                Me.ErrorProvider1.SetError(Me.category, "")
                Me.ErrorProvider1.SetError(Me.status, "")
                count = 0
                load_table()
                mysqlconn.Close()

            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try
        End If

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            Dim query As String
            mysqlconn.Open()
            query = "DELETE FROM persons WHERE person_id = '" & id.Text & "'"
            command = New MySqlCommand(query, mysqlconn)

            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            load_table()
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class