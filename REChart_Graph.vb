Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.Axes
Imports OxyPlot.Annotations
Imports OxyPlot.PdfExporter
Imports System
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

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

    'global vars for the hourly data
    Dim HourlyDateTime As Date()
    Dim HourlyPowerArray As Double()

    Private Sub REChart_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GenerateLoadProfile()
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        'Exports the graph as a PNG file. 

        'create a save file dialoge
        Dim MyFileDialog As SaveFileDialog = New SaveFileDialog()
        Dim FileNameString As String = " "

        'set up the save file dialoge
        MyFileDialog.Title = "Select a location to save load profile pdf (DO NOT include extention in filename)"
        MyFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        MyFileDialog.Filter = "PNG Files (*.PNG)|*.PNG|All files (*.*)|*.*"
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

            'Export
            Dim fs As FileStream = File.Create(FileNameString)
            'Dim pdfExp = New PdfExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height}
            'Dim svgExp = New SvgExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height}
            Dim pngExp = New OxyPlot.WindowsForms.PngExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height, .Background = OxyColors.White}
            Dim modPlot As OxyPlot.Model = PlotView1.Model
            pngExp.Export(modPlot, fs)
            'close the file stream, and dispose the object
            fs.Close()
            fs.Dispose()

            'calculate hourly daya and place in HourlyDateTime, HourlyPowerArray arrays
            Call CalculateHourlyData(REChart_Data.DateTimeArray, REChart_Data.PowerArray, HourlyDateTime, HourlyPowerArray)

            'do some stuff to export to excel somehow.......
            'Create new excel application
            Dim ex As New Excel.Application
            ex = CreateObject("Excel.Application")
            'Dont make it visible, we dont need to see it until later
            ex.Visible = False

            'Create new workbook and add it to the excel app
            Dim wb As Excel.Workbook
            wb = ex.Workbooks.Add

            'Create a new worksheet and add it to the workbook
            Dim ws As New Excel.Worksheet
            ws = wb.Worksheets(1)

            'Change the A column width so it doesn't show up at ###################################### gross
            ws.Range("A1").ColumnWidth = 15

            'Loop through all valid entries in hourly arrays and write to appropriate excel cells
            For x = 0 To HourlyDateTime.Length - 1
                ws.Cells(x + 1, 1).Value = HourlyDateTime(x)
                ws.Cells(x + 1, 2).Value = HourlyPowerArray(x)
            Next

            'Parse a new filename for the .xlsx based on the filename for the .png
            Dim wbFileName As String
            wbFileName = Strings.Left(FileNameString, FileNameString.Length - 4) & ".xlsx"

            'Save the workbook
            wb.SaveAs(wbFileName)

            'Garbage collection
            ws = Nothing
            wb = Nothing
            ex.Quit()
            ex = Nothing

            'Open .png and .xlsx for user to view
            System.Diagnostics.Process.Start(FileNameString)
            System.Diagnostics.Process.Start(wbFileName)

            Exit Try
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Sub ButtonExport_Click in REChart_Graph.vb " & vbNewLine & "Ensure directory path is valid and admin rights are not required.", MsgBoxStyle.Critical, "FATALITY")
            Exit Try
        End Try

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
        xAxis.StringFormat = "MM/dd" + vbNewLine + "HH:mm"
        xAxis.MajorGridlineStyle = LineStyle.Dash
        xAxis.Title = "Date/Time"
        xAxis.TitleFontWeight = FontWeights.Bold


        'setup y axis, and set max and mins 
        Dim yAxis As New LinearAxis
        yAxis.Position = AxisPosition.Left
        yAxis.Maximum = MaxValue(REChart_Data.PowerArray) + 4.5
        yAxis.Minimum = MinValue(REChart_Data.PowerArray) - 4.5
        yAxis.MajorGridlineStyle = LineStyle.Solid
        yAxis.Title = "Power Level (% CTP)"
        yAxis.TitleFontWeight = FontWeights.Bold

        'set up plot model, Create a Title, based on the entry from the data form. 
        Dim strTitle As String = REChart_Data.txtManuverTitle.Text + " " +
            REChart_Data.DateTimeArray(0).ToString("MM/dd/yy") + " - " +
            REChart_Data.DateTimeArray(REChart_Data.DateTimeArray.Length - 1).ToString("MM/dd/yy")
        MyModel.Title = strTitle
        MyModel.TitleFont = "Consolas"
        MyModel.TitleFontSize = 24
        MyModel.TitleFontWeight = FontWeights.Bold

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
        ' action appended with the actual description of the step from desc array. Also some logic 
        ' in there to Not include the mm/dd twice if the date has not changed. 
        Dim tempstr As String
        For i As Integer = 1 To AnnotationTextArray.Length
            'if the date has not changed then scrap the second MM/dd
            If REChart_Data.DateTimeArray(i - 1).ToString("MM/dd") = REChart_Data.DateTimeArray(i).ToString("MM/dd") Then
                tempstr = REChart_Data.DateTimeArray(i - 1).ToString("MM/dd HH:mm") + " - " +
                    REChart_Data.DateTimeArray(i).ToString("HH:mm")
                'else keep the second MM/dd
            Else
                tempstr = REChart_Data.DateTimeArray(i - 1).ToString("MM/dd HH:mm") + " - " +
                    REChart_Data.DateTimeArray(i).ToString("MM/dd HH:mm")
            End If

            'Handle condition If there is an empty desc block and the previous block was NOT empty
            ' then need from/to date time from begening And end of consecutive empty blocks. 
            ' This Is handling the condition when a combined desc block Is used. Or REChart_Data.DescArray(i) = ""
            If i < AnnotationTextArray.Length Then ' this covers the boundry condition of i + 1 
                If REChart_Data.DescArray(i + 1) = "" And REChart_Data.DescArray(i - 1) <> "" And REChart_Data.DescArray(i) <> "" Then
                    ' this is the "From" Date/Time for this annotation
                    Dim FromDateTime As String = REChart_Data.DateTimeArray(i - 1).ToString("MM/dd HH:mm")
                    'now need to find "TO" date time for this annotation. This is found by finding the last consecutive enpty desc block. 
                    Dim counter As Integer = i + 1
                    While REChart_Data.DescArray(counter) = ""
                        counter = counter + 1
                    End While
                    'found the TO date, set a var to it.
                    Dim ToDateTime As String = REChart_Data.DateTimeArray(counter - 1).ToString("MM/dd HH:mm")
                    AnnotationTextArray(i - 1) = Center2Lines(REChart_Data.DescArray(i), FromDateTime + " - " + ToDateTime)

                    'the condition where empty place holder is needed. 
                ElseIf REChart_Data.DescArray(i) = "" Then
                    AnnotationTextArray(i - 1) = ""

                    ' the normal condition
                Else
                    AnnotationTextArray(i - 1) = Center2Lines(REChart_Data.DescArray(i), tempstr)
                End If

            ElseIf i = AnnotationTextArray.Length Then ' handles the last desc block 
                AnnotationTextArray(i - 1) = Center2Lines(REChart_Data.DescArray(i), tempstr)
            End If

        Next

        Dim CurrentPoint As OxyPlot.DataPoint
        Dim NextPoint As OxyPlot.DataPoint
        'setup annotations. Add annotations to the a list. 
        'set the descriptions from DescArray, and the date/time range for action. 
        'set the locations at the mid point of the line for the action.
        For i = 0 To AnnotationTextArray.Length - 1
            AnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            AnnotationsList(i).Text = AnnotationTextArray(i)

            'set font to monospaced font and default size 12
            AnnotationsList(i).FontSize = 12
            AnnotationsList(i).Font = "Consolas"

            'set previous point and current point, calculate the mid point, and set the location of the annotation as the midpoint.
            CurrentPoint = New OxyPlot.DataPoint(REChart_Data.DateTimeArray(i).ToOADate, REChart_Data.PowerArray(i))
            NextPoint = New OxyPlot.DataPoint(REChart_Data.DateTimeArray(i + 1).ToOADate, REChart_Data.PowerArray(i + 1))
            AnnotationsList(i).TextPosition = CalculateMidPointOfLine(CurrentPoint, NextPoint)

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

        'don't draw legend since there is only one series. 
        MySeries.RenderInLegend = False

        'Do unit specific stuff 
        'Set the colors based on Unit. Unit 1 = blue, unit 2 = green.
        ' append "Unit x Cycle xx" + newline in the title based on selection. 
        If (REChart_Data.rbUnit1.Checked = True) Then
            MySeries.Color = OxyColors.RoyalBlue
            MySeries.StrokeThickness = 4
            MySeries.MarkerSize = 5
            MyModel.TitleColor = OxyColors.RoyalBlue
            MyModel.Title = Center2Lines("Unit 1 Cycle " + REChart_Data.txtCycle.Text, strTitle)
            For i As Integer = 0 To AnnotationsList.Count - 1
                AnnotationsList(i).Background = OxyColors.RoyalBlue
                AnnotationsList(i).TextColor = OxyColors.White
                AnnotationsList(i).FontWeight = FontWeights.Bold
                'if annotation text is empty or "" then hode the annotation
                If AnnotationsList(i).Text = "" Or AnnotationsList(i).Text = " " Then
                    AnnotationsList(i).Layer = AnnotationLayer.BelowSeries
                    AnnotationsList(i).Layer = AnnotationLayer.BelowAxes
                    AnnotationsList(i).Background = OxyColors.White
                    AnnotationsList(i).Stroke = OxyColors.White
                End If
            Next
        End If

        'Unit 2 stuff
        If (REChart_Data.rbUnit2.Checked = True) Then
            MySeries.Color = OxyColors.Green
            MySeries.StrokeThickness = 4
            MySeries.MarkerSize = 5
            MyModel.TitleColor = OxyColors.Green
            MyModel.Title = Center2Lines("Unit 2 Cycle " + REChart_Data.txtCycle.Text, strTitle)
            For i As Integer = 0 To AnnotationsList.Count - 1
                AnnotationsList(i).Background = OxyColors.Green
                AnnotationsList(i).TextColor = OxyColors.White
                AnnotationsList(i).FontWeight = FontWeights.Bold
                'if annotation text is empty or "" then hode the annotation
                If AnnotationsList(i).Text = "" Or AnnotationsList(i).Text = " " Then
                    AnnotationsList(i).Layer = AnnotationLayer.BelowSeries
                    AnnotationsList(i).Layer = AnnotationLayer.BelowAxes
                    AnnotationsList(i).Background = OxyColors.White
                    AnnotationsList(i).Stroke = OxyColors.White
                End If
            Next
        End If

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

        'if left click, then go into drag/drop functionality 
        If e.ChangedButton = OxyMouseButton.Left Then
            'select the annotation. 
            AnnotationsList(MyIndex).Select()

            'update the current position variable and flag the event as complete. 
            lastPoint = AnnotationsList(MyIndex).InverseTransform(e.Position)
            MyModel.InvalidatePlot(False)
            e.Handled = True

        ElseIf e.ChangedButton = OxyMouseButton.right Then

            'if not already selected, then select annotation.
            If AnnotationsList(MyIndex).IsSelected = False Then
                AnnotationsList(MyIndex).Select()
            Else
                AnnotationsList(MyIndex).Unselect()
            End If

            MyModel.InvalidatePlot(True)
            e.Handled = True
        End If

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

    Private Function CalculateMidPointOfLine(StartPoint As OxyPlot.DataPoint, EndPoint As OxyPlot.DataPoint) As OxyPlot.DataPoint
        'This function takes 2 oxyplot datapoints as input, and returns the midpoint of the line in between these 2 points. 

        'create the midpoint, X and Y vars to return.
        Dim MidPoint As OxyPlot.DataPoint
        Dim MidPointX As Double
        Dim MidPointY As Double

        'calculate the mid point X and Y values
        MidPointX = ((EndPoint.X - StartPoint.X) / 2) + StartPoint.X
        MidPointY = ((EndPoint.Y - StartPoint.Y) / 2) + StartPoint.Y

        'assign the X and Y values to the datapoint var
        MidPoint = New OxyPlot.DataPoint(MidPointX, MidPointY)

        'return the datapoint var
        Return MidPoint

    End Function

    Private Function Center2Lines(TopString As String, BotString As String) As String
        'this function accepts 2 string lines. And returns 1 string seperated by a vbnewline, and properly 
        ' padded with spaces top appear center text center aligned. The reason I had to write this is because the 
        ' oxy plot text anotations text alignment was not working.

        'create the finalstring var to return
        Dim FinalString As String
        Dim LengthDiff As Integer

        'calculate the diff in length of the 2 strings, and pad the shorter string with spaces 
        ' approriatelly to "CeNtEr AlIgN"
        If TopString.Length > BotString.Length Then
            LengthDiff = TopString.Length - BotString.Length
            For i As Integer = 1 To LengthDiff / 2
                BotString = " " + BotString
            Next
            FinalString = TopString + vbNewLine + BotString

        ElseIf BotString.Length > TopString.Length Then
            LengthDiff = BotString.Length - TopString.Length
            For i As Integer = 1 To LengthDiff / 2
                TopString = " " + TopString
            Next
            FinalString = TopString + vbNewLine + BotString

        Else
            FinalString = TopString + vbNewLine + BotString
        End If

        Return FinalString

    End Function

    Private Sub btnFontSizeUp_Click(sender As Object, e As EventArgs) Handles btnFontSizeUp.Click
        ' increases the font size of all text annotations by 1

        'loop through the array of Text annotations, and increase the font size by 1
        For i As Integer = 0 To AnnotationsList.Count - 1
            AnnotationsList(i).FontSize = AnnotationsList(i).FontSize + 1
        Next

        MyModel.InvalidatePlot(True)

    End Sub

    Private Sub btnFontSizeDown_Click(sender As Object, e As EventArgs) Handles btnFontSizeDown.Click
        ' decreases the font size of all text annotations by 1

        'loop through the array of Text annotations, and decrease the font size by 1
        For i As Integer = 0 To AnnotationsList.Count - 1
            AnnotationsList(i).FontSize = AnnotationsList(i).FontSize - 1
        Next

        MyModel.InvalidatePlot(True)

    End Sub

    Private Sub CalculateHourlyData(ByVal DTArray As Date(), ByVal PowArray As Double(), ByRef HourlyTime As Date(), ByRef HourlyPower As Double())
        'This sub will accept an array of date times and power levels as inputs, and will return byref, 
        ' an hourly array Of Date times And power levels, interpolated as nessicary. This is primairly for 
        ' providing the horuly power data for marketing And work week management. 

        ' first step is to confirm that DTArray and PowArray are the same size. 
        If DTArray.Length <> PowArray.Length Then
            MsgBox("Error in Sub CalculateHourlyData, the DTarray, and PowerArray are not the same size", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'check if the arrays are of length 1 if so then exit, need more data. 
        If DTArray.Length = 1 Then
            MsgBox("Error in Sub CalculateHourlyData, Only one statepoint entered. Please enter more data.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'next step is round up the first date/time to the nearesr hour. And Round down the last Date/time to the nearest hour
        Dim StartingDateTime As Date
        Dim EndingDateTime As Date

        'round up the first date/time
        If DTArray(0).Minute <> 0 Then
            StartingDateTime = DTArray(0)
            StartingDateTime = DateTime.Parse(DTArray(0).ToString("MM/dd/yyyy HH:00"))
            StartingDateTime = StartingDateTime.AddHours(1)
        Else
            StartingDateTime = DTArray(0)
        End If

        'round down the last date/time
        If DTArray(DTArray.Length - 1).Minute <> 0 Then
            EndingDateTime = DTArray(DTArray.Length - 1)
            EndingDateTime = DateTime.Parse(DTArray(DTArray.Length - 1)).ToString("MM/dd/yyyy HH:00")
        Else
            EndingDateTime = DTArray(DTArray.Length - 1)
        End If

        'calculate the difference between starting and ending date/time to figure out how many elements are needed in the hourly data arrays. 
        Dim diff As Long = DateAndTime.DateDiff(DateInterval.Hour, StartingDateTime, EndingDateTime)

        'MsgBox(StartingDateTime.ToString + " " + EndingDateTime.ToString + " " + diff.ToString)

        're dim the hourly arrays to appriorate dimension, based on the delta in hours between starting and ending time
        ReDim HourlyTime(diff - 1)
        ReDim HourlyPower(diff - 1)

        'Loop through and populate the hourly data arrays. 
        Dim CurrentDateTime As Date = StartingDateTime
        Dim i As Integer = 0
        Dim j As Integer = 0
        While CurrentDateTime < EndingDateTime
            HourlyTime(i) = CurrentDateTime ' fill out the hourly date/time array.

            'need to interpolate here to fill out hourlypower(i)... this is going to get real gross. 
            j = 0
            'need the upper and lower values for the supplied date/time in the overall DTarray
            While CurrentDateTime >= DTArray(j)
                j = j + 1
            End While

            'Now that i have the lower and upper bounds, call the interpolate routine 
            ' to get the in-between power level. 
            HourlyPower(i) = Interpolate(DTArray(j - 1).ToOADate, PowArray(j - 1), DTArray(j).ToOADate, PowArray(j), CurrentDateTime.ToOADate)
            'round to nearest 2 decimals.
            HourlyPower(i) = Math.Round(HourlyPower(i), 2)

            'MsgBox(HourlyTime(i).ToString + " , " + HourlyPower(i).ToString)

            i = i + 1 'increment the counter 
            CurrentDateTime = CurrentDateTime.AddHours(1) ' add 1 hour to current date time. 

        End While

    End Sub

    Private Function Interpolate(ByVal dblIndex1 As Double,
  ByVal dblValue1 As Double, ByVal dblIndex2 As Double,
  ByVal dblValue2 As Double, ByVal dblFindIndex As Double,
  Optional boolExtrapolate As Boolean = True) As Double
        '********************************************************
        'This function will return the linear interpolated value for dblFindIndex
        '
        '  *------------+-----*
        '  a               c      b
        '  1               3     5
        '  10             x      50
        '
        ' To find x at c the correct syntax would be:
        ' x = Interpolate(1,10,5,50,3)
        ' and the answer would be 30
        '********************************************************
        ' Passing a value of true for boolExtrapolate will switch on
        ' extropolation if find index falls outside the bounds of index1 
        ' and index2.
        '********************************************************

        'Trap Errors
        On Error GoTo Interpolate_Error

        Dim dblUpperLimitIndex As Double
        Dim dblUpperLimitValue As Double
        Dim dblLowerLimitIndex As Double
        Dim dblLowerLimitValue As Double

        'Main Function
        If Not boolExtrapolate Then
            'We are not extrapolating so cap the returned values

            If dblIndex2 > dblIndex1 Then
                dblLowerLimitIndex = dblIndex1
                dblUpperLimitIndex = dblIndex2
                dblLowerLimitValue = dblValue1
                dblUpperLimitValue = dblValue2
            Else
                dblLowerLimitIndex = dblIndex2
                dblUpperLimitIndex = dblIndex1
                dblLowerLimitValue = dblValue2
                dblUpperLimitValue = dblValue1
            End If

            If dblFindIndex <= dblLowerLimitIndex Then
                'If FindIndex is less than or equal to index1, 
                'return value will allways be Value1
                Interpolate = dblLowerLimitValue
                GoTo Interpolate_Exit
            ElseIf dblFindIndex >= dblUpperLimitIndex Then
                'If FindIndex is greater than or equal to index2, 
                'return value will allways be Value2
                Interpolate = dblUpperLimitValue
                GoTo Interpolate_Exit
            End If

        End If

        'Perform the interpolation
        Interpolate = dblValue1 + (dblValue2 - dblValue1) *
         (dblFindIndex - dblIndex1) / (dblIndex2 - dblIndex1)

        'Exit
Interpolate_Exit:
        Exit Function

        'Error Handling
Interpolate_Error:
        Dim Error_Location As String
        Error_Location = "Interpolate"
        MsgBox(Err.Description, vbExclamation, Error_Location & ":" & Err.Number)
        Interpolate = 0
        GoTo Interpolate_Exit
    End Function

End Class