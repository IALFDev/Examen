Public Class FormVentaPrincial
    Private Sub btnRealizarVenta_Click(sender As Object, e As EventArgs) Handles btnRealizarVenta.Click
        FormRealizarVenta.ShowDialog() 'Muesto el form donde se puede realziar las nuevas ventas
    End Sub
End Class