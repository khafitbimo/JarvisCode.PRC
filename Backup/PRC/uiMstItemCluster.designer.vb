<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstItemCluster
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
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_Group = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvMstItemClusterGroup = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ftabMain_ItemPerGroup = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvMstItemCluster = New System.Windows.Forms.DataGridView
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.btnDelItem = New System.Windows.Forms.Button
        Me.btnAddItem = New System.Windows.Forms.Button
        Me.cbo_Category_name = New System.Windows.Forms.ComboBox
        Me.obj_Group_name = New System.Windows.Forms.TextBox
        Me.obj_Category_id = New System.Windows.Forms.TextBox
        Me.lbl_Category_id = New System.Windows.Forms.Label
        Me.obj_Group_id = New System.Windows.Forms.TextBox
        Me.lbl_Group_id = New System.Windows.Forms.Label
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_Group.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstItemClusterGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_ItemPerGroup.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvMstItemCluster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDataMaster.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_Group)
        Me.ftabMain.Controls.Add(Me.ftabMain_ItemPerGroup)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_Group
        '
        Me.ftabMain_Group.BackColor = System.Drawing.Color.White
        Me.ftabMain_Group.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_Group.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_Group.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_Group.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Group.Name = "ftabMain_Group"
        Me.ftabMain_Group.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Group.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Group.TabIndex = 0
        Me.ftabMain_Group.Text = "Cluster"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvMstItemClusterGroup)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstItemClusterGroup
        '
        Me.DgvMstItemClusterGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstItemClusterGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstItemClusterGroup.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstItemClusterGroup.Name = "DgvMstItemClusterGroup"
        Me.DgvMstItemClusterGroup.Size = New System.Drawing.Size(704, 296)
        Me.DgvMstItemClusterGroup.TabIndex = 1
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
        '
        'ftabMain_ItemPerGroup
        '
        Me.ftabMain_ItemPerGroup.BackColor = System.Drawing.Color.White
        Me.ftabMain_ItemPerGroup.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_ItemPerGroup.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_ItemPerGroup.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_ItemPerGroup.Name = "ftabMain_ItemPerGroup"
        Me.ftabMain_ItemPerGroup.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_ItemPerGroup.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_ItemPerGroup.TabIndex = 1
        Me.ftabMain_ItemPerGroup.Text = "Items per Cluster"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 79)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 406)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvMstItemCluster)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 377)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvMstItemCluster
        '
        Me.DgvMstItemCluster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstItemCluster.Location = New System.Drawing.Point(9, 6)
        Me.DgvMstItemCluster.Name = "DgvMstItemCluster"
        Me.DgvMstItemCluster.Size = New System.Drawing.Size(707, 365)
        Me.DgvMstItemCluster.TabIndex = 1
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.btnDelItem)
        Me.PnlDataMaster.Controls.Add(Me.btnAddItem)
        Me.PnlDataMaster.Controls.Add(Me.cbo_Category_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Group_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Category_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Category_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Group_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Group_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 76)
        Me.PnlDataMaster.TabIndex = 0
        '
        'btnDelItem
        '
        Me.btnDelItem.BackColor = System.Drawing.Color.Bisque
        Me.btnDelItem.Location = New System.Drawing.Point(660, 41)
        Me.btnDelItem.Name = "btnDelItem"
        Me.btnDelItem.Size = New System.Drawing.Size(60, 23)
        Me.btnDelItem.TabIndex = 4
        Me.btnDelItem.Text = "Delete"
        Me.btnDelItem.UseVisualStyleBackColor = False
        '
        'btnAddItem
        '
        Me.btnAddItem.BackColor = System.Drawing.Color.Bisque
        Me.btnAddItem.Location = New System.Drawing.Point(594, 41)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(60, 23)
        Me.btnAddItem.TabIndex = 2
        Me.btnAddItem.Text = "Add Item"
        Me.btnAddItem.UseVisualStyleBackColor = False
        '
        'cbo_Category_name
        '
        Me.cbo_Category_name.FormattingEnabled = True
        Me.cbo_Category_name.Location = New System.Drawing.Point(204, 40)
        Me.cbo_Category_name.Name = "cbo_Category_name"
        Me.cbo_Category_name.Size = New System.Drawing.Size(310, 21)
        Me.cbo_Category_name.TabIndex = 3
        Me.cbo_Category_name.Visible = False
        '
        'obj_Group_name
        '
        Me.obj_Group_name.BackColor = System.Drawing.SystemColors.Window
        Me.obj_Group_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Group_name.Location = New System.Drawing.Point(204, 15)
        Me.obj_Group_name.Name = "obj_Group_name"
        Me.obj_Group_name.ReadOnly = True
        Me.obj_Group_name.Size = New System.Drawing.Size(310, 20)
        Me.obj_Group_name.TabIndex = 2
        '
        'obj_Category_id
        '
        Me.obj_Category_id.BackColor = System.Drawing.SystemColors.Control
        Me.obj_Category_id.Location = New System.Drawing.Point(96, 41)
        Me.obj_Category_id.Name = "obj_Category_id"
        Me.obj_Category_id.ReadOnly = True
        Me.obj_Category_id.Size = New System.Drawing.Size(102, 20)
        Me.obj_Category_id.TabIndex = 1
        Me.obj_Category_id.Visible = False
        '
        'lbl_Category_id
        '
        Me.lbl_Category_id.AutoSize = True
        Me.lbl_Category_id.Location = New System.Drawing.Point(10, 44)
        Me.lbl_Category_id.Name = "lbl_Category_id"
        Me.lbl_Category_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Category_id.TabIndex = 0
        Me.lbl_Category_id.Text = "Item ID"
        Me.lbl_Category_id.Visible = False
        '
        'obj_Group_id
        '
        Me.obj_Group_id.BackColor = System.Drawing.SystemColors.Control
        Me.obj_Group_id.Location = New System.Drawing.Point(96, 15)
        Me.obj_Group_id.Name = "obj_Group_id"
        Me.obj_Group_id.ReadOnly = True
        Me.obj_Group_id.Size = New System.Drawing.Size(102, 20)
        Me.obj_Group_id.TabIndex = 1
        '
        'lbl_Group_id
        '
        Me.lbl_Group_id.AutoSize = True
        Me.lbl_Group_id.Location = New System.Drawing.Point(10, 18)
        Me.lbl_Group_id.Name = "lbl_Group_id"
        Me.lbl_Group_id.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Group_id.TabIndex = 0
        Me.lbl_Group_id.Text = "Cluster"
        '
        'uiMstItemCluster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstItemCluster"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_Group.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstItemClusterGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_ItemPerGroup.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvMstItemCluster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_ItemPerGroup As System.Windows.Forms.TabPage
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Category_id As System.Windows.Forms.Label
    Friend WithEvents obj_Category_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Group_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Group_name As System.Windows.Forms.TextBox
    Friend WithEvents ftabMain_Group As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents DgvMstItemClusterGroup As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Group_id As System.Windows.Forms.Label
    Friend WithEvents DgvMstItemCluster As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_Category_name As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents btnDelItem As System.Windows.Forms.Button

End Class

