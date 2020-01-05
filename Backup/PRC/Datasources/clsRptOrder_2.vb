
Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptOrder_2
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_Name As String
        Private mChannel_Addr As String
        Private mChannel_Telp As String
        Private mChannel_Ext As String
        Private mChannel_Fax As String
        Private mDomain_name As String
        Private mChannel_Form_No1 As String
        Private mChannel_Form_No2 As String

        Private mOrder_dlvrname As String
        Private mOrder_dlvraddr1 As String
        Private mOrder_dlvraddr2 As String
        Private mOrder_dlvraddr3 As String
        Private mOrder_dlvrtelp As String
        Private mOrder_dlvrfax As String
        Private mOrder_dlvrhp As String

        Private mOrder_id As String
        Private mOrder_date As Date
        Private mOrder_descr As String
        Private mOrder_note As String
        Private mRequest_id As String
        Private mCurrency_id As String
        Private mCurrency_name As String
        Private mCurrency_shortname As String

        Private mOrdertype_id As String
        Private mOld_program_id As Integer
        Private mOrder_programtype As String
        Private mOrder_prognm As String
        Private mOrder_progsch As String
        Private mBudget_id As Integer
        Private mOrder_eps As String
        Private mOrder_setdate As Date
        Private mOrder_settime As String
        Private mOrder_setlocation As String
        Private mOrder_utilizeddatestart As Date
        Private mOrder_utilizeddateend As Date
        Private mOrder_utilizedtimestart As String
        Private mOrder_utilizedtimeend As String
        Private mOrder_utilizedlocation As String
        Private mOrder_pph_percent As Decimal
        Private mOrder_ppn_percent As Decimal
        Private mOrder_insurancecost As Decimal
        Private mOrder_transportationcost As Decimal
        Private mOrder_operatorcost As Decimal
        Private mOrder_othercost As Decimal
        Private mOrder_authname As String
        Private mOrder_authposition As String
        Private mOrder_authname2 As String
        Private mOrder_authposition2 As String
        Private mOrder_canceled As Boolean
        Private mOrder_createby As String
        Private mOrder_createdate As Date
        Private mOrder_modifyby As String
        Private mOrder_modifydate As Date
        Private mOrder_revno As String
        Private mOrder_revdesc As String
        Private mOrder_revdate As Date
        Private mOrder_source As String
        Private mOld_category_id As String
        Private mOld_apref As String
        Private mOrder_spkrequired As Boolean
        Private mOrder_spkworktype As String
        Private mOrder_spkdesc As String
        Private mPeriode_id As String
        Private mPeriode_name As String

        Private mRekanan_id As Decimal
        Private mRekananPO_Name As String
        Private mRekananPO_Alamat1 As String
        Private mRekananPO_Alamat2 As String
        Private mRekananPO_Alamat3 As String
        Private mRekananPO_Up As String
        Private mRekananPO_Up_position As String

        Private mRekananRO_Name As String
        Private mRekananRO_Alamat As String
        Private mRekananRO_Telpon As String
        Private mRekananRO_Fax As String
        Private mDaftarRekananRO_Contact As String
        Private mFirstRekananRO_Contact As String
        Private mFirstRekananRO_ContactPhone As String

        Private mOrder_Discount As Decimal
        'Private mRO_PPH As Double
        'Private mRO_PPN As Double
        'Private mPO_PPH As Double
        'Private mPO_PPN As Double

        Private mOrder_Subtotal As Double
        Private mOrder_SubtotalInclDisc As Double
        Private mOrder_SubtotalIDR As Double
        Private mOrder_SubtotalPPH As Double
        Private mOrder_SubtotalPPN As Double

        Private mOrder_Total As Double
        Private mOrder_TotalIDR As Double
        Private mOrder_Terbilang As String

        Private mOrder_PPH As Double
        Private mOrder_PPN As Double

        Private mdelivery_date As String


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

        Public Property domain_name() As String
            Get
                Return mDomain_name
            End Get
            Set(ByVal value As String)
                mDomain_name = value
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

        Private Sub setAtributChannel()

            If mChannel_id <> "" Then

                Dim tblChannel As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    'parCriteria.Value = String.Format(" channel_id = {0} ", mChannel_id)
                    parCriteria.Value = " channel_id = '" & mChannel_id & "'"
                    tblChannel = clsUtil.GetDataTable("pr_MstChannel_Select", Me.DSN, parCriteria)

                    If tblChannel.Rows.Count > 0 Then
                        Me.mChannel_Name = tblChannel.Rows(0)("channel_namereport").ToString.Trim
                        Me.mChannel_Addr = clsUtil.IsDbNull(tblChannel.Rows(0)("channel_address").ToString.Trim, "-")
                        Me.mChannel_Telp = clsUtil.IsDbNull(tblChannel.Rows(0)("channel_telp1").ToString.Trim, "-")
                        Me.mChannel_Ext = clsUtil.IsDbNull(tblChannel.Rows(0)("channel_telp2").ToString.Trim, "-")
                        Me.mChannel_Fax = clsUtil.IsDbNull(tblChannel.Rows(0)("channel_fax").ToString.Trim, "-")
                        Me.mDomain_name = clsUtil.IsDbNull(tblChannel.Rows(0)("channel_domainname").ToString.Trim, "-")

                        If Me.mChannel_id = "TV7" Then
                            'Me.mDomain_name = "transtv.co.id"
                            Me.mChannel_Form_No1 = "TransTV / DPRO / F-007 / Rev "
                            Me.mChannel_Form_No1 = "TransTV / DPRO / F-007"
                        Else
                            'Me.mDomain_name = "trans7.co.id"
                            Me.mChannel_Form_No1 = ""
                            Me.mChannel_Form_No2 = ""
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel information")
                Finally
                    parCriteria = Nothing
                    tblChannel = Nothing
                End Try

            End If
        End Sub


        Public Property order_dlvrname() As String
            Get
                Return mOrder_dlvrname
            End Get
            Set(ByVal value As String)
                mOrder_dlvrname = value
            End Set
        End Property

        Public Property order_dlvraddr1() As String
            Get
                Return mOrder_dlvraddr1
            End Get
            Set(ByVal value As String)
                mOrder_dlvraddr1 = value
            End Set
        End Property

        Public Property order_dlvraddr2() As String
            Get
                Return mOrder_dlvraddr2
            End Get
            Set(ByVal value As String)
                mOrder_dlvraddr2 = value
            End Set
        End Property

        Public Property order_dlvraddr3() As String
            Get
                Return mOrder_dlvraddr3
            End Get
            Set(ByVal value As String)
                mOrder_dlvraddr3 = value
            End Set
        End Property

        Public Property order_dlvrtelp() As String
            Get
                Return mOrder_dlvrtelp
            End Get
            Set(ByVal value As String)
                mOrder_dlvrtelp = value
            End Set
        End Property

        Public Property order_dlvrfax() As String
            Get
                Return mOrder_dlvrfax
            End Get
            Set(ByVal value As String)
                mOrder_dlvrfax = value
            End Set
        End Property

        Public Property order_dlvrhp() As String
            Get
                Return mOrder_dlvrhp
            End Get
            Set(ByVal value As String)
                mOrder_dlvrhp = value
            End Set
        End Property

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

        Public Property delivery_date() As Date
            Get
                Return mdelivery_date
            End Get
            Set(ByVal value As Date)
                mdelivery_date = value
            End Set
        End Property

        Public Property request_id() As String
            Get
                Return mRequest_id
            End Get
            Set(ByVal value As String)
                mRequest_id = value
            End Set
        End Property

        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
                setAtributRekanan()
            End Set
        End Property

        Private Sub setAtributRekanan()
            'Dim rekanan_name As String
            If mRekanan_id > 0 Then
                Dim tblRekananPO, tblRekananRO As DataTable
                Dim parCriteria As OleDbParameter
                'rekanan_name = String.Empty
                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" rekanan_id = {0} ", mRekanan_id)
                    tblRekananPO = clsUtil.GetDataTable("pr_MstRekanan_po_Select", Me.DSN, parCriteria)
                    If tblRekananPO.Rows.Count > 0 Then
                        Me.mRekananPO_Name = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_name").ToString), "-")
                        Me.mRekananPO_Alamat1 = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_addr1").ToString), "-")
                        Me.mRekananPO_Alamat2 = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_addr2").ToString), "-")
                        Me.mRekananPO_Alamat3 = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_addr3").ToString), "-")
                        Me.mRekananPO_Up = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_up").ToString), "-")
                        Me.mRekananPO_Up_position = clsUtil.IsDbNull(Trim(tblRekananPO.Rows(0)("rekanan_up_position").ToString), "-")

                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving vendor name")
                Finally
                    parCriteria = Nothing
                    tblRekananPO = Nothing
                End Try


                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" rekanan_id = {0} ", mRekanan_id)
                    tblRekananRO = clsUtil.GetDataTable("pr_MstRekanan_Select", Me.DSN, parCriteria)
                    If tblRekananRO.Rows.Count > 0 Then
                        Me.mRekananRO_Name = Trim(tblRekananRO.Rows(0)("rekanan_name").ToString)
                        Me.mRekananRO_Alamat = Trim(tblRekananRO.Rows(0)("rekanan_address").ToString)
                        If Trim(tblRekananRO.Rows(0)("rekanan_address2").ToString) <> String.Empty Then
                            Me.mRekananRO_Alamat += ", " & Trim(tblRekananRO.Rows(0)("rekanan_address2").ToString)
                        End If
                        Me.mRekananRO_Fax = tblRekananRO.Rows(0)("rekanan_fax").ToString.Trim
                        Me.mRekananRO_Telpon = tblRekananRO.Rows(0)("rekanan_telp").ToString.Trim
                        setAtributRekananContact()
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving vendor name")
                Finally
                    parCriteria = Nothing
                    tblRekananRO = Nothing
                End Try

            End If
        End Sub

        Public Property rekananpo_name() As String
            Get
                Return mRekananPO_Name
            End Get
            Set(ByVal value As String)
                mRekananPO_Name = value
            End Set
        End Property

        Public Property rekananpo_alamat1() As String
            Get
                Return mRekananPO_Alamat1
            End Get
            Set(ByVal value As String)
                mRekananPO_Alamat1 = value
            End Set
        End Property

        Public Property rekananpo_alamat2() As String
            Get
                Return mRekananPO_Alamat2
            End Get
            Set(ByVal value As String)
                mRekananPO_Alamat2 = value
            End Set
        End Property

        Public Property rekananpo_alamat3() As String
            Get
                Return mRekananPO_Alamat3
            End Get
            Set(ByVal value As String)
                mRekananPO_Alamat3 = value
            End Set
        End Property

        Public Property rekananpo_up() As String
            Get
                Return mRekananPO_Up
            End Get
            Set(ByVal value As String)
                mRekananPO_Up = value
            End Set
        End Property

        Public Property rekananpo_up_position() As String
            Get
                Return mRekananPO_Up_position
            End Get
            Set(ByVal value As String)
                mRekananPO_Up_position = value
            End Set
        End Property

        Public Property rekananro_name() As String
            Get
                Return mRekananRO_Name
            End Get
            Set(ByVal value As String)
                mRekananRO_Name = value
            End Set
        End Property

        Public Property rekananro_alamat() As String
            Get
                Return mRekananRO_Alamat
            End Get
            Set(ByVal value As String)
                mRekananRO_Alamat = value
            End Set
        End Property

        Public Property rekananro_telpon() As String
            Get
                Return mRekananRO_Telpon
            End Get
            Set(ByVal value As String)
                mRekananRO_Telpon = value
            End Set
        End Property

        Public Property rekananro_fax() As String
            Get
                Return mRekananRO_Fax
            End Get
            Set(ByVal value As String)
                mRekananRO_Fax = value
            End Set
        End Property

        Private Sub setAtributRekananContact()
            Dim tblRekananContact As DataTable
            Dim parCriteria As OleDbParameter
            Dim i As Byte

            Try
                parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                parCriteria.Value = String.Format(" rekanan_id = {0} ", mRekanan_id)
                'tblRekananContact = clsUtil.GetDataTable("ms_MstRekanancontact_Select", Me.DSN, parCriteria)

                tblRekananContact = clsUtil.GetDataTable("pr_MstRekanan_contact_Select", Me.DSN, parCriteria)
                If tblRekananContact.Rows.Count > 0 Then
                    For i = 0 To tblRekananContact.Rows.Count - 1
                        mDaftarRekananRO_Contact += clsUtil.IsDbNull(tblRekananContact.Rows(i)("rekanancontact_name"), "-") & " / "
                    Next
                    mDaftarRekananRO_Contact = Mid(mDaftarRekananRO_Contact, 1, Len(mDaftarRekananRO_Contact) - 3)
                    mFirstRekananRO_Contact = clsUtil.IsDbNull(tblRekananContact.Rows(0)("rekanancontact_name"), "-")
                    mFirstRekananRO_ContactPhone = clsUtil.IsDbNull(tblRekananContact.Rows(0)("rekanancontact_telpon"), "-")
                Else
                    mDaftarRekananRO_Contact = "-"
                    mFirstRekananRO_Contact = "-"
                    mFirstRekananRO_ContactPhone = "-"

                End If

            Catch ex As Exception
                'MsgBox("error retrieve rekanan contact")
            Finally
                parCriteria = Nothing
                tblRekananContact = Nothing
            End Try


        End Sub

        Public Property firstrekananro_contact() As String
            Get
                Return mFirstRekananRO_Contact
            End Get
            Set(ByVal value As String)
                mFirstRekananRO_Contact = value
            End Set
        End Property

        Public Property firstrekananro_contactphone() As String
            Get
                Return mFirstRekananRO_ContactPhone
            End Get
            Set(ByVal value As String)
                mFirstRekananRO_ContactPhone = value
            End Set
        End Property

        Public Property DaftarRekananContact() As String
            Get
                Return String.Empty
            End Get
            Set(ByVal value As String)
                mDaftarRekananRO_Contact = value
            End Set
        End Property

        Public Property ordertype_id() As String
            Get
                Return mOrdertype_id
            End Get
            Set(ByVal value As String)
                mOrdertype_id = value
            End Set
        End Property

        Public Property old_program_id() As Integer
            Get
                Return mOld_program_id
            End Get
            Set(ByVal value As Integer)
                mOld_program_id = value
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

        Public ReadOnly Property budget_name() As String
            Get
                Dim tblBudget As DataTable
                Dim parCriteria As OleDbParameter
                budget_name = String.Empty
                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" budget_id = {0} ", mBudget_id)
                    tblBudget = clsUtil.GetDataTable("pr_TrnBudget_Select", Me.DSN, parCriteria)
                    If tblBudget.Rows.Count > 0 Then
                        budget_name = tblBudget.Rows(0)("budget_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error retrieve budget name")
                Finally
                    parCriteria = Nothing
                    tblBudget = Nothing
                End Try

                Return budget_name
            End Get
        End Property

        Public Property currency_id() As String
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As String)
                mCurrency_id = value
                setAtributCurrency()
            End Set
        End Property

        Private Sub setAtributCurrency()

            If mCurrency_id <> "" Then
                Dim tblCurrency As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" currency_id = {0} ", mCurrency_id)
                    tblCurrency = clsUtil.GetDataTable("pr_MstCurrency_Select", Me.DSN, parCriteria)
                    If tblCurrency.Rows.Count > 0 Then
                        currency_name = Trim(tblCurrency.Rows(0)("currency_name").ToString.ToUpper)
                        currency_shortname = Trim(tblCurrency.Rows(0)("currency_shortname").ToString.ToUpper)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving currency name")
                Finally
                    parCriteria = Nothing
                    tblCurrency = Nothing
                End Try

            End If
        End Sub

        Public Property currency_name() As String
            Get
                Return mCurrency_name
            End Get
            Set(ByVal value As String)
                mCurrency_name = value
            End Set
        End Property

        Public Property currency_shortname() As String
            Get
                Return mCurrency_shortname
            End Get
            Set(ByVal value As String)
                mCurrency_shortname = value
            End Set
        End Property


        Public Property order_eps() As String
            Get
                Return mOrder_eps
            End Get
            Set(ByVal value As String)
                mOrder_eps = value
            End Set
        End Property

        Public Property order_setdate() As Date
            Get
                Return mOrder_setdate
            End Get
            Set(ByVal value As Date)
                mOrder_setdate = value
            End Set
        End Property

        Public Property order_settime() As String
            Get
                Return mOrder_settime
            End Get
            Set(ByVal value As String)
                mOrder_settime = value
            End Set
        End Property

        Public Property order_setlocation() As String
            Get
                Return mOrder_setlocation
            End Get
            Set(ByVal value As String)
                mOrder_setlocation = value
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

        Public Property order_utilizeddateend() As Date
            Get
                Return mOrder_utilizeddateend
            End Get
            Set(ByVal value As Date)
                mOrder_utilizeddateend = value
            End Set
        End Property

        Public Property order_utilizedtimestart() As String
            Get
                Return mOrder_utilizedtimestart
            End Get
            Set(ByVal value As String)
                mOrder_utilizedtimestart = value
            End Set
        End Property

        Public Property order_utilizedtimeend() As String
            Get
                Return mOrder_utilizedtimeend
            End Get
            Set(ByVal value As String)
                mOrder_utilizedtimeend = value
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

        Public Property order_authname() As String
            Get
                Return mOrder_authname
            End Get
            Set(ByVal value As String)
                mOrder_authname = value
            End Set
        End Property

        Public Property order_authposition() As String
            Get
                Return mOrder_authposition
            End Get
            Set(ByVal value As String)
                mOrder_authposition = value
            End Set
        End Property

        Public Property order_authname2() As String
            Get
                Return mOrder_authname2
            End Get
            Set(ByVal value As String)
                mOrder_authname2 = value
            End Set
        End Property

        Public Property order_authposition2() As String
            Get
                Return mOrder_authposition2
            End Get
            Set(ByVal value As String)
                mOrder_authposition2 = value
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

        Public Property order_createby() As String
            Get
                Return mOrder_createby
            End Get
            Set(ByVal value As String)
                mOrder_createby = value
            End Set
        End Property

        Public Property order_createdate() As Date
            Get
                Return mOrder_createdate
            End Get
            Set(ByVal value As Date)
                mOrder_createdate = value
            End Set
        End Property

        Public Property order_modifyby() As String
            Get
                Return mOrder_modifyby
            End Get
            Set(ByVal value As String)
                mOrder_modifyby = value
            End Set
        End Property

        Public Property order_modifydate() As Date
            Get
                Return mOrder_modifydate
            End Get
            Set(ByVal value As Date)
                mOrder_modifydate = value
            End Set
        End Property

        Public Property order_revno() As String
            Get
                Return mOrder_revno
            End Get
            Set(ByVal value As String)
                mOrder_revno = value
            End Set
        End Property

        Public Property order_revdesc() As String
            Get
                Return mOrder_revdesc
            End Get
            Set(ByVal value As String)
                mOrder_revdesc = value
            End Set
        End Property

        Public Property order_revdate() As Date
            Get
                Return mOrder_revdate
            End Get
            Set(ByVal value As Date)
                mOrder_revdate = value
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

        Public Property old_category_id() As String
            Get
                Return mOld_category_id
            End Get
            Set(ByVal value As String)
                mOld_category_id = value
            End Set
        End Property

        Public Property old_apref() As String
            Get
                Return mOld_apref
            End Get
            Set(ByVal value As String)
                mOld_apref = value
            End Set
        End Property

        Public Property order_spkrequired() As Boolean
            Get
                Return mOrder_spkrequired
            End Get
            Set(ByVal value As Boolean)
                mOrder_spkrequired = value
            End Set
        End Property

        Public Property order_spkworktype() As String
            Get
                Return mOrder_spkworktype
            End Get
            Set(ByVal value As String)
                mOrder_spkworktype = value
            End Set
        End Property

        Public Property order_spkdesc() As String
            Get
                Return mOrder_spkdesc
            End Get
            Set(ByVal value As String)
                mOrder_spkdesc = value
            End Set
        End Property

        Public Property order_descr() As String
            Get
                Return mOrder_descr
            End Get
            Set(ByVal value As String)
                mOrder_descr = value
            End Set
        End Property

        Public Property order_note() As String
            Get
                Return mOrder_note
            End Get
            Set(ByVal value As String)
                mOrder_note = value
            End Set
        End Property

        Public Property periode_id() As String
            Get
                Return mPeriode_id
            End Get
            Set(ByVal value As String)
                mPeriode_id = value
            End Set
        End Property

        Public ReadOnly Property periode_name() As String
            Get
                Dim tblPeriode As DataTable
                Dim parCriteria As OleDbParameter
                periode_name = String.Empty
                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" periode_id = '{0}' ", mPeriode_id)
                    tblPeriode = clsUtil.GetDataTable("pr_MstPeriode_Select", Me.DSN, parCriteria)
                    If tblPeriode.Rows.Count > 0 Then
                        periode_name = tblPeriode.Rows(0)("periode_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error retrieve periode name")
                Finally
                    parCriteria = Nothing
                    tblPeriode = Nothing
                End Try

                Return periode_name

            End Get
        End Property

        Public Property order_Subtotal() As Double
            Get
                Return mOrder_Subtotal
            End Get
            Set(ByVal value As Double)
                mOrder_Subtotal = value
            End Set
        End Property

        Public Property order_SubtotalIDR() As Double
            Get
                Return mOrder_SubtotalIDR
            End Get
            Set(ByVal value As Double)
                mOrder_SubtotalIDR = value
            End Set
        End Property

        Public Property order_SubtotalInclDisc() As Double
            Get
                Return mOrder_SubtotalInclDisc
            End Get
            Set(ByVal value As Double)
                mOrder_SubtotalInclDisc = value
            End Set
        End Property

        Public Property order_PPH()
            Get
                Return mOrder_PPH
            End Get
            Set(ByVal value)
                mOrder_PPH = value
            End Set
        End Property

        Public Property order_PPN()
            Get
                Return mOrder_PPN
            End Get
            Set(ByVal value)
                mOrder_PPN = value
            End Set
        End Property

        Public Property order_Total() As Double
            Get
                Return mOrder_Total
            End Get
            Set(ByVal value As Double)
                mOrder_Total = value
            End Set
        End Property

        Public Property order_TotalIDR() As Double
            Get
                Return mOrder_TotalIDR
            End Get
            Set(ByVal value As Double)
                mOrder_TotalIDR = value
            End Set
        End Property

        Public Property order_SubtotalPPH() As Double
            Get
                Return mOrder_SubtotalPPH
            End Get
            Set(ByVal value As Double)
                mOrder_SubtotalPPH = value
            End Set
        End Property

        Public Property order_SubtotalPPN() As Double
            Get
                Return mOrder_SubtotalPPN
            End Get
            Set(ByVal value As Double)
                mOrder_SubtotalPPN = value
            End Set
        End Property

        Public Property order_Terbilang() As String
            Get
                Return mOrder_Terbilang
            End Get
            Set(ByVal value As String)
                mOrder_Terbilang = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class

End Namespace


