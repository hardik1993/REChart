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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.btnAddStatePoint = New System.Windows.Forms.Button()
        Me.lblInitialPower = New System.Windows.Forms.Label()
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
        Me.btnGenerateLP = New System.Windows.Forms.Button()
        Me.btnSaveData = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        CType(Me.dgvStatepoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAddStatePoints.SuspendLayout()
        Me.grpInitialConditions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(203, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(514, 35)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "RE-Chart (Load Profile Generator)"
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.AutoSize = True
        Me.lblStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDateTime.Location = New System.Drawing.Point(6, 16)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(83, 13)
        Me.lblStartDateTime.TabIndex = 1
        Me.lblStartDateTime.Text = "Start Date/Time"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(94, 13)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "HH:mm"
        Me.dtpStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(196, 13)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(61, 20)
        Me.dtpStartTime.TabIndex = 3
        Me.dtpStartTime.Value = New Date(2021, 9, 20, 0, 0, 0, 0)
        '
        'btnAddStatePoint
        '
        Me.btnAddStatePoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStatePoint.Location = New System.Drawing.Point(404, 19)
        Me.btnAddStatePoint.Name = "btnAddStatePoint"
        Me.btnAddStatePoint.Size = New System.Drawing.Size(66, 39)
        Me.btnAddStatePoint.TabIndex = 4
        Me.btnAddStatePoint.Text = "Add State Point"
        Me.btnAddStatePoint.UseVisualStyleBackColor = True
        '
        'lblInitialPower
        '
        Me.lblInitialPower.AutoSize = True
        Me.lblInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialPower.Location = New System.Drawing.Point(26, 41)
        Me.lblInitialPower.Name = "lblInitialPower"
        Me.lblInitialPower.Size = New System.Drawing.Size(62, 13)
        Me.lblInitialPower.TabIndex = 6
        Me.lblInitialPower.Text = "Start Power"
        '
        'txtInitialPower
        '
        Me.txtInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitialPower.Location = New System.Drawing.Point(94, 38)
        Me.txtInitialPower.Name = "txtInitialPower"
        Me.txtInitialPower.Size = New System.Drawing.Size(96, 20)
        Me.txtInitialPower.TabIndex = 7
        Me.txtInitialPower.Text = "100"
        '
        'lblStatePointPower
        '
        Me.lblStatePointPower.AutoSize = True
        Me.lblStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatePointPower.Location = New System.Drawing.Point(4, 17)
        Me.lblStatePointPower.Name = "lblStatePointPower"
        Me.lblStatePointPower.Size = New System.Drawing.Size(37, 13)
        Me.lblStatePointPower.TabIndex = 8
        Me.lblStatePointPower.Text = "Power"
        '
        'txtStatePointPower
        '
        Me.txtStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatePointPower.Location = New System.Drawing.Point(3, 33)
        Me.txtStatePointPower.Name = "txtStatePointPower"
        Me.txtStatePointPower.Size = New System.Drawing.Size(80, 20)
        Me.txtStatePointPower.TabIndex = 9
        Me.txtStatePointPower.Text = "100"
        '
        'txtHoursForAction
        '
        Me.txtHoursForAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoursForAction.Location = New System.Drawing.Point(89, 33)
        Me.txtHoursForAction.Name = "txtHoursForAction"
        Me.txtHoursForAction.Size = New System.Drawing.Size(80, 20)
        Me.txtHoursForAction.TabIndex = 11
        Me.txtHoursForAction.Text = "0"
        '
        'lblHoursforAction
        '
        Me.lblHoursforAction.AutoSize = True
        Me.lblHoursforAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoursforAction.Location = New System.Drawing.Point(86, 17)
        Me.lblHoursforAction.Name = "lblHoursforAction"
        Me.lblHoursforAction.Size = New System.Drawing.Size(83, 13)
        Me.lblHoursforAction.TabIndex = 10
        Me.lblHoursforAction.Text = "Hours for Action"
        '
        'dgvStatepoints
        '
        Me.dgvStatepoints.AllowUserToAddRows = False
        Me.dgvStatepoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatepoints.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateTime, Me.HoursForAction, Me.HoursFromStart, Me.Power, Me.Description})
        Me.dgvStatepoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStatepoints.Location = New System.Drawing.Point(15, 119)
        Me.dgvStatepoints.Name = "dgvStatepoints"
        Me.dgvStatepoints.Size = New System.Drawing.Size(845, 349)
        Me.dgvStatepoints.TabIndex = 12
        '
        'DateTime
        '
        Me.DateTime.HeaderText = "Date/Time"
        Me.DateTime.Name = "DateTime"
        '
        'HoursForAction
        '
        Me.HoursForAction.HeaderText = "Hours For Action"
        Me.HoursForAction.Name = "HoursForAction"
        '
        'HoursFromStart
        '
        Me.HoursFromStart.HeaderText = "Hours From Start"
        Me.HoursFromStart.Name = "HoursFromStart"
        '
        'Power
        '
        Me.Power.HeaderText = "Power"
        Me.Power.Name = "Power"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 400
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(175, 33)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(223, 20)
        Me.txtDescription.TabIndex = 14
        Me.txtDescription.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Description"
        '
        'bthRefresh
        '
        Me.bthRefresh.Location = New System.Drawing.Point(769, 68)
        Me.bthRefresh.Name = "bthRefresh"
        Me.bthRefresh.Size = New System.Drawing.Size(66, 39)
        Me.bthRefresh.TabIndex = 15
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
        Me.grpAddStatePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAddStatePoints.Location = New System.Drawing.Point(287, 49)
        Me.grpAddStatePoints.Name = "grpAddStatePoints"
        Me.grpAddStatePoints.Size = New System.Drawing.Size(476, 64)
        Me.grpAddStatePoints.TabIndex = 16
        Me.grpAddStatePoints.TabStop = False
        Me.grpAddStatePoints.Text = "Add State Points"
        '
        'grpInitialConditions
        '
        Me.grpInitialConditions.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpInitialConditions.Controls.Add(Me.txtInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.lblInitialPower)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartTime)
        Me.grpInitialConditions.Controls.Add(Me.dtpStartDate)
        Me.grpInitialConditions.Controls.Add(Me.lblStartDateTime)
        Me.grpInitialConditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInitialConditions.Location = New System.Drawing.Point(15, 49)
        Me.grpInitialConditions.Name = "grpInitialConditions"
        Me.grpInitialConditions.Size = New System.Drawing.Size(266, 64)
        Me.grpInitialConditions.TabIndex = 17
        Me.grpInitialConditions.TabStop = False
        Me.grpInitialConditions.Text = "Initial Conditions"
        '
        'btnGenerateLP
        '
        Me.btnGenerateLP.Location = New System.Drawing.Point(765, 11)
        Me.btnGenerateLP.Name = "btnGenerateLP"
        Me.btnGenerateLP.Size = New System.Drawing.Size(95, 39)
        Me.btnGenerateLP.TabIndex = 18
        Me.btnGenerateLP.Text = "Generate Load Profile"
        Me.btnGenerateLP.UseVisualStyleBackColor = True
        '
        'btnSaveData
        '
        Me.btnSaveData.Location = New System.Drawing.Point(24, 474)
        Me.btnSaveData.Name = "btnSaveData"
        Me.btnSaveData.Size = New System.Drawing.Size(66, 30)
        Me.btnSaveData.TabIndex = 19
        Me.btnSaveData.Text = "Save Data"
        Me.btnSaveData.UseVisualStyleBackColor = True
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(96, 474)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(66, 30)
        Me.btnLoadData.TabIndex = 20
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'REChart_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 516)
        Me.Controls.Add(Me.btnLoadData)
        Me.Controls.Add(Me.btnSaveData)
        Me.Controls.Add(Me.btnGenerateLP)
        Me.Controls.Add(Me.grpInitialConditions)
        Me.Controls.Add(Me.grpAddStatePoints)
        Me.Controls.Add(Me.bthRefresh)
        Me.Controls.Add(Me.dgvStatepoints)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "REChart_Data"
        Me.Text = "Form1"
        CType(Me.dgvStatepoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAddStatePoints.ResumeLayout(False)
        Me.grpAddStatePoints.PerformLayout()
        Me.grpInitialConditions.ResumeLayout(False)
        Me.grpInitialConditions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents btnAddStatePoint As Button
    Friend WithEvents lblInitialPower As Label
    Friend WithEvents txtInitialPower As TextBox
    Friend WithEvents lblStatePointPower As Label
    Friend WithEvents txtStatePointPower As TextBox
    Friend WithEvents txtHoursForAction As TextBox
    Friend WithEvents lblHoursforAction As Label
    Friend WithEvents dgvStatepoints As DataGridView
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents HoursForAction As DataGridViewTextBoxColumn
    Friend WithEvents HoursFromStart As DataGridViewTextBoxColumn
    Friend WithEvents Power As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bthRefresh As Button
    Friend WithEvents grpAddStatePoints As GroupBox
    Friend WithEvents grpInitialConditions As GroupBox
    Friend WithEvents btnGenerateLP As Button
    Friend WithEvents btnSaveData As Button
    Friend WithEvents btnLoadData As Button
End Class
