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
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.PlotView1 = New OxyPlot.WindowsForms.PlotView()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(576, 778)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(138, 28)
        Me.BtnExport.TabIndex = 2
        Me.BtnExport.Text = "Export (Needs Work)"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'PlotView1
        '
        Me.PlotView1.Location = New System.Drawing.Point(12, 12)
        Me.PlotView1.Name = "PlotView1"
        Me.PlotView1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.PlotView1.Size = New System.Drawing.Size(1265, 760)
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
        Me.lblAuthor.Location = New System.Drawing.Point(-1, 807)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(42, 10)
        Me.lblAuthor.TabIndex = 22
        Me.lblAuthor.Text = "HDP/LTP"
        '
        'REChart_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 818)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.PlotView1)
        Me.Controls.Add(Me.BtnExport)
        Me.Name = "REChart_Graph"
        Me.Text = "RE-Chart Load Profile Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnExport As Button
    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblAuthor As Label
End Class
