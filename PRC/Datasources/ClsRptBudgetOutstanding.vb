Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptBudgetOutstanding
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

        Private mTransaction_id As String
        Private mBudget_id As Integer
        Private mBudgetdetil_id As Decimal
        Private mItem_id As String
        Private mQty As Decimal
        Private mAmount As Decimal
        Private mRate As Decimal
        Private mCurrency As Decimal
        Private mBudgetdetil_amount As String
        Private mSubtotal_amount As Decimal
        Private mBudget_name As String
        Private mType As String
        Private mItem_name As String
        Private mbudgetdetil_name As String
        Private mbudget_amount As Decimal
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
        Public Property domain_name() As String
            Get
                Return mDomain_name
            End Get
            Set(ByVal value As String)
                mDomain_name = value
            End Set
        End Property
        Public Property transaction_id() As String

            Get
                Return mTransaction_id
            End Get
            Set(ByVal value As String)
                mTransaction_id = value
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
        Public Property budgetdetil_id() As Decimal
            Get
                Return mBudgetdetil_id
            End Get
            Set(ByVal value As Decimal)
                mBudgetdetil_id = value
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
        Public Property qty() As Decimal
            Get
                Return mQty
            End Get
            Set(ByVal value As Decimal)
                mQty = value
            End Set
        End Property
        Public Property amount() As Decimal
            Get
                Return mAmount
            End Get
            Set(ByVal value As Decimal)
                mAmount = value
            End Set
        End Property
        Public Property rate() As Decimal
            Get
                Return mRate
            End Get
            Set(ByVal value As Decimal)
                mRate = value
            End Set
        End Property
        Public Property currency() As  Decimal
            Get
                Return mCurrency
            End Get
            Set(ByVal value As Decimal)
                mCurrency = value
            End Set
        End Property
        Public Property budgetdetil_amount() As Decimal
            Get
                Return mBudgetdetil_amount
            End Get
            Set(ByVal value As Decimal)
                mBudgetdetil_amount = value
            End Set
        End Property
        Public Property subtotal_amount() As Decimal
            Get
                Return mSubtotal_amount
            End Get
            Set(ByVal value As Decimal)
                mSubtotal_amount = value
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
        Public Property type() As String
            Get
                Return mType
            End Get
            Set(ByVal value As String)
                mType = value
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
        Public Property budgetdetil_name() As String
            Get
                Return mbudgetdetil_name
            End Get
            Set(ByVal value As String)
                mbudgetdetil_name = value
            End Set
        End Property
        Public Property budget_amount() As Decimal
            Get
                Return mbudget_amount
            End Get
            Set(ByVal value As Decimal)
                mbudget_amount = value
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
        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace
