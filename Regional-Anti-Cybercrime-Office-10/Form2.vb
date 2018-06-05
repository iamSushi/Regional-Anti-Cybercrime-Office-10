Imports MySql.Data.MySqlClient

Public Class Form2
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Public Property lab_case As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Do While panel_slide.Width > 0
            panel_slide.Width = panel_slide.Width - 1
        Loop
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Do While panel_slide.Width < 109
            panel_slide.Width = panel_slide.Width + 1
        Loop
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Application.ExitThread()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form13.Show()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String
            query = "insert into facts values('" & lab_case & "','" & factname.Text & "','" & DateTimePicker2.Value & "','" & DateTimePicker3.Value & "','" & TextBox13.Text & "','" & TextBox4.Text & "','" & facts.Text & "',null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            TextBox6.Text = ""
            TextBox13.Text = ""
            TextBox4.Text = ""
            factname.Text = ""
            facts.Text = ""

            DateTimePicker1.Text = ""
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String
            query = "update facts set what ='" & factname.Text & "', date_occur = '" & DateTimePicker2.Value & "', time_occur =='" & DateTimePicker3.Value & "', place_occur = '" & TextBox13.Text & "', why = '" & TextBox4.Text & "', how = '" & facts.Text & "' where lab_Case_no = '" & lab_case & "' "
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            TextBox6.Text = ""
            TextBox13.Text = ""
            TextBox4.Text = ""
            factname.Text = ""
            facts.Text = ""

            DateTimePicker1.Text = ""
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
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

            query = "select lab_case_no_id,date_received,requesting_agency,examiner,investigator from laboratory_case"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView2.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

End Class