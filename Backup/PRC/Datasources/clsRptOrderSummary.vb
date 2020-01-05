Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptOrderSummary
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_Name As String
        Private mChannel_Addr As String
        Private mChannel_Telp As String
        Private mChannel_Ext As String
        Private mChannel_Fax As String
        Private mChannel_Form_No1 As String
        Private mChannel_Form_No2 As String
        Private mDomain_name As String

        Private mOrder_id As String
        Private mOrder_date As Date
        Private mRekanan_id As String
        Private mRekanan_name As String
        Private mOrder_programtype As String
        Private mOrder_prognm As String
        Private mOrder_progsch As String
        Private mBudget_id As String
        Private mBudget_name As String
        Private mOrder_utilizeddatestart As Date
        Private mOrder_utilizedlocation As String
        Private mOrder_discount As Decimal
        Private mOrder_pph_percent As Decimal
        Private mOrder_ppn_percent As Decimal
        Private mOrder_insurancecost As Decimal
        Private mOrder_transportationcost As Decimal
        Private mOrder_operatorcost As Decimal
        Private mOrder_othercost As Decimal
        Private mOrder_canceled As Boolean
        Private mOrder_source As String
        Private mOrdertype_id As String
        Private mPeriode_id As String
        Private mPeriode_name As String

        Private mRO_PPH As Double
        Private mRO_PPN As Double
        Private mPO_PPH As Double
        Private mPO_PPN As Double

        Private mOrderdetil_line As Integer
        Private mItem_id As String
        Private mItem_name As String
        Private mStrukturUnit_name As String
        Private mCategory_id As String
        Private mCategory_name As String
        Private mOrderdetil_descr As String

        Private mOrderdetil_days As Decimal
        Private mOrderdetil_qty As Decimal
        Private mOrderdetil_idr As Decimal
        Private mOrderdetil_foreign As Decimal
        Private mOrderdetil_discount As Decimal

        Private mCurrency_id As String
        Private mCurrency_name As String
        Private mUnit_id As Int16
        Private mUnit_name As String

        Private mOrderdetil_pphpercent As Decimal
        Private mOrderdetil_ppnpercent As Decimal

        Private mROdetil_rowtotalforeign As Decimal
        Private mROdetil_rowtotalforeign_incldisc As Decimal
        Private mROdetil_rowtotalforeign_incltax As Decimal

        Private mROdetil_rowtotalidr As Decimal
        Private mROdetil_rowtotalidr_incldisc As Decimal
        Private mROdetil_rowtotal_incltax As Decimal

        Private mPOdetil_pph As Decimal
        Private mPOdetil_ppn As Decimal

        Private mPOdetil_rowtotalforeign As Decimal
        Private mPOdetil_rowtotalforeign_incldisc As Decimal
        Private mPOdetil_rowtotalforeign_incltax As Decimal

        Private mPOdetil_rowtotalidr As Decimal
        Private mPOdetil_rowtotalidr_incldisc As Decimal
        Private mPOdetil_rowtotalidr_incltax As Decimal

        Private mOrder_total As Decimal
        Private mOrder_totalperorder As Decimal

        Private mOrderdetil_foreignrate As Decimal
        Private mRequest_idref As String
        Private mRequest_approved As String

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                setAtributChannel()
            End Set
        End Property

        Public Property channelname() As String
            Get
                Return mChannel_Name
            End Get
            Set(ByVal value As String)
                mChannel_Name = value
            End Set
        End Property

        Public Property channeladdr() As String
            Get
                Return mChannel_Addr
            End Get
            Set(ByVal value As String)
                mChannel_Addr = value
            End Set
        End Property

        Public Property channeltelp() As String
            Get
                Return mChannel_Telp
            End Get
            Set(ByVal value As String)
                mChannel_Telp = value
            End Set
        End Property

        Public Property channelext() As String
            Get
                Return mChannel_Ext
            End Get
            Set(ByVal value As String)
                mChannel_Ext = value
            End Set
        End Property

        Public Property channelfax() As String
            Get
                Return mChannel_Fax
            End Get
            Set(ByVal value As String)
                mChannel_Fax = value
            End Set
        End Property

        Public Property channelform_no1() As String
            Get
                Return mChannel_Form_No1
            End Get
            Set(ByVal value As String)
                mChannel_Form_No1 = value
            End Set
        End Property

        Public Property channelform_no2() As String
            Get
                Return mChannel_Form_No2
            End Get
            Set(ByVal value As String)
                mChannel_Form_No2 = value
            End Set
        End Property

        'Private Sub setAtributChannel()

        'If mChannel_id <> "" Then

        'Dim tblChannel As DataTable
        'Dim parCriteria As OleDbParameter

        ' Try
        'parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        'parCriteria.Value = String.Format(" channel_id = {0} ", mChannel_id)
        ' parCriteria.Value = " channel_id = '" & mChannel_id & "'"
        'tblChannel = clsUtil.GetDataTable("pr_MstChannel_Select", Me.DSN, parCriteria)

        '  If tblChannel.Rows.Count > 0 Then
        ' Me.mChannel_Name = tblChannel.Rows(0)("channel_namereport").ToString.Trim
        '' Me.mChannel_Addr = tblChannel.Rows(0)("channel_address").ToString.Trim
        'Me.mChannel_Telp = tblChannel.Rows(0)("channel_telp1").ToString.Trim
        ' Me.mChannel_Ext = tblChannel.Rows(0)("channel_telp2").ToString.Trim
        ' Me.mChannel_Fax = tblChannel.Rows(0)("channel_fax").ToString.Trim

        ''If Me.mChannel_id = "TV7" Then
        ' Me.mChannel_Form_No1 = "TransTV / DPRO / F-007 / Rev "
        ' Me.mChannel_Form_No1 = "TransTV / DPRO / F-007"
        ' Else
        ' Me.mChannel_Form_No1 = ""
        ' Me.mChannel_Form_No2 = ""
        'End If
        'End If

        ' Catch ex As Exception
        ' MsgBox("error on retrieving channel information")
        'Finally
        ' parCriteria = Nothing
        'tblChannel = Nothing
        ' End Try

        'End If
        'End Sub

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property

        Public Property order_date() As Date
            Get
                Return mOrder_date
            End Get
            Set(ByVal value As Date)
                mOrder_date = value
            End Set
        End Property

        Public Property orderdetil_line() As Integer
            Get
                Return mOrderdetil_line
            End Get
            Set(ByVal value As Integer)
                mOrderdetil_line = value
            End Set
        End Property

        Public Property item_id() As String
            Get
                Return mItem_id
            End Get
            Set(ByVal value As String)
                mItem_id = value
            End Set
        End Property

        Public Property item_name() As String
            Get
                Return mItem_name
            End Get
            Set(ByVal value As String)
                mItem_name = value
            End Set
        End Property
        Public Property strukturunit_name() As String
            Get
                Return mStrukturUnit_name
            End Get
            Set(ByVal value As String)
                mStrukturUnit_name = value
            End Set
        End Property

        Public Property orderdetil_descr() As String
            Get
                Return mOrderdetil_descr
            End Get
            Set(ByVal value As String)
                mOrderdetil_descr = value
            End Set
        End Property

        Public Property category_id() As String
            Get
                Return mCategory_id
            End Get
            Set(ByVal value As String)
                mCategory_id = value
            End Set
        End Property

        Public Property category_name() As String
            Get
                Return mCategory_name
            End Get
            Set(ByVal value As String)
                mCategory_name = value
            End Set
        End Property

        Public Property rekanan_id() As String
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As String)
                mRekanan_id = value
            End Set
        End Property

        Public Property rekanan_name() As String
            Get
                Return mRekanan_name
            End Get
            Set(ByVal value As String)
                mRekanan_name = value
            End Set
        End Property

        Public Property order_programtype() As String
            Get
                Return mOrder_programtype
            End Get
            Set(ByVal value As String)
                mOrder_programtype = value
            End Set
        End Property

        Public Property order_prognm() As String
            Get
                Return mOrder_prognm
            End Get
            Set(ByVal value As String)
                mOrder_prognm = value
            End Set
        End Property

        Public Property order_progsch() As String
            Get
                Return mOrder_progsch
            End Get
            Set(ByVal value As String)
                mOrder_progsch = value
            End Set
        End Property

        Public Property budget_id() As Integer
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Integer)
                mBudget_id = value
            End Set
        End Property

        Public Property budget_name() As String
            Get
                Return mBudget_name
            End Get
            Set(ByVal value As String)
                mBudget_name = value
            End Set
        End Property

        Public Property order_utilizeddatestart() As Date
            Get
                Return mOrder_utilizeddatestart
            End Get
            Set(ByVal value As Date)
                mOrder_utilizeddatestart = value
            End Set
        End Property

        Public Property order_utilizedlocation() As String
            Get
                Return mOrder_utilizedlocation
            End Get
            Set(ByVal value As String)
                mOrder_utilizedlocation = value
            End Set
        End Property

        Public Property order_pph_percent() As Decimal
            Get
                Return mOrder_pph_percent
            End Get
            Set(ByVal value As Decimal)
                mOrder_pph_percent = value
            End Set
        End Property

        Public Property order_ppn_percent() As Decimal
            Get
                Return mOrder_ppn_percent
            End Get
            Set(ByVal value As Decimal)
                mOrder_ppn_percent = value
            End Set
        End Property

        Public Property order_insurancecost() As Decimal
            Get
                Return mOrder_insurancecost
            End Get
            Set(ByVal value As Decimal)
                mOrder_insurancecost = value
            End Set
        End Property

        Public Property order_transportationcost() As Decimal
            Get
                Return mOrder_transportationcost
            End Get
            Set(ByVal value As Decimal)
                mOrder_transportationcost = value
            End Set
        End Property

        Public Property order_operatorcost() As Decimal
            Get
                Return mOrder_operatorcost
            End Get
            Set(ByVal value As Decimal)
                mOrder_operatorcost = value
            End Set
        End Property

        Public Property order_othercost() As Decimal
            Get
                Return mOrder_othercost
            End Get
            Set(ByVal value As Decimal)
                mOrder_othercost = value
            End Set
        End Property

        Public Property order_canceled() As Boolean
            Get
                Return mOrder_canceled
            End Get
            Set(ByVal value As Boolean)
                mOrder_canceled = value
            End Set
        End Property

        Public Property order_discount() As Decimal
            Get
                Return mOrder_discount
            End Get
            Set(ByVal value As Decimal)
                mOrder_discount = value
            End Set
        End Property

        Public Property order_source() As String
            Get
                Return mOrder_source
            End Get
            Set(ByVal value As String)
                mOrder_source = value
            End Set
        End Property

        Public Property periode_id() As String
            Get
                Return mPeriode_id
            End Get
            Set(ByVal value As String)
                mPeriode_id = value
                SetPeriode_Name()
            End Set
        End Property

        Public Property periode_name() As String
            Get
                Return mPeriode_name
            End Get
            Set(ByVal value As String)
                mPeriode_name = value
            End Set
        End Property

        Private Sub SetPeriode_Name()
            If mPeriode_id <> "" Then
                Dim tblPeriode As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" periode_id = '{0}' ", mPeriode_id)
                    tblPeriode = clsUtil.GetDataTable("pr_MstPeriode_Select", Me.DSN, parCriteria)
                    If tblPeriode.Rows.Count > 0 Then
                        mPeriode_name = tblPeriode.Rows(0)("periode_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error retrieve periode name")
                Finally
                    parCriteria = Nothing
                    tblPeriode = Nothing
                End Try
            End If
        End Sub

        'Public ReadOnly Property periode_name() As String
        '    Get
        '        Dim tblPeriode As DataTable
        '        Dim parCriteria As OleDbParameter
        '        periode_name = String.Empty
        '        Try
        '            parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        '            parCriteria.Value = String.Format(" periode_id = '{0}' ", mPeriode_id)
        '            tblPeriode = clsUtil.GetDataTable("pr_MstPeriode_Select", Me.DSN, parCriteria)
        '            If tblPeriode.Rows.Count > 0 Then
        '                periode_name = tblPeriode.Rows(0)("periode_name").ToString
        '            End If

        '        Catch ex As Exception
        '            MsgBox("error retrieve periode name")
        '        Finally
        '            parCriteria = Nothing
        '            tblPeriode = Nothing
        '        End Try

        '        Return periode_name

        '    End Get
        'End Property


        Public Property ro_PPH()
            Get
                Return mRO_PPH
            End Get
            Set(ByVal value)
                mRO_PPH = value
            End Set
        End Property

        Public Property ro_PPN()
            Get
                Return mRO_PPN
            End Get
            Set(ByVal value)
                mRO_PPN = value
            End Set
        End Property

        Public Property po_PPH()
            Get
                Return mPO_PPH
            End Get
            Set(ByVal value)
                mPO_PPH = value
            End Set
        End Property

        Public Property po_PPN()
            Get
                Return mPO_PPN
            End Get
            Set(ByVal value)
                mPO_PPN = value
            End Set
        End Property

        Public Property orderdetil_days() As Decimal
            Get
                Return mOrderdetil_days
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_days = value
            End Set
        End Property

        Public Property orderdetil_qty() As Decimal
            Get
                Return mOrderdetil_qty
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_qty = value
            End Set
        End Property

        Public Property orderdetil_idr() As Decimal
            Get
                Return mOrderdetil_idr
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_idr = value
            End Set
        End Property

        Public Property orderdetil_foreign() As Decimal
            Get
                Return mOrderdetil_foreign
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_foreign = value
            End Set
        End Property

        Public Property orderdetil_discount() As Decimal
            Get
                Return mOrderdetil_discount
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_discount = value
            End Set
        End Property

        Public Property currency_id() As String
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As String)
                mCurrency_id = value
            End Set
        End Property

        Public Property currency_name() As String
            Get
                Return mCurrency_name
            End Get
            Set(ByVal value As String)
                mCurrency_name = value
            End Set
        End Property

        Public Property rodetil_rowtotalforeign() As Decimal
            Get
                Return mROdetil_rowtotalforeign
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotalforeign = value
            End Set
        End Property

        Public Property rodetil_rowtotalforeign_incldisc() As Decimal
            Get
                Return mROdetil_rowtotalforeign_incldisc
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotalforeign_incldisc = value
            End Set
        End Property

        Public Property rodetil_rowtotalforeign_incltax() As Decimal
            Get
                Return mROdetil_rowtotalforeign_incltax
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotalforeign_incltax = value
            End Set
        End Property

        Public Property rodetil_rowtotalidr() As Decimal
            Get
                Return mROdetil_rowtotalidr
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotalidr = value
            End Set
        End Property

        Public Property rodetil_rowtotalidr_incldisc() As Decimal
            Get
                Return mROdetil_rowtotalidr_incldisc
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotalidr_incldisc = value
            End Set
        End Property

        '==
        Public Property podetil_pph() As Decimal
            Get
                Return mPOdetil_pph
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_pph = value
            End Set
        End Property

        Public Property podetil_ppn() As Decimal
            Get
                Return mPOdetil_ppn
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_ppn = value
            End Set
        End Property

        Public Property podetil_rowtotalforeign() As Decimal
            Get
                Return mPOdetil_rowtotalforeign
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotalforeign = value
            End Set
        End Property

        Public Property podetil_rowtotalforeign_incldisc() As Decimal
            Get
                Return mPOdetil_rowtotalforeign_incldisc
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotalforeign_incldisc = value
            End Set
        End Property

        Public Property podetil_rowtotalforeign_incltax() As Decimal
            Get
                Return mPOdetil_rowtotalforeign_incltax
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotalforeign_incltax = value
            End Set
        End Property

        Public Property podetil_rowtotalidr() As Decimal
            Get
                Return mPOdetil_rowtotalidr
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotalidr = value
            End Set
        End Property

        Public Property podetil_rowtotalidr_incldisc() As Decimal
            Get
                Return mPOdetil_rowtotalidr_incldisc
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotalidr_incldisc = value
            End Set
        End Property

        Public Property order_Total() As Double
            Get
                Return mOrder_total
            End Get
            Set(ByVal value As Double)
                mOrder_total = value
            End Set
        End Property

        Public Property order_TotalperOrder() As Double
            Get
                Return mOrder_totalperorder
            End Get
            Set(ByVal value As Double)
                mOrder_totalperorder = value
            End Set
        End Property

        Public Property unit_id() As Int64
            Get
                Return mUnit_id
            End Get
            Set(ByVal value As Int64)
                mUnit_id = value
            End Set
        End Property

        Public Property unit_name() As String
            Get
                Return mUnit_name
            End Get
            Set(ByVal value As String)
                mUnit_name = value
            End Set
        End Property

        Public Property orderdetil_pphpercent() As Decimal
            Get
                Return mOrderdetil_pphpercent
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_pphpercent = value
            End Set
        End Property

        Public Property orderdetil_ppnpercent() As Decimal
            Get
                Return mOrderdetil_ppnpercent
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_ppnpercent = value
            End Set
        End Property
        Public Property orderdetil_foreignrate() As Decimal
            Get
                Return mOrderdetil_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_foreignrate = value
            End Set
        End Property
        Public Property request_idref() As String
            Get
                Return mRequest_idref
            End Get
            Set(ByVal value As String)
                mRequest_idref = value
            End Set
        End Property
        Public Property request_approved() As String
            Get
                Return mRequest_approved
            End Get
            Set(ByVal value As String)
                mRequest_approved = value
            End Set
        End Property
        Private Sub setAtributChannel()


            If mChannel_id <> "" Then
                Dim tblAgging As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblAgging = clsUtil.GetDataTable("pr_MstChannel_Select", Me.DSN, parCriteria)
                    If tblAgging.Rows.Count > 0 Then
                        Me.channelname = Trim(tblAgging.Rows(0)("channel_namereport").ToString)
                        Me.channeladdr = Trim(tblAgging.Rows(0)("channel_address").ToString)
                        Me.channelext = Trim(tblAgging.Rows(0)("channel_telp1").ToString)
                        Me.channelfax = Trim(tblAgging.Rows(0)("channel_fax").ToString)

                        Me.mDomain_name = Trim(tblAgging.Rows(0)("channel_domainname").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblAgging = Nothing
                End Try
            End If
        End Sub
        Public Property domain_name() As String
            Get
                Return mDomain_name
            End Get
            Set(ByVal value As String)
                mDomain_name = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class

End Namespace


