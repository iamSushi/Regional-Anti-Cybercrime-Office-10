Imports MySql.Data.MySqlClient

Public Class Form3
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim command2 As MySqlCommand
    Dim reader2 As MySqlDataReader

    Dim examiner As String
    Dim investigator As String
    Dim examiner2 As String
    Dim investigator2 As String
    Dim lab_case_no As String
    Dim lab_case_no_ni As String

    Public Property releasedby As String
    Public Property claimedby As String
    Public Property agency As String
    Public Property complainant As String
    Public Property lab_case As String



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

    Private Sub Button32_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs)
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String

            query = "insert into laboratory_case values(null,'" & TextBox2.Text & "','" & DateTimePicker1.Text & "',null,null,null,'" & agency & "','null','null','null','null',null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""


            DateTimePicker1.Text = ""
            ComboBox3.Text = ""

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
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

            query = "select lab_case_no_id,date_received,requesting_agency,examiner,investigator from laboratory_case"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet

            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        load_table2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select officer_id as id , fname as f ,mname as m ,sname as s from officer where position = 'examiner'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("0", "")
            While reader.Read
                Dim fname = reader.GetString("f")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + sname
                Dim id = reader.GetString("id")
                comboSource.Add(id, name)
            End While
            ComboBox15.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox15.DisplayMember = "Value"
            ComboBox15.ValueMember = "Key"

            Dim examiner As String = DirectCast(ComboBox15.SelectedItem, KeyValuePair(Of String, String)).Key



            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select officer_id as id , fname as f ,mname as m ,sname as s from officer where position = 'investigator'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("0", "")
            While reader.Read
                Dim fname = reader.GetString("f")
                Dim sname = reader.GetString("s")
                Dim name = fname + " " + sname
                Dim id = reader.GetString("id")
                comboSource.Add(id, name)
            End While
            ComboBox17.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox17.DisplayMember = "Value"
            ComboBox17.ValueMember = "Key"

            Dim investigator As String = DirectCast(ComboBox17.SelectedItem, KeyValuePair(Of String, String)).Key

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        ComboBox3.Items.Add("Cellphone")
        ComboBox3.Items.Add("Computer")
        ComboBox3.Items.Add("Audio Visual")
        ComboBox3.Items.Add("Intel")

        ComboBox18.Items.Add("Stored")
        ComboBox18.Items.Add("Withdrawn")

        Me.DataGridView1.Columns("ID").Visible = False
        Me.DataGridView2.Columns("ID").Visible = False
        Me.DataGridView3.Columns("ID").Visible = False
    End Sub





    Private Sub Button32_Click_1(sender As Object, e As EventArgs) Handles Button32.Click


        If lab_case > 0 Then
            Form24.Show()
            Form24.lab_case = lab_case

        Else
            Me.ErrorProvider1.SetError(Me.Button35, "Select a Laboratory Case")
            MessageBox.Show("First Select Laboratory Case")
        End If

    End Sub

    Private Sub Button28_Click_1(sender As Object, e As EventArgs) Handles Button28.Click

        If lab_case > 0 Then
            Form8.Show()
            Form8.lab_case = lab_case
        Else
            Me.ErrorProvider1.SetError(Me.Button35, "Select a Laboratory Case")
            MessageBox.Show("First Select Laboratory Case")
        End If
    End Sub

    Private Sub Button21_Click_1(sender As Object, e As EventArgs) Handles Button21.Click

        If lab_case > 0 Then
            Form18.Show()
            Form18.lab_case = lab_case
        Else
            Me.ErrorProvider1.SetError(Me.Button35, "Select a Laboratory Case")
            MessageBox.Show("First Select Laboratory Case")
        End If
    End Sub

    Private Sub Button31_Click_1(sender As Object, e As EventArgs) Handles Button31.Click
        Dim count As Int16
        count = 0
        Dim investigator As String = DirectCast(ComboBox17.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim examiner As String = DirectCast(ComboBox15.SelectedItem, KeyValuePair(Of String, String)).Key
        If investigator = 0 Then

        Else

        End If
        If examiner > 0 Then
            Me.ErrorProvider1.SetError(Me.ComboBox15, "")
        Else
            Me.ErrorProvider1.SetError(Me.ComboBox15, "Select Examiner")
            count += 1
        End If
        If String.IsNullOrEmpty(TextBox2.Text) Then
            Me.ErrorProvider1.SetError(Me.TextBox2, "Input Laboratory Case ID")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.TextBox2, "")
        End If
        If String.IsNullOrEmpty(ComboBox13.Text) Then
            Me.ErrorProvider1.SetError(Me.ComboBox13, "Input Case Status")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.ComboBox13, "")
        End If
        If String.IsNullOrEmpty(agency) Then
            Me.ErrorProvider1.SetError(Me.Button34, "Input firstname")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.Button34, "")
        End If

        If String.IsNullOrEmpty(ComboBox3.Text) Then
            Me.ErrorProvider1.SetError(Me.ComboBox3, "Input DFE")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.ComboBox3, "")
        End If

        If count > 0 Then
            Return

        Else
            mysqlconn = New MySqlConnection
            mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

            count = 0

            Try
                mysqlconn.Open()

                Dim query As String
                Dim query1 As String


                query = "insert into laboratory_case values(null,'" & TextBox2.Text & "','" & DateTimePicker1.Value.ToShortDateString & "','null','" & DateTimePicker5.Value.ToShortDateString & "','" & DateTimePicker6.Value.ToShortDateString & "','" & ComboBox13.Text & "',0,0,'null','" & agency & "','" & examiner & "','" & investigator & "',' " & ComboBox3.Text & " ',null)"
                query1 = "insert into laboratory_case values(null,         '1'            ,'          1                 ','3','4','5',          '6',      '     7       ',   '       8'           ,'        9                  ','              10             ','             11          ', 12 ,null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                TextBox2.Text = ""
                TextBox7.Text = ""
                ComboBox13.Text = ""
                ComboBox15.Text = ""
                ComboBox17.Text = ""
                ComboBox3.Text = ""
                DateTimePicker1.Text = ""
                load_table()
                load_table2()
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
            investigator = "0"
            examiner = "0"
        End If


    End Sub

    Private Sub Button36_Click_1(sender As Object, e As EventArgs) Handles Button36.Click


        If lab_case > 0 Then
            Form19.Show()
        Else
            Me.ErrorProvider1.SetError(Me.Button35, "Select a Laboratory Case")
            MessageBox.Show("First Select Laboratory Case")
        End If
    End Sub


    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        If lab_case > 0 Then
            Try
                mysqlconn.Open()
                Dim query As String
                Dim query1 As String
                query = "insert into evidence values('" & lab_case & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "', '" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & ComboBox7.Text & "','" & ComboBox8.Text & "','" & ComboBox9.Text & "','" & ComboBox10.Text & "','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & ComboBox16.Text & "','" & ComboBox14.Text & "','" & ComboBox18.Text & "',null )"
                query1 = "insert into laboratory_case values(null,         '1'            ,'          1                 ','3','4','5',          '6',      '     7       ',   '       8'           ,'        9                  ','              10             ','             11          ', 12 ,null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")
                TextBox1.Text = ""
                TextBox8.Text = ""
                TextBox4.Text = ""
                TextBox11.Text = ""
                TextBox3.Text = ""
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox5.Text = ""
                ComboBox4.Text = ""
                ComboBox6.Text = ""
                ComboBox7.Text = ""
                ComboBox8.Text = ""
                ComboBox9.Text = ""
                ComboBox10.Text = ""
                ComboBox11.Text = ""
                ComboBox12.Text = ""
                ComboBox15.Text = ""
                ComboBox14.Text = ""
                ComboBox16.Text = ""
                ComboBox18.Text = ""
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try

            Try
                mysqlconn.Open()
                Dim query As String
                query = "update laboratory_case set complainant = '" + complainant + "' where lab_case_no = '" & lab_case & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")

                TextBox3.Text = ""

                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try

        Else
            Me.ErrorProvider1.SetError(Me.Button35, "Select a Laboratory Case")
            MessageBox.Show("First Select Laboratory Case")
        End If


    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Form13.Show()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs)
        Form21.Show()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs)
        Form22.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Form23.Show()
    End Sub

    Private Sub Button25_Click_1(sender As Object, e As EventArgs) Handles Button25.Click
        Form21.Show()
    End Sub

    Private Sub Button27_Click_1(sender As Object, e As EventArgs) Handles Button27.Click
        Form22.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        If lab_case_no > 0 Then

            If releasedby > 0 Then
                Try
                    mysqlconn.Open()
                    Dim query As String
                    query = "update laboratory_case set released_by = '" + releasedby + "' where lab_case_no = '" & lab_case_no & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Successful")

                    TextBox5.Text = ""

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    mysqlconn.Dispose()
                End Try
            End If

            If claimedby > 0 Then
                Try
                    mysqlconn.Open()
                    Dim query As String
                    query = "update laboratory_case set claimed_by = '" + claimedby + "' where lab_case_no = '" & lab_case_no & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader
                    MessageBox.Show("Successful")

                    TextBox6.Text = ""

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    mysqlconn.Dispose()
                End Try


            End If
            Try
                mysqlconn.Open()
                Dim query As String
                query = "update laboratory_case set date_informed = '" + DateTimePicker4.Value + "' where lab_case_no = '" & lab_case_no & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successful")

                TextBox6.Text = ""

                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                mysqlconn.Dispose()
            End Try
        Else
            MessageBox.Show("First Select Laboratory Case")


            Me.ErrorProvider1.SetError(Me.TextBox10, "Select Examiner")

        End If

        TextBox10.Text = ""
        TextBox12.Text = ""
        TextBox14.Text = ""


    End Sub

    Private Sub load_table2()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select lab_case_no as ID,lab_case_no_id as CaseID,date_received as Date_Received,date_released as Date_Released,date_examined as Date_Examined,case_status as Case_Status,type as DFE from laboratory_case order by lab_case_no desc"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView3.DataSource = soure
            DataGridView2.DataSource = soure
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Try
            mysqlconn.Open()
            TextBox10.Text = ""
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView2.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim case_name = row.Cells("CaseID").Value.ToString
                TextBox10.Text = case_name
                lab_case_no = pili
                Dim query As String
                query = "select * from laboratory_case where lab_case_no = '" & pili & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader

                While reader.Read
                    examiner2 = reader.GetString("examiner")
                    investigator2 = reader.GetString("investigator")
                End While

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try
        Try
            mysqlconn.Open()

            Dim query As String
            query = "select fname,mname,sname from officer where officer_id = '" & examiner2 & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name_ni = f + " " + m + " " + s
                TextBox12.Text = name_ni
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select fname,mname,sname from officer where officer_id = '" & investigator2 & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name_ni = f + " " + m + " " + s
                TextBox14.Text = name_ni
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        TextBox2.Text = ""
        ComboBox13.Text = ""
        TextBox7.Text = ""
        ComboBox17.Text = ""
        ComboBox15.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub TabControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseClick


    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            mysqlconn.Open()

            Dim query As String
            query = "select * from laboratory_case where lab_case_no = '" & lab_case_no & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                examiner2 = reader.GetString("examiner")
                investigator2 = reader.GetString("investigator")
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select fname,mname,sname from officer where officer_id = '" & examiner2 & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name = f + " " + m + " " + s
                TextBox12.Text = name
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String
            query = "select fname,mname,sname from officer where officer_id = '" & investigator2 & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            While reader.Read
                Dim f = reader.GetString("fname")
                Dim m = reader.GetString("mname")
                Dim s = reader.GetString("sname")
                Dim name = f + " " + m + " " + s
                TextBox14.Text = name
            End While

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            mysqlconn.Dispose()
        End Try

    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected

    End Sub

    Private Sub ComboBox15_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox15.SelectedIndexChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select lab_case_no as ID,lab_case_no_id as CaseID,date_received as Date_Received,date_released as Date_Released,date_examined as Date_Examined,case_status as Case_Status,type as DFE from laboratory_case where lab_case_no_id like '" & TextBox9.Text & "%'"
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
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged

    End Sub
End Class