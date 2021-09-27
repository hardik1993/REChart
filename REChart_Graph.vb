Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.Axes

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

        'set up x axis as a date/time axis
        Dim MinDateTime As Date
        Dim MaxDateTime As Date
        Dim MinXValue As Double
        Dim MaxYValue As Double

        'populate max and min values and convert to doubles
        MinDateTime = REChart_Data.DateTimeArray(0)
        MaxDateTime = REChart_Data.DateTimeArray(REChart_Data.DateTimeArray.Length - 1)
        MinXValue = DateTimeAxis.ToDouble(MinDateTime)
        MaxYValue = DateTimeAxis.ToDouble(MaxDateTime)

        'setup max and min values to axis
        Dim xAxis As New DateTimeAxis()
        xAxis.Position = AxisPosition.Bottom
        xAxis.Minimum = MinXValue
        xAxis.Maximum = MaxYValue
        xAxis.StringFormat = "M/d"

        'setup y axis, and set max and mins 
        Dim yAxis As New LinearAxis
        yAxis.Position = AxisPosition.Left
        yAxis.Maximum = 100
        yAxis.Minimum = 0

        'set up plot model
        Dim MyModel As PlotModel = New PlotModel()
        MyModel.Title = "TestModel"

        'set up line series
        Dim MySeries As New LineSeries
        MySeries.Title = "TestSeries"

        'add x and y axis to the data model
        MyModel.Axes.Add(xAxis)
        MyModel.Axes.Add(yAxis)

        'loop through array, and add points to data series
        MySeries.MarkerType = MarkerType.Circle
        For i = 0 To REChart_Data.PowerArray.Length - 1
            MySeries.Points.Add(New OxyPlot.DataPoint(DateTimeAxis.ToDouble(REChart_Data.DateTimeArray(i)), REChart_Data.PowerArray(i)))
        Next

        'add series to the data model, and bind the model to the plotview. 
        MyModel.Series.Add(MySeries)
        Me.PlotView1.Model = MyModel

    End Sub
End Class