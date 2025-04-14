Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient

Public Class FrmLogin

    ' Método para encriptar la contraseña usando SHA256
    Private Function EncriptarSHA256(texto As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytesTexto As Byte() = Encoding.UTF8.GetBytes(texto)
            Dim hash As Byte() = sha256.ComputeHash(bytesTexto)
            Dim resultado As New StringBuilder()
            For Each b As Byte In hash
                resultado.Append(b.ToString("x2")) ' convierte a hexadecimal
            Next
            Return resultado.ToString()
        End Using
    End Function

    ' Método para validar el login
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contrasena As String = EncriptarSHA256(txtPassword.Text.Trim())

        Try
            Dim con As SqlConnection = Conexion.ObtenerConexion()
            Dim cmd As New SqlCommand("sp_ValidarLogin", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario)
            cmd.Parameters.AddWithValue("@Contrasena", contrasena)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                Dim nombre As String = reader("NombreUsuario").ToString()
                MessageBox.Show("Bienvenido, " & nombre & "!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Abrir pantalla principal
                Dim principal As New FrmPrincipal(nombre)
                principal.Show()
                Me.Hide()
            Else
                MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            reader.Close()
            Conexion.CerrarConexion()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class