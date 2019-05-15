Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form7
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer

    Private Sub button4_click(sender As Object, e As EventArgs) Handles Button4.Click
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            'mysqlconn = New MySqlConnection
            'mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
            'Try
            '    mysqlconn.Open()
            '    Dim query2 As String
            '    query2 = "UPDATE accounts SET status = 0 WHERE status = 1"
            '    command = New MySqlCommand(query2, mysqlconn)
            '    reader = command.ExecuteReader

            '    mysqlconn.Close()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'Finally
            '    mysqlconn.Dispose()
            'End Try

            Me.Close()
            Form1.Show()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Form10.Show()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Form11.Show()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Form16.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
        Me.Close()
    End Sub


    'Private Sub load_table()
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
    '    Try
    '        mysqlconn.Open()
    '        Dim query As String

    '        query = "SELECT * from userprofile WHERE status = 1"
    '        command = New MySqlCommand(query, mysqlconn)
    '        Dim adapter As New MySqlDataAdapter(command)
    '        Dim table As New DataTable()
    '        adapter.Fill(table)

    '        TextBox10.Text = table.Rows(0)(0).ToString()
    '        TextBox1.Text = table.Rows(0)(1).ToString() + " " + table.Rows(0)(2).ToString() + " " + table.Rows(0)(3).ToString()
    '        TextBox2.Text = table.Rows(0)(4).ToString()
    '        TextBox3.Text = table.Rows(0)(5).ToString()

    '        TextBox9.Text = table.Rows(0)(6).ToString()
    '        Dim img() As Byte

    '        img = table.Rows(0)(8)
    '        Dim ms As New MemoryStream(img)

    '        PictureBox2.Image = Image.FromStream(ms)

    '        mysqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    Finally
    '        mysqlconn.Dispose()
    '    End Try
    'End Sub

    'Private Sub officer_table()
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
    '    Dim adapter As New MySqlDataAdapter
    '    Dim dbDataSet As New DataTable
    '    Dim soure As New BindingSource

    '    Try
    '        mysqlconn.Open()
    '        Dim query As String

    '        query = "SELECT officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, position as Position, rank as Rank FROM officer WHERE position != 'admin'"
    '        command = New MySqlCommand(query, mysqlconn)
    '        adapter.SelectCommand = command
    '        adapter.Fill(dbDataSet)
    '        soure.DataSource = dbDataSet
    '        DataGridView1.DataSource = soure
    '        adapter.Update(dbDataSet)

    '        mysqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    Finally
    '        mysqlconn.Dispose()
    '    End Try
    'End Sub

    'Private Sub accounts_table()
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
    '    Dim adapter As New MySqlDataAdapter
    '    Dim dbDataSet As New DataTable
    '    Dim soure As New BindingSource

    '    Try
    '        mysqlconn.Open()
    '        Dim query As String

    '        query = "SELECT officer.officer_id as ID, officer.fname as Firstname, officer.sname as Surname, officer.position as Position, officer.rank as Rank, officer.agency as Agency, accounts.username as Username, accounts.date_created as DateCreated FROM accounts INNER JOIN officer ON officer.officer_id = accounts.officer_id WHERE position != 'admin'"
    '        command = New MySqlCommand(query, mysqlconn)
    '        adapter.SelectCommand = command
    '        adapter.Fill(dbDataSet)
    '        soure.DataSource = dbDataSet
    '        DataGridView2.DataSource = soure
    '        adapter.Update(dbDataSet)

    '        mysqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    Finally
    '        mysqlconn.Dispose()
    '    End Try
    'End Sub

    'Private Sub Form7_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    load_table()
    '    officer_table()
    '    accounts_table()
    '    Me.DataGridView1.Columns("ID").Visible = False
    '    Me.DataGridView2.Columns("ID").Visible = False
    'End Sub

    'Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"

    '    Dim count As Int16
    '    count = 0

    '    If String.IsNullOrEmpty(TextBox6.Text) Then
    '        Me.ErrorProvider1.SetError(Me.TextBox6, "Input current password")
    '        count += 1
    '    Else
    '        Me.ErrorProvider1.SetError(Me.TextBox6, "")
    '    End If

    '    Dim z As String = TextBox6.Text
    '    Dim pft() As Byte = System.Text.Encoding.UTF8.GetBytes(z)
    '    Dim kaka As String = System.Convert.ToBase64String(pft)

    '    If kaka <> TextBox9.Text Then
    '        MessageBox.Show("Current password don't match!")
    '        load_table()
    '        TextBox6.Text = ""
    '        TextBox7.Text = ""
    '        TextBox8.Text = ""
    '        count += 1
    '    End If

    '    If String.IsNullOrEmpty(TextBox7.Text) Then
    '        Me.ErrorProvider1.SetError(Me.TextBox7, "Input new password")
    '        count += 1
    '    Else
    '        Me.ErrorProvider1.SetError(Me.TextBox7, "")
    '    End If

    '    If String.IsNullOrEmpty(TextBox8.Text) Then
    '        Me.ErrorProvider1.SetError(Me.TextBox8, "Input retype password")
    '        count += 1
    '    Else
    '        Me.ErrorProvider1.SetError(Me.TextBox8, "")
    '    End If

    '    If TextBox7.Text <> TextBox8.Text Then
    '        MessageBox.Show("New password don't match!")
    '        TextBox7.Text = ""
    '        TextBox8.Text = ""
    '        count += 1
    '    End If

    '    If count <> 0 Then
    '        Return
    '    Else
    '        Try
    '            Dim s As String = TextBox8.Text
    '            Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(s)
    '            Dim sb64 As String = System.Convert.ToBase64String(bArry)

    '            mysqlconn.Open()
    '            If String.IsNullOrEmpty(TextBox5.Text) Then
    '                Dim query As String
    '                query = "UPDATE accounts SET username = '" & TextBox3.Text & "', password = '" & sb64 & "' WHERE officer_id = '" & TextBox10.Text & "'"
    '                command = New MySqlCommand(query, mysqlconn)
    '                reader = command.ExecuteReader
    '                MessageBox.Show("Updated Successfully!")
    '            Else
    '                Dim query As String
    '                query = "UPDATE accounts SET username = '" & TextBox5.Text & "', password = '" & sb64 & "' WHERE officer_id = '" & TextBox10.Text & "'"
    '                command = New MySqlCommand(query, mysqlconn)
    '                reader = command.ExecuteReader
    '                MessageBox.Show("Updated Successfully!")
    '            End If

    '            load_table()
    '            TextBox5.Text = ""
    '            TextBox6.Text = ""
    '            TextBox7.Text = ""
    '            TextBox8.Text = ""
    '            TextBox9.Text = ""
    '            TextBox10.Text = ""
    '            mysqlconn.Close()

    '            count = 0
    '        Catch ex As Exception
    '            MessageBox.Show("Invalid user input", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Finally
    '            mysqlconn.Dispose()
    '        End Try
    '    End If
    '    load_table()
    '    officer_table()
    '    accounts_table()
    'End Sub

    'Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
    '    Form12.Show()
    'End Sub

    'Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
    '    Dim adapter As New MySqlDataAdapter
    '    Dim dbDataSet As New DataTable
    '    Dim soure As New BindingSource

    '    Try
    '        mysqlconn.Open()
    '        Dim query As String

    '        query = "SELECT officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, position as Position, rank as Rank FROM officer WHERE fname like '" & TextBox4.Text & "%' or mname like '" & TextBox4.Text & "%' or sname like '" & TextBox4.Text & "%' and position != 'Admin'"

    '        command = New MySqlCommand(query, mysqlconn)
    '        adapter.SelectCommand = command
    '        adapter.Fill(dbDataSet)
    '        soure.DataSource = dbDataSet
    '        DataGridView1.DataSource = soure
    '        adapter.Update(dbDataSet)
    '        officer_table()
    '        If String.IsNullOrEmpty(TextBox4.Text) Then
    '            load_table()
    '        End If
    '        mysqlconn.Close()
    '    Catch ex As MySqlException
    '        MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    Finally
    '        mysqlconn.Dispose()
    '    End Try

    'End Sub


    'Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    '    Try
    '        index = e.RowIndex
    '        Dim selectedRow As DataGridViewRow
    '        selectedRow = DataGridView1.Rows(index)

    '        id.Text = selectedRow.Cells(0).Value.ToString()
    '        TextBox11.Text = selectedRow.Cells(3).Value.ToString()
    '    Catch ex As Exception
    '        Return
    '    End Try
    'End Sub

    'Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
    '    Dim count As Int16
    '    Dim query As String
    '    count = 0
    '    mysqlconn.Open()
    '    query = "SELECT * FROM accounts WHERE officer_id = '" & id.Text & "'"
    '    command = New MySqlCommand(query, mysqlconn)
    '    reader = command.ExecuteReader

    '    While reader.Read
    '        count += 1
    '    End While
    '    count = count - 1

    '    mysqlconn.Close()
    '    If count <> 0 Then
    '        Try
    '            Dim s As String = TextBox11.Text
    '            Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(s)
    '            Dim sb64 As String = System.Convert.ToBase64String(bArry)

    '            Dim query2 As String
    '            mysqlconn.Open()
    '            query2 = "INSERT INTO accounts VALUES('" & id.Text & "',null,'" & TextBox11.Text & "','" & sb64 & "','',NOW())"
    '            command = New MySqlCommand(query2, mysqlconn)
    '            reader = command.ExecuteReader
    '            mysqlconn.Close()
    '            MessageBox.Show("Successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            count = 0
    '        Catch ex As Exception
    '            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End Try
    '    Else
    '        MessageBox.Show("User account has already existed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If

    '    mysqlconn.Close()
    '    accounts_table()
    '    officer_table()
    'End Sub

    'Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
    '    Try
    '        index = e.RowIndex
    '        Dim selectedRow As DataGridViewRow
    '        selectedRow = DataGridView2.Rows(index)
    '        id.Text = selectedRow.Cells(0).Value.ToString()
    '    Catch ex As Exception
    '        Return
    '    End Try
    'End Sub

    'Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

    '    Dim dialog As DialogResult
    '    dialog = MessageBox.Show("Do you really want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If dialog = DialogResult.Yes Then
    '        Try
    '            mysqlconn.Open()

    '            Dim query As String

    '            query = "DELETE FROM accounts WHERE officer_id = '" & id.Text & "'"
    '            command = New MySqlCommand(query, mysqlconn)
    '            reader = command.ExecuteReader

    '            MessageBox.Show("Successfully removed user!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            mysqlconn.Close()

    '        Catch ex As MySqlException
    '            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Finally
    '            mysqlconn.Dispose()
    '        End Try
    '    ElseIf dialog = DialogResult.No Then
    '        Me.DialogResult = DialogResult.None
    '    End If

    '    accounts_table()
    '    officer_table()
    'End Sub

    'Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
    '    Dim dialog As DialogResult
    '    dialog = MessageBox.Show("Do you really want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If dialog = DialogResult.Yes Then
    '        mysqlconn = New MySqlConnection
    '        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
    '        Try
    '            mysqlconn.Open()
    '            Dim query2 As String
    '            query2 = "UPDATE accounts SET status = 0 WHERE status = 1"
    '            command = New MySqlCommand(query2, mysqlconn)
    '            reader = command.ExecuteReader

    '            mysqlconn.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        Finally
    '            mysqlconn.Dispose()
    '        End Try

    '        Me.Close()
    '        Form1.Show()
    '    ElseIf dialog = DialogResult.No Then
    '        Me.DialogResult = DialogResult.None
    '    End If
    'End Sub


End Class