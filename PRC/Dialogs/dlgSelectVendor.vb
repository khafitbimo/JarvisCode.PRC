Public Class dlgSelectVendor
    Private DSN As String
    Public tbl_SelectVendor As DataTable = New DataTable
    Private CloseButtonIsPressed As Boolean
    Private rekanan_id As String
    Private criteria As String
    Private channel As String

    Private Function FormatDgvMstRekanan(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstRekanan Columns 
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_badanhukum As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_namereport As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanantype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Addr1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Addr2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_city As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_telp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_fax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_email As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_NPWP As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Create_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRekanan_Bill As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxprefix As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_pkpname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_salesperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_trf As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 50
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Vendor Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cRekanan_badanhukum.Name = "rekanan_badanhukum"
        cRekanan_badanhukum.HeaderText = "rekanan_badanhukum"
        cRekanan_badanhukum.DataPropertyName = "rekanan_badanhukum"
        cRekanan_badanhukum.Width = 100
        cRekanan_badanhukum.Visible = False
        cRekanan_badanhukum.ReadOnly = False

        cRekanan_namereport.Name = "rekanan_namereport"
        cRekanan_namereport.HeaderText = "rekanan_namereport"
        cRekanan_namereport.DataPropertyName = "rekanan_namereport"
        cRekanan_namereport.Width = 100
        cRekanan_namereport.Visible = False
        cRekanan_namereport.ReadOnly = False

        cRekanantype_id.Name = "rekanantype_id"
        cRekanantype_id.HeaderText = "rekanantype_id"
        cRekanantype_id.DataPropertyName = "rekanantype_id"
        cRekanantype_id.Width = 100
        cRekanantype_id.Visible = False
        cRekanantype_id.ReadOnly = False

        cRekanan_Addr1.Name = "rekanan_Addr1"
        cRekanan_Addr1.HeaderText = "rekanan_Addr1"
        cRekanan_Addr1.DataPropertyName = "rekanan_Addr1"
        cRekanan_Addr1.Width = 100
        cRekanan_Addr1.Visible = False
        cRekanan_Addr1.ReadOnly = False

        cRekanan_Addr2.Name = "rekanan_Addr2"
        cRekanan_Addr2.HeaderText = "rekanan_Addr2"
        cRekanan_Addr2.DataPropertyName = "rekanan_Addr2"
        cRekanan_Addr2.Width = 100
        cRekanan_Addr2.Visible = False
        cRekanan_Addr2.ReadOnly = False

        cRekanan_city.Name = "rekanan_city"
        cRekanan_city.HeaderText = "rekanan_city"
        cRekanan_city.DataPropertyName = "rekanan_city"
        cRekanan_city.Width = 100
        cRekanan_city.Visible = False
        cRekanan_city.ReadOnly = False

        cRekanan_telp.Name = "rekanan_telp"
        cRekanan_telp.HeaderText = "rekanan_telp"
        cRekanan_telp.DataPropertyName = "rekanan_telp"
        cRekanan_telp.Width = 100
        cRekanan_telp.Visible = False
        cRekanan_telp.ReadOnly = False

        cRekanan_fax.Name = "rekanan_fax"
        cRekanan_fax.HeaderText = "rekanan_fax"
        cRekanan_fax.DataPropertyName = "rekanan_fax"
        cRekanan_fax.Width = 100
        cRekanan_fax.Visible = False
        cRekanan_fax.ReadOnly = False

        cRekanan_email.Name = "rekanan_email"
        cRekanan_email.HeaderText = "rekanan_email"
        cRekanan_email.DataPropertyName = "rekanan_email"
        cRekanan_email.Width = 100
        cRekanan_email.Visible = False
        cRekanan_email.ReadOnly = False

        cRekanan_NPWP.Name = "rekanan_NPWP"
        cRekanan_NPWP.HeaderText = "rekanan_NPWP"
        cRekanan_NPWP.DataPropertyName = "rekanan_NPWP"
        cRekanan_NPWP.Width = 100
        cRekanan_NPWP.Visible = False
        cRekanan_NPWP.ReadOnly = False

        cRekanan_Create_by.Name = "rekanan_Create_by"
        cRekanan_Create_by.HeaderText = "rekanan_Create_by"
        cRekanan_Create_by.DataPropertyName = "rekanan_Create_by"
        cRekanan_Create_by.Width = 100
        cRekanan_Create_by.Visible = False
        cRekanan_Create_by.ReadOnly = False

        cRekanan_Create_dt.Name = "rekanan_Create_dt"
        cRekanan_Create_dt.HeaderText = "rekanan_Create_dt"
        cRekanan_Create_dt.DataPropertyName = "rekanan_Create_dt"
        cRekanan_Create_dt.Width = 100
        cRekanan_Create_dt.Visible = False
        cRekanan_Create_dt.ReadOnly = False

        cRekanan_active.Name = "rekanan_active"
        cRekanan_active.HeaderText = "rekanan_active"
        cRekanan_active.DataPropertyName = "rekanan_active"
        cRekanan_active.Width = 100
        cRekanan_active.Visible = False
        cRekanan_active.ReadOnly = False

        cRekanan_Bill.Name = "rekanan_Bill"
        cRekanan_Bill.HeaderText = "rekanan_Bill"
        cRekanan_Bill.DataPropertyName = "rekanan_Bill"
        cRekanan_Bill.Width = 100
        cRekanan_Bill.Visible = False
        cRekanan_Bill.ReadOnly = False

        cRekanan_taxprefix.Name = "rekanan_taxprefix"
        cRekanan_taxprefix.HeaderText = "rekanan_taxprefix"
        cRekanan_taxprefix.DataPropertyName = "rekanan_taxprefix"
        cRekanan_taxprefix.Width = 100
        cRekanan_taxprefix.Visible = False
        cRekanan_taxprefix.ReadOnly = False

        cRekanan_pkpname.Name = "rekanan_pkpname"
        cRekanan_pkpname.HeaderText = "rekanan_pkpname"
        cRekanan_pkpname.DataPropertyName = "rekanan_pkpname"
        cRekanan_pkpname.Width = 100
        cRekanan_pkpname.Visible = False
        cRekanan_pkpname.ReadOnly = False

        cRekanan_salesperson.Name = "rekanan_salesperson"
        cRekanan_salesperson.HeaderText = "rekanan_salesperson"
        cRekanan_salesperson.DataPropertyName = "rekanan_salesperson"
        cRekanan_salesperson.Width = 100
        cRekanan_salesperson.Visible = False
        cRekanan_salesperson.ReadOnly = False

        cRekanan_trf.Name = "rekanan_trf"
        cRekanan_trf.HeaderText = "rekanan_trf"
        cRekanan_trf.DataPropertyName = "rekanan_trf"
        cRekanan_trf.Width = 100
        cRekanan_trf.Visible = False
        cRekanan_trf.ReadOnly = False

        cRekanan_invsign.Name = "rekanan_invsign"
        cRekanan_invsign.HeaderText = "rekanan_invsign"
        cRekanan_invsign.DataPropertyName = "rekanan_invsign"
        cRekanan_invsign.Width = 100
        cRekanan_invsign.Visible = False
        cRekanan_invsign.ReadOnly = False

        cRekanan_invsignpos.Name = "rekanan_invsignpos"
        cRekanan_invsignpos.HeaderText = "rekanan_invsignpos"
        cRekanan_invsignpos.DataPropertyName = "rekanan_invsignpos"
        cRekanan_invsignpos.Width = 100
        cRekanan_invsignpos.Visible = False
        cRekanan_invsignpos.ReadOnly = False

        cRekanan_taxsign.Name = "rekanan_taxsign"
        cRekanan_taxsign.HeaderText = "rekanan_taxsign"
        cRekanan_taxsign.DataPropertyName = "rekanan_taxsign"
        cRekanan_taxsign.Width = 100
        cRekanan_taxsign.Visible = False
        cRekanan_taxsign.ReadOnly = False

        cRekanan_taxsignpos.Name = "rekanan_taxsignpos"
        cRekanan_taxsignpos.HeaderText = "rekanan_taxsignpos"
        cRekanan_taxsignpos.DataPropertyName = "rekanan_taxsignpos"
        cRekanan_taxsignpos.Width = 100
        cRekanan_taxsignpos.Visible = False
        cRekanan_taxsignpos.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekanan_name, cRekanan_badanhukum, cRekanan_namereport, cRekanantype_id, cRekanan_Addr1, cRekanan_Addr2, cRekanan_city, cRekanan_telp, cRekanan_fax, cRekanan_email, cRekanan_NPWP, cRekanan_Create_by, cRekanan_Create_dt, cRekanan_active, cRekanan_Bill, cRekanan_taxprefix, cRekanan_pkpname, cRekanan_salesperson, cRekanan_trf, cRekanan_invsign, cRekanan_invsignpos, cRekanan_taxsign, cRekanan_taxsignpos})



        ' DgvMstRekanan Behaviours: 
        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Public Sub New(ByVal sDSN As String, ByVal channel As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.DSN = sDSN
        Me.channel = channel
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub dlgSelectVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.dgvSelectVendor.Dock = DockStyle.Fill
    End Sub

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim criteria = ""
        'Dim i As Integer
        'Dim key(0) As DataColumn

        Me.tbl_SelectVendor.Clear()
       

        'oDataFiller.DataFill(Me.tbl_SelectVendor, "pr_MstRekanan_Select", criteria)
        oDataFiller.DataFill(Me.tbl_SelectVendor, "pr_MstRekanan_Select2", criteria, Me.channel)

        'Me.tbl_SelectVendor.Columns.Remove("rekanan_namereport")
        '====
        'Me.tbl_SelectVendor.Columns.Remove("rekanan_address")
        'Me.tbl_SelectVendor.Columns.Remove("rekanan_address2")
        '=====
        'Me.tbl_SelectVendor.Columns.Remove("rekanan_fax")
        'Me.tbl_SelectVendor.Columns.Remove("rekanan_telp")
        Me.tbl_SelectVendor.DefaultView.Sort = "rekanan_id"
        Me.InitLayoutUI()

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.rekanan_id
        Else
            Return Nothing
        End If

    End Function

#End Region

    Private Function InitLayoutUI() As Boolean
        Try
            Me.FormatDgvMstRekanan(Me.dgvSelectVendor)
            Me.dgvSelectVendor.DataSource = Me.tbl_SelectVendor
            Me.dgvSelectVendor.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        Dim obj As Button = sender

        Dim i As Integer
        Dim row As DataGridViewRow

        If obj.Name = "Button1" Then
            For i = 0 To Me.dgvSelectVendor.SelectedRows.Count - 1

                row = Me.dgvSelectVendor.SelectedRows(i)
                Me.rekanan_id = row.Cells("rekanan_id").Value

            Next
            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim criteria As String

        'If Me.rbName.Checked Then
        criteria = String.Format("rekanan_name like '%{0}%'", Me.TextBox1.Text.ToString)
        Me.tbl_SelectVendor.DefaultView.RowFilter = criteria
    End Sub
End Class