<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REChart_Data
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(REChart_Data))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.btnAddStatePoint = New System.Windows.Forms.Button()
        Me.txtInitialPower = New System.Windows.Forms.TextBox()
        Me.lblStatePointPower = New System.Windows.Forms.Label()
        Me.txtStatePointPower = New System.Windows.Forms.TextBox()
        Me.txtHoursForAction = New System.Windows.Forms.TextBox()
        Me.lblHoursforAction = New System.Windows.Forms.Label()
        Me.dgvStatepoints = New System.Windows.Forms.DataGridView()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoursForAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoursFromStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Power = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bthRefresh = New System.Windows.Forms.Button()
        Me.grpAddStatePoints = New System.Windows.Forms.GroupBox()
        Me.grpInitialConditions = New System.Windows.Forms.GroupBox()
        Me.rbUnit2 = New System.Windows.Forms.RadioButton()
        Me.txtCycle = New System.Windows.Forms.TextBox()
        Me.rbUnit1 = New System.Windows.Forms.RadioButton()
        Me.txtManuverTitle = New System.Windows.Forms.TextBox()
        Me.lblTitleOfManuver = New System.Windows.Forms.Label()
        Me.lblInitialPower = New System.Windows.Forms.Label()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.cbStartUpLP = New System.Windows.Forms.CheckBox()
        Me.btnGenerateLP = New System.Windows.Forms.Button()
        Me.btnSaveData = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblMWE = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLostMWE = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_Help = New System.Windows.Forms.Button()
        Me.lblLoading = New System.Windows.Forms.Label()
        CType(Me.dgvStatepoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAddStatePoints.SuspendLayout()
        Me.grpInitialConditions.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(158, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(514, 35)
        Me.lblTitle.TabIndex = 90
        Me.lblTitle.Text = "RE-Chart (Load Profile Generator)"
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.AutoSize = True
        Me.lblStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDateTime.Location = New System.Drawing.Point(-2, 21)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(111, 18)
        Me.lblStartDateTime.TabIndex = 97
        Me.lblStartDateTime.Text = "Start DateTime:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(107, 18)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(96, 22)
        Me.dtpStartDate.TabIndex = 1
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "HH:mm"
        Me.dtpStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(209, 18)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(78, 22)
        Me.dtpStartTime.TabIndex = 2
        Me.dtpStartTime.Value = New Date(2021, 9, 20, 0, 0, 0, 0)
        '
        'btnAddStatePoint
        '
        Me.btnAddStatePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddStatePoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStatePoint.Location = New System.Drawing.Point(442, 14)
        Me.btnAddStatePoint.Name = "btnAddStatePoint"
        Me.btnAddStatePoint.Size = New System.Drawing.Size(66, 55)
        Me.btnAddStatePoint.TabIndex = 11
        Me.btnAddStatePoint.Text = "Add State Point"
        Me.btnAddStatePoint.UseVisualStyleBackColor = True
        '
        'txtInitialPower
        '
        Me.txtInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitialPower.Location = New System.Drawing.Point(107, 71)
        Me.txtInitialPower.Name = "txtInitialPower"
        Me.txtInitialPower.Size = New System.Drawing.Size(43, 22)
        Me.txtInitialPower.TabIndex = 4
        Me.txtInitialPower.Text = "100"
        '
        'lblStatePointPower
        '
        Me.lblStatePointPower.AutoSize = True
        Me.lblStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatePointPower.Location = New System.Drawing.Point(4, 21)
        Me.lblStatePointPower.Name = "lblStatePointPower"
        Me.lblStatePointPower.Size = New System.Drawing.Size(51, 18)
        Me.lblStatePointPower.TabIndex = 93
        Me.lblStatePointPower.Text = "Power"
        '
        'txtStatePointPower
        '
        Me.txtStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatePointPower.Location = New System.Drawing.Point(4, 41)
        Me.txtStatePointPower.Name = "txtStatePointPower"
        Me.txtStatePointPower.Size = New System.Drawing.Size(80, 22)
        Me.txtStatePointPower.TabIndex = 8
        Me.txtStatePointPower.Text = "100"
        '
        'txtHoursForAction
        '
        Me.txtHoursForAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoursForAction.Location = New System.Drawing.Point(90, 41)
        Me.txtHoursForAction.Name = "txtHoursForAction"
        Me.txtHoursForAction.Size = New System.Drawing.Size(80, 22)
        Me.txtHoursForAction.TabIndex = 9
        Me.txtHoursForAction.Text = "0"
        '
        'lblHoursforAction
        '
        Me.lblHoursforAction.AutoSize = True
        Me.lblHoursforAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoursforAction.Location = New System.Drawing.Point(71, 21)
        Me.lblHoursforAction.Name = "lblHoursforAction"
        Me.lblHoursforAction.Size = New System.Drawing.Size(116, 18)
        Me.lblHoursforAction.TabIndex = 92
        Me.lblHoursforAction.Text = "Hours for Action"
        '
        'dgvStatepoints
        '
        Me.dgvStatepoints.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStatepoints.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStatepoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatepoints.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateTime, Me.HoursForAction, Me.HoursFromStart, Me.Power, Me.Description})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStatepoints.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStatepoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStatepoints.Location = New System.Drawing.Point(9, 168)
        Me.dgvStatepoints.Name = "dgvStatepoints"
        Me.dgvStatepoints.Size = New System.Drawing.Size(814, 431)
        Me.dgvStatepoints.TabIndex = 20
        Me.dgvStatepoints.TabStop = False
        '
        'DateTime
        '
        Me.DateTime.HeaderText = "Date/Time"
        Me.DateTime.Name = "DateTime"
        Me.DateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DateTime.Width = 110
        '
        'HoursForAction
        '
        Me.HoursForAction.HeaderText = "Hours For Action"
        Me.HoursForAction.Name = "HoursForAction"
        Me.HoursForAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HoursForAction.Width = 130
        '
        'HoursFromStart
        '
        Me.HoursFromStart.HeaderText = "Hours From Start"
        Me.HoursFromStart.Name = "HoursFromStart"
        Me.HoursFromStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HoursFromStart.Width = 130
        '
        'Power
        '
        Me.Power.HeaderText = "Power"
        Me.Power.Name = "Power"
        Me.Power.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Power.Width = 70
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Description.Width = 330
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(176, 41)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(261, 22)
        Me.txtDescription.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 18)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Description"
        '
        'bthRefresh
        '
        Me.bthRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bthRefresh.FlatAppearance.BorderSize = 4
        Me.bthRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bthRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bthRefresh.Location = New System.Drawing.Point(311, 123)
        Me.bthRefresh.Name = "bthRefresh"
        Me.bthRefresh.Size = New System.Drawing.Size(121, 39)
        Me.bthRefresh.TabIndex = 12
        Me.bthRefresh.TabStop = False
        Me.bthRefresh.Text = "Refresh"
        Me.bthRefresh.UseVisualStyleBackColor = True
        '
        'grpAddStatePoints
        '
        Me.grpAddStatePoints.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpAddStatePoints.Controls.Add(Me.txtDescription)
        Me.grpAddStatePoints.Controls.Add(Me.Label1)
        Me.grpAddStatePoints.Controls.Add(Me.txtHoursForAction)
        Me.grpAddStatePoints.Controls.Add(Me.lblHoursforAction)
        Me.grpAddStatePoints.Controls.Add(Me.txtStatePointPower)
        Me.grpAddStatePoints.Controls.Add(Me.lblStatePointPower)
        Me.grpAddStatePoints.Controls.Add(Me.btnAddStatePoint)
        Me.grpAddStatePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAddStatePoints.Location = New System.Drawing.Point(311, 41)
        Me.grpAddStatePoints.Name = "grpAddStatePoints"
        Me.grpAddStatePoints.Size = New System.Drawing.Size(512, 77)
        Me.grpAddStatePoints.TabIndex = 98
        Me.grpAddStatePoints.TabStop = False
        Me.grpAddStatePoints.Text = "Add State Points"
        '
        'grpInitialConditions
        '
        Me.grpInitialConditions.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpInitialConditions.Controls.Add(Me.rbUnit2)
        Me.grpInitialConditions.Controls.Add(Me.txtCycle)
        Me.grpInitialConditions.Controls.Add(Me.rbUnit1)
        Me.grpInitialConditions.Controls.Add(Me.txtManuverTitle)
        Me.grpInitialConditions.Controls.Add(Me.txtInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartTime)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartDate)
        Me.grpInitialConditions.Controls.Add(Me.lblTitleOfManuver)
        Me.grpInitialConditions.Controls.Add(Me.lblInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.lblStartDateTime)
        Me.grpInitialConditions.Controls.Add(Me.lblCycle)
        Me.grpInitialConditions.Controls.Add(Me.cbStartUpLP)
        Me.grpInitialConditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInitialConditions.Location = New System.Drawing.Point(9, 41)
        Me.grpInitialConditions.Name = "grpInitialConditions"
        Me.grpInitialConditions.Size = New System.Drawing.Size(296, 121)
        Me.grpInitialConditions.TabIndex = 99
        Me.grpInitialConditions.TabStop = False
        Me.grpInitialConditions.Text = "Initial Conditions"
        '
        'rbUnit2
        '
        Me.rbUnit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnit2.Location = New System.Drawing.Point(190, 99)
        Me.rbUnit2.Name = "rbUnit2"
        Me.rbUnit2.Size = New System.Drawing.Size(45, 19)
        Me.rbUnit2.TabIndex = 7
        Me.rbUnit2.TabStop = True
        Me.rbUnit2.Text = "U2"
        Me.rbUnit2.UseVisualStyleBackColor = True
        '
        'txtCycle
        '
        Me.txtCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCycle.Location = New System.Drawing.Point(107, 98)
        Me.txtCycle.MaxLength = 2
        Me.txtCycle.Name = "txtCycle"
        Me.txtCycle.Size = New System.Drawing.Size(27, 22)
        Me.txtCycle.TabIndex = 5
        Me.txtCycle.Text = "xx"
        '
        'rbUnit1
        '
        Me.rbUnit1.AutoSize = True
        Me.rbUnit1.Checked = True
        Me.rbUnit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnit1.Location = New System.Drawing.Point(141, 99)
        Me.rbUnit1.Name = "rbUnit1"
        Me.rbUnit1.Size = New System.Drawing.Size(43, 20)
        Me.rbUnit1.TabIndex = 6
        Me.rbUnit1.TabStop = True
        Me.rbUnit1.Text = "U1"
        Me.rbUnit1.UseVisualStyleBackColor = True
        '
        'txtManuverTitle
        '
        Me.txtManuverTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManuverTitle.Location = New System.Drawing.Point(107, 43)
        Me.txtManuverTitle.Name = "txtManuverTitle"
        Me.txtManuverTitle.Size = New System.Drawing.Size(183, 22)
        Me.txtManuverTitle.TabIndex = 3
        Me.txtManuverTitle.Text = "Example: A1/A2 Sequence Exchange"
        '
        'lblTitleOfManuver
        '
        Me.lblTitleOfManuver.AutoSize = True
        Me.lblTitleOfManuver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleOfManuver.Location = New System.Drawing.Point(9, 45)
        Me.lblTitleOfManuver.Name = "lblTitleOfManuver"
        Me.lblTitleOfManuver.Size = New System.Drawing.Size(100, 18)
        Me.lblTitleOfManuver.TabIndex = 96
        Me.lblTitleOfManuver.Text = "Manuver Title:"
        '
        'lblInitialPower
        '
        Me.lblInitialPower.AutoSize = True
        Me.lblInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialPower.Location = New System.Drawing.Point(19, 73)
        Me.lblInitialPower.Name = "lblInitialPower"
        Me.lblInitialPower.Size = New System.Drawing.Size(90, 18)
        Me.lblInitialPower.TabIndex = 95
        Me.lblInitialPower.Text = "Start Power:"
        '
        'lblCycle
        '
        Me.lblCycle.AutoSize = True
        Me.lblCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCycle.Location = New System.Drawing.Point(22, 99)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(87, 18)
        Me.lblCycle.TabIndex = 94
        Me.lblCycle.Text = "Cycle / Unit:"
        '
        'cbStartUpLP
        '
        Me.cbStartUpLP.AutoSize = True
        Me.cbStartUpLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStartUpLP.Location = New System.Drawing.Point(153, 66)
        Me.cbStartUpLP.Name = "cbStartUpLP"
        Me.cbStartUpLP.Size = New System.Drawing.Size(146, 34)
        Me.cbStartUpLP.TabIndex = 98
        Me.cbStartUpLP.Text = "Start-Up LP? (Hours " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from Breaker Closure)"
        Me.cbStartUpLP.UseVisualStyleBackColor = True
        '
        'btnGenerateLP
        '
        Me.btnGenerateLP.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerateLP.FlatAppearance.BorderSize = 4
        Me.btnGenerateLP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGenerateLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateLP.Location = New System.Drawing.Point(442, 123)
        Me.btnGenerateLP.Name = "btnGenerateLP"
        Me.btnGenerateLP.Size = New System.Drawing.Size(121, 39)
        Me.btnGenerateLP.TabIndex = 13
        Me.btnGenerateLP.TabStop = False
        Me.btnGenerateLP.Text = "Generate Load Profile"
        Me.btnGenerateLP.UseVisualStyleBackColor = True
        '
        'btnSaveData
        '
        Me.btnSaveData.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSaveData.FlatAppearance.BorderSize = 4
        Me.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveData.Location = New System.Drawing.Point(572, 123)
        Me.btnSaveData.Name = "btnSaveData"
        Me.btnSaveData.Size = New System.Drawing.Size(121, 39)
        Me.btnSaveData.TabIndex = 14
        Me.btnSaveData.TabStop = False
        Me.btnSaveData.Text = "Save Data"
        Me.btnSaveData.UseVisualStyleBackColor = True
        '
        'btnLoadData
        '
        Me.btnLoadData.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnLoadData.FlatAppearance.BorderSize = 4
        Me.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadData.Location = New System.Drawing.Point(702, 123)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(121, 39)
        Me.btnLoadData.TabIndex = 15
        Me.btnLoadData.TabStop = False
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(3, 610)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(52, 11)
        Me.lblAuthor.TabIndex = 21
        Me.lblAuthor.Text = "HDP/LTP"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMWE, Me.lblLostMWE})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 599)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(830, 25)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblMWE
        '
        Me.lblMWE.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMWE.Name = "lblMWE"
        Me.lblMWE.Size = New System.Drawing.Size(18, 20)
        Me.lblMWE.Text = "0"
        '
        'lblLostMWE
        '
        Me.lblLostMWE.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLostMWE.Name = "lblLostMWE"
        Me.lblLostMWE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLostMWE.Size = New System.Drawing.Size(84, 20)
        Me.lblLostMWE.Text = "Lost MWe:"
        '
        'btn_Help
        '
        Me.btn_Help.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_Help.FlatAppearance.BorderSize = 4
        Me.btn_Help.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_Help.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Help.Location = New System.Drawing.Point(780, 6)
        Me.btn_Help.Name = "btn_Help"
        Me.btn_Help.Size = New System.Drawing.Size(43, 31)
        Me.btn_Help.TabIndex = 100
        Me.btn_Help.TabStop = False
        Me.btn_Help.Text = "Help"
        Me.btn_Help.UseVisualStyleBackColor = True
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Red
        Me.lblLoading.Location = New System.Drawing.Point(359, 599)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(113, 24)
        Me.lblLoading.TabIndex = 101
        Me.lblLoading.Text = "--Loading--"
        '
        'REChart_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 624)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.btn_Help)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.btnLoadData)
        Me.Controls.Add(Me.btnSaveData)
        Me.Controls.Add(Me.btnGenerateLP)
        Me.Controls.Add(Me.grpInitialConditions)
        Me.Controls.Add(Me.grpAddStatePoints)
        Me.Controls.Add(Me.bthRefresh)
        Me.Controls.Add(Me.dgvStatepoints)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "REChart_Data"
        Me.Text = "RE-Chart Data Entry Form"
        CType(Me.dgvStatepoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAddStatePoints.ResumeLayout(False)
        Me.grpAddStatePoints.PerformLayout()
        Me.grpInitialConditions.ResumeLayout(False)
        Me.grpInitialConditions.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents btnAddStatePoint As Button
    Friend WithEvents txtInitialPower As TextBox
    Friend WithEvents lblStatePointPower As Label
    Friend WithEvents txtStatePointPower As TextBox
    Friend WithEvents txtHoursForAction As TextBox
    Friend WithEvents lblHoursforAction As Label
    Friend WithEvents dgvStatepoints As DataGridView
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bthRefresh As Button
    Friend WithEvents grpAddStatePoints As GroupBox
    Friend WithEvents grpInitialConditions As GroupBox
    Friend WithEvents btnGenerateLP As Button
    Friend WithEvents btnSaveData As Button
    Friend WithEvents btnLoadData As Button
    Friend WithEvents lblAuthor As Label
    Friend WithEvents rbUnit2 As RadioButton
    Friend WithEvents rbUnit1 As RadioButton
    Friend WithEvents lblTitleOfManuver As Label
    Friend WithEvents txtManuverTitle As TextBox
    Friend WithEvents lblInitialPower As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblLostMWE As ToolStripStatusLabel
    Friend WithEvents lblMWE As ToolStripStatusLabel
    Friend WithEvents txtCycle As TextBox
    Friend WithEvents lblCycle As Label
    Friend WithEvents btn_Help As Button
    Friend WithEvents cbStartUpLP As CheckBox
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents HoursForAction As DataGridViewTextBoxColumn
    Friend WithEvents HoursFromStart As DataGridViewTextBoxColumn
    Friend WithEvents Power As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents lblLoading As Label
End Class
