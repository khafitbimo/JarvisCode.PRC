Imports System.Windows.Forms

Public Class dlgProgressOrder
    Private indexcount As Integer

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim i As Integer

        MyBase.Show()
        MyBase.CenterToScreen()
        For i = 0 To Me.indexcount
            Threading.Thread.Sleep(100)
            Label1.Text = "Loading " & i & " of " & Me.indexcount & " records"
            Label1.Refresh()
            ProgressBar1.Value = CInt(100 * (i / Me.indexcount))
            ProgressBar1.Refresh()
        Next

        MyBase.Close()

        Return True
    End Function

#End Region

    Public Sub New(ByVal o As Integer)
        InitializeComponent()
        Me.indexcount = o

    End Sub


End Class
