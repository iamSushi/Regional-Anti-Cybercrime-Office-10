Imports MySql.Data.MySqlClient

Public Class Form4
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Public Property complainant As String
    Public Property released_by As String
    Public Property claimed_by As String
    Public Property investigator As String
    Public Property examiner As String
    Public Property agency As String

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
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try

            Me.Close()
            Form1.Show()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString

                Form25.lab_case = pili
                Form26.lab_case = pili
                Form25.Show()

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        Me.DataGridView1.Columns("ID").Visible = False
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

            query = "select * from laboratory"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)


            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
        ComboBox1.Items.Add("Pending")
        ComboBox1.Items.Add("For Released")
        ComboBox1.Items.Add("Released")
        ComboBox2.Items.Add("Computer")
        ComboBox2.Items.Add("Cellphone")
        ComboBox2.Items.Add("Audio Visual")
        ComboBox2.Items.Add("Intel")
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Form2.Show()
        Me.Close()
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

            query = "select * from laboratory where CaseID like '" & TextBox1.Text & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            query = "select * from laboratory where DateReleased like '" & DateTimePicker1.Value & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where DateInformed like '" & DateTimePicker2.Value & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where DateReleased like '" & DateTimePicker3.Value & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where DateExamined like '" & DateTimePicker4.Value & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub


    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        TextBox4.Text = ""
        Try
            mysqlconn.Open()

            Dim query As String

            query = "SELECT 
                    laboratory_case.lab_case_no as ID,
                    laboratory_case.lab_case_no_id as CaseID,
                    laboratory_case.date_received AS DateReceived,
                    laboratory_case.date_informed AS DateInformed,
                    laboratory_case.date_released AS DateReleased,
                    laboratory_case.date_examined AS DateExamined,
                    laboratory_case.case_status AS CaseStatus,
                    agency.agency_name AS RequestingAgency,
                    laboratory_case.type AS DFE,       
                    laboratory_case.complainant AS Complainant
                    FROM laboratory_case
                    INNER JOIN agency ON agency.agency_id = laboratory_case.requesting_agency
                    where Complainant like '" & complainant & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where RequestingAgency like'" & TextBox6.Text & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource
        TextBox5.Text = ""

        Try
            mysqlconn.Open()

            Dim query As String

            query = "SELECT 
                    laboratory_case.lab_case_no as ID,
                    laboratory_case.lab_case_no_id as CaseID,
                    laboratory_case.date_received AS DateReceived,
                    laboratory_case.date_informed AS DateInformed,
                    laboratory_case.date_released AS DateReleased,
                    laboratory_case.date_examined AS DateExamined,
                    laboratory_case.case_status AS CaseStatus,
                    agency.agency_name AS RequestingAgency,
                    laboratory_case.type AS DFE,
                    laboratory_case.released_by AS ReleasedBy
                    FROM laboratory_case
                    INNER JOIN agency ON agency.agency_id = laboratory_case.requesting_agency
                    where Released_by like '" & released_by & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        TextBox7.Text = ""

        Try
            mysqlconn.Open()

            Dim query As String

            query = "SELECT 
                    laboratory_case.lab_case_no as ID,
                    laboratory_case.lab_case_no_id as CaseID,
                    laboratory_case.date_received AS DateReceived,
                    laboratory_case.date_informed AS DateInformed,
                    laboratory_case.date_released AS DateReleased,
                    laboratory_case.date_examined AS DateExamined,
                    laboratory_case.case_status AS CaseStatus,
                    agency.agency_name AS RequestingAgency,
                    laboratory_case.type AS DFE,
                    laboratory_case.claimed_by AS ClaimedBy
                    FROM laboratory_case
                    INNER JOIN agency ON agency.agency_id = laboratory_case.requesting_agency
                    where Claimed_By like '" & claimed_by & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub



    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "SELECT 
                    laboratory_case.lab_case_no as ID,
                    laboratory_case.lab_case_no_id as CaseID,
                    laboratory_case.date_received AS DateReceived,
                    laboratory_case.date_informed AS DateInformed,
                    laboratory_case.date_released AS DateReleased,
                    laboratory_case.date_examined AS DateExamined,
                    laboratory_case.case_status AS CaseStatus,
                    agency.agency_name AS RequestingAgency,
                    laboratory_case.type AS DFE,
                    laboratory_case.investigator AS InvestigatorID
                    FROM laboratory_case
                    INNER JOIN agency ON agency.agency_id = laboratory_case.requesting_agency
                    where investigator like '" & investigator & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)
            TextBox9.Clear()

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "SELECT 
                    laboratory_case.lab_case_no as ID,
                    laboratory_case.lab_case_no_id as CaseID,
                    laboratory_case.date_received AS DateReceived,
                    laboratory_case.date_informed AS DateInformed,
                    laboratory_case.date_released AS DateReleased,
                    laboratory_case.date_examined AS DateExamined,
                    laboratory_case.case_status AS CaseStatus,
                    agency.agency_name AS RequestingAgency,
                    laboratory_case.type AS DFE,
                    laboratory_case.examiner AS ExaminerID
                    FROM laboratory_case
                    INNER JOIN agency ON agency.agency_id = laboratory_case.requesting_agency
                    where examiner like '" & examiner & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)
            TextBox8.Clear()

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where CaseStatus like '" & ComboBox1.Text & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs)
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select * from laboratory where RequestingAgency like'" & agency & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)
            TextBox6.Clear()
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox6_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox6.MouseDoubleClick


    End Sub

    Private Sub TextBox4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox4.MouseDoubleClick
        Form24.Show()
    End Sub

    Private Sub TextBox5_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseDoubleClick
        Form21.Show()
    End Sub

    Private Sub TextBox7_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox7.MouseDoubleClick
        Form22.Show()
    End Sub

    Private Sub TextBox8_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox8.MouseDoubleClick
        Form14.Show()
    End Sub

    Private Sub TextBox9_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox9.MouseDoubleClick
        Form15.Show()
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

            query = "select * from laboratory where DFE like ' " & ComboBox2.Text & "%' "

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString

                Form25.lab_case = pili
                Form26.lab_case = pili
                Me.Close()
                Form25.Show()

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString

                Form25.lab_case = pili
                Form26.lab_case = pili
                Me.Close()
                Form25.Show()

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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