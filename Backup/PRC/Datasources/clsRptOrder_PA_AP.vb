
Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptOrder_PA_AP
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_Name As String
        Private mChannel_Addr As String
        Private mChannel_Telp As String
        Private mChannel_Ext As String
        Private mChannel_Fax As String
        Private mChannel_Form_No1 As String
        Private mChannel_Form_No2 As String

        Private mOrder_Id As String
        Private mAp_Ref As String
        Private mAp_Date As Date
        Private mOrder_Utilizeddatestart As Date
        Private mOrder_Utilizedlocation As String
        Private mPaymentreq_Id As String
        Private mOrderpaymreq_Amount As Decimal
        'Private mOrderdetil_Subtotal As Decimal
        Private mRO_total_excltax As Decimal
        Private mPO_total_excltax As Decimal
        Private mRO_total_incltax As Decimal
        Private mPO_total_incltax As Decimal

        Private mAccru_Idr As Decimal
        Private mOutstanding_AP As Decimal

        Private mRekanan_Id As String
        Private mRekanan_Name As String
        Private mBudget_Id As String
        Private mBudget_Name As String


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
                        Me.mChannel_Addr = tblChannel.Rows(0)("channel_address").ToString.Trim
                        Me.mChannel_Telp = tblChannel.Rows(0)("channel_telp1").ToString.Trim
                        Me.mChannel_Ext = tblChannel.Rows(0)("channel_telp2").ToString.Trim
                        Me.mChannel_Fax = tblChannel.Rows(0)("channel_fax").ToString.Trim

                        If Me.mChannel_id = "TV7" Then
                            Me.mChannel_Form_No1 = "TransTV / DPRO / F-007 / Rev "
                            Me.mChannel_Form_No1 = "TransTV / DPRO / F-007"
                        Else
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

        Public Property order_id() As String
            Get
                Return mOrder_Id
            End Get
            Set(ByVal value As String)
                mOrder_Id = value
            End Set
        End Property

        Public Property ap_ref() As String
            Get
                Return mAp_Ref
            End Get
            Set(ByVal value As String)
                mAp_Ref = value
            End Set
        End Property

        Public Property ap_date() As Date
            Get
                Return mAp_Date
            End Get
            Set(ByVal value As Date)
                mAp_Date = value
            End Set
        End Property

        Public Property accru_idr() As Decimal
            Get
                Return mAccru_Idr
            End Get
            Set(ByVal value As Decimal)
                mAccru_Idr = value
            End Set
        End Property

        Public Property outstanding_ap() As Decimal
            Get
                Return mOutstanding_AP
            End Get
            Set(ByVal value As Decimal)
                mOutstanding_AP = value
            End Set
        End Property

        Public Property order_utilizeddatestart() As Date
            Get
                Return mOrder_Utilizeddatestart
            End Get
            Set(ByVal value As Date)
                mOrder_Utilizeddatestart = value
            End Set
        End Property

        Public Property order_utilizedlocation() As String
            Get
                Return mOrder_Utilizedlocation
            End Get
            Set(ByVal value As String)
                mOrder_Utilizedlocation = value
            End Set
        End Property

        Public Property paymentreq_id() As String
            Get
                Return mPaymentreq_Id
            End Get
            Set(ByVal value As String)
                mPaymentreq_Id = value
            End Set
        End Property

        Public Property orderpaymreq_amount() As Decimal
            Get
                Return mOrderpaymreq_Amount
            End Get
            Set(ByVal value As Decimal)
                mOrderpaymreq_Amount = value
            End Set
        End Property


        'Public Property orderdetil_Subtotal() As Decimal
        '    Get
        '        Return mOrderdetil_Subtotal
        '    End Get
        '    Set(ByVal value As Decimal)
        '        mOrderdetil_Subtotal = value
        '    End Set
        'End Property

        Public Property ro_total_excltax() As Decimal
            Get
                Return mRO_total_excltax
            End Get
            Set(ByVal value As Decimal)
                mRO_total_excltax = value
            End Set
        End Property

        Public Property po_total_excltax() As Decimal
            Get
                Return mPO_total_excltax
            End Get
            Set(ByVal value As Decimal)
                mPO_total_excltax = value
            End Set
        End Property

        Public Property ro_total_incltax() As Decimal
            Get
                Return mRO_total_incltax
            End Get
            Set(ByVal value As Decimal)
                mRO_total_incltax = value
            End Set
        End Property

        Public Property po_total_incltax() As Decimal
            Get
                Return mPO_total_incltax
            End Get
            Set(ByVal value As Decimal)
                mPO_total_incltax = value
            End Set
        End Property

        Public Property rekanan_id() As String
            Get
                Return mRekanan_Id
            End Get
            Set(ByVal value As String)
                mRekanan_Id = value
            End Set
        End Property

        Public Property rekanan_name() As String
            Get
                Return mRekanan_Name
            End Get
            Set(ByVal value As String)
                mRekanan_Name = value
            End Set
        End Property

        Public Property budget_id() As String
            Get
                Return mBudget_Id
            End Get
            Set(ByVal value As String)
                mBudget_Id = value
            End Set
        End Property

        Public Property budget_name() As String
            Get
                Return mBudget_Name
            End Get
            Set(ByVal value As String)
                mBudget_Name = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub

    End Class

End Namespace