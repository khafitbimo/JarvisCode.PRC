<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiOrderVoid
    Inherits uiBase2

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiOrderVoid))
        Me.xtabmainmenu = New DevExpress.XtraTab.XtraTabControl()
        Me.xtabmenulist = New DevExpress.XtraTab.XtraTabPage()
        Me.gcListOrderVoid = New DevExpress.XtraGrid.GridControl()
        Me.gvListVoidOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colordervoid_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderVoid_Desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannelID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colapproved1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkapproved1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colapproved1by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApprove1dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colapproved2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkapproved2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colApprove2by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApproveSpv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colapproved3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkapproved3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colApprove3by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApprove3dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApprovedProc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkapprovedproc = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colApprovedProcBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApprovedProcDt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCanceledBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCanceledDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PnlDfSearch = New DevExpress.XtraEditors.PanelControl()
        Me.mesearch_orderid = New DevExpress.XtraEditors.MemoEdit()
        Me.chkorderid = New DevExpress.XtraEditors.CheckEdit()
        Me.desearch_date = New DevExpress.XtraEditors.DateEdit()
        Me.txtsearchvoid_id = New DevExpress.XtraEditors.TextEdit()
        Me.chkdate = New DevExpress.XtraEditors.CheckEdit()
        Me.chkvoid_id = New DevExpress.XtraEditors.CheckEdit()
        Me.xtabmenudata = New DevExpress.XtraTab.XtraTabPage()
        Me.obj_Channelid = New DevExpress.XtraEditors.TextEdit()
        Me.lbldata_channelid = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.obj_Ordervoid_cancaled = New DevExpress.XtraEditors.CheckEdit()
        Me.obj_Ordervoid_cancaledby = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_cancaleddt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.obj_Ordervoid_approvedproc = New DevExpress.XtraEditors.CheckEdit()
        Me.obj_Ordervoid_approvedprocby = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_approvedprocdt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.obj_Ordervoid_approved3 = New DevExpress.XtraEditors.CheckEdit()
        Me.obj_Ordervoid_approved2 = New DevExpress.XtraEditors.CheckEdit()
        Me.obj_Ordervoid_approved1 = New DevExpress.XtraEditors.CheckEdit()
        Me.obj_Ordervoid_approved1by = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_approved3dt = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_approved1dt = New DevExpress.XtraEditors.TextEdit()
        Me.lblapproval_appspvdt = New DevExpress.XtraEditors.LabelControl()
        Me.obj_Ordervoid_approved3by = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_approved2by = New DevExpress.XtraEditors.TextEdit()
        Me.lblapproval_appavpdt = New DevExpress.XtraEditors.LabelControl()
        Me.lblapproval_appuserdt = New DevExpress.XtraEditors.LabelControl()
        Me.obj_Ordervoid_approved2dt = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_modifiedby = New DevExpress.XtraEditors.TextEdit()
        Me.lblinfo_createdby = New DevExpress.XtraEditors.LabelControl()
        Me.obj_Ordervoid_createby = New DevExpress.XtraEditors.TextEdit()
        Me.lblinfo_createddt = New DevExpress.XtraEditors.LabelControl()
        Me.obj_Ordervoid_modifieddt = New DevExpress.XtraEditors.TextEdit()
        Me.obj_Ordervoid_createdt = New DevExpress.XtraEditors.TextEdit()
        Me.lblinfo_modifiedby = New DevExpress.XtraEditors.LabelControl()
        Me.lblinfo_modifieddt = New DevExpress.XtraEditors.LabelControl()
        Me.btndata_browseorderid = New DevExpress.XtraEditors.SimpleButton()
        Me.obj_Order_id = New DevExpress.XtraEditors.TextEdit()
        Me.lbldata_orderid = New DevExpress.XtraEditors.LabelControl()
        Me.obj_Ordervoid_desc = New DevExpress.XtraEditors.MemoEdit()
        Me.lbldata_voiddesc = New System.Windows.Forms.Label()
        Me.obj_Ordervoid_id = New DevExpress.XtraEditors.TextEdit()
        Me.lbldataordervoid = New DevExpress.XtraEditors.LabelControl()
        CType(Me.xtabmainmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtabmainmenu.SuspendLayout()
        Me.xtabmenulist.SuspendLayout()
        CType(Me.gcListOrderVoid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvListVoidOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkapproved1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkapproved2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkapproved3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkapprovedproc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnlDfSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.mesearch_orderid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkorderid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.desearch_date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.desearch_date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsearchvoid_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkvoid_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtabmenudata.SuspendLayout()
        CType(Me.obj_Channelid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.obj_Ordervoid_cancaled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_cancaledby.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_cancaleddt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.obj_Ordervoid_approvedproc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approvedprocby.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approvedprocdt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.obj_Ordervoid_approved3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved1by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved3dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved1dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved3by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved2by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_approved2dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_modifiedby.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_createby.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_modifieddt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_createdt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Order_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_desc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_Ordervoid_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xtabmainmenu
        '
        Me.xtabmainmenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xtabmainmenu.Location = New System.Drawing.Point(0, 26)
        Me.xtabmainmenu.Name = "xtabmainmenu"
        Me.xtabmainmenu.SelectedTabPage = Me.xtabmenulist
        Me.xtabmainmenu.Size = New System.Drawing.Size(798, 522)
        Me.xtabmainmenu.TabIndex = 4
        Me.xtabmainmenu.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtabmenulist, Me.xtabmenudata})
        '
        'xtabmenulist
        '
        Me.xtabmenulist.Controls.Add(Me.gcListOrderVoid)
        Me.xtabmenulist.Controls.Add(Me.PnlDfSearch)
        Me.xtabmenulist.Name = "xtabmenulist"
        Me.xtabmenulist.Size = New System.Drawing.Size(793, 497)
        Me.xtabmenulist.Text = "List"
        '
        'gcListOrderVoid
        '
        Me.gcListOrderVoid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcListOrderVoid.Location = New System.Drawing.Point(0, 114)
        Me.gcListOrderVoid.MainView = Me.gvListVoidOrder
        Me.gcListOrderVoid.Name = "gcListOrderVoid"
        Me.gcListOrderVoid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkapproved1, Me.chkapproved2, Me.chkapproved3, Me.chkapprovedproc})
        Me.gcListOrderVoid.Size = New System.Drawing.Size(793, 383)
        Me.gcListOrderVoid.TabIndex = 1
        Me.gcListOrderVoid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvListVoidOrder})
        '
        'gvListVoidOrder
        '
        Me.gvListVoidOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colordervoid_id, Me.colOrderVoid_Desc, Me.colOrderID, Me.colChannelID, Me.colCreatedBy, Me.colCreatedDate, Me.colapproved1, Me.colapproved1by, Me.colApprove1dt, Me.colapproved2, Me.colApprove2by, Me.colApproveSpv, Me.colapproved3, Me.colApprove3by, Me.colApprove3dt, Me.colApprovedProc, Me.colApprovedProcBy, Me.colApprovedProcDt, Me.colCanceledBy, Me.colCanceledDate})
        Me.gvListVoidOrder.GridControl = Me.gcListOrderVoid
        Me.gvListVoidOrder.Name = "gvListVoidOrder"
        Me.gvListVoidOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvListVoidOrder.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvListVoidOrder.OptionsBehavior.Editable = False
        Me.gvListVoidOrder.OptionsBehavior.ReadOnly = True
        Me.gvListVoidOrder.OptionsView.ColumnAutoWidth = False
        Me.gvListVoidOrder.OptionsView.ShowGroupPanel = False
        '
        'colordervoid_id
        '
        Me.colordervoid_id.Caption = "Void ID"
        Me.colordervoid_id.FieldName = "ordervoid_id"
        Me.colordervoid_id.Name = "colordervoid_id"
        Me.colordervoid_id.Visible = True
        Me.colordervoid_id.VisibleIndex = 0
        Me.colordervoid_id.Width = 85
        '
        'colOrderVoid_Desc
        '
        Me.colOrderVoid_Desc.Caption = "Description"
        Me.colOrderVoid_Desc.FieldName = "ordervoid_desc"
        Me.colOrderVoid_Desc.Name = "colOrderVoid_Desc"
        Me.colOrderVoid_Desc.Visible = True
        Me.colOrderVoid_Desc.VisibleIndex = 1
        Me.colOrderVoid_Desc.Width = 162
        '
        'colOrderID
        '
        Me.colOrderID.Caption = "Order ID"
        Me.colOrderID.FieldName = "order_id"
        Me.colOrderID.Name = "colOrderID"
        Me.colOrderID.Visible = True
        Me.colOrderID.VisibleIndex = 2
        Me.colOrderID.Width = 98
        '
        'colChannelID
        '
        Me.colChannelID.Caption = "Channel"
        Me.colChannelID.FieldName = "channel_id"
        Me.colChannelID.Name = "colChannelID"
        Me.colChannelID.Visible = True
        Me.colChannelID.VisibleIndex = 3
        Me.colChannelID.Width = 72
        '
        'colCreatedBy
        '
        Me.colCreatedBy.Caption = "Created By"
        Me.colCreatedBy.FieldName = "ordervoid_createby"
        Me.colCreatedBy.Name = "colCreatedBy"
        Me.colCreatedBy.Visible = True
        Me.colCreatedBy.VisibleIndex = 4
        Me.colCreatedBy.Width = 72
        '
        'colCreatedDate
        '
        Me.colCreatedDate.Caption = "Created Date"
        Me.colCreatedDate.FieldName = "ordervoid_createdt"
        Me.colCreatedDate.Name = "colCreatedDate"
        Me.colCreatedDate.Visible = True
        Me.colCreatedDate.VisibleIndex = 5
        Me.colCreatedDate.Width = 81
        '
        'colapproved1
        '
        Me.colapproved1.Caption = "Status"
        Me.colapproved1.ColumnEdit = Me.chkapproved1
        Me.colapproved1.FieldName = "ordervoid_approved1"
        Me.colapproved1.Name = "colapproved1"
        Me.colapproved1.Visible = True
        Me.colapproved1.VisibleIndex = 6
        Me.colapproved1.Width = 44
        '
        'chkapproved1
        '
        Me.chkapproved1.AutoHeight = False
        Me.chkapproved1.Name = "chkapproved1"
        Me.chkapproved1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colapproved1by
        '
        Me.colapproved1by.Caption = "Approve User."
        Me.colapproved1by.FieldName = "ordervoid_approved1by"
        Me.colapproved1by.Name = "colapproved1by"
        Me.colapproved1by.Visible = True
        Me.colapproved1by.VisibleIndex = 7
        Me.colapproved1by.Width = 82
        '
        'colApprove1dt
        '
        Me.colApprove1dt.Caption = "App User Date"
        Me.colApprove1dt.FieldName = "ordervoid_approved1dt"
        Me.colApprove1dt.Name = "colApprove1dt"
        Me.colApprove1dt.Visible = True
        Me.colApprove1dt.VisibleIndex = 8
        Me.colApprove1dt.Width = 82
        '
        'colapproved2
        '
        Me.colapproved2.Caption = "Status"
        Me.colapproved2.ColumnEdit = Me.chkapproved2
        Me.colapproved2.FieldName = "ordervoid_approved2"
        Me.colapproved2.Name = "colapproved2"
        Me.colapproved2.Visible = True
        Me.colapproved2.VisibleIndex = 9
        Me.colapproved2.Width = 42
        '
        'chkapproved2
        '
        Me.chkapproved2.AutoHeight = False
        Me.chkapproved2.Name = "chkapproved2"
        Me.chkapproved2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colApprove2by
        '
        Me.colApprove2by.Caption = "Approve Spv."
        Me.colApprove2by.FieldName = "ordervoid_approved2by"
        Me.colApprove2by.Name = "colApprove2by"
        Me.colApprove2by.Visible = True
        Me.colApprove2by.VisibleIndex = 10
        Me.colApprove2by.Width = 78
        '
        'colApproveSpv
        '
        Me.colApproveSpv.Caption = "App Spv. Date"
        Me.colApproveSpv.FieldName = "ordervoid_approved2dt"
        Me.colApproveSpv.Name = "colApproveSpv"
        Me.colApproveSpv.Visible = True
        Me.colApproveSpv.VisibleIndex = 11
        Me.colApproveSpv.Width = 82
        '
        'colapproved3
        '
        Me.colapproved3.Caption = "Status"
        Me.colapproved3.ColumnEdit = Me.chkapproved3
        Me.colapproved3.FieldName = "ordervoid_approved3"
        Me.colapproved3.Name = "colapproved3"
        Me.colapproved3.Visible = True
        Me.colapproved3.VisibleIndex = 12
        Me.colapproved3.Width = 43
        '
        'chkapproved3
        '
        Me.chkapproved3.AutoHeight = False
        Me.chkapproved3.Name = "chkapproved3"
        Me.chkapproved3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colApprove3by
        '
        Me.colApprove3by.Caption = "Approve Avp."
        Me.colApprove3by.FieldName = "ordervoid_approved3by"
        Me.colApprove3by.Name = "colApprove3by"
        Me.colApprove3by.Visible = True
        Me.colApprove3by.VisibleIndex = 13
        Me.colApprove3by.Width = 79
        '
        'colApprove3dt
        '
        Me.colApprove3dt.Caption = "App Avp. Date"
        Me.colApprove3dt.FieldName = "ordervoid_approved3dt"
        Me.colApprove3dt.Name = "colApprove3dt"
        Me.colApprove3dt.Visible = True
        Me.colApprove3dt.VisibleIndex = 14
        Me.colApprove3dt.Width = 83
        '
        'colApprovedProc
        '
        Me.colApprovedProc.Caption = "Status"
        Me.colApprovedProc.ColumnEdit = Me.chkapprovedproc
        Me.colApprovedProc.FieldName = "ordervoid_approvedproc"
        Me.colApprovedProc.Name = "colApprovedProc"
        Me.colApprovedProc.Visible = True
        Me.colApprovedProc.VisibleIndex = 15
        Me.colApprovedProc.Width = 47
        '
        'chkapprovedproc
        '
        Me.chkapprovedproc.AutoHeight = False
        Me.chkapprovedproc.Name = "chkapprovedproc"
        Me.chkapprovedproc.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colApprovedProcBy
        '
        Me.colApprovedProcBy.Caption = "App Proc. By"
        Me.colApprovedProcBy.FieldName = "ordervoid_approvedprocby"
        Me.colApprovedProcBy.Name = "colApprovedProcBy"
        Me.colApprovedProcBy.Visible = True
        Me.colApprovedProcBy.VisibleIndex = 16
        '
        'colApprovedProcDt
        '
        Me.colApprovedProcDt.Caption = "App Proc. Date"
        Me.colApprovedProcDt.FieldName = "ordervoid_approvedprocdt"
        Me.colApprovedProcDt.Name = "colApprovedProcDt"
        Me.colApprovedProcDt.Visible = True
        Me.colApprovedProcDt.VisibleIndex = 17
        Me.colApprovedProcDt.Width = 88
        '
        'colCanceledBy
        '
        Me.colCanceledBy.Caption = "Canceled By"
        Me.colCanceledBy.FieldName = "ordervoid_canceledby"
        Me.colCanceledBy.Name = "colCanceledBy"
        Me.colCanceledBy.Visible = True
        Me.colCanceledBy.VisibleIndex = 18
        Me.colCanceledBy.Width = 71
        '
        'colCanceledDate
        '
        Me.colCanceledDate.Caption = "Canceled Date"
        Me.colCanceledDate.FieldName = "ordervoid_canceleddt"
        Me.colCanceledDate.Name = "colCanceledDate"
        Me.colCanceledDate.Visible = True
        Me.colCanceledDate.VisibleIndex = 19
        Me.colCanceledDate.Width = 82
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.mesearch_orderid)
        Me.PnlDfSearch.Controls.Add(Me.chkorderid)
        Me.PnlDfSearch.Controls.Add(Me.desearch_date)
        Me.PnlDfSearch.Controls.Add(Me.txtsearchvoid_id)
        Me.PnlDfSearch.Controls.Add(Me.chkdate)
        Me.PnlDfSearch.Controls.Add(Me.chkvoid_id)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(793, 114)
        Me.PnlDfSearch.TabIndex = 0
        Me.PnlDfSearch.Visible = False
        '
        'mesearch_orderid
        '
        Me.mesearch_orderid.Location = New System.Drawing.Point(88, 31)
        Me.mesearch_orderid.Name = "mesearch_orderid"
        Me.mesearch_orderid.Size = New System.Drawing.Size(288, 72)
        Me.mesearch_orderid.TabIndex = 6
        '
        'chkorderid
        '
        Me.chkorderid.Location = New System.Drawing.Point(6, 30)
        Me.chkorderid.Name = "chkorderid"
        Me.chkorderid.Properties.Caption = "Order ID"
        Me.chkorderid.Size = New System.Drawing.Size(75, 19)
        Me.chkorderid.TabIndex = 4
        '
        'desearch_date
        '
        Me.desearch_date.EditValue = Nothing
        Me.desearch_date.Location = New System.Drawing.Point(261, 6)
        Me.desearch_date.Name = "desearch_date"
        Me.desearch_date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.desearch_date.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.desearch_date.Size = New System.Drawing.Size(115, 20)
        Me.desearch_date.TabIndex = 3
        '
        'txtsearchvoid_id
        '
        Me.txtsearchvoid_id.Location = New System.Drawing.Point(88, 5)
        Me.txtsearchvoid_id.Name = "txtsearchvoid_id"
        Me.txtsearchvoid_id.Size = New System.Drawing.Size(114, 20)
        Me.txtsearchvoid_id.TabIndex = 2
        '
        'chkdate
        '
        Me.chkdate.Location = New System.Drawing.Point(208, 6)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Properties.Caption = "Date"
        Me.chkdate.Size = New System.Drawing.Size(75, 19)
        Me.chkdate.TabIndex = 1
        '
        'chkvoid_id
        '
        Me.chkvoid_id.Location = New System.Drawing.Point(5, 6)
        Me.chkvoid_id.Name = "chkvoid_id"
        Me.chkvoid_id.Properties.Caption = "Void ID"
        Me.chkvoid_id.Size = New System.Drawing.Size(75, 19)
        Me.chkvoid_id.TabIndex = 0
        '
        'xtabmenudata
        '
        Me.xtabmenudata.Controls.Add(Me.obj_Channelid)
        Me.xtabmenudata.Controls.Add(Me.lbldata_channelid)
        Me.xtabmenudata.Controls.Add(Me.GroupControl3)
        Me.xtabmenudata.Controls.Add(Me.btndata_browseorderid)
        Me.xtabmenudata.Controls.Add(Me.obj_Order_id)
        Me.xtabmenudata.Controls.Add(Me.lbldata_orderid)
        Me.xtabmenudata.Controls.Add(Me.obj_Ordervoid_desc)
        Me.xtabmenudata.Controls.Add(Me.lbldata_voiddesc)
        Me.xtabmenudata.Controls.Add(Me.obj_Ordervoid_id)
        Me.xtabmenudata.Controls.Add(Me.lbldataordervoid)
        Me.xtabmenudata.Name = "xtabmenudata"
        Me.xtabmenudata.Size = New System.Drawing.Size(793, 497)
        Me.xtabmenudata.Text = "Data"
        '
        'obj_Channelid
        '
        Me.obj_Channelid.Enabled = False
        Me.obj_Channelid.Location = New System.Drawing.Point(324, 10)
        Me.obj_Channelid.Name = "obj_Channelid"
        Me.obj_Channelid.Properties.ReadOnly = True
        Me.obj_Channelid.Size = New System.Drawing.Size(53, 20)
        Me.obj_Channelid.TabIndex = 30
        '
        'lbldata_channelid
        '
        Me.lbldata_channelid.Location = New System.Drawing.Point(258, 13)
        Me.lbldata_channelid.Name = "lbldata_channelid"
        Me.lbldata_channelid.Size = New System.Drawing.Size(59, 13)
        Me.lbldata_channelid.TabIndex = 29
        Me.lbldata_channelid.Text = "Company ID"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GroupBox3)
        Me.GroupControl3.Controls.Add(Me.GroupBox2)
        Me.GroupControl3.Controls.Add(Me.GroupBox1)
        Me.GroupControl3.Controls.Add(Me.obj_Ordervoid_modifiedby)
        Me.GroupControl3.Controls.Add(Me.lblinfo_createdby)
        Me.GroupControl3.Controls.Add(Me.obj_Ordervoid_createby)
        Me.GroupControl3.Controls.Add(Me.lblinfo_createddt)
        Me.GroupControl3.Controls.Add(Me.obj_Ordervoid_modifieddt)
        Me.GroupControl3.Controls.Add(Me.obj_Ordervoid_createdt)
        Me.GroupControl3.Controls.Add(Me.lblinfo_modifiedby)
        Me.GroupControl3.Controls.Add(Me.lblinfo_modifieddt)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 196)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(793, 301)
        Me.GroupControl3.TabIndex = 28
        Me.GroupControl3.Text = "Info"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.obj_Ordervoid_cancaled)
        Me.GroupBox3.Controls.Add(Me.obj_Ordervoid_cancaledby)
        Me.GroupBox3.Controls.Add(Me.obj_Ordervoid_cancaleddt)
        Me.GroupBox3.Controls.Add(Me.LabelControl5)
        Me.GroupBox3.Location = New System.Drawing.Point(363, 203)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(330, 85)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Canceled Info "
        '
        'obj_Ordervoid_cancaled
        '
        Me.obj_Ordervoid_cancaled.Location = New System.Drawing.Point(6, 22)
        Me.obj_Ordervoid_cancaled.Name = "obj_Ordervoid_cancaled"
        Me.obj_Ordervoid_cancaled.Properties.Caption = "Canceled By"
        Me.obj_Ordervoid_cancaled.Properties.ReadOnly = True
        Me.obj_Ordervoid_cancaled.Size = New System.Drawing.Size(87, 19)
        Me.obj_Ordervoid_cancaled.TabIndex = 17
        '
        'obj_Ordervoid_cancaledby
        '
        Me.obj_Ordervoid_cancaledby.Location = New System.Drawing.Point(129, 22)
        Me.obj_Ordervoid_cancaledby.Name = "obj_Ordervoid_cancaledby"
        Me.obj_Ordervoid_cancaledby.Properties.ReadOnly = True
        Me.obj_Ordervoid_cancaledby.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_cancaledby.TabIndex = 14
        '
        'obj_Ordervoid_cancaleddt
        '
        Me.obj_Ordervoid_cancaleddt.Location = New System.Drawing.Point(129, 48)
        Me.obj_Ordervoid_cancaleddt.Name = "obj_Ordervoid_cancaleddt"
        Me.obj_Ordervoid_cancaleddt.Properties.ReadOnly = True
        Me.obj_Ordervoid_cancaleddt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_cancaleddt.TabIndex = 16
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(25, 51)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl5.TabIndex = 15
        Me.LabelControl5.Text = "Canceled Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.obj_Ordervoid_approvedproc)
        Me.GroupBox2.Controls.Add(Me.obj_Ordervoid_approvedprocby)
        Me.GroupBox2.Controls.Add(Me.obj_Ordervoid_approvedprocdt)
        Me.GroupBox2.Controls.Add(Me.LabelControl3)
        Me.GroupBox2.Location = New System.Drawing.Point(363, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 85)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Procurement "
        '
        'obj_Ordervoid_approvedproc
        '
        Me.obj_Ordervoid_approvedproc.Location = New System.Drawing.Point(6, 22)
        Me.obj_Ordervoid_approvedproc.Name = "obj_Ordervoid_approvedproc"
        Me.obj_Ordervoid_approvedproc.Properties.Caption = "Proc. App/Unapp By"
        Me.obj_Ordervoid_approvedproc.Properties.ReadOnly = True
        Me.obj_Ordervoid_approvedproc.Size = New System.Drawing.Size(117, 19)
        Me.obj_Ordervoid_approvedproc.TabIndex = 30
        '
        'obj_Ordervoid_approvedprocby
        '
        Me.obj_Ordervoid_approvedprocby.Location = New System.Drawing.Point(160, 22)
        Me.obj_Ordervoid_approvedprocby.Name = "obj_Ordervoid_approvedprocby"
        Me.obj_Ordervoid_approvedprocby.Properties.ReadOnly = True
        Me.obj_Ordervoid_approvedprocby.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approvedprocby.TabIndex = 14
        '
        'obj_Ordervoid_approvedprocdt
        '
        Me.obj_Ordervoid_approvedprocdt.Location = New System.Drawing.Point(160, 48)
        Me.obj_Ordervoid_approvedprocdt.Name = "obj_Ordervoid_approvedprocdt"
        Me.obj_Ordervoid_approvedprocdt.Properties.ReadOnly = True
        Me.obj_Ordervoid_approvedprocdt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approvedprocdt.TabIndex = 16
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(108, 13)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "Proc. App/Unapp Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved3)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved2)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved1)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved1by)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved3dt)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved1dt)
        Me.GroupBox1.Controls.Add(Me.lblapproval_appspvdt)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved3by)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved2by)
        Me.GroupBox1.Controls.Add(Me.lblapproval_appavpdt)
        Me.GroupBox1.Controls.Add(Me.lblapproval_appuserdt)
        Me.GroupBox1.Controls.Add(Me.obj_Ordervoid_approved2dt)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 193)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Approval Info"
        '
        'obj_Ordervoid_approved3
        '
        Me.obj_Ordervoid_approved3.Location = New System.Drawing.Point(6, 134)
        Me.obj_Ordervoid_approved3.Name = "obj_Ordervoid_approved3"
        Me.obj_Ordervoid_approved3.Properties.Caption = "Avp. App/Unapp By"
        Me.obj_Ordervoid_approved3.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved3.Size = New System.Drawing.Size(117, 19)
        Me.obj_Ordervoid_approved3.TabIndex = 29
        '
        'obj_Ordervoid_approved2
        '
        Me.obj_Ordervoid_approved2.Location = New System.Drawing.Point(6, 78)
        Me.obj_Ordervoid_approved2.Name = "obj_Ordervoid_approved2"
        Me.obj_Ordervoid_approved2.Properties.Caption = "Spv. App/Unapp By"
        Me.obj_Ordervoid_approved2.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved2.Size = New System.Drawing.Size(117, 19)
        Me.obj_Ordervoid_approved2.TabIndex = 28
        '
        'obj_Ordervoid_approved1
        '
        Me.obj_Ordervoid_approved1.Location = New System.Drawing.Point(6, 22)
        Me.obj_Ordervoid_approved1.Name = "obj_Ordervoid_approved1"
        Me.obj_Ordervoid_approved1.Properties.Caption = "User App/Unapp By"
        Me.obj_Ordervoid_approved1.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved1.Size = New System.Drawing.Size(117, 19)
        Me.obj_Ordervoid_approved1.TabIndex = 27
        '
        'obj_Ordervoid_approved1by
        '
        Me.obj_Ordervoid_approved1by.Location = New System.Drawing.Point(162, 22)
        Me.obj_Ordervoid_approved1by.Name = "obj_Ordervoid_approved1by"
        Me.obj_Ordervoid_approved1by.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved1by.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved1by.TabIndex = 10
        '
        'obj_Ordervoid_approved3dt
        '
        Me.obj_Ordervoid_approved3dt.Location = New System.Drawing.Point(162, 160)
        Me.obj_Ordervoid_approved3dt.Name = "obj_Ordervoid_approved3dt"
        Me.obj_Ordervoid_approved3dt.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved3dt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved3dt.TabIndex = 20
        '
        'obj_Ordervoid_approved1dt
        '
        Me.obj_Ordervoid_approved1dt.Location = New System.Drawing.Point(162, 48)
        Me.obj_Ordervoid_approved1dt.Name = "obj_Ordervoid_approved1dt"
        Me.obj_Ordervoid_approved1dt.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved1dt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved1dt.TabIndex = 12
        '
        'lblapproval_appspvdt
        '
        Me.lblapproval_appspvdt.Location = New System.Drawing.Point(26, 107)
        Me.lblapproval_appspvdt.Name = "lblapproval_appspvdt"
        Me.lblapproval_appspvdt.Size = New System.Drawing.Size(105, 13)
        Me.lblapproval_appspvdt.TabIndex = 15
        Me.lblapproval_appspvdt.Text = "Spv. App/Unapp Date"
        '
        'obj_Ordervoid_approved3by
        '
        Me.obj_Ordervoid_approved3by.Location = New System.Drawing.Point(162, 134)
        Me.obj_Ordervoid_approved3by.Name = "obj_Ordervoid_approved3by"
        Me.obj_Ordervoid_approved3by.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved3by.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved3by.TabIndex = 18
        '
        'obj_Ordervoid_approved2by
        '
        Me.obj_Ordervoid_approved2by.Location = New System.Drawing.Point(162, 78)
        Me.obj_Ordervoid_approved2by.Name = "obj_Ordervoid_approved2by"
        Me.obj_Ordervoid_approved2by.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved2by.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved2by.TabIndex = 14
        '
        'lblapproval_appavpdt
        '
        Me.lblapproval_appavpdt.Location = New System.Drawing.Point(25, 163)
        Me.lblapproval_appavpdt.Name = "lblapproval_appavpdt"
        Me.lblapproval_appavpdt.Size = New System.Drawing.Size(106, 13)
        Me.lblapproval_appavpdt.TabIndex = 19
        Me.lblapproval_appavpdt.Text = "Avp. App/Unapp Date"
        '
        'lblapproval_appuserdt
        '
        Me.lblapproval_appuserdt.Location = New System.Drawing.Point(25, 51)
        Me.lblapproval_appuserdt.Name = "lblapproval_appuserdt"
        Me.lblapproval_appuserdt.Size = New System.Drawing.Size(105, 13)
        Me.lblapproval_appuserdt.TabIndex = 11
        Me.lblapproval_appuserdt.Text = "User App/Unapp Date"
        '
        'obj_Ordervoid_approved2dt
        '
        Me.obj_Ordervoid_approved2dt.Location = New System.Drawing.Point(162, 104)
        Me.obj_Ordervoid_approved2dt.Name = "obj_Ordervoid_approved2dt"
        Me.obj_Ordervoid_approved2dt.Properties.ReadOnly = True
        Me.obj_Ordervoid_approved2dt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_approved2dt.TabIndex = 16
        '
        'obj_Ordervoid_modifiedby
        '
        Me.obj_Ordervoid_modifiedby.Location = New System.Drawing.Point(320, 25)
        Me.obj_Ordervoid_modifiedby.Name = "obj_Ordervoid_modifiedby"
        Me.obj_Ordervoid_modifiedby.Properties.ReadOnly = True
        Me.obj_Ordervoid_modifiedby.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_modifiedby.TabIndex = 10
        '
        'lblinfo_createdby
        '
        Me.lblinfo_createdby.Location = New System.Drawing.Point(7, 28)
        Me.lblinfo_createdby.Name = "lblinfo_createdby"
        Me.lblinfo_createdby.Size = New System.Drawing.Size(54, 13)
        Me.lblinfo_createdby.TabIndex = 5
        Me.lblinfo_createdby.Text = "Created By"
        '
        'obj_Ordervoid_createby
        '
        Me.obj_Ordervoid_createby.Location = New System.Drawing.Point(81, 25)
        Me.obj_Ordervoid_createby.Name = "obj_Ordervoid_createby"
        Me.obj_Ordervoid_createby.Properties.ReadOnly = True
        Me.obj_Ordervoid_createby.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_createby.TabIndex = 6
        '
        'lblinfo_createddt
        '
        Me.lblinfo_createddt.Location = New System.Drawing.Point(7, 54)
        Me.lblinfo_createddt.Name = "lblinfo_createddt"
        Me.lblinfo_createddt.Size = New System.Drawing.Size(65, 13)
        Me.lblinfo_createddt.TabIndex = 7
        Me.lblinfo_createddt.Text = "Created Date"
        '
        'obj_Ordervoid_modifieddt
        '
        Me.obj_Ordervoid_modifieddt.Location = New System.Drawing.Point(320, 51)
        Me.obj_Ordervoid_modifieddt.Name = "obj_Ordervoid_modifieddt"
        Me.obj_Ordervoid_modifieddt.Properties.ReadOnly = True
        Me.obj_Ordervoid_modifieddt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_modifieddt.TabIndex = 12
        '
        'obj_Ordervoid_createdt
        '
        Me.obj_Ordervoid_createdt.Location = New System.Drawing.Point(81, 51)
        Me.obj_Ordervoid_createdt.Name = "obj_Ordervoid_createdt"
        Me.obj_Ordervoid_createdt.Properties.ReadOnly = True
        Me.obj_Ordervoid_createdt.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_createdt.TabIndex = 8
        '
        'lblinfo_modifiedby
        '
        Me.lblinfo_modifiedby.Location = New System.Drawing.Point(245, 28)
        Me.lblinfo_modifiedby.Name = "lblinfo_modifiedby"
        Me.lblinfo_modifiedby.Size = New System.Drawing.Size(55, 13)
        Me.lblinfo_modifiedby.TabIndex = 9
        Me.lblinfo_modifiedby.Text = "Modified By"
        '
        'lblinfo_modifieddt
        '
        Me.lblinfo_modifieddt.Location = New System.Drawing.Point(245, 54)
        Me.lblinfo_modifieddt.Name = "lblinfo_modifieddt"
        Me.lblinfo_modifieddt.Size = New System.Drawing.Size(66, 13)
        Me.lblinfo_modifieddt.TabIndex = 11
        Me.lblinfo_modifieddt.Text = "Modified Date"
        '
        'btndata_browseorderid
        '
        Me.btndata_browseorderid.Location = New System.Drawing.Point(249, 166)
        Me.btndata_browseorderid.Name = "btndata_browseorderid"
        Me.btndata_browseorderid.Size = New System.Drawing.Size(75, 23)
        Me.btndata_browseorderid.TabIndex = 27
        Me.btndata_browseorderid.Text = "Browse"
        '
        'obj_Order_id
        '
        Me.obj_Order_id.Location = New System.Drawing.Point(94, 167)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.Properties.ReadOnly = True
        Me.obj_Order_id.Size = New System.Drawing.Size(149, 20)
        Me.obj_Order_id.TabIndex = 26
        '
        'lbldata_orderid
        '
        Me.lbldata_orderid.Location = New System.Drawing.Point(8, 170)
        Me.lbldata_orderid.Name = "lbldata_orderid"
        Me.lbldata_orderid.Size = New System.Drawing.Size(42, 13)
        Me.lbldata_orderid.TabIndex = 25
        Me.lbldata_orderid.Text = "Order ID"
        '
        'obj_Ordervoid_desc
        '
        Me.obj_Ordervoid_desc.Location = New System.Drawing.Point(94, 36)
        Me.obj_Ordervoid_desc.Name = "obj_Ordervoid_desc"
        Me.obj_Ordervoid_desc.Size = New System.Drawing.Size(375, 122)
        Me.obj_Ordervoid_desc.TabIndex = 6
        '
        'lbldata_voiddesc
        '
        Me.lbldata_voiddesc.AutoSize = True
        Me.lbldata_voiddesc.Location = New System.Drawing.Point(5, 39)
        Me.lbldata_voiddesc.Name = "lbldata_voiddesc"
        Me.lbldata_voiddesc.Size = New System.Drawing.Size(83, 13)
        Me.lbldata_voiddesc.TabIndex = 5
        Me.lbldata_voiddesc.Text = "Void Description"
        '
        'obj_Ordervoid_id
        '
        Me.obj_Ordervoid_id.Location = New System.Drawing.Point(94, 10)
        Me.obj_Ordervoid_id.Name = "obj_Ordervoid_id"
        Me.obj_Ordervoid_id.Properties.ReadOnly = True
        Me.obj_Ordervoid_id.Size = New System.Drawing.Size(149, 20)
        Me.obj_Ordervoid_id.TabIndex = 4
        '
        'lbldataordervoid
        '
        Me.lbldataordervoid.Location = New System.Drawing.Point(8, 13)
        Me.lbldataordervoid.Name = "lbldataordervoid"
        Me.lbldataordervoid.Size = New System.Drawing.Size(34, 13)
        Me.lbldataordervoid.TabIndex = 1
        Me.lbldataordervoid.Text = "Void ID"
        '
        'uiOrderVoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.xtabmainmenu)
        Me.DSNFrm = resources.GetString("$this.DSNFrm")
        Me.Name = "uiOrderVoid"
        Me.Controls.SetChildIndex(Me.xtabmainmenu, 0)
        CType(Me.xtabmainmenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtabmainmenu.ResumeLayout(False)
        Me.xtabmenulist.ResumeLayout(False)
        CType(Me.gcListOrderVoid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvListVoidOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkapproved1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkapproved2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkapproved3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkapprovedproc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnlDfSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        CType(Me.mesearch_orderid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkorderid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.desearch_date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.desearch_date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsearchvoid_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkvoid_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtabmenudata.ResumeLayout(False)
        Me.xtabmenudata.PerformLayout()
        CType(Me.obj_Channelid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.obj_Ordervoid_cancaled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_cancaledby.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_cancaleddt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.obj_Ordervoid_approvedproc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approvedprocby.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approvedprocdt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.obj_Ordervoid_approved3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved1by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved3dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved1dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved3by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved2by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_approved2dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_modifiedby.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_createby.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_modifieddt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_createdt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Order_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_desc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_Ordervoid_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents xtabmainmenu As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtabmenulist As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtabmenudata As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcListOrderVoid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvListVoidOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PnlDfSearch As DevExpress.XtraEditors.PanelControl
    Friend WithEvents mesearch_orderid As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkorderid As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents desearch_date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtsearchvoid_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkdate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkvoid_id As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Ordervoid_desc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lbldata_voiddesc As System.Windows.Forms.Label
    Friend WithEvents obj_Ordervoid_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbldataordervoid As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_modifieddt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblinfo_modifieddt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_modifiedby As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblinfo_modifiedby As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_createdt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblinfo_createddt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_createby As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblinfo_createdby As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents obj_Ordervoid_approvedprocby As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_approvedprocdt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_Ordervoid_approved1by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_Ordervoid_approved3dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblapproval_appspvdt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_approved2by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblapproval_appavpdt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_approved2dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblapproval_appuserdt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_Ordervoid_approved3by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_Ordervoid_approved1dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btndata_browseorderid As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents obj_Order_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbldata_orderid As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents obj_Ordervoid_cancaled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Ordervoid_cancaledby As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_Ordervoid_cancaleddt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents obj_Ordervoid_approved1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Ordervoid_approved2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Ordervoid_approved3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Ordervoid_approvedproc As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents obj_Channelid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbldata_channelid As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colordervoid_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderVoid_Desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannelID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colapproved1by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApprove1dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApprove2by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApproveSpv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApprove3by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApprove3dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCanceledBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCanceledDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colapproved1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkapproved1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colapproved2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkapproved2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colapproved3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkapproved3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colApprovedProc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkapprovedproc As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colApprovedProcBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApprovedProcDt As DevExpress.XtraGrid.Columns.GridColumn

End Class
