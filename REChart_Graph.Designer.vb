<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.btnHideLabels = New System.Windows.Forms.Button()
        Me.btnShowLabels = New System.Windows.Forms.Button()
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
        Me.btnOverlay.Location = New System.Drawing.Point(1056, 38)
        Me.btnOverlay.Name = "btnOverlay"
        Me.btnOverlay.Size = New System.Drawing.Size(63, 28)
        Me.btnOverlay.TabIndex = 25
        Me.btnOverlay.Text = "Overlay"
        Me.btnOverlay.UseVisualStyleBackColor = True
        '
        'btnHideLabels
        '
        Me.btnHideLabels.Location = New System.Drawing.Point(1056, 216)
        Me.btnHideLabels.Name = "btnHideLabels"
        Me.btnHideLabels.Size = New System.Drawing.Size(63, 45)
        Me.btnHideLabels.TabIndex = 26
        Me.btnHideLabels.Text = "Hide Labels"
        Me.btnHideLabels.UseVisualStyleBackColor = True
        '
        'btnShowLabels
        '
        Me.btnShowLabels.Location = New System.Drawing.Point(1056, 267)
        Me.btnShowLabels.Name = "btnShowLabels"
        Me.btnShowLabels.Size = New System.Drawing.Size(63, 45)
        Me.btnShowLabels.TabIndex = 27
        Me.btnShowLabels.Text = "Show Labels"
        Me.btnShowLabels.UseVisualStyleBackColor = True
        '
        'REChart_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 796)
        Me.Controls.Add(Me.btnShowLabels)
        Me.Controls.Add(Me.btnHideLabels)
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
    Friend WithEvents btnHideLabels As Button
    Friend WithEvents btnShowLabels As Button
End Class
