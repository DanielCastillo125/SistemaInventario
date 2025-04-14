Public Class FrmPrincipal
    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    ' Botón para abrir el gestor de productos
    Private Sub BtnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim f As New FrmProductos()
        f.ShowDialog()
    End Sub

    ' Botón para abrir el gestor de movimientos
    Private Sub BtnMovimientos_Click(sender As Object, e As EventArgs) Handles btnMovimientos.Click
        Dim f As New FrmMovimientos()
        f.ShowDialog()
    End Sub

    ' Botón para abrir el gestor de reportes
    Private Sub BtnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        Dim f As New FrmReportes()
        f.ShowDialog()
    End Sub

    Public Sub New(nombreUsuario As String)
        InitializeComponent()
        lblBienvenida.Text = "Bienvenido, " & nombreUsuario
    End Sub

End Class