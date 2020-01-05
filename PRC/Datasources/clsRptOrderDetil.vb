
Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptOrderDetil
        Private DSN As String

        'Default
        Private mOrder_id As String
        Private mOrderdetil_line As Integer
        Private mOrderdetil_no As Integer
        Private mItem_id As String
        Private mItem_name As String
        Private mItem_catname As String
        Private mOrderdetil_type As String
        Private mOrderdetil_descr As String
        Private mOrderdetil_qty As Decimal
        Private mOrderdetil_days As Decimal
        Private mOrderdetil_idr As Decimal
        Private mOrderdetil_foreign As Decimal
        Private mOrderdetil_foreignrate As Decimal
        Private mOrderdetil_discount As Decimal
        Private mOrderdetil_actual As Decimal
        Private mOrderdetil_actualnote As String
        Private mPOdetil_pph As Decimal
        Private mPOdetil_ppn As Decimal

        Private mCurrency_id As String
        Private mBudgetdetil_line As Integer
        Private mBudgetaccount_id As String
        Private mOld_orderdetil_id As Integer
        Private mChannel_id As String
        Private mUnit_id As Decimal
        Private mUnit_name As String

        Private mROdetil_rowtotalforeign As Decimal
        Private mROdetil_rowtotalforeign_incldisc As Decimal
        Private mROdetil_rowtotalforeign_incltax As Decimal
        Private mROdetil_rowtotal As Decimal

        Private mPOdetil_rowtotalforeign As Decimal
        Private mPOdetil_rowtotalforeign_incldisc As Decimal
        Private mPOdetil_rowtotalforeign_incltax As Decimal
        Private mPOdetil_rowtotal As Decimal


        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property

        Public Property orderdetilunit_id() As Decimal
            Get
                Return mUnit_id
            End Get
            Set(ByVal value As Decimal)
                mUnit_id = value
                getUnitInfo()
            End Set
        End Property

        Public Property orderdetilunit_name() As String
            Get
                Return mUnit_name
            End Get
            Set(ByVal value As String)
                mUnit_name = value
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

        Public Property rodetil_rowtotal() As Decimal
            Get
                Return mROdetil_rowtotal
            End Get
            Set(ByVal value As Decimal)
                mROdetil_rowtotal = value
            End Set
        End Property

        '==
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

        Public Property podetil_rowtotal() As Decimal
            Get
                Return mPOdetil_rowtotal
            End Get
            Set(ByVal value As Decimal)
                mPOdetil_rowtotal = value
            End Set
        End Property

        '==

        Public Property orderdetil_line() As Integer
            Get
                Return mOrderdetil_line
            End Get
            Set(ByVal value As Integer)
                mOrderdetil_line = value
            End Set
        End Property

        Public Property orderdetil_no() As Integer
            Get
                Return mOrderdetil_no
            End Get
            Set(ByVal value As Integer)
                mOrderdetil_no = value
            End Set
        End Property

        Public Property item_id() As String
            Get
                Return mItem_id
            End Get
            Set(ByVal value As String)
                mItem_id = value
                getItemCategoryInfo()
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

        Public Property item_catname() As String
            Get
                Return mItem_catname
            End Get
            Set(ByVal value As String)
                mItem_catname = value
            End Set
        End Property

        Public Property orderdetil_type() As String
            Get
                Return mOrderdetil_type
            End Get
            Set(ByVal value As String)
                mOrderdetil_type = value
            End Set
        End Property

        Private Sub getItemCategoryInfo()

            If mItem_id <> "" Then

                Dim tblCategory As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = " item_id = '" & mItem_id & "'"
                    tblCategory = clsUtil.GetDataTable("pr_MstItem_Select", Me.DSN, parCriteria)

                    If tblCategory.Rows.Count > 0 Then
                        Me.mItem_catname = tblCategory.Rows(0)("category_name").ToString.Trim
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving item category information")
                Finally
                    parCriteria = Nothing
                    tblCategory = Nothing
                End Try

            End If
        End Sub

        Private Sub getUnitInfo()

            If mUnit_id > 0 Then

                Dim tblCategory As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = " unit_id = '" & mUnit_id & "'"
                    tblCategory = clsUtil.GetDataTable("pr_MstUnit_Select", Me.DSN, parCriteria)

                    If tblCategory.Rows.Count > 0 Then
                        Me.mUnit_name = tblCategory.Rows(0)("unit_shortname").ToString.Trim
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving unit name information")
                Finally
                    parCriteria = Nothing
                    tblCategory = Nothing
                End Try

            End If
        End Sub

        Public Property orderdetil_descr() As String
            Get
                Return mOrderdetil_descr
            End Get
            Set(ByVal value As String)
                mOrderdetil_descr = value
            End Set
        End Property

        Public Property orderdetil_qty() As Decimal
            Get
                Return mOrderdetil_qty
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_qty = IIf(value > 0, value, 1)
            End Set
        End Property

        Public Property orderdetil_days() As Decimal
            Get
                Return mOrderdetil_days
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_days = IIf(value > 0, value, 1)
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

        Public Property orderdetil_foreignrate() As Decimal
            Get
                Return mOrderdetil_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_foreignrate = value
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

        Public Property orderdetil_actual() As Decimal
            Get
                Return mOrderdetil_actual
            End Get
            Set(ByVal value As Decimal)
                mOrderdetil_actual = value
            End Set
        End Property

        Public Property orderdetil_actualnote() As String
            Get
                Return mOrderdetil_actualnote
            End Get
            Set(ByVal value As String)
                mOrderdetil_actualnote = value
            End Set
        End Property

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

        Public Property currency_id() As String
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As String)
                mCurrency_id = value
            End Set
        End Property

        Public Property budgetdetil_line() As Integer
            Get
                Return mBudgetdetil_line
            End Get
            Set(ByVal value As Integer)
                mBudgetdetil_line = value
            End Set
        End Property

        Public Property budgetaccount_id() As String
            Get
                Return mBudgetaccount_id
            End Get
            Set(ByVal value As String)
                mBudgetaccount_id = value
            End Set
        End Property

        Public Property old_orderdetil_id() As Integer
            Get
                Return mOld_orderdetil_id
            End Get
            Set(ByVal value As Integer)
                mOld_orderdetil_id = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property


        'Public ReadOnly Property NamaItem() As String
        '    Get
        '        NamaItem = String.Empty
        '        If mItem_id <> String.Empty Then

        '            Dim tblRentalItem As DataTable
        '            Dim parCriteria As OleDbParameter
        '            Try
        '                parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        '                parCriteria.Value = String.Format(" item_id = {0} ", mItem_id)
        '                tblRentalItem = clsUtil.GetDataTable("pr_MstItem_Select", Me.DSN, parCriteria)
        '                If tblRentalItem.Rows.Count > 0 Then
        '                    NamaItem = tblRentalItem.Rows(0)("item_name").ToString
        '                End If

        '            Catch ex As Exception
        '                MsgBox("error on retrieving item name")
        '            Finally
        '                parCriteria = Nothing
        '                tblRentalItem = Nothing
        '            End Try

        '        End If
        '    End Get
        'End Property

        Public ReadOnly Property SubTotalItem()
            Get
                Return (mOrderdetil_idr * Math.Ceiling(mOrderdetil_days * mOrderdetil_qty)) - mOrderdetil_discount
            End Get
        End Property

        Public Sub New(ByVal strDSN As String)
            Me.DSN = strDSN
        End Sub

    End Class
