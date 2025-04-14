Imports System.Data.SqlClient

Public Class Conexion
    Private Shared conexion As SqlConnection

    Private Shared cadenaConexion As String = "Data Source=.\SQLEXPRESS;Initial Catalog=SistemaInventario;Integrated Security=True"

    Public Shared Function ObtenerConexion() As SqlConnection
        If conexion Is Nothing Then
            conexion = New SqlConnection(cadenaConexion)
        End If

        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If

        Return conexion
    End Function

    Public Shared Sub CerrarConexion()
        If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub
End Class
