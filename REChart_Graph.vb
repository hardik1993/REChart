Imports System.Windows.Forms.DataVisualization.Charting

Public Class REChart_Graph
    Private Sub REChart_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim LPSeries As New Series

        'LPSeries.Name = "aline"

        'Change to a line graph.
        LPSeries.ChartType = SeriesChartType.Line

        For i = 0 To REChart_Data.PowerArray.Length - 1
            LPSeries.Points.AddXY(REChart_Data.DateTimeArray(i).ToOADate, REChart_Data.PowerArray(i))
        Next
        Chart1.Series.Add(LPSeries)
        Threading.Thread.Sleep(1000)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    End Sub
End Class