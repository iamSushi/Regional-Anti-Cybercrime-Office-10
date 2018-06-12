Imports MySql.Data.MySqlClient
Public Class Form13
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer
    Dim investigator2 As String
    Dim examiner2 As String

    Private Sub load_table()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select lab_case_no as ID,lab_case_no_id as CaseID,date_received as Date_Received,date_released as Date_Released,date_examined as Date_Examined,case_status as Case_Status,type as DFE from laboratory_case"
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

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles Me.Load
        load_table()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            mysqlconn.Open()

            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = Me.DataGridView1.Rows(e.RowIndex)
                Dim pili = row.Cells("ID").Value.ToString
                Dim name = row.Cells("CaseID").Value.ToString

                Form3.lab_case = pili

                Form3.TextBox1.Text = name
                Form2.lab_case = pili
                Form2.TextBox6.Text = name

                Form3.lab_case = pili
                Form8.lab_case = pili

                Form18.lab_case = pili
                Form19.lab_case = pili
                Form24.lab_case = pili



                Try
                    mysqlconn.Dispose()
                    mysqlconn.Open()

                    Dim query As String
                    query = "select * from laboratory_case where lab_case_no = '" & pili & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader

                    While reader.Read
                        examiner2 = reader.GetString("examiner")
                        investigator2 = reader.GetString("investigator")
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
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
                        Form3.TextBox12.Text = name_ni
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
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
                        Form3.TextBox14.Text = name_ni
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                Finally
                    mysqlconn.Dispose()
                End Try

                Me.Hide()

            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
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
                Dim name = row.Cells("CaseID").Value.ToString

                Form3.lab_case = pili
                Form3.TextBox10.Text = name
                Form3.TextBox1.Text = name
                Form2.lab_case = pili
                Form2.TextBox6.Text = name
                Form3.lab_case = pili
                Form8.lab_case = pili

                Form18.lab_case = pili
                Form19.lab_case = pili
                Form24.lab_case = pili
                MessageBox.Show("Successfully Selected " + name)

                Try
                    mysqlconn.Dispose()
                    mysqlconn.Open()

                    Dim query As String
                    query = "select * from laboratory_case where lab_case_no = '" & pili & "'"
                    command = New MySqlCommand(query, mysqlconn)
                    reader = command.ExecuteReader

                    While reader.Read
                        examiner2 = reader.GetString("examiner")
                        investigator2 = reader.GetString("investigator")
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
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
                        Form3.TextBox12.Text = name_ni
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
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
                        Form3.TextBox14.Text = name_ni
                    End While

                    mysqlconn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                Finally
                    mysqlconn.Dispose()
                End Try

                Me.Hide()
            End If
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource


        Try
            mysqlconn.Open()

            Dim query As String

            query = "select lab_case_no as ID,lab_case_no_id as CaseID,date_received as Date_Received,date_released as Date_Released,date_examined as Date_Examined,case_status as Case_Status,type as DFE from laboratory_case where lab_case_no_id like '" & TextBox6.Text & "%' "
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
End Class