Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormAgregarProducto
    Private Sub FormAgregarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActivarComboBoxCategoria()
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then 'Verifico que el campo Precio solo se ingrese numeros'
            MessageBox.Show("Por favor solo ingresar numeros", "Atención")
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
            If Not GuardarProductoEnBd(New Producto().GenerarObjetoProductoParaGuardarEnBd(txtNombre.Text, txtPrecio.Text, SeleccionarCategoria())).Excepcion.Error Then 'Verifico que el guardado en la base sea correcto de lo contrario muestro un MessageBox de error
                MessageBox.Show("Producto guardado", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) 'Si todo salio correcto muestro un MessageBox diciendo que el producto se guardo correctamente'

                txtNombre.Clear()
                txtPrecio.Clear() 'Limpio los campos Nombre, Precio y Categoria para que no quede con datos reciduales'
                txtCategoria.Clear()
                cbCategoria.Refresh()

            Else
                MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el producto no pudo se guardado'
            End If
        End If

        FormProducto.ActivarDataGridViewProducto() 'Refresco la grilla cada vez que haga click en el boton'
    End Sub

    ''' <summary>
    '''  Metodo que verifica que los campos Nombre Precio y Categoria no esten vacíos al mento de querer guardarlos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve bool de acuerdo a la verificación</returns>
    Protected Function VerificarCampos() As Boolean
        Dim validado As Boolean

        If Not String.IsNullOrEmpty(txtNombre.Text) Then 'Verifico que el campo Nombre no este vacío'
            validado = True
        Else
            MessageBox.Show("El campo Nombre no debe estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtPrecio.Text) Then 'Verifico que el campo Precio no este vacío'
            validado = True
        Else
            MessageBox.Show("El campo Precio no debe estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        Return validado = True
    End Function

    ''' <summary>
    '''  Metodo que verifica dos campos txtCategoria y cbCategoria si uno de los dos esta activo se toma la categoria del mismo
    ''' </summary>''
    Protected Function SeleccionarCategoria() As String
        If txtCategoria.Enabled Then
            Return txtCategoria.Text
        ElseIf cbCategoria.Enabled Then
            Return cbCategoria.SelectedValue
        End If

        Return ""
    End Function

    ''' <summary>
    '''  Metodo que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Protected Sub ActivarComboBoxCategoria()
        Dim categorias = ObtenerCategoriaProducto()
        Dim producto = New Producto
        producto.Categoria = "Seleccione una categoria"

        categorias.Insert(0, producto)

        If Not categorias.Count <= 0 Then
            cbCategoria.DataSource = categorias
            cbCategoria.DisplayMember = "Categoria"
            cbCategoria.ValueMember = "Categoria"
        End If
    End Sub

    ''' <summary>
    '''  Metodo que guarda en la base datos los datos del objeto Producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        Dim manager = New ManagerProducto()

        producto = manager.GuardarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion tipo ArrayList de la categoria de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerCategoriaProducto

        Return resultado
    End Function
End Class