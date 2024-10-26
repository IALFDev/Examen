Public Class FormClientePrincipal
    Private Sub FormClientePrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        FormAgregarCliente.ShowDialog() 'Muesto el form donde se puede agregar nuevos clientes
    End Sub
End Class