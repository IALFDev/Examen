Imports Examen.BLL
Imports Examen.Entidad

Public Class FormEditarVentaItemProducto
    Protected IdventaItem As Long 'Variable para almacenar el Id de VentaItem a editar
    Protected Idventa As Long 'Variable para almacenar el Id de Idventa a editar
    Protected IdProducto As Long 'Variable para almacenar el Id del producto a editar

    Private Sub FormEditarVentaItemProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Protected Sub ConfigurarContenido()
        txtPrecioUnitario.Text = Format(txtPrecioUnitario.Text, "Currency") 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda al iniciar la ventana
    End Sub

    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecioUnitario.LostFocus
        txtPrecioUnitario.Text = Format(txtPrecioUnitario.Text, "Currency") 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then 'Permite la tecla Enter
            e.Handled = False
        ElseIf Asc(e.KeyChar) = 8 Then 'Permite la tecla de retroceso (Backspace) solo si hay más de un carácter en el campo
            If sender.Text.Length = 1 Then
                MessageBox.Show("No se puede borrar el último carácter.", "Atención")
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf Not Char.IsDigit(e.KeyChar) Then 'Bloquea caracteres que no son números
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        ElseIf sender.Text.Length = 0 And e.KeyChar = "0"c Then 'Bloquea el ingreso de "0" como primer carácter
            MessageBox.Show("El primer dígito no puede ser 0.", "Atención")
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(ventaItem As VentaItem)
        IdventaItem = ventaItem.Id
        txtNompreProducto.Text = ventaItem.Producto.Nombre
        IdProducto = ventaItem.Producto.Id
        txtPrecioUnitario.Text = ventaItem.PrecioUnitario
        txtCantidad.Text = ventaItem.Cantidad
        Idventa = ventaItem.Venta.Id
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        If VerificarCamposProducto() Then
            Dim itemVenta = New VentaItem()
            Dim producto = New Producto()

            If Not EditarVentaItemEnBd(New VentaItem().GenerarObjetoVentaItemParaGuardarEnBd(IdventaItem, Idventa, IdProducto, Decimal.Parse(txtPrecioUnitario.Text), Integer.Parse(txtCantidad.Text))).Excepcion.Error Then
                If Not ActualizarTotalDeLaVenta(New Venta().GenerarObjetoVentaParaActualizarTotal(Idventa)).Excepcion.Error Then
                    MessageBox.Show("Producto guardado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el VentaItem se edito correctamente
                    FormEditarVenta.ActivarDataGridViewVentaItem() 'Refresco la grilla cada vez que haga click en el botón'
                    FormVentaPrincipal.ActivarDataGridViewVenta("Todos") 'Refresco la grilla cada vez que haga click en el botón'
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
        Dim validado As Boolean = False

        If Not String.IsNullOrEmpty(txtCantidad.Text) Then 'Verifico que el campo Precio no este vacío'
            Dim cantidad As Integer

            If Integer.TryParse(txtCantidad.Text, cantidad) Then ' Intento convertir el texto a un número decimal

                If cantidad <> 0 Then 'Verifico que el valor no sea 0
                    validado = True
                Else
                    MessageBox.Show("El campo Cantidad no debe ser 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    validado = False

                    Return validado
                End If
            Else
                MessageBox.Show("El campo Cantidad debe ser un número válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Cantidad no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtPrecioUnitario.Text) Then ' Verifico que el campo Precio no esté vacío
            Dim precioUnitario As Decimal

            If Decimal.TryParse(txtPrecioUnitario.Text, precioUnitario) Then ' Intento convertir el texto a un número decimal

                If precioUnitario <> 0 Then 'Verifico que el valor no sea 0
                    validado = True
                Else
                    MessageBox.Show("El campo Precio Unitario no debe ser 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    validado = False

                    Return validado
                End If
            Else
                MessageBox.Show("El campo Precio Unitario debe ser un número válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Precio Unitario no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validado = False

            Return validado
        End If

        Return validado
    End Function

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
End Class