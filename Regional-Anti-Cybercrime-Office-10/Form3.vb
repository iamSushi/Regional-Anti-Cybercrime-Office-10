Imports MySql.Data.MySqlClient

Public Class Form3
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Dim examiner As String
    Dim investigator As String

    Public Property releasedby As String
    Public Property claimedby As String
    Public Property agency As String
    Public Property complainant As String
    Public Property lab_case As String



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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
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
        dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Application.ExitThread()
        ElseIf dialog = DialogResult.No Then
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs)
        Form9.Show()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs)
        Form8.Show()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs)
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String

            query = "insert into laboratory_case values(null,'" & TextBox2.Text & "','" & DateTimePicker1.Text & "',null,null,null,'" & agency & "','" & DateTimePicker2.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','null',null)"
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
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select lab_case_no_id,date_received,requesting_agency,examiner,investigator,date_occur,time_occur,place_occur from laboratory_case"
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
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select fact_no as Id , name as Name from facts"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()

            While reader.Read
                Dim name = reader.GetString("name")
                Dim id = reader.GetString("id")
                comboSource.Add(id, name)
            End While
            ComboBox13.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox13.DisplayMember = "Value"
            ComboBox13.ValueMember = "Key"

            Dim facts As String = DirectCast(ComboBox13.SelectedItem, KeyValuePair(Of String, String)).Key

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try





        Try
            mysqlconn.Open()

            Dim query As String

            query = "select law_id as Id , designation as name from law"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()

            While reader.Read
                Dim name = reader.GetString("name")
                Dim id = reader.GetString("id")
                comboSource.Add(id, name)
            End While
            ComboBox16.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox16.DisplayMember = "Value"
            ComboBox16.ValueMember = "Key"

            Dim law As String = DirectCast(ComboBox16.SelectedItem, KeyValuePair(Of String, String)).Key

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select fact_no as Id , name as Name from facts"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()

            While reader.Read
                Dim name = reader.GetString("name")
                Dim id = reader.GetString("id")
                comboSource.Add(id, name)
            End While
            ComboBox13.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox13.DisplayMember = "Value"
            ComboBox13.ValueMember = "Key"

            Dim agency As String = DirectCast(ComboBox13.SelectedItem, KeyValuePair(Of String, String)).Key

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select officer_id as id , fname as f ,mname as m ,sname as s from officer"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()

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

            query = "select officer_id as id , fname as f ,mname as m ,sname as s from officer"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()

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


    End Sub





    Private Sub Button32_Click_1(sender As Object, e As EventArgs) Handles Button32.Click
        Form24.Show()
    End Sub

    Private Sub Button28_Click_1(sender As Object, e As EventArgs) Handles Button28.Click
        Form8.Show()
    End Sub

    Private Sub Button21_Click_1(sender As Object, e As EventArgs) Handles Button21.Click
        Form18.Show()
    End Sub

    Private Sub Button31_Click_1(sender As Object, e As EventArgs) Handles Button31.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"
        Dim investigator As String = DirectCast(ComboBox17.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim examiner As String = DirectCast(ComboBox15.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim agency As String = DirectCast(ComboBox13.SelectedItem, KeyValuePair(Of String, String)).Key
        Try
            mysqlconn.Open()

            Dim query As String
            Dim query1 As String


            query = "insert into laboratory_case values(null,'" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker4.Text & "','" & DateTimePicker5.Text & "','" + releasedby + "','" + claimedby + "',null,'" & agency & "','" & examiner & "','" & investigator & "','" & DateTimePicker2.Text & "',' " & DateTimePicker3.Text & "',' " & TextBox13.Text & "',' " & ComboBox3.Text & " ','null',null)"
            query1 = "insert into laboratory_case values(null,         '1'            ,'          1                 ','3','4','5',          '6',      '     7       ',   '       8'           ,'        9                  ','              10             ','             11          ', 12 ,null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""

            DateTimePicker1.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""

            load_table()



            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Button36_Click_1(sender As Object, e As EventArgs) Handles Button36.Click
        Form19.show()
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        Dim key As String = DirectCast(ComboBox13.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(ComboBox13.SelectedItem, KeyValuePair(Of String, String)).Value
        MessageBox.Show(key & "   " & value)
        MessageBox.Show(ComboBox13.SelectedText)
    End Sub


    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            Dim query As String
            Dim query1 As String


            query = "insert into evidence values('" & lab_case & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "', '" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & ComboBox7.Text & "','" & ComboBox8.Text & "','" & ComboBox9.Text & "','" & ComboBox10.Text & "','" & ComboBox11.Text & "','" & ComboBox12.Text & "',null )"
            query1 = "insert into laboratory_case values(null,         '1'            ,'          1                 ','3','4','5',          '6',      '     7       ',   '       8'           ,'        9                  ','              10             ','             11          ', 12 ,null)"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            ComboBox1.Text = ""
            ComboBox2.Text = ""

            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox7.Text = ""
            ComboBox8.Text = ""
            ComboBox9.Text = ""
            ComboBox10.Text = ""
            ComboBox11.Text = ""
            ComboBox12.Text = ""




            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub



    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click

    End Sub


    Private Sub ComboBox14_SelectedIndexChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Form20.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Form21.Show()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Form22.Show()
    End Sub
End Class