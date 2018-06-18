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

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
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
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try

            Me.Close()
            Form1.Show()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form13.Show()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(lab_case) Then
            Me.ErrorProvider1.SetError(Me.Button11, "Input Laboratory Case ID")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.Button11, "")
        End If
        If String.IsNullOrEmpty(factname.Text) Then
            Me.ErrorProvider1.SetError(Me.factname, "Input What")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.factname, "")
        End If
        If String.IsNullOrEmpty(TextBox13.Text) Then
            Me.ErrorProvider1.SetError(Me.TextBox13, "Input Place of Occurence")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.TextBox13, "")
        End If
        If String.IsNullOrEmpty(facts.Text) Then
            Me.ErrorProvider1.SetError(Me.facts, "Input How")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.facts, "")
        End If


        If count > 0 Then
            Return
        Else
            mysqlconn = New MySqlConnection
            mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

            Try
                mysqlconn.Open()

                Dim query As String
                query = "insert into facts values('" & lab_case & "','" & factname.Text & "','" & DateTimePicker2.Value & "','" & TextBox2.Text & "','" & TextBox13.Text & "','" & TextBox4.Text & "','" & facts.Text & "',null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                TextBox6.Text = ""
                TextBox2.Text = ""
                TextBox13.Text = ""
                TextBox4.Text = ""
                factname.Text = ""
                facts.Text = ""
                DateTimePicker1.Text = ""
                load_table()
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String
            query = "update facts set what ='" & factname.Text & "', date_occur = '" & DateTimePicker2.Value & "', time_occur ='" & TextBox2.Text & "', place_occur = '" & TextBox13.Text & "', why = '" & TextBox4.Text & "', how = '" & facts.Text & "' where lab_Case_no = '" & lab_case & "' "
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            TextBox6.Text = ""
            TextBox13.Text = ""
            TextBox2.Text = ""
            TextBox4.Text = ""
            factname.Text = ""
            facts.Text = ""
            DateTimePicker1.Text = ""
            load_table()
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try



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

            query = "select laboratory_case.lab_case_no as ID, laboratory_case.lab_case_no_id as CaseID, facts.what as What, facts.date_occur as Date_Occurence, facts.time_occur as Time_Occurence, facts.place_occur as Place_Occurence, facts.why as Why, facts.how as How from facts inner join laboratory_case on facts.lab_case_no = laboratory_case.lab_Case_no order by ID desc"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView2.DataSource = soure

            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

        Dim adapter2 As New MySqlDataAdapter
        Dim dbDataSet2 As New DataTable
        Dim soure2 As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select laboratory_case.lab_case_no as ID, laboratory_case.lab_case_no_id as CaseID, facts.what as What, facts.date_occur as Date_Occurence, facts.time_occur as Time_Occurence, facts.place_occur as Place_Occurence, facts.why as Why, facts.how as How from facts inner join laboratory_case on facts.lab_case_no = laboratory_case.lab_Case_no "
            command = New MySqlCommand(query, mysqlconn)
            adapter2.SelectCommand = command
            adapter2.Fill(dbDataSet2)
            soure2.DataSource = dbDataSet2
            DataGridView1.DataSource = soure2

            adapter2.Update(dbDataSet2)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        Me.DataGridView1.Columns("ID").Visible = False
        Me.DataGridView2.Columns("ID").Visible = False
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView2.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim what = row.Cells("What").Value.ToString
                Dim date_occ = row.Cells("Date_Occurence").Value.ToString
                Dim time_occ = row.Cells("Time_Occurence").Value.ToString
                Dim place_occ = row.Cells("Place_Occurence").Value.ToString
                Dim why = row.Cells("Why").Value.ToString
                Dim how = row.Cells("How").Value.ToString
                Dim name = row.Cells("CaseID").Value.ToString

                factname.Text = what

                TextBox2.Text = time_occ
                TextBox13.Text = place_occ
                TextBox4.Text = why
                TextBox6.Text = name
                facts.Text = how
                lab_case = pili

            End If

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim what = row.Cells("What").Value.ToString
                Dim date_occ = row.Cells("Date_Occurence").Value.ToString
                Dim time_occ = row.Cells("Time_Occurence").Value.ToString
                Dim place_occ = row.Cells("Place_Occurence").Value.ToString
                Dim why = row.Cells("Why").Value.ToString
                Dim how = row.Cells("How").Value.ToString
                Dim name = row.Cells("CaseID").Value.ToString

                factname.Text = what

                TextBox2.Text = time_occ
                TextBox13.Text = place_occ
                TextBox4.Text = why
                TextBox6.Text = name
                facts.Text = how
                lab_case = pili

            End If

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Try
                mysqlconn.Open()

                Dim query As String

                query = "delete from    facts where lab_case_no = '" & lab_case & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                load_table()
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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

            query = "select laboratory_case.lab_case_no as ID, laboratory_case.lab_case_no_id as CaseID, facts.what as What, facts.date_occur as Date_Occurence, facts.time_occur as Time_Occurence, facts.place_occur as Place_Occurence, facts.why as Why, facts.how as How from facts inner join laboratory_case on facts.lab_case_no = laboratory_case.lab_Case_no where lab_case_no_id like '" & TextBox1.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select laboratory_case.lab_case_no as ID, laboratory_case.lab_case_no_id as CaseID, facts.what as What, facts.date_occur as Date_Occurence, facts.time_occur as Time_Occurence, facts.place_occur as Place_Occurence, facts.why as Why, facts.how as How from facts inner join laboratory_case on facts.lab_case_no = laboratory_case.lab_Case_no where date_occur like '" & DateTimePicker1.Value & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select laboratory_case.lab_case_no as ID, laboratory_case.lab_case_no_id as CaseID, facts.what as What, facts.date_occur as Date_Occurence, facts.time_occur as Time_Occurence, facts.place_occur as Place_Occurence, facts.why as Why, facts.how as How from facts inner join laboratory_case on facts.lab_case_no = laboratory_case.lab_Case_no where time_occur like '" & TextBox3.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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