End Namespace





'Imports System.Data.OleDb
'Namespace DataSource
'    Public Class clsRptTrnRODetil

'        Private DSN As String

'        Private mOrder_id As String
'        Private mOrderdetil_line As Integer
'        Private mItem_id As String
'        Private mOrderdetil_descr As String
'        Private mOrderdetil_qty As Decimal
'        Private mOrderdetil_days As Decimal
'        Private mOrderdetil_idr As Decimal
'        Private mOrderdetil_foreign As Decimal
'        Private mOrderdetil_foreignrate As Decimal
'        Private mOrderdetil_discount As Decimal
'        Private mOrderdetil_actual As Decimal
'        Private mOrderdetil_actualnote As String
'        Private mCurrency_id As String
'        Private mBudgetdetil_line As Integer
'        Private mBudgetaccount_id As String
'        Private mOld_orderdetil_id As Integer
'        Private mChannel_id As String




'        Public Property order_id() As String
'            Get
'                Return mOrder_id
'            End Get
'            Set(ByVal value As String)
'                mOrder_id = value
'            End Set
'        End Property

'        Public Property orderdetil_line() As Integer
'            Get
'                Return mOrderdetil_line
'            End Get
'            Set(ByVal value As Integer)
'                mOrderdetil_line = value
'            End Set
'        End Property

