Imports Examen.BLL

Public Class FormProducto
    Private Sub FormProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActivarDataGridView()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

    End Sub
    Private Sub txtIdProducto_LostFocus(sender As Object, e As EventArgs) Handles txtIdProducto.LostFocus
        If Not IsNumeric(txtIdProducto.Text) And Trim(txtIdProducto.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdProducto.Text = "" 'Elimino el dato ingresado incorrecto'
        End If
    End Sub

    Private Sub txtRangoDesde_TextChanged(sender As Object, e As EventArgs) Handles txtRangoDesde.TextChanged

    End Sub

    Private Sub txtRangoDesde_LostFocus(sender As Object, e As EventArgs) Handles txtRangoDesde.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Text = "" 'Elimino el dato ingresado incorrecto'
        End If

    End Sub

    Private Sub txtRangoHasta_TextChanged(sender As Object, e As EventArgs) Handles txtRangoHasta.TextChanged

    End Sub

    Private Sub txtRangoHasta_LostFocus(sender As Object, e As EventArgs) Handles txtRangoHasta.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Text = "" 'Elimino el dato ingresado incorrecto'
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        FormAgregarProducto.ShowDialog()
    End Sub

    ''' <summary>
    '''  Metodo que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Protected Sub ActivarDataGridView()
        Dim productos = ObtenerTodosLosProductos()

        If Not productos.Count <= 0 Then
            dgvProducto.DataSource = productos
            dgvProducto.Visible = True
        End If
    End Sub

    ''' <summary>
    '''  Metodo que obtiene una collecion de todos los productos desde el "gestor" o "manager" de la capa de negocios
    '''  Procedure, una colección del Tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un Arraylis del Tipo Producto</returns>

    Protected Function ObtenerTodosLosProductos() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerTodosLosProductos

        Return resultado
    End Function
End Class