Imports Examen.BLL
Imports Examen.Entidad

Public Class FormEditarVentaItemProducto
    Protected IdventaItem As Long 'Variable para almacenar el Id del producto a editar
    Protected Idventa As Long 'Variable para almacenar el Id del producto a editar

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            ' Verifico que el campo Teléfono solo se ingresen números
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        ElseIf e.KeyChar = "0"c Or sender.Text.Length = 0 Then
            ' Verifico que el primer carácter no sea 0
            MessageBox.Show("La cantidad debe ser mayor a 0.", "Atención")
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(ventaItem As VentaItem)
        ActivarComboBoxProducto()
        IdventaItem = ventaItem.Id
        cbProducto.SelectedValue = ventaItem.Producto.Id
        txtCantidad.Text = ventaItem.Cantidad
        Idventa = ventaItem.Venta.Id
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        If VerificarCamposProducto() Then
            Dim itemVenta = New VentaItem()
            Dim datosProductos = ObtenerDatosDeProducto(New Producto() With {.Id = cbProducto.SelectedValue})
            Dim producto = New Producto()

            If datosProductos IsNot Nothing Then
                itemVenta.PrecioUnitario = datosProductos(0).Precio
            End If

            If Not EditarVentaItemEnBd(New VentaItem().GenerarObjetoVentaItemParaGuardarEnBd(IdventaItem, Idventa, cbProducto.SelectedValue, itemVenta.PrecioUnitario, txtCantidad.Text)).Excepcion.Error Then
                If Not ActualizarTotalDeLaVenta(New Venta().GenerarObjetoVentaParaActualizarTotal(Idventa)).Excepcion.Error Then
                    MessageBox.Show("Producto guardado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el VentaItem se edito correctamente
                    FormEditarVenta.ActivarDataGridViewVentaItem() 'Refresco la grilla cada vez que haga click en el botón'
                    FormVentaPrincipal.ActivarDataGridViewVenta() 'Refresco la grilla cada vez que haga click en el botón'
                Else
                    MessageBox.Show("Error al guardar Total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el VentaItem no se editar correctamente
                End If
            Else
                MessageBox.Show("Error al guardar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el VentaItem no se editar correctamente
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que verifica que los campos Producto(ComboBox), Cantidad(Texbox) y Fecha(DatePiker) no esten vacíos al momento de querer guardarlos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve bool de acuerdo a la verificación</returns>
    Protected Function VerificarCamposProducto() As Boolean
        Dim validado As Boolean

        If cbProducto.SelectedValue <> 0 Then
            validado = True
        Else
            MessageBox.Show("Debes seleccionar una opción en el campo Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtCantidad.Text) Then 'Verifico que el campo Precio no este vacío'
            validado = True
        Else
            MessageBox.Show("El campo Cantidad no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        Return validado = True
    End Function

    ''' <summary>
    '''  Método que rellena el ComboBox de Producto
    ''' </summary>'' 
    Protected Sub ActivarComboBoxProducto()
        Dim productos = ObtenerIDYNombreDelProducto()
        Dim producto = New Producto
        producto.Nombre = "Seleccione un producto" 'Agrego una opción nueva primera en lista

        productos.Insert(0, producto)

        If productos IsNot Nothing AndAlso productos.Count > 0 Then 'Verifico que "productos" no este vacío y no sea nulo
            cbProducto.DataSource = productos
            cbProducto.DisplayMember = "Nombre"
            cbProducto.ValueMember = "Id"
        End If
    End Sub

    ''' <summary>
    '''  Método que guarda la edicion de los datos del ventaItem ya existente en la base de datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Protected Function EditarVentaItemEnBd(ventaItem As VentaItem) As VentaItem
        Dim manager = New ManagerVentaItem()

        ventaItem = manager.EditarVentaItemEnBd(ventaItem)

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion del Total en la base de datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Protected Function ActualizarTotalDeLaVenta(venta As Venta) As Venta
        Dim manager = New ManagerVenta()

        venta = manager.ActualizarTotalDeLaVenta(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList con ID y Nombre de los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerIDYNombreDelProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerIDYNombreDelProducto()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList con todos los datos de un producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerDatosDeProducto(producto)

        Return resultado
    End Function
End Class