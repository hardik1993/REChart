Public Class REChart_Data

    'global vars
    Dim StartDateTimeSet As Boolean
    Public DateTimeArray As Date()
    Public PowerArray As Double()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load event.
        dgvStatepoints.Rows.Add(New String() {dtpStartDate.Value.ToShortDateString + " " + "00:00", "0", "0", txtInitialPower.Text, "START"})

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
        Beep()
        dgvStatepoints.EditMode = DataGridViewEditMode.EditOnEnter
        Call ReCalculateTimes()
    End Sub

    Private Sub ReCalculateTimes()
        'This Sub will re-calculate times based on the starting times, and hours for action. 

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

    End Sub

    Private Sub btnAddStatePoint_Click(sender As Object, e As EventArgs) Handles btnAddStatePoint.Click

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
    End Sub

    Private Sub bthRefresh_Click(sender As Object, e As EventArgs) Handles bthRefresh.Click
        Call ReCalculateTimes()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'for some reason the redim makes the array 1+row count. So i have to -1 in the redim statement. 
        ReDim DateTimeArray(dgvStatepoints.RowCount - 1)
        ReDim PowerArray(dgvStatepoints.RowCount - 1)

        For i = 0 To dgvStatepoints.RowCount - 1
            PowerArray(i) = dgvStatepoints.Rows(i).Cells(3).Value
            DateTimeArray(i) = dgvStatepoints.Rows(i).Cells(0).Value
        Next

        REChart_Graph.Show()
    End Sub


End Class
