Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormAgregarProducto
    Private Sub FormAgregarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Protected Sub ConfigurarContenido()
        ActivarComboBoxCategoria()

        cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList 'Convierto el campo Categoria en un DropDownList para que no se peuda escribir en el
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then 'Verifico que el campo Precio solo se ingrese numeros'
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        txtPrecio.Text = Format(txtPrecio.Text, "Currency") 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'
    End Sub
    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        If txtCategoria.Text.Length > 0 Then 'Verifico que el campo Categoria(TextBox) este vacío'
            cbCategoria.Enabled = False 'Si tiene datos desactivo el campo Categoria(ComboBox)'
        Else
            cbCategoria.Enabled = True 'Si no tiene datos activo el campo Categoria(ComboBox)'
        End If
    End Sub

    Private Sub cbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoria.SelectedIndexChanged
        If Not cbCategoria.SelectedIndex <> 0 Then 'Verifico que el campo Categoria(ComboBox) no tenga categoria seleccionada'
            txtCategoria.Enabled = True 'Si no tiene categoria seleccionada activo el campo Categoria(TextBox)'
        Else
            txtCategoria.Enabled = False 'Si tiene categoria seleccionada desactivo el campo Categoria(TextBox)'
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        If VerificarCampos() Then 'Verifico que los campos Nombre, Precio y Categoria no esten vacíos'

            If Not GuardarProductoEnBd(New Producto().GenerarObjetoProductoParaGuardarEnBd(txtNombre.Text, txtPrecio.Text, SeleccionarCampoCategoria())).Excepcion.Error Then 'Verifico que el guardado en la base sea correcto de lo contrario muestro un MessageBox de error
                MessageBox.Show("Producto guardado", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el producto se guardo correctamente'

                txtNombre.Clear()
                txtPrecio.Clear() 'Limpio los campos Nombre, Precio y Categoria para que no quede con datos reciduales'
                txtCategoria.Clear()
                cbCategoria.Refresh()

                FormProductoPrincipal.ActivarDataGridViewProducto() 'Refresco la grilla cada vez que haga click en el botón'
            Else
                MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el producto no se guardar correctamente'
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que verifica que los campos Nombre Precio y Categoria no esten vacíos al mento de querer guardarlos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve bool de acuerdo a la verificación</returns>
    Protected Function VerificarCampos() As Boolean
        Dim validado As Boolean

        If Not String.IsNullOrEmpty(txtNombre.Text) Then 'Verifico que el campo Nombre no este vacío'
            If Not txtNombre.Text.Length > 255 Then 'Verifico que el campo no tenga más de 255 caracteres'
                validado = True
            Else
                MessageBox.Show("El campo Nombre no debe tener más de 255 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Nombre no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtPrecio.Text) Then 'Verifico que el campo Precio no este vacío'
            validado = True
        Else
            MessageBox.Show("El campo Precio no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If txtCategoria.Enabled Then 'Verifico que el campo Categoria(TextBox) este activo'
            If Not String.IsNullOrEmpty(txtCategoria.Text) Then
                If Not txtCategoria.Text.Length > 255 Then 'Verifico que el Categoria(TextBox) no tenga más de 255 caracteres'
                    validado = True
                Else
                    MessageBox.Show("El campo Categoria no debe tener más de 255 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    validado = False

                    Return validado
                End If
            Else
                MessageBox.Show("El campo Categoria no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                validado = False

                Return validado
            End If

        End If

        Return validado = True
    End Function

    ''' <summary>
    '''  Método que verifica dos campos txtCategoria y cbCategoria si uno de los dos esta activo se toma la categoria del mismo
    ''' </summary>''
    Protected Function SeleccionarCampoCategoria() As String
        If txtCategoria.Enabled Then
            Return txtCategoria.Text
        ElseIf cbCategoria.Enabled Then
            Return cbCategoria.SelectedValue
        End If

        Return ""
    End Function

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Protected Sub ActivarComboBoxCategoria()
        Dim categorias = ObtenerCategoriaProducto()
        Dim producto = New Producto
        producto.Categoria = "Seleccione una categoría"

        categorias.Insert(0, producto) 'Agrego una opción nueva primera en lista'

        If categorias IsNot Nothing AndAlso categorias.Count > 0 Then 'Verifico que "categorias" no este vacío y no sea nulo
            cbCategoria.DataSource = categorias
            cbCategoria.DisplayMember = "Categoria"
            cbCategoria.ValueMember = "Categoria"
        End If
    End Sub

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        Dim manager = New ManagerProducto()

        producto = manager.GuardarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de la categoria de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerCategoriaProducto()

        Return resultado
    End Function
End Class