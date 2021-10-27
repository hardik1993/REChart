Imports PISDK

Public Class REChart_Data

    'global vars
    Dim StartDateTimeSet As Boolean
    Public DateTimeArray As Date()
    Public PowerArray As Double()
    Public DescArray As String()
    Public FullPowerMWE As Double = 1300
    Public LostMWHE As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load event.
        dgvStatepoints.Rows.Add(New String() {dtpStartDate.Value.ToShortDateString + " " + "00:00", "0", "0", txtInitialPower.Text, "START"})

        'Focus on first input field
        dtpStartDate.Focus()
        dtpStartDate.Select()

    End Sub

    Private Sub txtInitialPower_TextChanged(sender As Object, e As EventArgs) Handles txtInitialPower.TextChanged
        If (dgvStatepoints.RowCount >= 1) Then
            dgvStatepoints.Rows(0).SetValues(New String() {dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToString("HH:mm"), "0", "0", txtInitialPower.Text, "START"})
            Call ReCalculateTimes()
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If (dgvStatepoints.RowCount >= 1) Then
            dgvStatepoints.Rows(0).SetValues(New String() {dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToString("HH:mm"), "0", "0", txtInitialPower.Text, "START"})
            Call ReCalculateTimes()
        End If
    End Sub

    Private Sub dtpStartTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartTime.ValueChanged
        If (dgvStatepoints.RowCount >= 1) Then
            dgvStatepoints.Rows(0).SetValues(New String() {dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToString("HH:mm"), "0", "0", txtInitialPower.Text, "START"})
            Call ReCalculateTimes()
        End If
    End Sub

    Private Sub dgvStatepoints_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStatepoints.CellContentDoubleClick
        dgvStatepoints.EditMode = DataGridViewEditMode.EditOnEnter
        Call ReCalculateTimes()
    End Sub

    Private Sub ReCalculateTimes()
        'This Sub will re-calculate times based on the starting times, and hours for action. 
        Try
            Dim newDateTime As Date
            Dim curDateTime As Date
            Dim newHoursFromStart As Double
            Dim curHoursForAction As Double

            dgvStatepoints.EditMode = DataGridViewEditMode.EditProgrammatically

            For i = 1 To dgvStatepoints.RowCount - 1
                curDateTime = Convert.ToDateTime(dgvStatepoints.Rows(i - 1).Cells(0).Value)
                newDateTime = curDateTime.AddHours(Convert.ToDouble(dgvStatepoints.Rows(i).Cells(1).Value))

                curHoursForAction = Convert.ToDouble(dgvStatepoints.Rows(i).Cells(1).Value)
                newHoursFromStart = Convert.ToDouble(dgvStatepoints.Rows(i - 1).Cells(2).Value) + curHoursForAction

                dgvStatepoints.Rows(i).Cells(0).Value = newDateTime.ToString("MM/dd/yyyy HH:mm")
                dgvStatepoints.Rows(i).Cells(2).Value = Convert.ToString(Math.Round(newHoursFromStart, 2))

                'dgvStatepoints.Rows(i).SetValues(New String() {newDateTime.ToString("MM/dd/yyyy HH:mm"), curHoursForAction.ToString, newHoursFromStart.ToString, "0", "0"})
                dgvStatepoints.Refresh()
            Next


            'Next, calculate MWe Lost
            Dim result As Double = 0
            Dim dur As Double

            'Loop through array points to calculate MWe lost. Looks ahead to the next point to calculate the area.
            For x = 0 To dgvStatepoints.RowCount - 2
                'Calculate duration between points
                dur = Convert.ToDouble(dgvStatepoints.Rows(x + 1).Cells(1).Value)
                If dgvStatepoints.Rows(x).Cells(3).Value = 100 Or dgvStatepoints.Rows(x + 1).Cells(3).Value = 100 Then
                    'This is the first or last point to 100%, a triangular area needs to be calculated.
                    'If the current point is 100%, then base of triangle needs to be the difference between 100% and i+1
                    If dgvStatepoints.Rows(x).Cells(3).Value = 100 Then result += 0.5 * Convert.ToDouble(dur) * (((100 - Convert.ToDouble(dgvStatepoints.Rows(x + 1).Cells(3).Value)) / 100) * FullPowerMWE)
                    'If the next point is 100%, then base of triangle needs to be the difference between 100% and i
                    If dgvStatepoints.Rows(x + 1).Cells(3).Value = 100 Then result += 0.5 * Convert.ToDouble(dur) * (((100 - Convert.ToDouble(dgvStatepoints.Rows(x).Cells(3).Value)) / 100) * FullPowerMWE)
                    'If this is just a burn at full power, the result goes to 0 added MWe lost.
                Else
                    'This is a middle section and a trapazoidal area needs to be calculated.
                    result += ((((((100 - Convert.ToDouble(dgvStatepoints.Rows(x).Cells(3).Value)) / 100) * FullPowerMWE) + (((100 - Convert.ToDouble(dgvStatepoints.Rows(x + 1).Cells(3).Value)) / 100) * FullPowerMWE)) * Convert.ToDouble(dur)) * 0.5)
                End If
            Next

            LostMWHE = Math.Round(result, 1)
            lblMWE.Text = Math.Round(result, 1)
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Private Sub ReCalculateTimes in REChart_Data.vb", MsgBoxStyle.Critical, "FATALITY")
        End Try
    End Sub

    Private Sub btnAddStatePoint_Click(sender As Object, e As EventArgs) Handles btnAddStatePoint.Click
        Try
            'populate parameters from previous row.
            Dim lastDateTime As Date
            Dim curHoursForAction As Double
            Dim lastHoursFromStart As Double
            Dim i As Integer

            Dim newDateTime As Date
            Dim newHoursFromStart As Double

            'populate parameters from previous row.
            i = dgvStatepoints.RowCount - 1
            lastDateTime = dgvStatepoints.Rows(i).Cells(0).Value
            curHoursForAction = dgvStatepoints.Rows(i).Cells(1).Value
            lastHoursFromStart = dgvStatepoints.Rows(i).Cells(2).Value

            newDateTime = lastDateTime.AddHours(Convert.ToDouble(txtHoursForAction.Text))
            newHoursFromStart = lastHoursFromStart + Convert.ToDouble(txtHoursForAction.Text)

            'add new row based on form inputs. add the hours for action to cur date/time to get new date/time and 
            dgvStatepoints.Rows.Add(New String() {newDateTime.ToString("MM/dd/yyyy HH:mm"), txtHoursForAction.Text, newHoursFromStart.ToString, txtStatePointPower.Text, txtDescription.Text})
            Call ReCalculateTimes()

            'Set focus back to reoccuring input
            txtStatePointPower.Focus()
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Private Sub btnAddStatePoint_Click in REChart_Data.vb", MsgBoxStyle.Critical, "FATALITY")
        End Try
    End Sub

    Private Sub bthRefresh_Click(sender As Object, e As EventArgs) Handles bthRefresh.Click
        Call ReCalculateTimes()
    End Sub

    Private Sub btnGenerateLP_Click(sender As Object, e As EventArgs) Handles btnGenerateLP.Click
        Try
            'Validation Checks 
            'check to make sure a unit is selected. 
            If rbUnit1.Checked = False And rbUnit2.Checked = False Then
                MsgBox("Please Select a Unit", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'check to make sure a title is intered. 
            If txtManuverTitle.Text = "" Then
                MsgBox("Please enter a Title", MsgBoxStyle.Exclamation)
                Exit Sub
            End If


            'for some reason the redim makes the array 1+row count. So i have to -1 in the redim statement. 
            ReDim DateTimeArray(dgvStatepoints.RowCount - 1)
            ReDim PowerArray(dgvStatepoints.RowCount - 1)
            ReDim DescArray(dgvStatepoints.RowCount - 1)

            For i = 0 To dgvStatepoints.RowCount - 1
                PowerArray(i) = dgvStatepoints.Rows(i).Cells(3).Value
                DateTimeArray(i) = dgvStatepoints.Rows(i).Cells(0).Value
                DescArray(i) = dgvStatepoints.Rows(i).Cells(4).Value
            Next

            REChart_Graph.Show()
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Private Sub btnGenerateLP_Click in REChart_Data.vb", MsgBoxStyle.Critical, "FATALITY")
        End Try
    End Sub

    Private Sub btnSaveData_Click(sender As Object, e As EventArgs) Handles btnSaveData.Click
        'This routine will, prompt the user to select a location, and name the file, 
        ' and  save the current data in the form in a text file. 

        'create a save file dialoge
        Dim MyFileDialog As SaveFileDialog = New SaveFileDialog()
        Dim FileNameString As String = " "

        'set up the save file dialoge
        MyFileDialog.Title = "Select a location to save data (DO NOT include extention in filename)"
        MyFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        MyFileDialog.Filter = "REChart Files (*.REChart)|*.REChart|All files (*.*)|*.*"
        MyFileDialog.FilterIndex = 1
        MyFileDialog.RestoreDirectory = True

        Try
            'show the save file dialoge
            If MyFileDialog.ShowDialog() = DialogResult.OK Then
                FileNameString = MyFileDialog.FileName
            Else
                'if the file name is still blank, some thing went wrong. throw message box, and exit routine
                MsgBox("Please select a file to save the data.")
                Exit Sub
            End If

            'check if the user is stupid enough to include extention even tho i told them not to... 
            ' If extention of *.REChart Is included Then move on, if it is not then add it to the file path. 
            If Strings.Right(FileNameString, 8) <> ".REChart" Then
                FileNameString = FileNameString + ".REChart"
            End If


            'create a file writer object. and start writing to the file 
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(FileNameString, False)
            'file header
            file.WriteLine("This is a RE-Chart saved data file. Created on: " + Date.Now.ToString)
            file.WriteLine(" ")
            'initial conditions
            file.WriteLine("Initial Conditions (Start Date/Time, Title, Power, and Unit): ")
            file.WriteLine(dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToString("HH:mm"))
            file.WriteLine(txtManuverTitle.Text)
            file.WriteLine(txtInitialPower.Text)
            file.WriteLine(txtCycle.Text)
            If rbUnit1.Checked = True Then file.WriteLine("Unit 1")
            If rbUnit2.Checked = True Then file.WriteLine("Unit 2")
            file.WriteLine(" ")
            'data gridview statepoints 
            file.WriteLine("Statepoints (Date/Time, Hours for action, Hours from Start, Power, and Description): ")
            For i = 0 To dgvStatepoints.RowCount - 1
                file.WriteLine(dgvStatepoints.Rows(i).Cells(0).Value.ToString)
                file.WriteLine(dgvStatepoints.Rows(i).Cells(1).Value.ToString)
                file.WriteLine(dgvStatepoints.Rows(i).Cells(2).Value.ToString)
                file.WriteLine(dgvStatepoints.Rows(i).Cells(3).Value.ToString)
                file.WriteLine(dgvStatepoints.Rows(i).Cells(4).Value.ToString)
            Next

            'end of file footer
            file.WriteLine("--END OF FILE--")
            file.WriteLine("")

            'close the file
            file.Close()

            MsgBox("File Saved Successfully!", MsgBoxStyle.Information)
            Exit Try
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Sub btnSaveData_Click in REChart_Data.vb" & vbNewLine & "Ensure directory path is valid and admin rights are not required.", MsgBoxStyle.Critical, "FATALITY")
        End Try
    End Sub

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        'This routine will, prompt the user to select a location, and name the file, 
        ' and Load data from the file into the current form.

        'create a open file dialoge
        Dim MyFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim FileNameString As String = " "
        Dim tempstr As String

        'set up the open file dialoge
        MyFileDialog.Title = "Please select a file to load the data from"
        MyFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        MyFileDialog.Filter = "REChart Files (*.REChart)|*.REChart|All files (*.*)|*.*"
        MyFileDialog.FilterIndex = 1
        MyFileDialog.RestoreDirectory = True

        Try
            'show the open file dialoge
            If MyFileDialog.ShowDialog() = DialogResult.OK Then
                FileNameString = MyFileDialog.FileName
            Else
                'if the file name is still blank, some thing went wrong. throw message box, and exit routine
                MsgBox("Please select a file to load the data from")
                Exit Sub
            End If

            'create a file stream reader object and read file
            Dim file As System.IO.StreamReader
            file = My.Computer.FileSystem.OpenTextFileReader(FileNameString)

            'skip the header
            tempstr = file.ReadLine()
            tempstr = file.ReadLine()
            tempstr = file.ReadLine()

            'read initial conditions date/time and power 
            Dim tempdt As String
            tempdt = file.ReadLine
            dtpStartDate.Value = Convert.ToDateTime(tempdt)
            dtpStartTime.Value = Convert.ToDateTime(tempdt)
            txtManuverTitle.Text = file.ReadLine
            txtInitialPower.Text = file.ReadLine
            txtCycle.Text = file.ReadLine
            If file.ReadLine = "Unit 1" Then
                rbUnit1.Checked = True
            Else
                rbUnit2.Checked = True
            End If

            'skip more garbage
            tempstr = file.ReadLine()
            tempstr = file.ReadLine()

            'Clear the data grid view before populating the new data. 
            For i As Integer = 0 To dgvStatepoints.Rows.Count - 1
                dgvStatepoints.Rows.Remove(dgvStatepoints.Rows(0))
            Next

            'loop through until END OF FILE is reached. Add a data grid view row each time.
            Dim j As Integer = 0
            tempstr = file.ReadLine()
            While tempstr <> "--END OF FILE--"
                dgvStatepoints.Rows.Add()
                dgvStatepoints.Rows(j).Cells(0).Value = Convert.ToDateTime(tempstr)
                tempstr = file.ReadLine()
                dgvStatepoints.Rows(j).Cells(1).Value = Convert.ToDouble(tempstr)
                tempstr = file.ReadLine()
                dgvStatepoints.Rows(j).Cells(2).Value = Convert.ToDouble(tempstr)
                tempstr = file.ReadLine()
                dgvStatepoints.Rows(j).Cells(3).Value = Convert.ToDouble(tempstr)
                tempstr = file.ReadLine()
                dgvStatepoints.Rows(j).Cells(4).Value = Convert.ToString(tempstr)
                tempstr = file.ReadLine()
                j = j + 1
            End While

            'close the file 
            file.Close()

            're calculate rows to re-adjust the hours and date/time stamps. 
            Call ReCalculateTimes()

            MsgBox("File Loaded Successfully!", MsgBoxStyle.Information)

            Exit Try

        Catch ex As Exception
            MsgBox(ex.Message & " occured in Sub btnLoadData_Click in REChart_Data.vb" & vbNewLine & "Ensure file is valid.", MsgBoxStyle.Critical, "FATALITY")
        End Try
    End Sub

    'The following subs are to highlight all text in the reoccuring input fields to allow for easier tabbing.
    Private Sub txtStatePointPower_GotFocus(sender As Object, e As EventArgs) Handles txtStatePointPower.GotFocus
        txtStatePointPower.SelectAll()
    End Sub
    Private Sub txtHoursForAction_GotFocus(sender As Object, e As EventArgs) Handles txtHoursForAction.GotFocus
        txtHoursForAction.SelectAll()
    End Sub
    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        txtDescription.SelectAll()
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescription.KeyDown
        ' if enter is pressed in the desc box, click the add statepoint button. 
        If e.KeyCode = Keys.Enter Then
            btnAddStatePoint.PerformClick()
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        REChart_Help.Show()
    End Sub
End Class
