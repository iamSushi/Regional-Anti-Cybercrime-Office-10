Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form7
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader


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

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Try
            mysqlconn.Open()
            Dim query As String

            query = "SELECT * from userprofile WHERE status = 1"
            command = New MySqlCommand(query, mysqlconn)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            TextBox10.Text = table.Rows(0)(0).ToString()
            TextBox1.Text = table.Rows(0)(1).ToString() + " " + table.Rows(0)(2).ToString() + " " + table.Rows(0)(3).ToString()
            TextBox2.Text = table.Rows(0)(4).ToString()
            TextBox3.Text = table.Rows(0)(5).ToString()

            Dim img() As Byte

            img = table.Rows(0)(8)
            Dim ms As New MemoryStream(img)

            PictureBox2.Image = Image.FromStream(ms)

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub officer_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()
            Dim query As String

            query = "SELECT officer_id as ID, fname as Firstname, mname as Middlename, sname as Surname, position as Position, rank as Rank from officer"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles Me.Load
        load_table()
        officer_table()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(TextBox6.Text) Then
            Me.ErrorProvider1.SetError(Me.TextBox6, "Input current password")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.TextBox6, "")
        End If

        If TextBox6.Text <> TextBox9.Text Then
            MessageBox.Show("Current password don't match!")
            load_table()
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            count += 1
        End If

        If String.IsNullOrEmpty(TextBox7.Text) Then
            Me.ErrorProvider1.SetError(Me.TextBox7, "Input new password")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.TextBox7, "")
        End If

        If String.IsNullOrEmpty(TextBox8.Text) Then
            Me.ErrorProvider1.SetError(Me.TextBox8, "Input retype password")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.TextBox8, "")
        End If

        If TextBox7.Text <> TextBox8.Text Then
            MessageBox.Show("New password don't match!")
            TextBox7.Text = ""
            TextBox8.Text = ""
            count += 1
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()
                If String.IsNullOrEmpty(TextBox5.Text) Then
                    Dim query As String
                    query = "UPDATE accounts SET username = '" & TextBox3.Text & "', password = '" & TextBox8.Text & "' WHERE officer_id = '" & TextBox10.Text & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Updated Successfully!")
                Else
                    Dim query As String
                    query = "UPDATE accounts SET username = '" & TextBox5.Text & "', password = '" & TextBox8.Text & "' WHERE officer_id = '" & TextBox10.Text & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Updated Successfully!")
                End If
                load_table()
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                mysqlconn.Close()

                count = 0
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form12.Show()
    End Sub
End Class