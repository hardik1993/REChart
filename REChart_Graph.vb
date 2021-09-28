Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.Axes
Imports OxyPlot.Annotations

Public Class REChart_Graph

    Public lastPoint As OxyPlot.DataPoint = OxyPlot.DataPoint.Undefined
    Public moveStartPoint As Boolean = False
    Public moveEndPoint As Boolean = False
    Public originalColor As OxyPlot.OxyColor = OxyPlot.OxyColors.White

    Public MySeries As New LineSeries
    Public MyModel As New PlotModel
    Public AnnotationsList As New List(Of OxyPlot.Annotations.TextAnnotation)

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
        MyModel.Title = "TestModel"

        'set up line series
        MySeries.Title = "TestSeries"

        'add x and y axis to the data model
        MyModel.Axes.Add(xAxis)
        MyModel.Axes.Add(yAxis)

        'setup annotations. Add annotations to the a list. 
        'set the descriptions from DescArray.
        'set the locations using the values from PowerArray, and DateTimeArray
        For i = 0 To REChart_Data.PowerArray.Length - 1
            AnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            AnnotationsList(i).Text = REChart_Data.DescArray(i)
            AnnotationsList(i).TextPosition = New OxyPlot.DataPoint(REChart_Data.DateTimeArray(i).ToOADate, REChart_Data.PowerArray(i))

            'setting tag value to the index of the annotation in the list. so that it can be 
            ' checked later, to find out which annotation was clicked in the event handler. 
            AnnotationsList(i).Tag = i

            MyModel.Annotations.Add(AnnotationsList(i))
            AddHandler AnnotationsList(i).MouseDown, AddressOf AnnotationMouseDown
            AddHandler AnnotationsList(i).MouseMove, AddressOf AnnotationMouseMove
            AddHandler AnnotationsList(i).MouseUp, AddressOf AnnotationMouseUp
        Next

        'loop through array, and add points to data series
        MySeries.MarkerType = MarkerType.Circle
        For i = 0 To REChart_Data.PowerArray.Length - 1
            MySeries.Points.Add(New OxyPlot.DataPoint(DateTimeAxis.ToDouble(REChart_Data.DateTimeArray(i)), REChart_Data.PowerArray(i)))
        Next

        'add series to the data model, and bind the model to the plotview. 
        MyModel.Series.Add(MySeries)
        Me.PlotView1.Model = MyModel
    End Sub


    Private Sub AnnotationMouseDown(sender As Object, e As OxyPlot.OxyMouseDownEventArgs)

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag

        AnnotationsList(MyIndex).Select()

        lastPoint = AnnotationsList(MyIndex).InverseTransform(e.Position)
        MyModel.InvalidatePlot(False)
        e.Handled = True

    End Sub

    Private Sub AnnotationMouseMove(sender As Object, e As OxyPlot.OxyMouseEventArgs)

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag

        Dim thisPoint As OxyPlot.DataPoint
        thisPoint = AnnotationsList(MyIndex).InverseTransform(e.Position)
        Dim dx As Double = thisPoint.X - lastPoint.X
        Dim dy As Double = thisPoint.Y - lastPoint.Y

        Dim newPoint As OxyPlot.DataPoint = New OxyPlot.DataPoint(AnnotationsList(MyIndex).TextPosition.X + dx, AnnotationsList(MyIndex).TextPosition.Y + dy)

        AnnotationsList(MyIndex).TextPosition = newPoint

        lastPoint = thisPoint
        MyModel.InvalidatePlot(True)
        e.Handled = True
    End Sub

    Private Sub AnnotationMouseUp(sender As Object, e As OxyPlot.OxyMouseEventArgs)

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag
        Beep()
        AnnotationsList(MyIndex).Unselect()
        MyModel.InvalidatePlot(True)
        e.Handled = True
    End Sub


End Class