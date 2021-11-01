<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REChart_Help
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(REChart_Help))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerateLP = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSaveData = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bthRefresh = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnOverlay = New System.Windows.Forms.Button()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnFontSizeUp = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbMoreRPAs = New System.Windows.Forms.CheckBox()
        Me.cbReducedPower = New System.Windows.Forms.CheckBox()
        Me.cbDraft = New System.Windows.Forms.CheckBox()
        Me.cbApprovalBlock = New System.Windows.Forms.CheckBox()
        Me.cbLabels = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.grpInitialConditions = New System.Windows.Forms.GroupBox()
        Me.rbUnit2 = New System.Windows.Forms.RadioButton()
        Me.txtCycle = New System.Windows.Forms.TextBox()
        Me.rbUnit1 = New System.Windows.Forms.RadioButton()
        Me.txtManuverTitle = New System.Windows.Forms.TextBox()
        Me.txtInitialPower = New System.Windows.Forms.TextBox()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTitleOfManuver = New System.Windows.Forms.Label()
        Me.lblInitialPower = New System.Windows.Forms.Label()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.cbStartUpLP = New System.Windows.Forms.CheckBox()
        Me.grpAddStatePoints = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHoursForAction = New System.Windows.Forms.TextBox()
        Me.lblHoursforAction = New System.Windows.Forms.Label()
        Me.txtStatePointPower = New System.Windows.Forms.TextBox()
        Me.lblStatePointPower = New System.Windows.Forms.Label()
        Me.btnAddStatePoint = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grpInitialConditions.SuspendLayout()
        Me.grpAddStatePoints.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(106, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(611, 35)
        Me.lblTitle.TabIndex = 91
        Me.lblTitle.Text = "RE-Chart (Load Profile Generator) - Help"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(828, 16)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "RE-Chart is a tool designed to generate load profiles, hourly data for marketing," &
    " and the ovlay comparison with PI data. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(299, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(505, 112)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(300, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(510, 144)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'btnGenerateLP
        '
        Me.btnGenerateLP.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerateLP.FlatAppearance.BorderSize = 4
        Me.btnGenerateLP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGenerateLP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateLP.Location = New System.Drawing.Point(17, 378)
        Me.btnGenerateLP.Name = "btnGenerateLP"
        Me.btnGenerateLP.Size = New System.Drawing.Size(121, 27)
        Me.btnGenerateLP.TabIndex = 104
        Me.btnGenerateLP.TabStop = False
        Me.btnGenerateLP.Text = "Generate Load Profile"
        Me.btnGenerateLP.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(141, 383)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(599, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Click Generate Load Profile. This will take the existing Statepoints and generate" &
    " the Load Profile plot."
        '
        'btnSaveData
        '
        Me.btnSaveData.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSaveData.FlatAppearance.BorderSize = 4
        Me.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveData.Location = New System.Drawing.Point(17, 407)
        Me.btnSaveData.Name = "btnSaveData"
        Me.btnSaveData.Size = New System.Drawing.Size(121, 27)
        Me.btnSaveData.TabIndex = 106
        Me.btnSaveData.TabStop = False
        Me.btnSaveData.Text = "Save Data"
        Me.btnSaveData.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(140, 412)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(687, 16)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Click Save Data to save the current dataset into a data file (*.REChart extention" &
    "), which can be loaded at a later time."
        '
        'btnLoadData
        '
        Me.btnLoadData.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnLoadData.FlatAppearance.BorderSize = 4
        Me.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadData.Location = New System.Drawing.Point(17, 436)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(121, 27)
        Me.btnLoadData.TabIndex = 108
        Me.btnLoadData.TabStop = False
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(141, 441)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(493, 16)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Click Load Data to load an existing dataset from a data file with *.REChart exten" &
    "tion"
        '
        'bthRefresh
        '
        Me.bthRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bthRefresh.FlatAppearance.BorderSize = 4
        Me.bthRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bthRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bthRefresh.Location = New System.Drawing.Point(18, 465)
        Me.bthRefresh.Name = "bthRefresh"
        Me.bthRefresh.Size = New System.Drawing.Size(121, 27)
        Me.bthRefresh.TabIndex = 110
        Me.bthRefresh.TabStop = False
        Me.bthRefresh.Text = "Refresh"
        Me.bthRefresh.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(141, 470)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(684, 16)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Click Refresh to force the program to re-calculate all the Date/Times and lost MW" &
    "'s based on the current data entry."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 324)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(813, 45)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = resources.GetString("Label9.Text")
        '
        'btnOverlay
        '
        Me.btnOverlay.Location = New System.Drawing.Point(17, 535)
        Me.btnOverlay.Name = "btnOverlay"
        Me.btnOverlay.Size = New System.Drawing.Size(63, 28)
        Me.btnOverlay.TabIndex = 114
        Me.btnOverlay.Text = "Overlay"
        Me.btnOverlay.UseVisualStyleBackColor = True
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(17, 507)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(63, 28)
        Me.BtnExport.TabIndex = 113
        Me.BtnExport.Text = "Export"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 486)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(816, 16)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "_________________________________________________________________________________" &
    "____________________"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(83, 514)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(703, 16)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "Click Export to export the current plot to a PNG inage file, and generate the hou" &
    "rly marketing data in Excel (*.xlsx) format"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(83, 541)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(732, 16)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Click Overlay to retrieve the actual power data from PI, plot an overlay of Predi" &
    "cted vs Actual power, and calculate the delta."
        '
        'btnFontSizeUp
        '
        Me.btnFontSizeUp.Location = New System.Drawing.Point(17, 564)
        Me.btnFontSizeUp.Name = "btnFontSizeUp"
        Me.btnFontSizeUp.Size = New System.Drawing.Size(63, 45)
        Me.btnFontSizeUp.TabIndex = 118
        Me.btnFontSizeUp.Text = "Font Size +/-"
        Me.btnFontSizeUp.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(83, 575)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(487, 16)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Click Font Side +/- to increase/decrease the font size of the annotation text box" &
    "es. "
        '
        'cbMoreRPAs
        '
        Me.cbMoreRPAs.AutoSize = True
        Me.cbMoreRPAs.Location = New System.Drawing.Point(365, 645)
        Me.cbMoreRPAs.Name = "cbMoreRPAs"
        Me.cbMoreRPAs.Size = New System.Drawing.Size(55, 30)
        Me.cbMoreRPAs.TabIndex = 124
        Me.cbMoreRPAs.Text = "More" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RPA's"
        Me.cbMoreRPAs.UseVisualStyleBackColor = True
        '
        'cbReducedPower
        '
        Me.cbReducedPower.AutoSize = True
        Me.cbReducedPower.Location = New System.Drawing.Point(365, 617)
        Me.cbReducedPower.Name = "cbReducedPower"
        Me.cbReducedPower.Size = New System.Drawing.Size(70, 30)
        Me.cbReducedPower.TabIndex = 123
        Me.cbReducedPower.Text = "Reduced" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Power" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cbReducedPower.UseVisualStyleBackColor = True
        '
        'cbDraft
        '
        Me.cbDraft.AutoSize = True
        Me.cbDraft.Location = New System.Drawing.Point(366, 598)
        Me.cbDraft.Name = "cbDraft"
        Me.cbDraft.Size = New System.Drawing.Size(62, 17)
        Me.cbDraft.TabIndex = 122
        Me.cbDraft.Text = "DRAFT"
        Me.cbDraft.UseVisualStyleBackColor = True
        '
        'cbApprovalBlock
        '
        Me.cbApprovalBlock.AutoSize = True
        Me.cbApprovalBlock.Location = New System.Drawing.Point(22, 641)
        Me.cbApprovalBlock.Name = "cbApprovalBlock"
        Me.cbApprovalBlock.Size = New System.Drawing.Size(71, 30)
        Me.cbApprovalBlock.TabIndex = 121
        Me.cbApprovalBlock.Text = "Approval " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Block"
        Me.cbApprovalBlock.UseVisualStyleBackColor = True
        '
        'cbLabels
        '
        Me.cbLabels.AutoSize = True
        Me.cbLabels.Location = New System.Drawing.Point(22, 621)
        Me.cbLabels.Name = "cbLabels"
        Me.cbLabels.Size = New System.Drawing.Size(57, 17)
        Me.cbLabels.TabIndex = 120
        Me.cbLabels.Text = "Labels"
        Me.cbLabels.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(86, 621)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(260, 16)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "-Toggles displaying the State Point Labels"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(85, 647)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(244, 16)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "-Toggles displaying the Approval Block"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(436, 624)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(317, 16)
        Me.Label16.TabIndex = 127
        Me.Label16.Text = "-Toggles displaying the Reduced Power Level Note"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(435, 651)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(360, 16)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "-Toggles displaying the More RPA's May be Required note"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(438, 597)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(235, 16)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = "-Toggles displaying the DRAFT Block"
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
        Me.grpInitialConditions.Location = New System.Drawing.Point(4, 65)
        Me.grpInitialConditions.Name = "grpInitialConditions"
        Me.grpInitialConditions.Size = New System.Drawing.Size(296, 121)
        Me.grpInitialConditions.TabIndex = 130
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
        'txtInitialPower
        '
        Me.txtInitialPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitialPower.Location = New System.Drawing.Point(107, 71)
        Me.txtInitialPower.Name = "txtInitialPower"
        Me.txtInitialPower.Size = New System.Drawing.Size(43, 22)
        Me.txtInitialPower.TabIndex = 4
        Me.txtInitialPower.Text = "100"
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
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(107, 18)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(96, 22)
        Me.dtpStartDate.TabIndex = 1
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
        'grpAddStatePoints
        '
        Me.grpAddStatePoints.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpAddStatePoints.Controls.Add(Me.txtDescription)
        Me.grpAddStatePoints.Controls.Add(Me.Label3)
        Me.grpAddStatePoints.Controls.Add(Me.txtHoursForAction)
        Me.grpAddStatePoints.Controls.Add(Me.lblHoursforAction)
        Me.grpAddStatePoints.Controls.Add(Me.txtStatePointPower)
        Me.grpAddStatePoints.Controls.Add(Me.lblStatePointPower)
        Me.grpAddStatePoints.Controls.Add(Me.btnAddStatePoint)
        Me.grpAddStatePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAddStatePoints.Location = New System.Drawing.Point(5, 195)
        Me.grpAddStatePoints.Name = "grpAddStatePoints"
        Me.grpAddStatePoints.Size = New System.Drawing.Size(295, 128)
        Me.grpAddStatePoints.TabIndex = 131
        Me.grpAddStatePoints.TabStop = False
        Me.grpAddStatePoints.Text = "Add State Points"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(176, 41)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(92, 22)
        Me.txtDescription.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 18)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Description"
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
        'txtStatePointPower
        '
        Me.txtStatePointPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatePointPower.Location = New System.Drawing.Point(4, 41)
        Me.txtStatePointPower.Name = "txtStatePointPower"
        Me.txtStatePointPower.Size = New System.Drawing.Size(80, 22)
        Me.txtStatePointPower.TabIndex = 8
        Me.txtStatePointPower.Text = "100"
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
        'btnAddStatePoint
        '
        Me.btnAddStatePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddStatePoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStatePoint.Location = New System.Drawing.Point(104, 67)
        Me.btnAddStatePoint.Name = "btnAddStatePoint"
        Me.btnAddStatePoint.Size = New System.Drawing.Size(66, 55)
        Me.btnAddStatePoint.TabIndex = 11
        Me.btnAddStatePoint.Text = "Add State Point"
        Me.btnAddStatePoint.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(5, 359)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(816, 16)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "_________________________________________________________________________________" &
    "____________________"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(1, 175)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(816, 16)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "_________________________________________________________________________________" &
    "____________________"
        '
        'REChart_Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 679)
        Me.Controls.Add(Me.grpAddStatePoints)
        Me.Controls.Add(Me.grpInitialConditions)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cbMoreRPAs)
        Me.Controls.Add(Me.cbReducedPower)
        Me.Controls.Add(Me.cbDraft)
        Me.Controls.Add(Me.cbApprovalBlock)
        Me.Controls.Add(Me.cbLabels)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnFontSizeUp)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnOverlay)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.bthRefresh)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnLoadData)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSaveData)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnGenerateLP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "REChart_Help"
        Me.Text = "RE-Chart Help Form"
        Me.grpInitialConditions.ResumeLayout(False)
        Me.grpInitialConditions.PerformLayout()
        Me.grpAddStatePoints.ResumeLayout(False)
        Me.grpAddStatePoints.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGenerateLP As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSaveData As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnLoadData As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents bthRefresh As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnOverlay As Button
    Friend WithEvents BtnExport As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnFontSizeUp As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents cbMoreRPAs As CheckBox
    Friend WithEvents cbReducedPower As CheckBox
    Friend WithEvents cbDraft As CheckBox
    Friend WithEvents cbApprovalBlock As CheckBox
    Friend WithEvents cbLabels As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents grpInitialConditions As GroupBox
    Friend WithEvents rbUnit2 As RadioButton
    Friend WithEvents txtCycle As TextBox
    Friend WithEvents rbUnit1 As RadioButton
    Friend WithEvents txtManuverTitle As TextBox
    Friend WithEvents txtInitialPower As TextBox
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblTitleOfManuver As Label
    Friend WithEvents lblInitialPower As Label
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents lblCycle As Label
    Friend WithEvents cbStartUpLP As CheckBox
    Friend WithEvents grpAddStatePoints As GroupBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtHoursForAction As TextBox
    Friend WithEvents lblHoursforAction As Label
    Friend WithEvents txtStatePointPower As TextBox
    Friend WithEvents lblStatePointPower As Label
    Friend WithEvents btnAddStatePoint As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
End Class
