Imports System.Data.OleDb
Namespace DataSource
    Public Class clsMstRekananH

        Private mDSN As String

        Private mRekanan_id As Decimal
        Private mRekanan_name As String
        Private mRekanan_badanhukum As String
        Private mRekanantype_id As Decimal
        Private mRekanan_Addr1 As String
        Private mRekanan_Addr2 As String
        Private mRekanan_city As String
        Private mRekanan_telp As String
        Private mRekanan_fax As String
        Private mRekanan_email As String
        Private mRekanan_NPWP As String
        Private mRekanan_Create_by As String
        Private mRekanan_Create_dt As Date
        Private mRekanan_active As Boolean
        Private mRekanan_Bill As Decimal
        Private mRekanan_taxprefix As String
        Private mRekanan_pkpname As String
        Private mRekanan_salesperson As Decimal
        Private mRekanan_trf As String
        Private mRekanan_invsign As String
        Private mRekanan_invsignpos As String
        Private mRekanan_taxsign As String
        Private mRekanan_taxsignpos As String
        Private mEmployee_id As String



        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
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

        Public Property rekanan_badanhukum() As String
            Get
                Return mRekanan_badanhukum
            End Get
            Set(ByVal value As String)
                mRekanan_badanhukum = value
            End Set
        End Property

        Public Property rekanantype_id() As Decimal
            Get
                Return mRekanantype_id
            End Get
            Set(ByVal value As Decimal)
                mRekanantype_id = value
            End Set
        End Property

        Public Property rekanan_Addr1() As String
            Get
                Return mRekanan_Addr1
            End Get
            Set(ByVal value As String)
                mRekanan_Addr1 = value
            End Set
        End Property

        Public Property rekanan_Addr2() As String
            Get
                Return mRekanan_Addr2
            End Get
            Set(ByVal value As String)
                mRekanan_Addr2 = value
            End Set
        End Property

        Public Property rekanan_city() As String
            Get
                Return mRekanan_city
            End Get
            Set(ByVal value As String)
                mRekanan_city = value
            End Set
        End Property

        Public Property rekanan_telp() As String
            Get
                Return mRekanan_telp
            End Get
            Set(ByVal value As String)
                mRekanan_telp = value
            End Set
        End Property

        Public Property rekanan_fax() As String
            Get
                Return mRekanan_fax
            End Get
            Set(ByVal value As String)
                mRekanan_fax = value
            End Set
        End Property

        Public Property rekanan_email() As String
            Get
                Return mRekanan_email
            End Get
            Set(ByVal value As String)
                mRekanan_email = value
            End Set
        End Property

        Public Property rekanan_NPWP() As String
            Get
                Return mRekanan_NPWP
            End Get
            Set(ByVal value As String)
                mRekanan_NPWP = value
            End Set
        End Property

        Public Property rekanan_Create_by() As String
            Get
                Return mRekanan_Create_by
            End Get
            Set(ByVal value As String)
                mRekanan_Create_by = value
            End Set
        End Property

        Public Property rekanan_Create_dt() As Date
            Get
                Return mRekanan_Create_dt
            End Get
            Set(ByVal value As Date)
                mRekanan_Create_dt = value
            End Set
        End Property

        Public Property rekanan_active() As Boolean
            Get
                Return mRekanan_active
            End Get
            Set(ByVal value As Boolean)
                mRekanan_active = value
            End Set
        End Property

        Public Property rekanan_Bill() As Decimal
            Get
                Return mRekanan_Bill
            End Get
            Set(ByVal value As Decimal)
                mRekanan_Bill = value
            End Set
        End Property

        Public Property rekanan_taxprefix() As String
            Get
                Return mRekanan_taxprefix
            End Get
            Set(ByVal value As String)
                mRekanan_taxprefix = value
            End Set
        End Property

        Public Property rekanan_pkpname() As String
            Get
                Return mRekanan_pkpname
            End Get
            Set(ByVal value As String)
                mRekanan_pkpname = value
            End Set
        End Property

        Public Property rekanan_salesperson() As Decimal
            Get
                Return mRekanan_salesperson
            End Get
            Set(ByVal value As Decimal)
                mRekanan_salesperson = value
            End Set
        End Property

        Public Property rekanan_trf() As String
            Get
                Return mRekanan_trf
            End Get
            Set(ByVal value As String)
                mRekanan_trf = value
            End Set
        End Property

        Public Property rekanan_invsign() As String
            Get
                Return mRekanan_invsign
            End Get
            Set(ByVal value As String)
                mRekanan_invsign = value
            End Set
        End Property

        Public Property rekanan_invsignpos() As String
            Get
                Return mRekanan_invsignpos
            End Get
            Set(ByVal value As String)
                mRekanan_invsignpos = value
            End Set
        End Property

        Public Property rekanan_taxsign() As String
            Get
                Return mRekanan_taxsign
            End Get
            Set(ByVal value As String)
                mRekanan_taxsign = value
            End Set
        End Property

        Public Property rekanan_taxsignpos() As String
            Get
                Return mRekanan_taxsignpos
            End Get
            Set(ByVal value As String)
                mRekanan_taxsignpos = value
            End Set
        End Property

        Public Property employee_id() As String
            Get
                Return mEmployee_id
            End Get
            Set(ByVal value As String)
                mEmployee_id = value
            End Set
        End Property

        Public ReadOnly Property DaftarRekananContact() As String

            Get
                If mRekanan_id = String.Empty Then
                    Return String.Empty
                End If

                Dim tblRekananContact As DataTable
                Dim parCriteria As OleDbParameter
                Dim i As Byte
                DaftarRekananContact = String.Empty

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" rekanan_id = {0} ", mRekanan_id)
                    'tblRekananContact = clsUtil.GetDataTable("ms_MstRekanancontact_Select", Me.DSN, parCriteria)
                    tblRekananContact = clsUtil.GetDataTable("pr_MstRekanan_contact_Select", Me.DSN, parCriteria)
                    If tblRekananContact.Rows.Count > 0 Then
                        For i = 0 To tblRekananContact.Rows.Count - 1
                            DaftarRekananContact += tblRekananContact.Rows(i)("rekanancontact_name") & " / "
                        Next
                        DaftarRekananContact = Mid(DaftarRekananContact, 1, Len(DaftarRekananContact) - 1)
                    End If

                Catch ex As Exception
                    MsgBox("error retrieve budget name")
                Finally
                    parCriteria = Nothing
                    tblRekananContact = Nothing
                End Try

                Return DaftarRekananContact

            End Get
        End Property

        Public ReadOnly Property DSN() As String
            Get
                Return mDSN
            End Get
        End Property


        Public Sub New(ByVal sDSN As String)
            mDSN = sdsn
        End Sub
    End Class
End Namespace

