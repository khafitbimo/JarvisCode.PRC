Imports System.Windows.Forms
Imports System.Data.DataTable
Imports System.Threading
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.DataRowCollection
Imports System.Data.DataSet


Public Class dlgChooseUserEmail
    Private DSN As String
    Private tbl_MstUserContact As DataTable = clsDataset.CreateTblUserEmail
    Private CloseButtonIsPressed As Boolean
    Private comboFill As clsDataFiller = New clsDataFiller(Me.DSN)
    Private StrukturUnit As Decimal
    Private cUsername As String = String.Empty
    Private userposition As Integer

    'Function: user type
    Private Enum PositionType As Integer
        KaDept = 1
        KaDiv = 2
        SuperUser = 3
        Supervisor = 4
        Direktur = 5
        Staff = 6
    End Enum

    Public Sub New(ByVal strDSN As String, ByVal STRUKTURUNIT As Decimal, Optional ByVal USERPOSITION As Integer = 0)
        InitializeComponent()
        Me.DSN = strDSN
        Me.StrukturUnit = STRUKTURUNIT
        Me.userposition = USERPOSITION
    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.lueUsername.Text + "#" + Me.txtAlamatEmail.Text + "#" + Me.cUsername
        Else
            Return String.Empty
        End If
    End Function

    Private Sub btnKirimEmail_Click(sender As Object, e As EventArgs) Handles btnKirimEmail.Click
        If lueUsername.EditValue <> "0" Then
            If Me.txtAlamatEmail.Text = "" Or Me.txtAlamatEmail.Text = "xxx@xxx.com" Then
                Exit Sub
            End If

            If Me.cUsername = "" Then
                Exit Sub
            End If

            Me.CloseButtonIsPressed = True
            Me.Close()
        End If
    End Sub

    Private Sub lueUsername_EditValueChanged(sender As Object, e As EventArgs) Handles lueUsername.EditValueChanged
        Dim objTbl As DataTable = Me.tbl_MstUserContact.Select(String.Format("user_email = '{0}'", clsUtil.IsDbNull(Me.lueUsername.EditValue, ""))).CopyToDataTable

        If objTbl.Rows.Count > 0 Then
            Me.txtAlamatEmail.Text = objTbl.Rows(0).Item("user_email").ToString
            Me.cUsername = objTbl.Rows(0).Item("username").ToString
        Else
            Me.txtAlamatEmail.Text = ""
            Me.cUsername = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.CloseButtonIsPressed = False
        Me.Close()
    End Sub

    Private Sub dlgKirimEmail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim criteria As String = String.Empty

        If Me.userposition = PositionType.Staff Then
            criteria = String.Format("strukturunit_id = {0} AND user_position IN ({1})", Me.StrukturUnit, "20, 30")
        Else
            criteria = String.Format("strukturunit_id = {0} AND user_position IN ({1})", Me.StrukturUnit, "40, 35") '40 Posisi AVP/KaDept, 35 Posisi Deputy AVP/KaDept
        End If

        comboFill = New clsDataFiller(Me.DSN)
        comboFill.ComboFillDX(Me.lueUsername, "user_email", "user_fullname", Me.tbl_MstUserContact, "get_Email", criteria)
    End Sub
End Class
