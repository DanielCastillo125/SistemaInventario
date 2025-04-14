Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frmReporteStock
    Private Sub frmReporteStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable()
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_ObtenerProductos", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Conexion.CerrarConexion()

            ' Configurar el ReportViewer
            ReportViewer1.LocalReport.ReportPath = "ReporteStock.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim rds As New ReportDataSource("dtStock", dt)
            ReportViewer1.LocalReport.DataSources.Add(rds)

            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Error al cargar el reporte: " & ex.Message)
        End Try
    End Sub
End Class
