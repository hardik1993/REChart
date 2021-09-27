Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series


Public Class REChart_Graph
    Private Sub REChart_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlotView1.Visible = False
        Chart1.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim LPSeries As New DataVisualization.Charting.Series

        Chart1.Visible = True
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

        PlotView1.Visible = True

        '
        'Sample Series
        '
        Dim MyModel As PlotModel = New PlotModel()
        MyModel.Title = "TestModel"

        Dim MySeries As New LineSeries
        MySeries.Title = "TestSeries"

        MySeries.MarkerType = MarkerType.Circle
        For i = 0 To REChart_Data.PowerArray.Length - 1
            MySeries.Points.Add(New OxyPlot.DataPoint(REChart_Data.DateTimeArray(i).ToOADate, REChart_Data.PowerArray(i)))
        Next

        MyModel.Series.Add(MySeries)
        Me.PlotView1.Model = MyModel

    End Sub
End Class