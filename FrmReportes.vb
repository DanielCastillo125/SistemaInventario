Public Class FrmReportes
    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        Dim f As New frmReporteStock()
        f.ShowDialog()
    End Sub

    Private Sub btnHistMovs_Click(sender As Object, e As EventArgs) Handles btnHistMovs.Click
        Dim f As New FrmReporteMovimientos()
        f.ShowDialog()
    End Sub
End Class