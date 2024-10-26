Public Class FormPrincipal
    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        FormProductoPrincipal.ShowDialog() 'Muesto el form donde se puede ver los productos
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        FormClientePrincipal.ShowDialog() 'Muesto el form donde se puede ver los clientes
    End Sub
End Class
