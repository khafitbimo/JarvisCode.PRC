<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiBase2
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiBase2))
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.XafBarManager1 = New DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(Me.components)
        Me.Toolstrip1 = New DevExpress.ExpressApp.Win.Templates.Controls.XafBar()
        Me.tbtnNew = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnPrintPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnDel = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnLoad = New DevExpress.XtraBars.BarButtonItem()
        Me.tbtnQuery = New DevExpress.XtraBars.BarCheckItem()
        Me.tBtn_approve = New DevExpress.XtraBars.BarButtonItem()
        Me.tBtn_Disapprove = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.tbtnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.XafBarLinkContainerItem1 = New DevExpress.ExpressApp.Win.Templates.ActionContainers.XafBarLinkContainerItem()
        CType(Me.XafBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "tbtnNew.png")
        Me.ImageList2.Images.SetKeyName(1, "tbtnSave.png")
        Me.ImageList2.Images.SetKeyName(2, "tbtnPrint.png")
        Me.ImageList2.Images.SetKeyName(3, "tbtnPrintPreview.png")
        Me.ImageList2.Images.SetKeyName(4, "tbtnDel.png")
        Me.ImageList2.Images.SetKeyName(5, "tbtnLoad.png")
        Me.ImageList2.Images.SetKeyName(6, "tbtnQuery.png")
        Me.ImageList2.Images.SetKeyName(7, "newtbtnDelete.png")
        Me.ImageList2.Images.SetKeyName(8, "newtbtnNewFile.png")
        Me.ImageList2.Images.SetKeyName(9, "newtbtnPreview.png")
        Me.ImageList2.Images.SetKeyName(10, "newtbtnPrint.png")
        Me.ImageList2.Images.SetKeyName(11, "newtbtnSave.png")
        Me.ImageList2.Images.SetKeyName(12, "newtbtnApprove.png")
        Me.ImageList2.Images.SetKeyName(13, "newtbtnUnapproved.png")
        Me.ImageList2.Images.SetKeyName(14, "newtbtnQuery.png")
        Me.ImageList2.Images.SetKeyName(15, "newtbtnRetrieve.png")
        '
        'XafBarManager1
        '
        Me.XafBarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Toolstrip1})
        Me.XafBarManager1.DockControls.Add(Me.BarDockControl1)
        Me.XafBarManager1.DockControls.Add(Me.BarDockControl2)
        Me.XafBarManager1.DockControls.Add(Me.BarDockControl3)
        Me.XafBarManager1.DockControls.Add(Me.BarDockControl4)
        Me.XafBarManager1.Form = Me
        Me.XafBarManager1.Images = Me.ImageList2
        Me.XafBarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.tbtnNew, Me.tbtnSave, Me.tbtnPrint, Me.tbtnPrintPreview, Me.tbtnDel, Me.tbtnLoad, Me.tbtnRefresh, Me.tbtnQuery, Me.XafBarLinkContainerItem1, Me.tBtn_approve, Me.tBtn_Disapprove})
        Me.XafBarManager1.MainMenu = Me.Toolstrip1
        Me.XafBarManager1.MaxItemId = 14
        '
        'Toolstrip1
        '
        Me.Toolstrip1.BarItemHorzIndent = 4
        Me.Toolstrip1.BarName = "Main Menu"
        Me.Toolstrip1.DockCol = 0
        Me.Toolstrip1.DockRow = 0
        Me.Toolstrip1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Toolstrip1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnNew), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.tbtnSave, DevExpress.XtraBars.BarItemPaintStyle.Standard), New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnPrintPreview), New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnDel, True), New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnLoad), New DevExpress.XtraBars.LinkPersistInfo(Me.tbtnQuery), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.tBtn_approve, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.tBtn_Disapprove)})
        Me.Toolstrip1.OptionsBar.AllowQuickCustomization = False
        Me.Toolstrip1.OptionsBar.DrawDragBorder = False
        Me.Toolstrip1.OptionsBar.MultiLine = True
        Me.Toolstrip1.OptionsBar.UseWholeRow = True
        Me.Toolstrip1.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.Toolstrip1.Text = "Main Menu"
        '
        'tbtnNew
        '
        Me.tbtnNew.Id = 1
        Me.tbtnNew.ImageIndex = 8
        Me.tbtnNew.Name = "tbtnNew"
        '
        'tbtnSave
        '
        Me.tbtnSave.Id = 2
        Me.tbtnSave.ImageIndex = 11
        Me.tbtnSave.Name = "tbtnSave"
        '
        'tbtnPrint
        '
        Me.tbtnPrint.Id = 3
        Me.tbtnPrint.ImageIndex = 10
        Me.tbtnPrint.Name = "tbtnPrint"
        '
        'tbtnPrintPreview
        '
        Me.tbtnPrintPreview.Id = 4
        Me.tbtnPrintPreview.ImageIndex = 9
        Me.tbtnPrintPreview.Name = "tbtnPrintPreview"
        '
        'tbtnDel
        '
        Me.tbtnDel.Id = 5
        Me.tbtnDel.ImageIndex = 7
        Me.tbtnDel.Name = "tbtnDel"
        '
        'tbtnLoad
        '
        Me.tbtnLoad.Id = 6
        Me.tbtnLoad.ImageIndex = 15
        Me.tbtnLoad.Name = "tbtnLoad"
        '
        'tbtnQuery
        '
        Me.tbtnQuery.Id = 9
        Me.tbtnQuery.ImageIndex = 14
        Me.tbtnQuery.Name = "tbtnQuery"
        '
        'tBtn_approve
        '
        Me.tBtn_approve.Caption = "Approve"
        Me.tBtn_approve.Id = 12
        Me.tBtn_approve.ImageIndex = 12
        Me.tBtn_approve.Name = "tBtn_approve"
        Me.tBtn_approve.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.tBtn_approve.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'tBtn_Disapprove
        '
        Me.tBtn_Disapprove.Caption = "Disapprove"
        Me.tBtn_Disapprove.Id = 13
        Me.tBtn_Disapprove.ImageIndex = 13
        Me.tBtn_Disapprove.Name = "tBtn_Disapprove"
        Me.tBtn_Disapprove.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.tBtn_Disapprove.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(800, 26)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 548)
        Me.BarDockControl2.Size = New System.Drawing.Size(800, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 522)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(800, 26)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 522)
        '
        'tbtnRefresh
        '
        Me.tbtnRefresh.Id = 8
        Me.tbtnRefresh.ImageIndex = 12
        Me.tbtnRefresh.Name = "tbtnRefresh"
        '
        'XafBarLinkContainerItem1
        '
        Me.XafBarLinkContainerItem1.Id = 11
        Me.XafBarLinkContainerItem1.Name = "XafBarLinkContainerItem1"
        Me.XafBarLinkContainerItem1.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.XafBarLinkContainerItem1.TargetPageGroupCaption = Nothing
        '
        'uiBase2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.MinimumSize = New System.Drawing.Size(755, 550)
        Me.Name = "uiBase2"
        Me.Size = New System.Drawing.Size(800, 548)
        CType(Me.XafBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents XafBarManager1 As DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager
    Friend WithEvents Toolstrip1 As DevExpress.ExpressApp.Win.Templates.Controls.XafBar
    Friend WithEvents tbtnNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnPrintPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnDel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnLoad As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbtnQuery As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents tbtnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents XafBarLinkContainerItem1 As DevExpress.ExpressApp.Win.Templates.ActionContainers.XafBarLinkContainerItem
    Friend WithEvents tBtn_approve As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tBtn_Disapprove As DevExpress.XtraBars.BarButtonItem

End Class
