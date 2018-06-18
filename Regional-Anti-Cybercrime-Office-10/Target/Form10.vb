Imports MySql.Data.MySqlClient

Public Class Form10
    Dim mysqlconn As MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Dim index As Integer
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(agency.Text) Then
            Me.ErrorProvider1.SetError(Me.agency, "Input agency name")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.agency, "")
        End If

        If String.IsNullOrEmpty(mother.Text) Then
            Me.ErrorProvider1.SetError(Me.mother, "Input mother unit")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.mother, "")
        End If

        If String.IsNullOrEmpty(contact.Text) Then
            Me.ErrorProvider1.SetError(Me.contact, "Input contact")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.contact, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String

                query = "insert into agency values(null,'" & agency.Text & "','" & street.Text & "','" & barangay.Text & "','" & city.Text & "','" & province.Text & "','" & mother.Text & "','" & contact.Text & "','" & email.Text & "',null)"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successfully Add an Agency")
                agency.Text = ""
                city.Text = ""
                barangay.Text = ""
                street.Text = ""
                province.Text = ""
                mother.Text = ""
                contact.Text = ""
                email.Text = ""
                load_table()
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            query = "select agency_id as ID, agency_name as Agency, mother_unit as MotherUnit, street as Street, barangay as Barangay, city as City, province as Province, contact_no as Contact, email as Email from agency"
            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            index = e.RowIndex
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(index)

            id.Text = selectedRow.Cells(0).Value.ToString()
            agency.Text = selectedRow.Cells(1).Value.ToString()
            mother.Text = selectedRow.Cells(2).Value.ToString()
            street.Text = selectedRow.Cells(3).Value.ToString()
            barangay.Text = selectedRow.Cells(4).Value.ToString()
            city.Text = selectedRow.Cells(5).Value.ToString()
            province.Text = selectedRow.Cells(6).Value.ToString()
            contact.Text = selectedRow.Cells(7).Value.ToString()
            email.Text = selectedRow.Cells(8).Value.ToString()
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Dim count As Int16
        count = 0

        If String.IsNullOrEmpty(agency.Text) Then
            Me.ErrorProvider1.SetError(Me.agency, "Input agency name")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.agency, "")
        End If

        If String.IsNullOrEmpty(mother.Text) Then
            Me.ErrorProvider1.SetError(Me.mother, "Input mother unit")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.mother, "")
        End If

        If String.IsNullOrEmpty(contact.Text) Then
            Me.ErrorProvider1.SetError(Me.contact, "Input contact")
            count += 1
        Else
            Me.ErrorProvider1.SetError(Me.contact, "")
        End If

        If count <> 0 Then
            Return
        Else
            Try
                mysqlconn.Open()

                Dim query As String

                query = "UPDATE agency set agency_name = '" & agency.Text & "', city = '" & city.Text & "',street = '" & street.Text & "', barangay = '" & barangay.Text & "', contact_no = '" & contact.Text & "',email = '" & email.Text & "', province = '" & province.Text & "',mother_unit = '" & mother.Text & "' where agency_id = '" & id.Text & "'"
                command = New MySqlCommand(query, mysqlconn)
                reader = command.ExecuteReader
                MessageBox.Show("Successfully Add an Agency")
                agency.Text = ""
                city.Text = ""
                street.Text = ""
                barangay.Text = ""
                province.Text = ""
                mother.Text = ""
                contact.Text = ""
                email.Text = ""
                load_table()
                mysqlconn.Close()
            Catch ex As MySqlException
                MessageBox.Show("Invalid user input", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                mysqlconn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles Me.Load
        load_table()
        Me.DataGridView1.Columns("ID").Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none"

        Try
            Dim query As String
            mysqlconn.Open()
            query = "DELETE FROM agency WHERE agency_id = '" & id.Text & "'"
            command = New MySqlCommand(query, mysqlconn)
            reader = command.ExecuteReader
            MessageBox.Show("Successful")
            agency.Text = ""
            city.Text = ""
            street.Text = ""
            barangay.Text = ""
            province.Text = ""
            mother.Text = ""
            contact.Text = ""
            email.Text = ""
            load_table()
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select agency_id as ID, agency_name as Agency, mother_unit as MotherUnit, street as Street, barangay as Barangay, city as City, province as Province, contact_no as Contact, email as Email FROM agency WHERE agency_name like '" & TextBox10.Text & "%' "


            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;password=Admin@RACO102018;persistsecurityinfo=True;port=3306;database=cybercrime;SslMode=none;pooling = false; convert zero datetime=True"
        Dim adapter As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim soure As New BindingSource

        Try
            mysqlconn.Open()

            Dim query As String

            query = "select agency_id as ID, agency_name as Agency, mother_unit as MotherUnit, street as Street, barangay as Barangay, city as City, province as Province, contact_no as Contact, email as Email FROM agency where street like '" & TextBox11.Text & "%' or barangay like '" & TextBox11.Text & "%' or city like '" & TextBox11.Text & "%' or province like '" & TextBox11.Text & "%'"

            command = New MySqlCommand(query, mysqlconn)
            adapter.SelectCommand = command
            adapter.Fill(dbDataSet)
            soure.DataSource = dbDataSet
            DataGridView1.DataSource = soure
            adapter.Update(dbDataSet)

            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show("Invalid user action", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
End Class