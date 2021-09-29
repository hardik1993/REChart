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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PlotView1 = New OxyPlot.WindowsForms.PlotView()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 556)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 56)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "OxyPlot Chart Control"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PlotView1
        '
        Me.PlotView1.Location = New System.Drawing.Point(12, 12)
        Me.PlotView1.Name = "PlotView1"
        Me.PlotView1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.PlotView1.Size = New System.Drawing.Size(1011, 538)
        Me.PlotView1.TabIndex = 3
        Me.PlotView1.Text = "PlotView1"
        Me.PlotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.PlotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PlotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'REChart_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 624)
        Me.Controls.Add(Me.PlotView1)
        Me.Controls.Add(Me.Button2)
        Me.Name = "REChart_Graph"
        Me.Text = "RE-Chart Load Profile Form"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
End Class
