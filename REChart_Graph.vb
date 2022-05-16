Imports System.Windows.Forms.DataVisualization.Charting
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.Axes
Imports OxyPlot.Annotations
Imports OxyPlot.PdfExporter
Imports System
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.ComponentModel

Public Class REChart_Graph

    'global point vars for the drag and drop of Chart Text Annotations 
    Public lastPoint As OxyPlot.DataPoint
    Public thisPoint As OxyPlot.DataPoint
    Public newPoint As OxyPlot.DataPoint

    'global objects for the Plotview, Plot Model, and data series
    Public MySeries As New LineSeries
    Public MyActualPowerSeries As New LineSeries
    Public MyModel As New PlotModel
    'This is the list of annotations for the various state points, descriptions and to/from date-times. 
    Public AnnotationsList As New List(Of OxyPlot.Annotations.TextAnnotation)
    Public AnnotationTextArray As String()
    'This is the list of Note type annotations, such as Approval Block, Reduced Power level note, Draft, etc. 
    Public NoteAnnotationsList As New List(Of OxyPlot.Annotations.TextAnnotation)

    'globals for prompts for extra note blocks 
    Dim REName As String = ""
    Dim highPower As String = ""
    Dim lowPower As String = ""

    'global vars for the hourly data
    Dim HourlyDateTime As Date()
    Dim HourlyPowerArray As Double()

    'Global var for actual lost mwe
    Public ActLostMW As Double = 0


    'PI Object global vars 
    ' Pi Server host name
    Dim PIServerName As String = "DL2550T"
    Dim MyPISDK As PISDK.PISDK
    Dim MyApplicationObject As PISDKDlg.ApplicationObject
    Dim MyServer As PISDK.Server
    Dim MyPoints As PISDK.PIPoints
    Dim MyPoint As PISDK.PIPoint
    'Global vars For minutely data For PI data overlay. 
    Dim MyTimeStampArray As Object()
    Dim MyValues As PISDK.PIValues


    Private Sub REChart_Graph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' if its not a startup LP then 
        If REChart_Data.cbStartUpLP.Checked = False Then
            Call GenerateLoadProfile()
            Me.lblPredictedLostMWs.Text = REChart_Data.LostMWHE
        End If

        If REChart_Data.cbStartUpLP.Checked = True Then
            GenerateLoadProfile_StartUp()
        End If

    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        'Exports the graph as a PNG file. 

        'checks if the approval block was added, if it was not, then prompt the user. 
        Dim result As DialogResult
        If cbApprovalBlock.Checked = False Then
            'prompt user, get result yes or no to continue
            result = MessageBox.Show("It looks like you don't have an approval block. Do you want to continue exporting?", "Approval Block Missing?", MessageBoxButtons.YesNo)
            'if user selected no, exit sub
            If result = DialogResult.No Then Exit Sub
        End If

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

            BtnExport.Text = "(Working)"
            BtnExport.Refresh()

            'Export
            Dim fs As FileStream = File.Create(FileNameString)
            'Dim pdfExp = New PdfExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height}
            'Dim svgExp = New SvgExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height}
            Dim pngExp = New OxyPlot.WindowsForms.PngExporter With {.Width = PlotView1.Width, .Height = PlotView1.Height, .Background = OxyColors.White, .Resolution = 10000}
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
            ws.Range("A1").WrapText = True
            ws.Range("A2").WrapText = True

            'add headers to the columns
            ws.Cells(1, 1).value = MyModel.Title

            If REChart_Data.cbStartUpLP.Checked = False Then ws.Cells(2, 1).value = "Date/Time"
            If REChart_Data.cbStartUpLP.Checked = True Then ws.Cells(2, 1).value = "Hours from Breaker Closure"

            ws.Cells(2, 2).value = "Power(%)"

            ' if it is NOT a start up LP, then use horuly D/T stamps with hourly power. 
            'Loop through all valid entries in hourly arrays and write to appropriate excel cells
            If REChart_Data.cbStartUpLP.Checked = False Then
                For x = 0 To HourlyDateTime.Length - 1
                    ws.Cells(x + 3, 1).Value = HourlyDateTime(x)
                    ws.Cells(x + 3, 2).Value = HourlyPowerArray(x)
                Next
            End If

            'if it is a startup LP then use hours from breaker closure(instead of D/T stamps) with hourly power. 
            If REChart_Data.cbStartUpLP.Checked = True Then
                For x = 0 To HourlyDateTime.Length - 1
                    ws.Cells(x + 3, 1).Value = x
                    ws.Cells(x + 3, 2).Value = HourlyPowerArray(x)
                Next
            End If

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

            BtnExport.Text = "Export"
            BtnExport.Refresh()

            'Open .png and .xlsx for user to view
            System.Diagnostics.Process.Start(FileNameString)
            System.Diagnostics.Process.Start(wbFileName)

            Exit Try
        Catch ex As Exception
            MsgBox(ex.Message & " occured in Sub ButtonExport_Click in REChart_Graph.vb " & vbNewLine & "Ensure directory path is valid and admin rights are not required.", MsgBoxStyle.Critical, "FATALITY")
            BtnExport.Text = "Export"
            BtnExport.Refresh()
            Exit Try
        End Try

    End Sub

    Private Sub GenerateLoadProfile()
        ' This sub takes data from the Data Entry form from the global arrays, and generates the Load Profile. 
        ' Sets up the oxyplot controls, axis, data model, binds the data, generates the annotations, etc. 
        ' This is the NON-Startup LP routine. X axis is in Date/Time. 
        Try
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

            ' more dean proofing. If the title is too long, make the title block smaller. 
            If REChart_Data.txtManuverTitle.Text.Length < 51 Then
                MyModel.TitleFontSize = 24
            ElseIf REChart_Data.txtManuverTitle.Text.Length >= 51 And REChart_Data.txtManuverTitle.Text.Length < 61 Then
                MyModel.TitleFontSize = 21
            ElseIf REChart_Data.txtManuverTitle.Text.Length >= 61 And REChart_Data.txtManuverTitle.Text.Length < 70 Then
                MyModel.TitleFontSize = 19
            ElseIf REChart_Data.txtManuverTitle.Text.Length >= 70 And REChart_Data.txtManuverTitle.Text.Length < 81 Then
                MyModel.TitleFontSize = 17
            Else
                MsgBox("Your Title is too long!!!!", MsgBoxStyle.Critical, "FATALITY")
                Exit Sub
            End If



            MyModel.TitleFontWeight = FontWeights.Bold
            MyModel.Background = OxyColors.White

            'set up line series
            MySeries.Title = "Predicted Load Profile"

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
            'set the descriptions from AnnotationTextArray, and the date/time range for action. 
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

            'add blank annotations/event handlers for Draft, Approval Block, and Reduced Power Level Note
            ' List in order
            ' 0 - Aproval Block
            ' 1 - Reduced Power Level Note
            ' 2 - DRAFT Note
            ' 3 - More RPAs Note
            ' 4 - Power Fluctuate Note

            ' 0- Approval Block
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(0).Text = ""
            NoteAnnotationsList(0).Tag = 0
            NoteAnnotationsList(0).FontSize = 10
            NoteAnnotationsList(0).Font = "Consolas"
            NoteAnnotationsList(0).Background = OxyColors.White
            NoteAnnotationsList(0).Stroke = OxyColors.White
            NoteAnnotationsList(0).TextColor = OxyColors.White
            NoteAnnotationsList(0).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(0).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 0.5)
            MyModel.Annotations.Add(NoteAnnotationsList(0))
            ' Event handlers 
            AddHandler NoteAnnotationsList(0).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(0).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(0).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 1- Reduced Power Level Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(1).Text = ""
            NoteAnnotationsList(1).Tag = 1
            NoteAnnotationsList(1).FontSize = 10
            NoteAnnotationsList(1).Font = "Consolas"
            NoteAnnotationsList(1).Background = OxyColors.White
            NoteAnnotationsList(1).Stroke = OxyColors.White
            NoteAnnotationsList(1).TextColor = OxyColors.White
            NoteAnnotationsList(1).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(1).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 14)
            MyModel.Annotations.Add(NoteAnnotationsList(1))
            ' Event handlers 
            AddHandler NoteAnnotationsList(1).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(1).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(1).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 2- DRAFT Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(2).Text = ""
            NoteAnnotationsList(2).Tag = 2
            NoteAnnotationsList(2).FontSize = 30
            NoteAnnotationsList(2).Font = "Consolas"
            NoteAnnotationsList(2).Background = OxyColors.White
            NoteAnnotationsList(2).Stroke = OxyColors.White
            NoteAnnotationsList(2).TextColor = OxyColors.White
            NoteAnnotationsList(2).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(2).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 14)
            MyModel.Annotations.Add(NoteAnnotationsList(2))
            ' Event handlers 
            AddHandler NoteAnnotationsList(2).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(2).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(2).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 3- More RPAs Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(3).Text = ""
            NoteAnnotationsList(3).Tag = 3
            NoteAnnotationsList(3).FontSize = 10
            NoteAnnotationsList(3).Font = "Consolas"
            NoteAnnotationsList(3).Background = OxyColors.White
            NoteAnnotationsList(3).Stroke = OxyColors.White
            NoteAnnotationsList(3).TextColor = OxyColors.White
            NoteAnnotationsList(3).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(3).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 15)
            MyModel.Annotations.Add(NoteAnnotationsList(3))
            ' Event handlers 
            AddHandler NoteAnnotationsList(3).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(3).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(3).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 4 - Power Fluctuate Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(4).Text = ""
            NoteAnnotationsList(4).Tag = 4
            NoteAnnotationsList(4).FontSize = 10
            NoteAnnotationsList(4).Font = "Consolas"
            NoteAnnotationsList(4).Background = OxyColors.White
            NoteAnnotationsList(4).Stroke = OxyColors.White
            NoteAnnotationsList(4).TextColor = OxyColors.White
            NoteAnnotationsList(4).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(4).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 16)
            MyModel.Annotations.Add(NoteAnnotationsList(4))
            ' Event handlers 
            AddHandler NoteAnnotationsList(4).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(4).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(4).MouseUp, AddressOf NoteAnnotationMouseUp

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
                MySeries.MarkerSize = 4
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

            'Update Predicted Lost MW's
            lblPredictedLostMWs.Text = REChart_Data.LostMWHE.ToString

        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub GenerateLoadProfile() in REChart_Graph.vb")
        End Try

    End Sub

    Private Sub GenerateLoadProfile_StartUp()
        ' This sub takes data from the Data Entry form from the global arrays, and generates the Load Profile. 
        ' Sets up the oxyplot controls, axis, data model, binds the data, generates the annotations, etc. 
        ' This is the Startup LP routine. X axis is in hours from breaker closure. 
        Try
            'set up x axis as a hours linear axis. Setup max and min values to x axis
            Dim xAxis As New LinearAxis()
            xAxis.Position = AxisPosition.Bottom
            xAxis.Minimum = 0
            xAxis.Maximum = REChart_Data.HoursArray(REChart_Data.HoursArray.Length - 1)
            xAxis.MajorGridlineStyle = LineStyle.Dash
            xAxis.Title = "Hours After Breaker Closure"
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
            Dim strTitle As String = REChart_Data.txtManuverTitle.Text
            MyModel.Title = strTitle
            MyModel.TitleFont = "Consolas"
            MyModel.TitleFontSize = 24
            MyModel.TitleFontWeight = FontWeights.Bold
            MyModel.Background = OxyColors.White

            'set up line series
            MySeries.Title = "Predicted Load Profile"

            'add x and y axis to the data model
            MyModel.Axes.Add(xAxis)
            MyModel.Axes.Add(yAxis)

            ' Have to -2 because redim keeps the initial 1 element, and we are trashing the first "START". 
            ' Skip the first annotation Label "START". This is the default label on the load profile for the starting point.
            ' and does not need to be labeled on the load profile.  
            ReDim AnnotationTextArray(REChart_Data.DescArray.Length - 2)

            'first step is to form array of annotation descriptions.  
            For i As Integer = 1 To AnnotationTextArray.Length
                'Handle condition If there is an empty desc block and the previous block was NOT empty
                ' This Is handling the condition when a combined desc block Is used. Or REChart_Data.DescArray(i) = ""
                If i < AnnotationTextArray.Length Then ' this covers the boundry condition of i + 1 
                    If REChart_Data.DescArray(i + 1) = "" And REChart_Data.DescArray(i - 1) <> "" And REChart_Data.DescArray(i) <> "" Then
                        AnnotationTextArray(i - 1) = REChart_Data.DescArray(i)

                    ElseIf REChart_Data.DescArray(i) = "" Then 'the condition where empty place holder is needed. 
                        AnnotationTextArray(i - 1) = ""

                    Else ' the normal condition
                        AnnotationTextArray(i - 1) = REChart_Data.DescArray(i)
                    End If

                ElseIf i = AnnotationTextArray.Length Then ' handles the last desc block 
                    AnnotationTextArray(i - 1) = REChart_Data.DescArray(i)
                End If

            Next

            Dim CurrentPoint As OxyPlot.DataPoint
            Dim NextPoint As OxyPlot.DataPoint
            'setup annotations. Add annotations to the a list. 
            'setup the text annotations to fill from AnnotationTextArray
            'set the locations at the mid point of the line for the action.
            For i = 0 To AnnotationTextArray.Length - 1
                AnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
                AnnotationsList(i).Text = AnnotationTextArray(i)

                'set font to monospaced font and default size 12
                AnnotationsList(i).FontSize = 12
                AnnotationsList(i).Font = "Consolas"

                'set previous point and current point, calculate the mid point, and set the location of the annotation as the midpoint.
                CurrentPoint = New OxyPlot.DataPoint(REChart_Data.HoursArray(i), REChart_Data.PowerArray(i))
                NextPoint = New OxyPlot.DataPoint(REChart_Data.HoursArray(i + 1), REChart_Data.PowerArray(i + 1))
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

            'add blank annotations/event handlers for Draft, Approval Block, and Reduced Power Level Note
            ' List in order
            ' 0 - Aproval Block
            ' 1 - Reduced Power Level Note
            ' 2 - DRAFT Note
            ' 3 - More RPAs Note
            ' 4 - Power Fluctuate Note

            ' 0- Approval Block
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(0).Text = ""
            NoteAnnotationsList(0).Tag = 0
            NoteAnnotationsList(0).FontSize = 10
            NoteAnnotationsList(0).Font = "Consolas"
            NoteAnnotationsList(0).Background = OxyColors.White
            NoteAnnotationsList(0).Stroke = OxyColors.White
            NoteAnnotationsList(0).TextColor = OxyColors.White
            NoteAnnotationsList(0).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(0).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 0.5)
            MyModel.Annotations.Add(NoteAnnotationsList(0))
            ' Event handlers 
            AddHandler NoteAnnotationsList(0).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(0).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(0).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 1- Reduced Power Level Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(1).Text = ""
            NoteAnnotationsList(1).Tag = 1
            NoteAnnotationsList(1).FontSize = 10
            NoteAnnotationsList(1).Font = "Consolas"
            NoteAnnotationsList(1).Background = OxyColors.White
            NoteAnnotationsList(1).Stroke = OxyColors.White
            NoteAnnotationsList(1).TextColor = OxyColors.White
            NoteAnnotationsList(1).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(1).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 14)
            MyModel.Annotations.Add(NoteAnnotationsList(1))
            ' Event handlers 
            AddHandler NoteAnnotationsList(1).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(1).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(1).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 2- DRAFT Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(2).Text = ""
            NoteAnnotationsList(2).Tag = 2
            NoteAnnotationsList(2).FontSize = 30
            NoteAnnotationsList(2).Font = "Consolas"
            NoteAnnotationsList(2).Background = OxyColors.White
            NoteAnnotationsList(2).Stroke = OxyColors.White
            NoteAnnotationsList(2).TextColor = OxyColors.White
            NoteAnnotationsList(2).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(2).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 14)
            MyModel.Annotations.Add(NoteAnnotationsList(2))
            ' Event handlers 
            AddHandler NoteAnnotationsList(2).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(2).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(2).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 3- More RPAs Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(3).Text = ""
            NoteAnnotationsList(3).Tag = 3
            NoteAnnotationsList(3).FontSize = 10
            NoteAnnotationsList(3).Font = "Consolas"
            NoteAnnotationsList(3).Background = OxyColors.White
            NoteAnnotationsList(3).Stroke = OxyColors.White
            NoteAnnotationsList(3).TextColor = OxyColors.White
            NoteAnnotationsList(3).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(3).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 15)
            MyModel.Annotations.Add(NoteAnnotationsList(3))
            ' Event handlers 
            AddHandler NoteAnnotationsList(3).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(3).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(3).MouseUp, AddressOf NoteAnnotationMouseUp

            ' 4 - Power Fluctuate Note
            NoteAnnotationsList.Add(New OxyPlot.Annotations.TextAnnotation)
            NoteAnnotationsList(4).Text = ""
            NoteAnnotationsList(4).Tag = 4
            NoteAnnotationsList(4).FontSize = 10
            NoteAnnotationsList(4).Font = "Consolas"
            NoteAnnotationsList(4).Background = OxyColors.White
            NoteAnnotationsList(4).Stroke = OxyColors.White
            NoteAnnotationsList(4).TextColor = OxyColors.White
            NoteAnnotationsList(4).Layer = AnnotationLayer.BelowAxes
            NoteAnnotationsList(4).TextPosition = New OxyPlot.DataPoint(xAxis.Maximum, yAxis.Minimum + 16)
            MyModel.Annotations.Add(NoteAnnotationsList(4))
            ' Event handlers 
            AddHandler NoteAnnotationsList(4).MouseDown, AddressOf NoteAnnotationMouseDown
            AddHandler NoteAnnotationsList(4).MouseMove, AddressOf NoteAnnotationMouseMove
            AddHandler NoteAnnotationsList(4).MouseUp, AddressOf NoteAnnotationMouseUp

            'loop through array, and add points to data series
            MySeries.MarkerType = MarkerType.Circle
            For i = 0 To REChart_Data.PowerArray.Length - 1
                MySeries.Points.Add(New OxyPlot.DataPoint(REChart_Data.HoursArray(i), REChart_Data.PowerArray(i)))
            Next

            'don't draw legend since there is only one series. 
            MySeries.RenderInLegend = False

            'Do unit specific stuff 
            'Set the colors based on Unit. Unit 1 = blue, unit 2 = green.
            ' append "Unit x Cycle xx" + newline in the title based on selection. 
            If (REChart_Data.rbUnit1.Checked = True) Then
                MySeries.Color = OxyColors.RoyalBlue
                MySeries.StrokeThickness = 4
                MySeries.MarkerSize = 4
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

            'Update Predicted Lost MW's
            lblPredictedLostMWs.Text = REChart_Data.LostMWHE.ToString

        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub GenerateLoadProfile_StartUp() in REChart_Graph.vb")
        End Try

    End Sub

    Private Sub AnnotationMouseDown(sender As Object, e As OxyPlot.OxyMouseDownEventArgs)
        'this event occurs when the mouse button is first pressed down on a annotation. 
        Try
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

            ElseIf e.ChangedButton = OxyMouseButton.Right Then

                'if not already selected, then select annotation.
                If AnnotationsList(MyIndex).IsSelected = False Then
                    AnnotationsList(MyIndex).Select()
                Else
                    AnnotationsList(MyIndex).Unselect()
                End If

                MyModel.InvalidatePlot(True)
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub AnnotationMouseDown in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub AnnotationMouseMove(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        ' this event occurs after the mouse down event when the mouse is moved/dragged on an annotation. 
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub AnnotationMouseMove in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub AnnotationMouseUp(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        'this event occurs when the mouse button is released on an annotation. 
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub AnnotationMouseUp in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub NoteAnnotationMouseDown(sender As Object, e As OxyPlot.OxyMouseDownEventArgs)
        'this event occurs when the mouse button is first pressed down on a NOTE annotation. 
        Try
            'have to cast the event sender object to a local TextAnnotation Object to work with. 
            Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
            MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

            'get the index of the event sending text annotation, to that we know what index in the 
            ' Global list Of text annotations to modify. 
            Dim MyIndex As Integer = MyAnnotation.Tag

            'if left click, then go into drag/drop functionality 
            If e.ChangedButton = OxyMouseButton.Left Then
                'select the annotation. 
                NoteAnnotationsList(MyIndex).Select()

                'update the current position variable and flag the event as complete. 
                lastPoint = NoteAnnotationsList(MyIndex).InverseTransform(e.Position)
                MyModel.InvalidatePlot(False)
                e.Handled = True

            ElseIf e.ChangedButton = OxyMouseButton.Right Then

                'if not already selected, then select annotation.
                If NoteAnnotationsList(MyIndex).IsSelected = False Then
                    NoteAnnotationsList(MyIndex).Select()
                Else
                    NoteAnnotationsList(MyIndex).Unselect()
                End If

                MyModel.InvalidatePlot(True)
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub NoteAnnotationMouseDown in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub NoteAnnotationMouseMove(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        ' this event occurs after the mouse down event when the mouse is moved/dragged on a NOTE annotation. 
        Try
            'have to cast the event sender object to a local TextAnnotation Object to work with. 
            Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
            MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

            'get the index of the event sending text annotation, to that we know what index in the 
            ' Global list Of text annotations to modify. 
            Dim MyIndex As Integer = MyAnnotation.Tag

            'get the new position and calculate the delta. 
            thisPoint = NoteAnnotationsList(MyIndex).InverseTransform(e.Position)
            Dim dx As Double = thisPoint.X - lastPoint.X
            Dim dy As Double = thisPoint.Y - lastPoint.Y

            'calculate the new point based on the delta, and set the new position. 
            newPoint = New OxyPlot.DataPoint(NoteAnnotationsList(MyIndex).TextPosition.X + dx, NoteAnnotationsList(MyIndex).TextPosition.Y + dy)
            NoteAnnotationsList(MyIndex).TextPosition = newPoint

            'update the current point for calculation of delta in thre next iteration.
            lastPoint = thisPoint

            're-draw the plot, to render the new position. and flag the event as handled. 
            MyModel.InvalidatePlot(True)
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub NoteAnnotationMouseMove in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub NoteAnnotationMouseUp(sender As Object, e As OxyPlot.OxyMouseEventArgs)
        'this event occurs when the mouse button is released on a NOTE annotation. 
        Try
            'have to cast the event sender object to a local TextAnnotation Object to work with. 
            Dim MyAnnotation As OxyPlot.Annotations.TextAnnotation
            MyAnnotation = CType(sender, OxyPlot.Annotations.TextAnnotation)

            'get the index of the event sending text annotation, to that we know what index in the 
            ' Global list Of text annotations to modify. 
            Dim MyIndex As Integer = MyAnnotation.Tag

            'unselect the annotation when mouse button is released. 
            NoteAnnotationsList(MyIndex).Unselect()

            're-draw the plot, to render the new position. and flag the event as handled. 
            MyModel.InvalidatePlot(True)
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub NoteAnnotationMouseUp in REChart_Graph.vb")
        End Try
    End Sub

    Private Function MaxValue(InputArray As Double()) As Double
        'Takes an array of doubles, and returns the maximum value
        Try
            'temp var for the max value
            Dim MaxDouble As Double = 0

            'loop through array to find max value
            For i = 0 To InputArray.Count - 1
                If MaxDouble < InputArray(i) Then MaxDouble = InputArray(i)
            Next

            'return the max value
            Return MaxDouble
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Function MaxValue in REChart_Graph.vb")
        End Try
    End Function

    Private Function MinValue(InputArray As Double()) As Double
        'Takes an array of doubles, and returns the minimum value
        Try
            'temp var for the min value
            Dim MinDouble As Double = 100

            'loop through array to find max value
            For i = 0 To InputArray.Count - 1
                If MinDouble > InputArray(i) Then MinDouble = InputArray(i)
            Next

            'return the max value
            Return MinDouble
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Function MinValue in REChart_Graph.vb")
        End Try
    End Function

    Private Function CalculateMidPointOfLine(StartPoint As OxyPlot.DataPoint, EndPoint As OxyPlot.DataPoint) As OxyPlot.DataPoint
        'This function takes 2 oxyplot datapoints as input, and returns the midpoint of the line in between these 2 points. 
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Function CalculateMidPointOfLine in REChart_Graph.vb")
        End Try
    End Function

    Private Function Center2Lines(TopString As String, BotString As String) As String
        'this function accepts 2 string lines. And returns 1 string seperated by a vbnewline, and properly 
        ' padded with spaces top appear center text center aligned. The reason I had to write this is because the 
        ' oxy plot text anotations text alignment was not working.
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Function Center2Lines in REChart_Graph.vb")
        End Try
    End Function

    Private Sub btnFontSizeUp_Click(sender As Object, e As EventArgs) Handles btnFontSizeUp.Click
        ' increases the font size of all text annotations by 1
        Try
            'loop through the array of Text annotations, and increase the font size by 1
            For i As Integer = 0 To AnnotationsList.Count - 1
                AnnotationsList(i).FontSize = AnnotationsList(i).FontSize + 1
            Next

            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub btnFontSizeUp_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub btnFontSizeDown_Click(sender As Object, e As EventArgs) Handles btnFontSizeDown.Click
        ' decreases the font size of all text annotations by 1
        Try
            'loop through the array of Text annotations, and decrease the font size by 1
            For i As Integer = 0 To AnnotationsList.Count - 1
                AnnotationsList(i).FontSize = AnnotationsList(i).FontSize - 1
            Next

            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub btnFontSizeDown_Click in REChart_Graph.vb")
        End Try
    End Sub


    Private Sub CalculateHourlyData(ByVal DTArray As Date(), ByVal PowArray As Double(), ByRef HourlyTime As Date(), ByRef HourlyPower As Double())
        'This sub will accept an array of date times and power levels as inputs, and will return byref, 
        ' an hourly array Of Date times And power levels, interpolated as nessicary. This is primairly for 
        ' providing the horuly power data for marketing And work week management. 
        Try
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
            ReDim HourlyTime(diff)
            ReDim HourlyPower(diff)

            'Loop through and populate the hourly data arrays. 
            Dim CurrentDateTime As Date = StartingDateTime
            Dim i As Integer = 0
            Dim j As Integer = 0
            While CurrentDateTime <= EndingDateTime
                HourlyTime(i) = CurrentDateTime ' fill out the hourly date/time array.

                'need to interpolate here to fill out hourlypower(i)... this is going to get real gross. 
                j = 0
                'need the upper and lower values for the supplied date/time in the overall DTarray
                ' added the And j < DTArray.Length - 1 to the while loop to bound going outside of the array length. 
                While CurrentDateTime >= DTArray(j) And j < DTArray.Length - 1
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
        Catch ex As Exception
            MsgBox(ex.Message + " Occured in Private Sub CalculateHourlyData in REChart_Graph.vb")
        End Try
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

    Private Sub btnOverlay_Click(sender As Object, e As EventArgs) Handles btnOverlay.Click
        ' This Sub will take the ploted load profile, and retrieve minutelly actual power data from PI server. 
        Try

            'check to make sure the time/dates are in the past, to get historical data.
            If REChart_Data.DateTimeArray(REChart_Data.DateTimeArray.Length - 1) > Now Then
                MsgBox("I can't PREDICT the future dawg! The times in the Load Profile are in the future. ")
                Exit Sub
            End If

            ' Change the Button to indicate data is being retrieved. 
            btnOverlay.Text = "(Working)"
            btnOverlay.Refresh()

            'generate array of minutes that spans from the begening to end of the datetime array. 
            Dim NumberOfMinutes As Integer
            Dim diffTimeSpan As TimeSpan

            ' calculate the difference time span between the begening and end of the plots. And calculate the number of minutes. 
            diffTimeSpan = REChart_Data.DateTimeArray(REChart_Data.DateTimeArray.Length - 1).Subtract(REChart_Data.DateTimeArray(0))
            NumberOfMinutes = diffTimeSpan.TotalMinutes.ToString()

            ' redim the array to the number of minutes.
            ReDim MyTimeStampArray(NumberOfMinutes - 1)

            'temp date working variable 
            Dim tempdate As Date

            'initialize the first element in the array, the the first time stamp 
            MyTimeStampArray(0) = REChart_Data.DateTimeArray(0).ToString("MM/dd/yyyy HH:mm:ss")
            For i = 1 To MyTimeStampArray.Length - 1
                'increment the time stamp by 1 minute until the end of the time stamps is reached. 
                tempdate = MyTimeStampArray(i - 1)
                tempdate = tempdate.AddMinutes(1)
                MyTimeStampArray(i) = tempdate.ToString("MM/dd/yyyy HH:mm:ss")
            Next

            'initialize the PI SDK object.
            MyPISDK = New PISDK.PISDKClass()

            'initialize the PI server Properties. 
            MyServer = MyPISDK.Servers(PIServerName)
            MyPoints = MyServer.PIPoints
            'select the correct tag based on Unit
            If (REChart_Data.rbUnit1.Checked = True) Then MyPoint = MyPoints("U01.NBA08")
            If (REChart_Data.rbUnit2.Checked = True) Then MyPoint = MyPoints("U02.NBA08")

            'get the timed values from the pi server. This method will return an array of values corresponding to the array of timestamps sent. 
            MyValues = MyPoint.Data.TimedValues(MyTimeStampArray)

            'set the Title of the new series. 
            MyActualPowerSeries.Title = "Actual Power"

            'add the power and timestamp values to the lineseries. 
            For i = 0 To MyTimeStampArray.Length - 1
                tempdate = MyTimeStampArray(i)
                MyActualPowerSeries.Points.Add(New OxyPlot.DataPoint(DateTimeAxis.ToDouble(tempdate), MyValues(i + 1).Value))
            Next

            'Show the Legends and setup color
            MyActualPowerSeries.Color = OxyColors.Red
            MyActualPowerSeries.RenderInLegend = True
            MySeries.RenderInLegend = True

            'add the series to the plotmodel, and refresh the model. 
            MyModel.Series.Add(MyActualPowerSeries)
            MyModel.InvalidatePlot(True)

            ' Change the Button to indicate data is being retrieved. 
            btnOverlay.Text = "Overlay"
            btnOverlay.Refresh()

            'dispose of objects
            MyPoints = Nothing
            MyServer = Nothing
            MyPISDK = Nothing

            'Next, calculate MWe Lost
            Dim result As Double = 0
            Dim dur As Double = (1 / 60) 'Calculate duration in hrs between points, this is just 1min
            Dim fpMWE As Double = 1300 'Full power MWe
            'Loop through array points to calculate MWe lost. Looks ahead to the next point to calculate the area.
            For x = 1 To MyValues.Count - 1

                If MyValues(x).Value = 100 Or MyValues(x + 1).Value = 100 Then
                    'This is the first or last point to 100%, a triangular area needs to be calculated.
                    'If the current point is 100%, then base of triangle needs to be the difference between 100% and i+1
                    If MyValues(x).Value = 100 Then result += 0.5 * dur * (((100 - Convert.ToDouble(MyValues(x + 1).Value) / 100) * fpMWE))
                    'If the next point is 100%, then base of triangle needs to be the difference between 100% and i
                    If MyValues(x + 1).Value = 100 Then result += 0.5 * dur * (((100 - Convert.ToDouble(MyValues(x).Value)) / 100) * fpMWE)
                    'If this is just a burn at full power, the result goes to 0 added MWe lost.
                Else
                    'This is a middle section and a trapazoidal area needs to be calculated.
                    result += ((((100 - MyValues(x).Value) / 100) * fpMWE) + (((100 - MyValues(x + 1).Value) / 100) * fpMWE)) * dur * 0.5
                End If
            Next

            'Change labels
            ActLostMW = Math.Round(result, 1)
            lblActualLostMWs.Text = Math.Round(result, 1)

            'Calculate difference and update labels. If result is positive, we beat the profile.
            lblMWdiff.Text = REChart_Data.LostMWHE - ActLostMW
            'Change label color based on pos or neg
            If REChart_Data.LostMWHE - ActLostMW > 0 Then
                lblMWdiff.ForeColor = Color.Green
            Else
                lblMWdiff.ForeColor = Color.Red
            End If



        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub btnOverlay_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbApprovalBlock_Click(sender As Object, e As EventArgs) Handles cbApprovalBlock.Click
        'Handles the adding and hiding of the approval block. 
        Try
            If cbApprovalBlock.Checked = True Then
                'If a RE Name has not been entered, then prompt for one. 
                If REName = "" Then
                    REName = InputBox("Please enter the name you wish to display under RE In the Approval Block", "Enter RE Name", "Example: H. Patel")
                End If
                ' create the approval block text 
                NoteAnnotationsList(0).Text = "Reactor Engineering: " + REName + vbNewLine + " " + vbNewLine + "Work Request #: ___________" +
                vbNewLine + " " + vbNewLine + "- Activities Planned & Scheduled" + vbNewLine + "- Resources Reviewed" + vbNewLine +
                "- Marketing Notified" + vbNewLine + "- Risk Evaluated" + vbNewLine + "Manager - Work Mgmt: ___________" +
                vbNewLine + " " + vbNewLine + "Reactivity Manipulations Reviewed:" + vbNewLine + "Manager - Nuclear Ops: ___________" +
                vbNewLine + " " + vbNewLine + "Approval to Perform:" + vbNewLine + "Plant Manager-Nuclear: ___________"
                ' change the text and border color to black. Background color to white, and place above axis.
                NoteAnnotationsList(0).Stroke = OxyColors.Black
                NoteAnnotationsList(0).TextColor = OxyColors.Black
                NoteAnnotationsList(0).Background = OxyColors.White
                NoteAnnotationsList(0).Layer = AnnotationLayer.AboveSeries

            End If

            If cbApprovalBlock.Checked = False Then
                ' Change the text to blank, and change colors to match background to "hide". 
                NoteAnnotationsList(0).Text = ""
                NoteAnnotationsList(0).Background = OxyColors.White
                NoteAnnotationsList(0).Stroke = OxyColors.White
                NoteAnnotationsList(0).TextColor = OxyColors.White
                NoteAnnotationsList(0).Layer = AnnotationLayer.BelowAxes
            End If

            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbApprovalBlock_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbLabels_Click(sender As Object, e As EventArgs) Handles cbLabels.Click
        'this sub handles the hiding and showing of the annotation labels. 
        Try
            If cbLabels.Checked = True Then
                ' Show all the annotation labels by changing the text color to black, and background color to green/yellow. 
                For i = 0 To AnnotationsList.Count - 1
                    If (REChart_Data.rbUnit1.Checked = True) Then
                        AnnotationsList(i).Background = OxyColors.RoyalBlue
                    End If
                    If (REChart_Data.rbUnit2.Checked = True) Then
                        AnnotationsList(i).Background = OxyColors.Green
                    End If

                    'if its an empty annotation, then let it remain hidden
                    If AnnotationsList(i).Text = "" Then
                        AnnotationsList(i).Background = OxyColors.White
                        AnnotationsList(i).Stroke = OxyColors.White
                        AnnotationsList(i).TextColor = OxyColors.White
                        AnnotationsList(i).Layer = AnnotationLayer.BelowAxes
                    Else
                        'else unhide it.
                        AnnotationsList(i).Stroke = OxyColors.Black
                        AnnotationsList(i).TextColor = OxyColors.White
                        AnnotationsList(i).Layer = AnnotationLayer.AboveSeries
                    End If
                Next
            End If

            If cbLabels.Checked = False Then
                ' Hide all of the annotation labels by changing the color and background to match the background grey color. 
                For i = 0 To AnnotationsList.Count - 1
                    AnnotationsList(i).Background = OxyColors.White
                    AnnotationsList(i).Stroke = OxyColors.White
                    AnnotationsList(i).TextColor = OxyColors.White
                    AnnotationsList(i).Layer = AnnotationLayer.BelowAxes
                Next
            End If

            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbLabels_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbDraft_Click(sender As Object, e As EventArgs) Handles cbDraft.Click
        ' This Handles the adding and hiding of the DRAFT block.
        Try
            If cbDraft.Checked = True Then
                'create the draft block text, and setup colors. 
                NoteAnnotationsList(2).Text = "DRAFT"
                NoteAnnotationsList(2).FontWeight = FontWeights.Bold
                NoteAnnotationsList(2).TextColor = OxyColors.Red
                NoteAnnotationsList(2).Stroke = OxyColors.White
                NoteAnnotationsList(2).Background = OxyColors.White
            End If

            If cbDraft.Checked = False Then
                ' Change the text to blank, and change colors to match background to "hide". 
                NoteAnnotationsList(2).Text = ""
                NoteAnnotationsList(2).Background = OxyColors.White
                NoteAnnotationsList(2).Stroke = OxyColors.White
                NoteAnnotationsList(2).TextColor = OxyColors.White
                NoteAnnotationsList(2).Layer = AnnotationLayer.BelowAxes
            End If
            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbDraft_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbReducedPower_Click(sender As Object, e As EventArgs) Handles cbReducedPower.Click
        ' This Handles the adding and hiding of the Reduced Power Level note block.
        Try
            If cbReducedPower.Checked = True Then
                ' add the text, and set up the colors, and borders 
                NoteAnnotationsList(1).Text = "Note: At reduced power, Power Levels" + vbNewLine + "are +/- 2% RTP - Unless otherwise noted."
                NoteAnnotationsList(1).TextColor = OxyColors.Black
                NoteAnnotationsList(1).StrokeThickness = 3
                NoteAnnotationsList(1).Stroke = OxyColor.FromRgb(204, 204, 0)
                NoteAnnotationsList(1).Background = OxyColors.White
            End If

            If cbReducedPower.Checked = False Then
                ' Change the text to blank, and change colors to match background to "hide". 
                NoteAnnotationsList(1).Text = ""
                NoteAnnotationsList(1).Background = OxyColors.White
                NoteAnnotationsList(1).Stroke = OxyColors.White
                NoteAnnotationsList(1).TextColor = OxyColors.White
                NoteAnnotationsList(1).Layer = AnnotationLayer.BelowAxes
            End If
            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbReducedPower_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbMoreRPAs_Click(sender As Object, e As EventArgs) Handles cbMoreRPAs.Click
        ' This Handles the adding and hiding of the More RPA's note block..
        Try
            If cbMoreRPAs.Checked = True Then
                ' add the text, and set up the colors, and borders 
                NoteAnnotationsList(3).Text =
                "Note: More Rod Pattern Adjustments (including" + vbNewLine +
                "as low as 60%) will be needed to establish" + vbNewLine +
                "the final Rod Pattern. The Load Profile will" + vbNewLine +
                "be updated as new data becomes available."
                NoteAnnotationsList(3).TextColor = OxyColors.Black
                NoteAnnotationsList(3).StrokeThickness = 3
                NoteAnnotationsList(3).Stroke = OxyColor.FromRgb(204, 204, 0)
                NoteAnnotationsList(3).Background = OxyColors.White
            End If

            If cbMoreRPAs.Checked = False Then
                ' Change the text to blank, and change colors to match background to "hide". 
                NoteAnnotationsList(3).Text = ""
                NoteAnnotationsList(3).Background = OxyColors.White
                NoteAnnotationsList(3).Stroke = OxyColors.White
                NoteAnnotationsList(3).TextColor = OxyColors.White
                NoteAnnotationsList(3).Layer = AnnotationLayer.BelowAxes
            End If
            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbMoreRPAs_Click in REChart_Graph.vb")
        End Try
    End Sub

    Private Sub cbPowerFluctuate_Click(sender As Object, e As EventArgs) Handles cbPowerFluctuate.Click
        ' This Handles the adding and hiding of the Power Fluctuate note block.
        Try
            If cbPowerFluctuate.Checked = True Then
                'If a high and low power level has not been entered, then prompt. 
                If highPower = "" Or lowPower = "" Then
                    lowPower = InputBox("Please enter the lower power level (do not include %)", "Lower Power Level Entry", "Example: 69")
                    highPower = InputBox("Please enter the higher power level (do not include %)", "Lower Power Level Entry", "Example: 96")
                End If

                ' add the text, and set up the colors, and borders 
                NoteAnnotationsList(4).Text = "Note: Power will fluctuate between " + vbNewLine + lowPower + "% " + "and " + highPower + "% " + "RTP during the maneuver."
                NoteAnnotationsList(4).TextColor = OxyColors.Black
                NoteAnnotationsList(4).StrokeThickness = 3
                NoteAnnotationsList(4).Stroke = OxyColor.FromRgb(204, 204, 0)
                NoteAnnotationsList(4).Background = OxyColors.White
            End If

            If cbPowerFluctuate.Checked = False Then
                ' Change the text to blank, and change colors to match background to "hide". 
                NoteAnnotationsList(4).Text = ""
                NoteAnnotationsList(4).Background = OxyColors.White
                NoteAnnotationsList(4).Stroke = OxyColors.White
                NoteAnnotationsList(4).TextColor = OxyColors.White
                NoteAnnotationsList(4).Layer = AnnotationLayer.BelowAxes
            End If
            MyModel.InvalidatePlot(True)
        Catch ex As Exception
            MsgBox(ex.Message + " - Occured in Private Sub cbPowerFluctuate_Click in REChart_Graph.vb")
        End Try
    End Sub
End Class