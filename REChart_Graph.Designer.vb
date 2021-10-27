﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REChart_Graph
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(REChart_Graph))
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.PlotView1 = New OxyPlot.WindowsForms.PlotView()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.btnFontSizeUp = New System.Windows.Forms.Button()
        Me.btnFontSizeDown = New System.Windows.Forms.Button()
        Me.btnOverlay = New System.Windows.Forms.Button()
        Me.cbLabels = New System.Windows.Forms.CheckBox()
        Me.cbApprovalBlock = New System.Windows.Forms.CheckBox()
        Me.cbDraft = New System.Windows.Forms.CheckBox()
        Me.cbReducedPower = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(1056, 4)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(63, 28)
        Me.BtnExport.TabIndex = 2
        Me.BtnExport.Text = "Export"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'PlotView1
        '
        Me.PlotView1.Location = New System.Drawing.Point(3, -7)
        Me.PlotView1.Name = "PlotView1"
        Me.PlotView1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.PlotView1.Size = New System.Drawing.Size(1050, 800)
        Me.PlotView1.TabIndex = 3
        Me.PlotView1.Text = "PlotView1"
        Me.PlotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.PlotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PlotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(1, 786)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(42, 10)
        Me.lblAuthor.TabIndex = 22
        Me.lblAuthor.Text = "HDP/LTP"
        '
        'btnFontSizeUp
        '
        Me.btnFontSizeUp.Location = New System.Drawing.Point(1056, 95)
        Me.btnFontSizeUp.Name = "btnFontSizeUp"
        Me.btnFontSizeUp.Size = New System.Drawing.Size(63, 45)
        Me.btnFontSizeUp.TabIndex = 23
        Me.btnFontSizeUp.Text = "Font Size +"
        Me.btnFontSizeUp.UseVisualStyleBackColor = True
        '
        'btnFontSizeDown
        '
        Me.btnFontSizeDown.Location = New System.Drawing.Point(1056, 144)
        Me.btnFontSizeDown.Name = "btnFontSizeDown"
        Me.btnFontSizeDown.Size = New System.Drawing.Size(63, 45)
        Me.btnFontSizeDown.TabIndex = 24
        Me.btnFontSizeDown.Text = "Font Size -"
        Me.btnFontSizeDown.UseVisualStyleBackColor = True
        '
        'btnOverlay
        '
        Me.btnOverlay.Location = New System.Drawing.Point(1056, 37)
        Me.btnOverlay.Name = "btnOverlay"
        Me.btnOverlay.Size = New System.Drawing.Size(63, 28)
        Me.btnOverlay.TabIndex = 25
        Me.btnOverlay.Text = "Overlay"
        Me.btnOverlay.UseVisualStyleBackColor = True
        '
        'cbLabels
        '
        Me.cbLabels.AutoSize = True
        Me.cbLabels.Checked = True
        Me.cbLabels.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbLabels.Location = New System.Drawing.Point(1056, 219)
        Me.cbLabels.Name = "cbLabels"
        Me.cbLabels.Size = New System.Drawing.Size(57, 17)
        Me.cbLabels.TabIndex = 26
        Me.cbLabels.Text = "Labels"
        Me.cbLabels.UseVisualStyleBackColor = True
        '
        'cbApprovalBlock
        '
        Me.cbApprovalBlock.AutoSize = True
        Me.cbApprovalBlock.Location = New System.Drawing.Point(1056, 242)
        Me.cbApprovalBlock.Name = "cbApprovalBlock"
        Me.cbApprovalBlock.Size = New System.Drawing.Size(71, 30)
        Me.cbApprovalBlock.TabIndex = 27
        Me.cbApprovalBlock.Text = "Approval " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Block"
        Me.cbApprovalBlock.UseVisualStyleBackColor = True
        '
        'cbDraft
        '
        Me.cbDraft.AutoSize = True
        Me.cbDraft.Location = New System.Drawing.Point(1056, 278)
        Me.cbDraft.Name = "cbDraft"
        Me.cbDraft.Size = New System.Drawing.Size(62, 17)
        Me.cbDraft.TabIndex = 28
        Me.cbDraft.Text = "DRAFT"
        Me.cbDraft.UseVisualStyleBackColor = True
        '
        'cbReducedPower
        '
        Me.cbReducedPower.AutoSize = True
        Me.cbReducedPower.Location = New System.Drawing.Point(1056, 301)
        Me.cbReducedPower.Name = "cbReducedPower"
        Me.cbReducedPower.Size = New System.Drawing.Size(70, 30)
        Me.cbReducedPower.TabIndex = 29
        Me.cbReducedPower.Text = "Reduced" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Power" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cbReducedPower.UseVisualStyleBackColor = True
        '
        'REChart_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 796)
        Me.Controls.Add(Me.cbReducedPower)
        Me.Controls.Add(Me.cbDraft)
        Me.Controls.Add(Me.cbApprovalBlock)
        Me.Controls.Add(Me.cbLabels)
        Me.Controls.Add(Me.btnOverlay)
        Me.Controls.Add(Me.btnFontSizeDown)
        Me.Controls.Add(Me.btnFontSizeUp)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.PlotView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "REChart_Graph"
        Me.Text = "RE-Chart Load Profile Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnExport As Button
    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblAuthor As Label
    Friend WithEvents btnFontSizeUp As Button
    Friend WithEvents btnFontSizeDown As Button
    Friend WithEvents btnOverlay As Button
    Friend WithEvents cbLabels As CheckBox
    Friend WithEvents cbApprovalBlock As CheckBox
    Friend WithEvents cbDraft As CheckBox
    Friend WithEvents cbReducedPower As CheckBox
End Class
