Public Class uiBase2

    Public Const _Name As String = "MainControl"
    Public Const _ProductName As String = "Gamba"
    Public IsDevelopment As Boolean = False

    Public Enum FormSaveResult
        Nochanges = 0
        SaveError = 1
        SaveSuccess = 2
    End Enum

    Private mDSN As String
    Private mDSNFrm As String

    Private mParameter As String
    Private mUserName As String
    Private mBrowser As Object = Nothing

    Private mDataFiller As clsDataFiller
    Private mMstUser As clsMstUser
    Private mConfig As Data.DataSet

    Sub New()
        InitializeComponent()
    End Sub

    Private Sub SetDefaultSkin()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue")
    End Sub

    Public Sub InitializeControl(ByVal UserName As String, ByVal Parameter As String, ByRef Browser As Object, ByVal Config As DataSet)
        Me.mDSN = DSNFrm
        Me.mUserName = UserName
        Me.mParameter = Parameter
        Me.mBrowser = Browser

        Me.mConfig = Config

        Call Me.ReadConfigDSN()

        Me.mDataFiller = New clsDataFiller(Me.DSNFrm)
        Me.mMstUser = New clsMstUser(Me.DSNFrm)

        clsUtil.SetLocalization()
        clsApplicationRole.SetConfig(Config)
    End Sub

    Private Sub ReadConfigDSN()
        Using dbConn As New clsDatabaseConfig("FRM", Me.mConfig)
            Me.DSNFrm = dbConn.DSN
        End Using
    End Sub

    Private Sub ReadConfigurasiDataset(ByVal path As String)
        path = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & path
        Me.mConfig = New Data.DataSet
        Me.mConfig.ReadXml(path)
    End Sub

#Region " Property "
    Public Property DSNFrm() As String
        Get
            Return Me.mDSNFrm
        End Get
        Set(ByVal value As String)
            Me.mDSNFrm = value
        End Set
    End Property

    Public ReadOnly Property Parameter() As String
        Get
            Return mParameter
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return mUserName
        End Get
    End Property

    Public ReadOnly Property Browser() As Object
        Get
            Return mBrowser
        End Get
    End Property

    Public ReadOnly Property User() As clsMstUser
        Get
            Return Me.mMstUser
        End Get
    End Property
#End Region

#Region " Overridable "

    Public Overridable Function btnNew_Click() As Boolean
    End Function

    Public Overridable Function btnSave_Click() As Boolean
    End Function

    Public Overridable Function btnPrint_Click() As Boolean
    End Function

    Public Overridable Function btnPrintPreview_Click() As Boolean
    End Function

    Public Overridable Function btnEdit_Click() As Boolean
    End Function

    Public Overridable Function btnDel_Click() As Boolean
    End Function

    Public Overridable Function btnLoad_Click() As Boolean
    End Function

    Public Overridable Function btnQuery_Click() As Boolean
    End Function

    Public Overridable Function btnRefresh_Click() As Boolean
    End Function

    Public Overridable Function btnReset_Click() As Boolean
    End Function

    Public Overridable Function btnFirst_Click() As Boolean
    End Function

    Public Overridable Function btnPrev_Click() As Boolean
    End Function

    Public Overridable Function btnNext_Click() As Boolean
    End Function

    Public Overridable Function btnLast_Click() As Boolean
    End Function

    Public Overridable Function btnHelpTopic_Click() As Boolean
    End Function

    Public Overridable Function btnShowStatus_Click() As Boolean
    End Function

    Public Overridable Function btnShowConsole_Click() As Boolean
    End Function

    Public Overridable Function btnReserved1_Click() As Boolean
    End Function

    Public Overridable Function btnReserved2_Click() As Boolean
    End Function

    Public Overridable Function btnReserved3_Click() As Boolean
    End Function

    Public Overridable Function btnReserved4_Click() As Boolean
    End Function

    Public Overridable Function btnReserved5_Click() As Boolean
    End Function

    Public Overridable Function btnReserved6_Click() As Boolean
    End Function

    Public Overridable Function btnApprove_Click() As Boolean
    End Function

    Public Overridable Function btnDisapprove_Click() As Boolean
    End Function

#End Region

#Region " ToolStripButton Event "
    Private Sub tbtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNew.ItemClick
        Me.btnNew_Click()
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.ItemClick
        Me.btnSave_Click()
    End Sub

    Private Sub tbtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrint.ItemClick
        Me.btnPrint_Click()
    End Sub

    Private Sub tbtnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.ItemClick
        Me.btnPrintPreview_Click()
    End Sub

    Private Sub tbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnEdit_Click()
    End Sub

    Private Sub tbtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDel.ItemClick
        Me.btnDel_Click()
    End Sub

    Private Sub tbtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLoad.ItemClick
        Me.btnLoad_Click()
    End Sub

    Private Sub tbtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnQuery.ItemClick
        Me.btnQuery_Click()
    End Sub

    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.ItemClick
        Me.btnRefresh_Click()
    End Sub

    Private Sub tbtn_Approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBtn_approve.ItemClick
        Me.btnApprove_Click()
    End Sub

    Private Sub tbtn_Disapprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBtn_Disapprove.ItemClick
        Me.btnDisapprove_Click()
    End Sub

