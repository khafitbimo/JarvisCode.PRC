Imports System.Data.OleDb
Namespace DataSource



    Public Class clsRptOrderTOPDetil
        Private mOrder_id As String
        Private mOrdertop_line As Int64
        Private mOrderterm_line As Int64
        Private mOrderterm_seq As Int64
        Private mOrderterm_percent As Decimal
        Private mCurrency_id As Decimal
        Private mOrderterm_rate As Decimal
        Private mOrderterm_amount As Decimal
        Private mOrderterm_payplant As String
        Private mOrderterm_status As String
        Private mOrderterm_notes As String
        Private mIsresponse As Boolean
        Private mResponse_id As String

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property

        Public Property ordertop_line() As Int64
            Get
                Return mOrdertop_line
            End Get
            Set(ByVal value As Int64)
                mOrdertop_line = value
            End Set
        End Property

        Public Property orderterm_line() As Int64
            Get
                Return mOrderterm_line
            End Get
            Set(ByVal value As Int64)
                mOrderterm_line = value
            End Set
        End Property

        Public Property orderterm_seq() As Int64
            Get
                Return mOrderterm_seq
            End Get
            Set(ByVal value As Int64)
                mOrderterm_seq = value
            End Set
        End Property

        Public Property orderterm_percent() As Decimal
            Get
                Return mOrderterm_percent
            End Get
            Set(ByVal value As Decimal)
                mOrderterm_percent = value
            End Set
        End Property

        Public Property currency_id() As Decimal
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id = value
            End Set
        End Property

        Public Property orderterm_rate() As Decimal
            Get
                Return mOrderterm_rate
            End Get
            Set(ByVal value As Decimal)
                mOrderterm_rate = value
            End Set
        End Property

        Public Property orderterm_amount() As Decimal
            Get
                Return mOrderterm_amount
            End Get
            Set(ByVal value As Decimal)
                mOrderterm_amount = value
            End Set
        End Property

        Public Property orderterm_payplant() As String
            Get
                Return mOrderterm_payplant
            End Get
            Set(ByVal value As String)
                mOrderterm_payplant = value
            End Set
        End Property

        Public Property orderterm_status() As String
            Get
                Return mOrderterm_status
            End Get
            Set(ByVal value As String)
                mOrderterm_status = value
            End Set
        End Property

        Public Property orderterm_notes() As String
            Get
                Return mOrderterm_notes
            End Get
            Set(ByVal value As String)
                mOrderterm_notes = value
            End Set
        End Property

        Public Property isresponse() As Boolean
            Get
                Return mIsresponse
            End Get
            Set(ByVal value As Boolean)
                mIsresponse = value
            End Set
        End Property

        Public Property response_id() As String
            Get
                Return mResponse_id
            End Get
            Set(ByVal value As String)
                mResponse_id = value
            End Set
        End Property

    End Class
End Namespace