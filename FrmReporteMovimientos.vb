Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmReporteMovimientos
    Private Sub FrmReporteMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar productos al combo
        CargarProductos(cmbProducto)
    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
        ' Configurar la fecha mínima de "Fecha Hasta" basada en la fecha seleccionada en "Fecha Desde"
        dtpHasta.MinDate = dtpDesde.Value.Date
    End Sub

    Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
        ' Configurar la fecha máxima de "Fecha Desde" basada en la fecha seleccionada en "Fecha Hasta"
        dtpDesde.MaxDate = dtpHasta.Value.Date
    End Sub

    ' Método para generar el reporte de movimientos con los filtros seleccionados
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        ' Validar que la fecha "Desde" no sea mayor que la fecha "Hasta"
        If dtpDesde.Value.Date > dtpHasta.Value.Date Then
            MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Validación de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim dt As New DataTable()
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_ObtenerMovimientos", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@FechaInicio", dtpDesde.Value.Date)
            cmd.Parameters.AddWithValue("@FechaFin", dtpHasta.Value.Date)

            If cmbProducto.SelectedIndex <> -1 Then
                cmd.Parameters.AddWithValue("@ProductoID", CInt(cmbProducto.SelectedValue))
            Else
                cmd.Parameters.AddWithValue("@ProductoID", DBNull.Value)
            End If

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            Conexion.CerrarConexion()

            ' Configurar el ReportViewer
            ReportViewer1.LocalReport.ReportPath = "ReporteMovimientos.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim rds As New ReportDataSource("dtMovimientos", dt)
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Error al cargar el reporte: " & ex.Message)
        End Try
    End Sub
End Class