#End Region

#Region " Syncronisasi "
    Private Sub tbtnNew_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._SyncronizeControlEnableState("New", tbtnNew.Enabled)
    End Sub

    Private Sub tbtnSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._SyncronizeControlEnableState("Save", tbtnSave.Enabled)
    End Sub

    Private Sub tbtnPrint_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._SyncronizeControlEnableState("Print", tbtnPrint.Enabled)
    End Sub

    Private Sub tbtnPrintPreview_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._SyncronizeControlEnableState("PrintPreview", tbtnPrintPreview.Enabled)
    End Sub

    Private Sub tbtnDel_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._SyncronizeControlEnableState("Delete", tbtnDel.Enabled)
    End Sub

    Public Sub SyncronizeControlEnableState()
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled("New", tbtnNew.Enabled)
                Me.Browser.MenuEnabled("Save", tbtnSave.Enabled)
                Me.Browser.MenuEnabled("Print", tbtnPrint.Enabled)
                Me.Browser.MenuEnabled("PrintPreview", tbtnPrintPreview.Enabled)
                Me.Browser.MenuEnabled("Delete", tbtnDel.Enabled)
            End If
        End If
    End Sub

    Public Sub _SyncronizeControlEnableState(ByVal Name As String, ByVal state As Boolean)
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled(Name, state)
            End If
        End If
    End Sub
#End Region

    Private Sub uiBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Browser Is Nothing And Application.ProductName <> _ProductName Then
            ReadConfigurasiDataset("config.xml")
            Me.InitializeControl("ari.chandra", "", Nothing, Me.mConfig)
            Me.IsDevelopment = True
            Me.SetDefaultSkin()
        End If
    End Sub

    Public Function GetParameterCollection(ByVal ParameterString As String) As Collection
        Dim i As Integer
        Dim arrParameter() As String
        Dim tempParameterLine() As String
        Dim ParameterKey As String
        Dim ParameterValue As String
        Dim objParameters As Collection = New Collection

        arrParameter = ParameterString.Split(";")
        If Trim(ParameterString) <> "" Then
            For i = 0 To arrParameter.Length - 1
                tempParameterLine = arrParameter(i).Split("=")
                If tempParameterLine.Length = 2 Then
                    ParameterKey = Trim(tempParameterLine(0))
                    ParameterValue = Trim(tempParameterLine(1))

                    If objParameters.Contains(ParameterKey) Then
                        objParameters.Remove(ParameterKey)
                    End If

                    objParameters.Add(ParameterValue, ParameterKey)
                End If
            Next
        End If

        Return objParameters
    End Function

    Public Function GetBolValueFromParameter(ByVal Col As Collection, ByVal key As String) As Boolean
        If Col.Contains(key) Then
            If Col(key) = "0" Or Col(key) = "1" Or Col(key) = "true" Or Col(key) = "false" Then
                If Col(key) = "0" Or Col(key) = "false" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIntValueFromParameter(ByVal Col As Collection, ByVal key As String) As Integer
        If Col.Contains(key) Then
            Return CType(Col(key), Integer)
        Else
            Return 0
        End If
    End Function

    Public Function GetValueFromParameter(ByVal Col As Collection, ByVal key As String) As String
        If Col.Contains(key) Then
            Return Col(key)
        Else
            Return ""
        End If
    End Function

    Public Overloads Function DataFill(ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFill(dt, procedure, criteria, channel_id)
    End Function

    Public Overloads Function DataFill(ByRef dbconn As OleDb.OleDbConnection, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFill(dbconn, dt, procedure, criteria, channel_id)
    End Function

    Public Function ComboFill(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.ComboFill(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function

    Public Function ComboFill(ByVal DSN As String, ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return New clsDataFiller(DSN).ComboFill(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function

    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean) As Boolean
        Return Me.mDataFiller.ComboLink(combobox, valuemember, displaymember, datatable, withOption)
    End Function

    Public Function ComboFillFromDataTable(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable) As Boolean
        combobox.DataSource = dt
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember
    End Function

    '=== Tambahan Buat LookupEdit (pengganti combobox di vb) : MDP2 ================================================================
    Public Function ComboFillDX(ByRef combobox As DevExpress.XtraEditors.LookUpEdit, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.ComboFillDX(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function

    Public Function ComboFillDX(ByVal DSN As String, ByRef combobox As DevExpress.XtraEditors.LookUpEdit, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return New clsDataFiller(DSN).ComboFillDX(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function
    '===============================================================================================================================

    Public Function GetModuleID() As Integer
        If Me.Parent IsNot Nothing Then
            If Me.Parent.GetType().ToString() = "frmProgram" Then
                Return CType(Me.Parent, Object).GetProgramID
            Else
                Return 811110000
            End If
        End If
    End Function


End Class

