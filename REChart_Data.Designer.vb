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
        Me.lblTitleOfManuver = New System.Windows.Forms.Label()
        Me.txtManuverTitle = New System.Windows.Forms.TextBox()
        Me.lblInitialPower = New System.Windows.Forms.Label()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.btnGenerateLP = New System.Windows.Forms.Button()
        Me.btnSaveData = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblMWE = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLostMWE = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.lblTitle.Location = New System.Drawing.Point(141, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(514, 35)
        Me.lblTitle.TabIndex = 90
        Me.lblTitle.Text = "RE-Chart (Load Profile Generator)"
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.AutoSize = True
        Me.lblStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDateTime.Location = New System.Drawing.Point(-2, 21)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(81, 13)
        Me.lblStartDateTime.TabIndex = 97
        Me.lblStartDateTime.Text = "Start DateTime:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(78, 18)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "HH:mm"
        Me.dtpStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(178, 18)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(70, 20)
        Me.dtpStartTime.TabIndex = 2
        Me.dtpStartTime.Value = New Date(2021, 9, 20, 0, 0, 0, 0)
        '
        'btnAddStatePoint
        '
        Me.btnAddStatePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddStatePoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStatePoint.Location = New System.Drawing.Point(442, 15)
        Me.btnAddStatePoint.Name = "btnAddStatePoint"
        Me.btnAddStatePoint.Size = New System.Drawing.Size(66, 41)
        Me.btnAddStatePoint.TabIndex = 11
        Me.btnAddStatePoint.Text = "Add State Point"
        Me.btnAddStatePoint.UseVisualStyleBackColor = True
        '
        'txtInitialPower
        '
        Me.txtInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitialPower.Location = New System.Drawing.Point(77, 67)
        Me.txtInitialPower.Name = "txtInitialPower"
        Me.txtInitialPower.Size = New System.Drawing.Size(43, 20)
        Me.txtInitialPower.TabIndex = 4
        Me.txtInitialPower.Text = "100"
        '
        'lblStatePointPower
        '
        Me.lblStatePointPower.AutoSize = True
        Me.lblStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatePointPower.Location = New System.Drawing.Point(4, 18)
        Me.lblStatePointPower.Name = "lblStatePointPower"
        Me.lblStatePointPower.Size = New System.Drawing.Size(37, 13)
        Me.lblStatePointPower.TabIndex = 93
        Me.lblStatePointPower.Text = "Power"
        '
        'txtStatePointPower
        '
        Me.txtStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatePointPower.Location = New System.Drawing.Point(3, 34)
        Me.txtStatePointPower.Name = "txtStatePointPower"
        Me.txtStatePointPower.Size = New System.Drawing.Size(80, 20)
        Me.txtStatePointPower.TabIndex = 8
        Me.txtStatePointPower.Text = "100"
        '
        'txtHoursForAction
        '
        Me.txtHoursForAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoursForAction.Location = New System.Drawing.Point(89, 34)
        Me.txtHoursForAction.Name = "txtHoursForAction"
        Me.txtHoursForAction.Size = New System.Drawing.Size(80, 20)
        Me.txtHoursForAction.TabIndex = 9
        Me.txtHoursForAction.Text = "0"
        '
        'lblHoursforAction
        '
        Me.lblHoursforAction.AutoSize = True
        Me.lblHoursforAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoursforAction.Location = New System.Drawing.Point(86, 18)
        Me.lblHoursforAction.Name = "lblHoursforAction"
        Me.lblHoursforAction.Size = New System.Drawing.Size(83, 13)
        Me.lblHoursforAction.TabIndex = 92
        Me.lblHoursforAction.Text = "Hours for Action"
        '
        'dgvStatepoints
        '
        Me.dgvStatepoints.AllowUserToAddRows = False
        Me.dgvStatepoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatepoints.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateTime, Me.HoursForAction, Me.HoursFromStart, Me.Power, Me.Description})
        Me.dgvStatepoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStatepoints.Location = New System.Drawing.Point(9, 140)
        Me.dgvStatepoints.Name = "dgvStatepoints"
        Me.dgvStatepoints.Size = New System.Drawing.Size(772, 415)
        Me.dgvStatepoints.TabIndex = 20
        Me.dgvStatepoints.TabStop = False
        '
        'DateTime
        '
        Me.DateTime.HeaderText = "Date/Time"
        Me.DateTime.Name = "DateTime"
        Me.DateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'HoursForAction
        '
        Me.HoursForAction.HeaderText = "Hours For Action"
        Me.HoursForAction.Name = "HoursForAction"
        Me.HoursForAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'HoursFromStart
        '
        Me.HoursFromStart.HeaderText = "Hours From Start"
        Me.HoursFromStart.Name = "HoursFromStart"
        Me.HoursFromStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Power
        '
        Me.Power.HeaderText = "Power"
        Me.Power.Name = "Power"
        Me.Power.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Description.Width = 325
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(175, 34)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(261, 20)
        Me.txtDescription.TabIndex = 10
        Me.txtDescription.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Description"
        '
        'bthRefresh
        '
        Me.bthRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bthRefresh.FlatAppearance.BorderSize = 4
        Me.bthRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bthRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bthRefresh.Location = New System.Drawing.Point(269, 104)
        Me.bthRefresh.Name = "bthRefresh"
        Me.bthRefresh.Size = New System.Drawing.Size(121, 31)
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
        Me.grpAddStatePoints.Location = New System.Drawing.Point(269, 41)
        Me.grpAddStatePoints.Name = "grpAddStatePoints"
        Me.grpAddStatePoints.Size = New System.Drawing.Size(512, 60)
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
        Me.grpInitialConditions.Controls.Add(Me.lblTitleOfManuver)
        Me.grpInitialConditions.Controls.Add(Me.txtManuverTitle)
        Me.grpInitialConditions.Controls.Add(Me.txtInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.lblInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartTime)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartDate)
        Me.grpInitialConditions.Controls.Add(Me.lblStartDateTime)
        Me.grpInitialConditions.Controls.Add(Me.lblCycle)
        Me.grpInitialConditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInitialConditions.Location = New System.Drawing.Point(9, 41)
        Me.grpInitialConditions.Name = "grpInitialConditions"
        Me.grpInitialConditions.Size = New System.Drawing.Size(254, 93)
        Me.grpInitialConditions.TabIndex = 99
        Me.grpInitialConditions.TabStop = False
        Me.grpInitialConditions.Text = "Initial Conditions"
        '
        'rbUnit2
        '
        Me.rbUnit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnit2.Location = New System.Drawing.Point(216, 67)
        Me.rbUnit2.Name = "rbUnit2"
        Me.rbUnit2.Size = New System.Drawing.Size(45, 19)
        Me.rbUnit2.TabIndex = 7
        Me.rbUnit2.TabStop = True
        Me.rbUnit2.Text = "U2"
        Me.rbUnit2.UseVisualStyleBackColor = True
        '
        'txtCycle
        '
        Me.txtCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCycle.Location = New System.Drawing.Point(151, 67)
        Me.txtCycle.MaxLength = 2
        Me.txtCycle.Name = "txtCycle"
        Me.txtCycle.Size = New System.Drawing.Size(27, 20)
        Me.txtCycle.TabIndex = 5
        Me.txtCycle.Text = "xx"
        '
        'rbUnit1
        '
        Me.rbUnit1.AutoSize = True
        Me.rbUnit1.Checked = True
        Me.rbUnit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUnit1.Location = New System.Drawing.Point(180, 68)
        Me.rbUnit1.Name = "rbUnit1"
        Me.rbUnit1.Size = New System.Drawing.Size(39, 17)
        Me.rbUnit1.TabIndex = 6
        Me.rbUnit1.TabStop = True
        Me.rbUnit1.Text = "U1"
        Me.rbUnit1.UseVisualStyleBackColor = True
        '
        'lblTitleOfManuver
        '
        Me.lblTitleOfManuver.AutoSize = True
        Me.lblTitleOfManuver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleOfManuver.Location = New System.Drawing.Point(2, 46)
        Me.lblTitleOfManuver.Name = "lblTitleOfManuver"
        Me.lblTitleOfManuver.Size = New System.Drawing.Size(75, 13)
        Me.lblTitleOfManuver.TabIndex = 96
        Me.lblTitleOfManuver.Text = "Manuver Title:"
        '
        'txtManuverTitle
        '
        Me.txtManuverTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManuverTitle.Location = New System.Drawing.Point(77, 43)
        Me.txtManuverTitle.Name = "txtManuverTitle"
        Me.txtManuverTitle.Size = New System.Drawing.Size(171, 20)
        Me.txtManuverTitle.TabIndex = 3
        Me.txtManuverTitle.Text = "Example: A1/A2 Sequence Exchange"
        '
        'lblInitialPower
        '
        Me.lblInitialPower.AutoSize = True
        Me.lblInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialPower.Location = New System.Drawing.Point(14, 71)
        Me.lblInitialPower.Name = "lblInitialPower"
        Me.lblInitialPower.Size = New System.Drawing.Size(65, 13)
        Me.lblInitialPower.TabIndex = 95
        Me.lblInitialPower.Text = "Start Power:"
        '
        'lblCycle
        '
        Me.lblCycle.AutoSize = True
        Me.lblCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCycle.Location = New System.Drawing.Point(117, 70)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(36, 13)
        Me.lblCycle.TabIndex = 94
        Me.lblCycle.Text = "Cycle:"
        '
        'btnGenerateLP
        '
        Me.btnGenerateLP.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerateLP.FlatAppearance.BorderSize = 4
        Me.btnGenerateLP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGenerateLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateLP.Location = New System.Drawing.Point(400, 104)
        Me.btnGenerateLP.Name = "btnGenerateLP"
        Me.btnGenerateLP.Size = New System.Drawing.Size(121, 31)
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
        Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveData.Location = New System.Drawing.Point(530, 104)
        Me.btnSaveData.Name = "btnSaveData"
        Me.btnSaveData.Size = New System.Drawing.Size(121, 31)
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
        Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadData.Location = New System.Drawing.Point(660, 104)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(121, 31)
        Me.btnLoadData.TabIndex = 15
        Me.btnLoadData.TabStop = False
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(0, 572)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(42, 10)
        Me.lblAuthor.TabIndex = 21
        Me.lblAuthor.Text = "HDP/LTP"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMWE, Me.lblLostMWE})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 563)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(788, 22)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblMWE
        '
        Me.lblMWE.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMWE.Name = "lblMWE"
        Me.lblMWE.Size = New System.Drawing.Size(15, 17)
        Me.lblMWE.Text = "0"
        '
        'lblLostMWE
        '
        Me.lblLostMWE.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLostMWE.Name = "lblLostMWE"
        Me.lblLostMWE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLostMWE.Size = New System.Drawing.Size(74, 17)
        Me.lblLostMWE.Text = "Lost MWe:"
        '
        'REChart_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 585)
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
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents HoursForAction As DataGridViewTextBoxColumn
    Friend WithEvents HoursFromStart As DataGridViewTextBoxColumn
    Friend WithEvents Power As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
End Class
