Imports System.Data.SqlClient

Module ModGeneral

    ' En este modulo van las funciones que se llaman en más de un formulario

    ' Metodo para permitir solo números en un TextBox
    Public Sub PermitirSoloNumeros(e As KeyPressEventArgs)
        ' Permitir solo números y la tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Metodo para cargar los productos en el ComboBox
    Public Sub CargarProductos(cmbProducto)
        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim da As New SqlDataAdapter("sp_ObtenerProductos", con)
            Dim dt As New DataTable()
            da.Fill(dt)

            cmbProducto.DataSource = dt
            cmbProducto.DisplayMember = "Nombre"
            cmbProducto.ValueMember = "ProductoID"

            Conexion.CerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try
    End Sub

End Module
