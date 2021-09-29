Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.Axes
Imports OxyPlot.Annotations

Public Class REChart_Graph

    'global point vars for the drag and drop of Chart Text Annotations 
    Public lastPoint As OxyPlot.DataPoint
    Public thisPoint As OxyPlot.DataPoint
    Public newPoint As OxyPlot.DataPoint

    'global objects for the Plotview, Plot Model, and data series
    Public MySeries As New LineSeries
    Public MyModel As New PlotModel
    Public AnnotationsList As New List(Of OxyPlot.Annotations.TextAnnotation)
    Public AnnotationTextArray As String()

    Private Sub REChart_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GenerateLoadProfile()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub GenerateLoadProfile()
        ' This sub takes data from the Data Entry form from the global arrays, and generates the Load Profile. 
        ' Sets up the oxyplot controls, axis, data model, binds the data, generates the annotations, etc. 

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
        yAxis.Maximum = MaxValue(REChart_Data.PowerArray) + 5
        yAxis.Minimum = MinValue(REChart_Data.PowerArray) - 5

        'set up plot model
        MyModel.Title = REChart_Data.txtManuverTitle.Text

        'set up line series
        MySeries.Title = "Load Profile"

        'add x and y axis to the data model
        MyModel.Axes.Add(xAxis)
        MyModel.Axes.Add(yAxis)

        ' Have to -2 because redim keeps the initial 1 element, and we are trashing the first "START". 
        ' Skip the first annotation Label "START". This is the default label on the load profile for the starting point.
        ' and does not need to be labeled on the load profile.  
        ReDim AnnotationTextArray(REChart_Data.DescArray.Length - 2)

        'first step is to form array of annotation descriptions. This will be the date/time range for 
        ' action appended with the actual description of the step from desc array. 
        For i As Integer = 1 To AnnotationTextArray.Length
            AnnotationTextArray(i - 1) = REChart_Data.DateTimeArray(i - 1).ToString("MM/dd/yyyy HH:mm") + " - " +
                REChart_Data.DateTimeArray(i).ToString("MM/dd/yyyy HH:mm") +
                vbNewLine + REChart_Data.DescArray(i)
        Next

        'setup annotations. Add annotations to the a list. 
        'set the descriptions from DescArray, and the date/time range for action. 
        'set the locations using the values from PowerArray, and DateTimeArray
        For i = 0 To AnnotationTextArray.Length - 1
            AnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            AnnotationsList(i).Text = AnnotationTextArray(i)
            AnnotationsList(i).TextPosition = New OxyPlot.DataPoint(REChart_Data.DateTimeArray(i).ToOADate, REChart_Data.PowerArray(i))

            'setting tag value to the index of the annotation in the list. so that it can be 
            ' checked later, to find out which annotation was clicked in the event handler. 
            AnnotationsList(i).Tag = i

            'add annotation to the data model. 
            MyModel.Annotations.Add(AnnotationsList(i))

            'add event handlers for mouse down, move and up events, to enable draging the annotation in real time. 
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
        'this event occurs when the mouse button is first pressed down on a annotation. 

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag

        'select the annotation. 
        AnnotationsList(MyIndex).Select()

        'update the current position variable and flag the event as complete. 
        lastPoint = AnnotationsList(MyIndex).InverseTransform(e.Position)
        MyModel.InvalidatePlot(False)
        e.Handled = True

    End Sub

    Private Sub AnnotationMouseMove(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        ' this event occurs after the mouse down event when the mouse is moved/dragged on an annotation. 

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag

        'get the new position and calculate the delta. 
        thisPoint = AnnotationsList(MyIndex).InverseTransform(e.Position)
        Dim dx As Double = thisPoint.X - lastPoint.X
        Dim dy As Double = thisPoint.Y - lastPoint.Y

        'calculate the new point based on the delta, and set the new position. 
        newPoint = New OxyPlot.DataPoint(AnnotationsList(MyIndex).TextPosition.X + dx, AnnotationsList(MyIndex).TextPosition.Y + dy)
        AnnotationsList(MyIndex).TextPosition = newPoint

        'update the current point for calculation of delta in thre next iteration.
        lastPoint = thisPoint

        're-draw the plot, to render the new position. and flag the event as handled. 
        MyModel.InvalidatePlot(True)
        e.Handled = True
    End Sub

    Private Sub AnnotationMouseUp(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        'this event occurs when the mouse button is released on an annotation. 

        'have to cast the event sender object to a local TextAnnotation Object to work with. 
        Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
        MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

        'get the index of the event sending text annotation, to that we know what index in the 
        ' Global list Of text annotations to modify. 
        Dim MyIndex As Integer = MyAnnotation.Tag

        'unselect the annotation when mouse button is released. 
        AnnotationsList(MyIndex).Unselect()

        're-draw the plot, to render the new position. and flag the event as handled. 
        MyModel.InvalidatePlot(True)
        e.Handled = True
    End Sub

    Private Function MaxValue(InputArray As Double()) As Double
        'Takes an array of doubles, and returns the maximum value

        'temp var for the max value
        Dim MaxDouble As Double = 0

        'loop through array to find max value
        For i = 0 To InputArray.Count - 1
            If MaxDouble < InputArray(i) Then MaxDouble = InputArray(i)
        Next

        'return the max value
        Return MaxDouble
    End Function

    Private Function MinValue(InputArray As Double()) As Double
        'Takes an array of doubles, and returns the minimum value

        'temp var for the min value
        Dim MinDouble As Double = 100

        'loop through array to find max value
        For i = 0 To InputArray.Count - 1
            If MinDouble > InputArray(i) Then MinDouble = InputArray(i)
        Next

        'return the max value
        Return MinDouble
    End Function

End Class