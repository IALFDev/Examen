Imports Examen.BLL
Imports Examen.Entidad

Public Class FormEditarVenta
    Protected IdVenta As Long 'Variable para almacenar el IdVenta de la Venta 
    Private Sub FormDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Private Sub FormEditarVenta_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LimpiarControles()
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

    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVentaItem()
        ActivarComboBoxProducto()
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(venta As Venta)
        ActivarComboBoxCliente()

        IdVenta = venta.Id
        cbCliente.SelectedValue = venta.Cliente.Id
        dtpFecha.Text = venta.Fecha.ToString("dd/MM/yyyy")
    End Sub

    Private Sub btnGuardarVenta_Click(sender As Object, e As EventArgs) Handles btnGuardarVenta.Click
        If VerificarCamposVenta() Then
            If Not EditarVentaEnBd(New Venta().GenerarObjetoVentaParaGuardarEnBd(IdVenta, cbCliente.SelectedValue, dtpFecha.Value, 0)).Excepcion.Error Then
                MessageBox.Show("Venta guardada.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la venta se edito correctamente

                FormVentaPrincipal.ActivarDataGridViewVenta("Todos") 'Refresco la grilla cada vez que haga click en el botón'
            Else
                MessageBox.Show("Error al guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que la venta no se editar correctamente
            End If
        End If
    End Sub

    Protected Function VerificarCamposVenta()
        Dim validado As Boolean

        If cbCliente.SelectedValue <> 0 Then
            validado = True
        Else
            MessageBox.Show("Debes seleccionar una opción en el campo cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        Return validado = True
    End Function

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewVentaItem()
        Dim ventasItem = ObtenerVentasItemId(New VentaItem() With {.Venta = New Venta() With {.Id = IdVenta}})
        If ventasItem IsNot Nothing AndAlso ventasItem.Count > 0 Then
            dgvItemVenta.DataSource = ventasItem
            dgvItemVenta.Visible = True

            dgvItemVenta.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvItemVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvItemVenta.Columns.Contains("ID") Then 'Si la grilla contiene la columna "ID" la oculto
                dgvItemVenta.Columns("ID").Visible = False 'Oculto la columna de objeto ID
            End If

            If dgvItemVenta.Columns.Contains("Venta") Then 'Si la grilla contiene la columna "Venta" la oculto
                dgvItemVenta.Columns("Venta").Visible = False 'Oculto la columna de objeto Venta
            End If

            If dgvItemVenta.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvItemVenta.Columns("Producto").Visible = False 'Oculto la columna de objeto Producto
            End If

            If dgvItemVenta.Columns.Contains("IdProducto") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvItemVenta.Columns("IdProducto").Visible = False
            End If

            If dgvItemVenta.Columns.Contains("NombreProducto") Then 'Si la grilla contiene la columna "NombreProducto" la oculto
                dgvItemVenta.Columns("NombreProducto").HeaderText = "Producto" 'Renombro la columna "NombreProducto" por "Producto"
            End If

            If dgvItemVenta.Columns.Contains("PrecioUnitario") Then
                dgvItemVenta.Columns("PrecioUnitario").HeaderText = "Precio Unitario" 'Renombro la columna "PrecioUnitario" por "Precio Unitario"
                dgvItemVenta.Columns("PrecioUnitario").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvItemVenta.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvItemVenta.Columns("Activo").Visible = False
            End If

            If dgvItemVenta.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvItemVenta.Columns("Excepcion").Visible = False
            End If

            If dgvItemVenta.Columns.Contains("PrecioTotal") Then
                dgvItemVenta.Columns("PrecioTotal").HeaderText = "Precio Total" 'Renombro la columna "PrecioTotal" por "Precio Total"
                dgvItemVenta.Columns("PrecioTotal").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvItemVenta.Columns("Editar") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales
                'Creo y agrego la columna y el botón "Editar"'
                Dim btnEditar As New DataGridViewButtonColumn()
                btnEditar.Name = "Editar"
                btnEditar.HeaderText = "Editar"
                btnEditar.Text = "Editar"
                btnEditar.UseColumnTextForButtonValue = True
                dgvItemVenta.Columns.Add(btnEditar)

                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvItemVenta.Columns.Add(btnEliminar)
            End If
        End If


    End Sub

    Protected Sub dgvItemVenta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItemVenta.CellClick

        If e.RowIndex >= 0 Then 'Verifico si es una fila válida
            Dim idVentaItem As Long = Long.Parse(dgvItemVenta.Rows(e.RowIndex).Cells("Id").Value.ToString())
            Dim idProducto As Long = Long.Parse(dgvItemVenta.Rows(e.RowIndex).Cells("IDProducto").Value.ToString())
            Dim cantidadProducto As Long = dgvItemVenta.Rows(e.RowIndex).Cells("Cantidad").Value.ToString()
            Dim NombreProducto As String = dgvItemVenta.Rows(e.RowIndex).Cells("NombreProducto").Value.ToString()
            Dim PrecioUnitario As Decimal = dgvItemVenta.Rows(e.RowIndex).Cells("PrecioUnitario").Value.ToString()


            If dgvItemVenta.Columns(e.ColumnIndex).Name = "Editar" Then 'Verifico si se hizo click en el botón "Editar"
                Dim ventaItem = New VentaItem() 'Creo un objeto VentaItem para almacenar los datos de la venta que quiere editar

                ventaItem.Id = idVentaItem
                ventaItem.Venta.Id = IdVenta
                ventaItem.Producto.Id = idProducto
                ventaItem.Producto.Nombre = NombreProducto
                ventaItem.PrecioUnitario = PrecioUnitario
                ventaItem.Cantidad = cantidadProducto

                FormEditarVentaItemProducto.RellenarDatosVenta(ventaItem) 'llamo al metodo en el otro form para ir almacenando los datos de la ventaItem

                FormEditarVentaItemProducto.ShowDialog() 'Muesto el form donde se puede editar los datos de la ventaItem

            ElseIf dgvItemVenta.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el " + NombreProducto + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar la ventaItem
                If result = DialogResult.Yes Then
                    If Not EliminarVentaItemEnBd(New VentaItem().GenerarObjetoVentaItemParaEliminarEnBd(idVentaItem)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                        If Not ActualizarTotalDeLaVenta(New Venta().GenerarObjetoVentaParaActualizarTotal(IdVenta)).Excepcion.Error Then 'Verifico que la actualización del Total en la base sea correcto de lo contrario muestro un MessageBox de error
                            MessageBox.Show("Producto eliminado de la venta correctamnte.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la ventaItem se elimino correctamente'
                            ConfigurarContenido()
                            FormVentaPrincipal.ActivarDataGridViewVenta("")
                        Else
                            MessageBox.Show("Error al guardar Total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el VentaItem no se editar correctamente
                        End If
                    Else
                        MessageBox.Show("Error al eliminar el producto de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que la ventaItem no se guardar correctamente'
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvItemVenta_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvItemVenta.DataBindingComplete
        CalcularTotalGeneral()
    End Sub


    ''' <summary>
    '''  Método que calcula el Precio Total de la compra
    ''' </summary>''
    Protected Sub CalcularTotalGeneral()
        Dim decValue As Decimal
        Dim total As Decimal = 0


        If dgvItemVenta.Columns.Contains("PrecioTotal") Then 'Verifico de que la columna "PrecioTotal" existe antes de intentar acceder a ella
            For Each row As DataGridViewRow In dgvItemVenta.Rows
                If Decimal.TryParse(row.Cells("PrecioTotal").Value, decValue) Then
                    total += decValue
                End If
            Next
        End If

        lbTotalVenta.Text = Format(total.ToString(), "Currency")
    End Sub


    ''' <summary>
    '''  Método que rellena el ComboBox de Cliente
    ''' </summary>'' 
    Protected Sub ActivarComboBoxCliente()
        Dim clientes = ObtenerIDYNombreDelCliente()
        Dim cliente = New Cliente
        cliente.Cliente = "Seleccione un cliente" 'Agrego una opción nueva primera en lista

        clientes.Insert(0, cliente)

        If clientes IsNot Nothing AndAlso clientes.Count > 0 Then 'Verifico que "categorias" no este vacío y no sea nulo
            cbCliente.DataSource = clientes
            cbCliente.DisplayMember = "Cliente"
            cbCliente.ValueMember = "Id"
        End If
    End Sub

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If VerificarCamposProducto() Then
            Dim itemVenta = New VentaItem()
            Dim datosProductos = ObtenerDatosDeProducto(New Producto() With {.Id = cbProducto.SelectedValue})
            Dim producto = New Producto()

            If datosProductos IsNot Nothing Then
                itemVenta.PrecioUnitario = datosProductos(0).Precio
            End If

            If Not GuardarVentaItemEnBD(New VentaItem().GenerarObjetoVentaItemParaGuardarEnBd(IdVenta, cbProducto.SelectedValue, itemVenta.PrecioUnitario, txtCantidad.Text)).Excepcion.Error Then
                If Not ActualizarTotalDeLaVenta(New Venta().GenerarObjetoVentaParaActualizarTotal(IdVenta)).Excepcion.Error Then 'Verifico que la actualización del Total en la base sea correcto de lo contrario muestro un MessageBox de error
                    MessageBox.Show("Producto guardado en la venta correctamnte.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la ventaItem se elimino correctamente'
                    ConfigurarContenido()

                    FormVentaPrincipal.ActivarDataGridViewVenta("Todos") 'Refresco la grilla cada vez que haga click en el botón'

                    cbProducto.SelectedIndex = 0
                    txtCantidad.Text = "1" 'Limpio los campos Producto y Cantidad para que no quede con datos reciduales'
                Else
                    MessageBox.Show("Error al guardar Total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que no se pudo actualizar el Total de la venta en la base de datos
                End If
            Else
                MessageBox.Show("Error al guardar los ItemVenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el Ventaitem no se pudo correctamente'
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
            Dim productoExistente As Boolean = False

            For Each row As DataGridViewRow In dgvItemVenta.Rows
                If row.Cells("IDProducto").Value = cbProducto.SelectedValue Then
                    productoExistente = True
                    Exit For
                End If
            Next

            If productoExistente Then
                MessageBox.Show("El producto " + cbProducto.GetItemText(cbProducto.SelectedItem) + " ya está en la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                validado = False
            End If

        Else
            MessageBox.Show("Debes seleccionar una opción en el campo Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            validado = False
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
    '''  Método que limpia controles despues de realizar alguna acción
    ''' </summary>''
    Protected Sub LimpiarControles()
        dgvItemVenta.Columns.Clear() 'Limpio las columnas de la grilla
        dgvItemVenta.DataSource = Nothing 'Limpio el datasourse de la grilla
        dgvItemVenta.Rows.Clear() ''Limpio las filas de la grilla
    End Sub

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto VentaItem desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaItemEnBD(ventaItem As VentaItem) As VentaItem
        Dim manager = New ManagerVentaItem()

        ventaItem = manager.GuardarVentaItemEnBD(ventaItem)

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del venta ya existente en la base de datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Protected Function EditarVentaEnBd(venta As Venta) As Venta
        Dim manager = New ManagerVenta()

        venta = manager.EditarVentaEnBd(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que elimina la venta de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de eliminación del venta en la base datos</returns>
    Protected Function EliminarVentaItemEnBd(ventaItem As VentaItem) As VentaItem
        Dim manager = New ManagerVentaItem()

        ventaItem = manager.EliminarVentaItemEnBd(ventaItem)

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
    '''  Método que obtiene una collecion del tipo ArrayList con el ID y Nombre de los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerIDYNombreDelCliente() As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerIDYNombreDelCliente()

        Return resultado
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
    '''  Método que obtiene una collecion de ventasItem por ID desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Protected Function ObtenerVentasItemId(ventasItem As VentaItem) As ArrayList
        Dim manager = New ManagerVentaItem()

        Dim resultado = manager.ObtenerVentasItemId(ventasItem)

        Return resultado
    End Function

    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerDatosDeProducto(producto)

        Return resultado
    End Function
End Class