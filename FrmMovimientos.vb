Imports System.Data.SqlClient

Public Class FrmMovimientos
    Private Sub TxtSoloNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        ' Permitir solo números y la tecla de retroceso
        PermitirSoloNumeros(e)
    End Sub

    ' Metodo para cargar el historial de movimientos
    Private Sub frmMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTipo.Items.Add("Entrada")
        cmbTipo.Items.Add("Salida")
        cmbTipo.SelectedIndex = 0
        CargarProductos(cmbProducto)
        CargarHistorial()
    End Sub

    ' Metodo para registrar el movimiento
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            If cmbProducto.SelectedIndex = -1 OrElse cmbTipo.SelectedIndex = -1 Then
                MessageBox.Show("Seleccione producto y tipo de movimiento.")
                Return
            End If

            Dim productoID As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
            Dim tipo As String = cmbTipo.SelectedItem.ToString()
            Dim cantidad As Integer

            If Not Integer.TryParse(txtCantidad.Text, cantidad) OrElse cantidad <= 0 Then
                MessageBox.Show("Ingrese una cantidad válida.")
                Return
            End If

            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_RegistrarMovimiento", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ProductoID", productoID)
            cmd.Parameters.AddWithValue("@TipoMovimiento", tipo)
            cmd.Parameters.AddWithValue("@Cantidad", cantidad)

            cmd.ExecuteNonQuery()
            Conexion.CerrarConexion()

            MessageBox.Show("Movimiento registrado exitosamente.")
            txtCantidad.Clear()
            CargarHistorial()
        Catch ex As SqlException When ex.Number = 50000 
            MessageBox.Show(ex.Message, "Error de stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al registrar movimiento: " & ex.Message)
        End Try
    End Sub

    ' Metodo para cargar el historial de movimientos
    Private Sub CargarHistorial()
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_ObtenerMovimientos", con)
            cmd.CommandType = CommandType.StoredProcedure

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvMovimientos.DataSource = dt

            Conexion.CerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al cargar historial: " & ex.Message)
        End Try
    End Sub

End Class