<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRptBudgetOutstanding
    Inherits PRC.uiBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbudgetname = New System.Windows.Forms.RadioButton
        Me.rdbudgetid = New System.Windows.Forms.RadioButton
        Me.obj_budget = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PnlDfSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.LightBlue
        Me.PnlDfSearch.Controls.Add(Me.GroupBox1)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 25)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 87)
        Me.PnlDfSearch.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox1.Controls.Add(Me.rdbudgetname)
        Me.GroupBox1.Controls.Add(Me.rdbudgetid)
        Me.GroupBox1.Controls.Add(Me.obj_budget)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 74)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rdbudgetname
        '
        Me.rdbudgetname.AutoSize = True
        Me.rdbudgetname.Location = New System.Drawing.Point(123, 14)
        Me.rdbudgetname.Name = "rdbudgetname"
        Me.rdbudgetname.Size = New System.Drawing.Size(90, 17)
        Me.rdbudgetname.TabIndex = 6
        Me.rdbudgetname.Text = "Budget Name"
        Me.rdbudgetname.UseVisualStyleBackColor = True
        '
        'rdbudgetid
        '
        Me.rdbudgetid.AutoSize = True
        Me.rdbudgetid.Location = New System.Drawing.Point(18, 14)
        Me.rdbudgetid.Name = "rdbudgetid"
        Me.rdbudgetid.Size = New System.Drawing.Size(73, 17)
        Me.rdbudgetid.TabIndex = 5
        Me.rdbudgetid.Text = "Budget ID"
        Me.rdbudgetid.UseVisualStyleBackColor = True
        '
        'obj_budget
        '
        Me.obj_budget.FormattingEnabled = True
        Me.obj_budget.Location = New System.Drawing.Point(18, 37)
        Me.obj_budget.Name = "obj_budget"
        Me.obj_budget.Size = New System.Drawing.Size(339, 21)
        Me.obj_budget.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReportViewer1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 440)
        Me.Panel1.TabIndex = 2
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(796, 471)
        Me.ReportViewer1.TabIndex = 3
        '
        'uiRptBudgetOutstanding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlDfSearch)
        Me.Name = "uiRptBudgetOutstanding"
        Me.Controls.SetChildIndex(Me.PnlDfSearch, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbudgetname As System.Windows.Forms.RadioButton
    Friend WithEvents rdbudgetid As System.Windows.Forms.RadioButton
    Friend WithEvents obj_budget As System.Windows.Forms.ComboBox

End Class