'        Public Property item_id() As String
'            Get
'                Return mItem_id
'            End Get
'            Set(ByVal value As String)
'                mItem_id = value
'            End Set
'        End Property

'        Public Property orderdetil_descr() As String
'            Get
'                Return mOrderdetil_descr
'            End Get
'            Set(ByVal value As String)
'                mOrderdetil_descr = value
'            End Set
'        End Property

'        Public Property orderdetil_qty() As Decimal
'            Get
'                Return mOrderdetil_qty
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_qty = value
'            End Set
'        End Property

'        Public Property orderdetil_days() As Decimal
'            Get
'                Return mOrderdetil_days
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_days = value
'            End Set
'        End Property

'        Public Property orderdetil_idr() As Decimal
'            Get
'                Return mOrderdetil_idr
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_idr = value
'            End Set
'        End Property

'        Public Property orderdetil_foreign() As Decimal
'            Get
'                Return mOrderdetil_foreign
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_foreign = value
'            End Set
'        End Property

'        Public Property orderdetil_foreignrate() As Decimal
'            Get
'                Return mOrderdetil_foreignrate
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_foreignrate = value
'            End Set
'        End Property

'        Public Property orderdetil_discount() As Decimal
'            Get
'                Return mOrderdetil_discount
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_discount = value
'            End Set
'        End Property

'        Public Property orderdetil_actual() As Decimal
'            Get
'                Return mOrderdetil_actual
'            End Get
'            Set(ByVal value As Decimal)
'                mOrderdetil_actual = value
'            End Set
'        End Property

'        Public Property orderdetil_actualnote() As String
'            Get
'                Return mOrderdetil_actualnote
'            End Get
'            Set(ByVal value As String)
'                mOrderdetil_actualnote = value
'            End Set
'        End Property

'        Public Property currency_id() As String
'            Get
'                Return mCurrency_id
'            End Get
'            Set(ByVal value As String)
'                mCurrency_id = value
'            End Set
'        End Property

'        Public Property budgetdetil_line() As Integer
'            Get
'                Return mBudgetdetil_line
'            End Get
'            Set(ByVal value As Integer)
'                mBudgetdetil_line = value
'            End Set
'        End Property

'        Public Property budgetaccount_id() As String
'            Get
'                Return mBudgetaccount_id
'            End Get
'            Set(ByVal value As String)
'                mBudgetaccount_id = value
'            End Set
'        End Property

'        Public Property old_orderdetil_id() As Integer
'            Get
'                Return mOld_orderdetil_id
'            End Get
'            Set(ByVal value As Integer)
'                mOld_orderdetil_id = value
'            End Set
'        End Property

'        Public Property channel_id() As String
'            Get
'                Return mChannel_id
'            End Get
'            Set(ByVal value As String)
'                mChannel_id = value
'            End Set
'        End Property


'        Public ReadOnly Property NamaBarang() As String
'            Get
'                NamaBarang = String.Empty
'                If mItem_id <> String.Empty Then

'                    Dim tblRentalItem As DataTable
'                    Dim parCriteria As OleDbParameter
'                    Try
'                        parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
'                        parCriteria.Value = String.Format(" item_id = {0} ", mItem_id)
'                        tblRentalItem = clsUtil.GetDataTable("pr_MstRentalItem_Select", Me.DSN, parCriteria)
'                        If tblRentalItem.Rows.Count > 0 Then
'                            NamaBarang = tblRentalItem.Rows(0)("item_name").ToString
'                        End If

'                    Catch ex As Exception
'                        MsgBox("error on retrieving item name")
'                    Finally
'                        parCriteria = Nothing
'                        tblRentalItem = Nothing
'                    End Try

'                End If
'            End Get
'        End Property

'        Public ReadOnly Property SubTotalItem()
'            Get
'                Return mOrderdetil_idr * mOrderdetil_days * mOrderdetil_qty
'            End Get
'        End Property

'        Public Sub New(ByVal strDSN As String)
'            Me.DSN = strDSN
'        End Sub

'    End Class
'End Namespace



