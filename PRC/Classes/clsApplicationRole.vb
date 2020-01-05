﻿Imports System.Data.OleDb

Public Class clsApplicationRole

    Private Shared _roleName As String
    Private Shared _rolePassword As String
    Private Shared _config As DataSet

    Public Shared Sub SetConfig(ByVal Config As DataSet)
        Dim objTbl As DataTable

        objTbl = Config.Tables("ApplicationRole")

        If objTbl.Rows.Count > 0 Then
            With objTbl.Rows(0)
                _roleName = .Item("RoleName")
                _rolePassword = .Item("RolePassword")
            End With
        Else
            _roleName = ""
            _rolePassword = ""
        End If
    End Sub

    Public Shared Sub SetAppRole(ByRef dbConn As OleDbConnection, ByRef cookie As Byte())
        Dim cmd As OleDbCommand

        Try
            cmd = New OleDbCommand("sp_setapprole", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rolename", _roleName)
            cmd.Parameters.AddWithValue("@password", _rolePassword)
            cmd.Parameters.AddWithValue("@encrypt", "none")
            cmd.Parameters.AddWithValue("@fCreateCookie", True)
            cmd.Parameters.Add(New OleDbParameter() With {.DbType = DbType.Binary,
                                                          .Direction = ParameterDirection.Output,
                                                          .ParameterName = "@cookie",
                                                          .Size = 8000
                                                         })

            cmd.ExecuteNonQuery()

            cookie = cmd.Parameters("@cookie").Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub SetAppRole(ByRef dbConn As OleDbConnection, ByRef dbTrans As OleDbTransaction, ByRef cookie As Byte())
        Dim cmd As OleDbCommand

        Try
            cmd = New OleDbCommand("sp_setapprole", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rolename", _roleName)
            cmd.Parameters.AddWithValue("@password", _rolePassword)
            cmd.Parameters.AddWithValue("@encrypt", "none")
            cmd.Parameters.AddWithValue("@fCreateCookie", True)
            cmd.Parameters.Add(New OleDbParameter() With {.DbType = DbType.Binary,
                                                          .Direction = ParameterDirection.Output,
                                                          .ParameterName = "@cookie",
                                                          .Size = 8000
                                                         })

            cmd.ExecuteNonQuery()

            cookie = cmd.Parameters("@cookie").Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub UnsetAppRole(ByRef dbConn As OleDbConnection, ByRef dbTrans As OleDbTransaction, ByRef cookie As Byte())
        Dim cmd As OleDbCommand

        Try
            cmd = New OleDbCommand("sp_unsetapprole", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New OleDbParameter() With {.ParameterName = "@cookie",
                                                          .DbType = DbType.Binary,
                                                          .Value = cookie,
                                                          .Size = 8000
                                                         })
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub UnsetAppRole(ByRef dbConn As OleDbConnection, ByRef cookie As Byte())
        Dim cmd As OleDbCommand

        Try
            cmd = New OleDbCommand("sp_unsetapprole", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New OleDbParameter() With {.ParameterName = "@cookie",
                                                          .DbType = DbType.Binary,
                                                          .Value = cookie,
                                                          .Size = 8000
                                                         })
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
