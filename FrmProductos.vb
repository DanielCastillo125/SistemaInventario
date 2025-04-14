Imports System.Data.SqlClient

Public Class FrmProductos

    ' Validadores de campos de texto
    Private Sub TxtSoloNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress, txtStock.KeyPress
        ' Permitir solo números y la tecla de retroceso
        PermitirSoloNumeros(e)
    End Sub

    ' Método para limpiar los campos de texto y habilitar la creación de nuevos productos
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtStock.Clear()

        btnAgregar.Enabled = True
        btnActualizar.Enabled = False
        btnEliminar.Enabled = False
    End Sub

    ' Botón para limpiar los campos
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
    End Sub

    ' Método para cargar los productos en el DataGridView
    Private Sub CargarProductos()
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim da As New SqlDataAdapter("sp_ObtenerProductos", con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvProductos.DataSource = dt

            Conexion.CerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try
    End Sub

    ' Método que carga los productos al iniciar el formulario
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
        btnActualizar.Enabled = False
        btnEliminar.Enabled = False
    End Sub

    ' Método para agregar un nuevo producto
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_InsertarProducto", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text)
            cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text))
            cmd.Parameters.AddWithValue("@StockInicial", Convert.ToInt32(txtStock.Text))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Producto agregado correctamente.")
            Conexion.CerrarConexion()

            CargarProductos()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Método para seleccionar un producto en el DataGridView
    Private Sub DgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtDescripcion.Text = fila.Cells("Descripcion").Value.ToString()
            txtPrecio.Text = fila.Cells("Precio").Value.ToString()
            txtStock.Text = fila.Cells("StockActual").Value.ToString()

            btnActualizar.Enabled = True
            btnEliminar.Enabled = True
            btnAgregar.Enabled = False
        End If
    End Sub

    ' Método para actualizar un producto
    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvProductos.CurrentRow Is Nothing Then Return

            Dim id As Integer = dgvProductos.CurrentRow.Cells("ProductoID").Value

            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_ActualizarProducto", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ProductoID", id)
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text)
            cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio.Text))
            cmd.Parameters.AddWithValue("@StockActual", Convert.ToInt32(txtStock.Text))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Producto actualizado.")
            Conexion.CerrarConexion()

            CargarProductos()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Método para eliminar un producto
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvProductos.CurrentRow Is Nothing Then Return

            Dim id As Integer = dgvProductos.CurrentRow.Cells("ProductoID").Value

            If MessageBox.Show("¿Estás seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim con As SqlConnection = Conexion.ObtenerConexion()
                Dim cmd As New SqlCommand("sp_EliminarProducto", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ProductoID", id)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Producto eliminado.")
                Conexion.CerrarConexion()

                CargarProductos()
                LimpiarCampos()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class