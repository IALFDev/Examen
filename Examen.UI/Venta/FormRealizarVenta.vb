Imports System.ComponentModel
Imports System.Net.Mime.MediaTypeNames
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormRealizarVenta
    Protected listVentaItemProductos As BindingList(Of VentaItem) = New BindingList(Of VentaItem)() 'Variable para almacenar los productos en la grilla
    Protected totalGeneral As Decimal 'Variable para almacenar el total general

    Private Sub FormRealizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Private Sub FormRealizarVenta_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LimpiarControles()
        ActivarDataGridViewVentaItemProducto() 'Refresco la grilla
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarComboBoxCliente()
        ActivarComboBoxProducto()
    End Sub

    Private Sub chkbHoy_CheckedChanged(sender As Object, e As EventArgs) Handles chkbHoy.CheckedChanged
        dtpFecha.Enabled = Not chkbHoy.Checked
    End Sub

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If VerificarCamposProducto() Then

            Dim productoCoincidente = listVentaItemProductos.Cast(Of VentaItem)().FirstOrDefault(Function(vi) vi.Producto.Id = Long.Parse(cbProducto.SelectedValue.ToString())) 'Buscar el producto correspondiente en listVentaItemProductos

            If productoCoincidente Is Nothing Then ' Verifico si el producto ya fue agregado a la lista
                listVentaItemProductos.Add(New VentaItem() With {
                    .Producto = New Producto() With {.Id = Long.Parse(cbProducto.SelectedValue.ToString())},
                    .Cantidad = Long.Parse(txtCantidad.Text)
                })

                cbProducto.SelectedIndex = 0
                txtCantidad.Text = "1"
            Else
                MessageBox.Show("Ya has agregado el producto " + cbProducto.GetItemText(cbProducto.SelectedItem) + " a lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ActivarDataGridViewVentaItemProducto()
        End If

    End Sub

    ''' <summary>
    '''  Método que busca en la base de datos los datos del producto por el Id
    ''' </summary>
    Protected Function RellenarDatosProducto(productos As BindingList(Of VentaItem)) As BindingList(Of VentaItem)

        For Each dato In productos
            Dim productoDatos As ArrayList = ObtenerDatosDeProducto(New Producto() With {.Id = dato.Producto.Id})

            Dim productoCoincidente = productoDatos.Cast(Of Producto)().FirstOrDefault(Function(pd) pd.Id = dato.Producto.Id) 'Buscar el producto correspondiente en el ArrayList

            If productoCoincidente IsNot Nothing Then
                dato.PrecioUnitario = productoCoincidente.Precio
                dato.Producto.Nombre = productoCoincidente.Nombre
            End If
        Next
        Return productos
    End Function

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Public Sub ActivarDataGridViewVentaItemProducto()
        If listVentaItemProductos IsNot Nothing AndAlso listVentaItemProductos.Count <> 0 Then

            lbNumTotalGeneral.Text = "0" 'Limpio la etiqueta para que no quede ningun valor recidual

            listVentaItemProductos = RellenarDatosProducto(listVentaItemProductos)

            dgvVentaProducto.DataSource = listVentaItemProductos

            dgvVentaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            dgvVentaProducto.EditMode = DataGridViewEditMode.EditProgrammatically

            If dgvVentaProducto.Columns.Contains("Venta") Then 'Si la grilla contiene la columna "Venta" la oculto
                dgvVentaProducto.Columns("Venta").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Id") Then 'Si la grilla contiene la columna "Id" la oculto
                dgvVentaProducto.Columns("Id").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("IdProducto") Then 'Si la grilla contiene la columna "IdProducto" la oculto
                dgvVentaProducto.Columns("IdProducto").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("Producto").Visible = False 'Oculta la columna de objeto Producto
            End If

            If dgvVentaProducto.Columns.Contains("NombreProducto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("NombreProducto").HeaderText = "Producto" 'Renombro la columna "NombreProducto" por "Producto"
            End If

            If dgvVentaProducto.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("Producto").Visible = False ' Elimina la columna de objeto Producto
            End If

            If dgvVentaProducto.Columns.Contains("PrecioUnitario") Then
                dgvVentaProducto.Columns("PrecioUnitario").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVentaProducto.Columns.Contains("PrecioTotal") Then
                dgvVentaProducto.Columns("PrecioTotal").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVentaProducto.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaProducto.Columns("Activo").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaProducto.Columns("Excepcion").Visible = False
            End If

            If dgvVentaProducto.Columns("Eliminar") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales
                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvVentaProducto.Columns.Add(btnEliminar)
            End If

            dgvVentaProducto.AllowUserToAddRows = False ' Desactivar la fila de nueva fila

            CalcularTotalGeneral() 'Calculo el total general
        End If
    End Sub

    Protected Sub dgvVentaProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentaProducto.CellClick
        If e.RowIndex >= 0 Then 'Verifico si es una fila válida

            Dim ventaItem As VentaItem = CType(dgvVentaProducto.Rows(e.RowIndex).DataBoundItem, VentaItem) ' Obtener el objeto VentaItem de la fila
            Dim idProducto As Long = ventaItem.Producto.Id
            Dim nombreProducto As String = ventaItem.NombreProducto

            If dgvVentaProducto.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el producto " + nombreProducto + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar el cliente
                If result = DialogResult.Yes Then
                    ' Eliminar el producto directamente de la lista
                    listVentaItemProductos.Remove(ventaItem)

                    ActivarDataGridViewVentaItemProducto()

                    lbNumTotalGeneral.Text = "$0" 'Limpio la etiqueta para que no quede ningun valor recidual
                End If
            End If
        End If
    End Sub

    Private Sub dgvVentaProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentaProducto.CellContentClick
        If e.ColumnIndex = 6 Then
            dgvVentaProducto.CurrentCell = dgvVentaProducto(6, e.RowIndex)
            dgvVentaProducto.BeginEdit(True)
        End If
    End Sub

    Private Sub dgvVentaProducto_EndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentaProducto.CellEndEdit
        If e.ColumnIndex = 6 Then
            Dim ventaItem As VentaItem = CType(dgvVentaProducto.Rows(e.RowIndex).DataBoundItem, VentaItem) ' Obtener el objeto VentaItem de la fila editada


            Dim nuevaCantidad As Integer 'Obtener el nuevo valor de la celda editada


            If Integer.TryParse(dgvVentaProducto.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), nuevaCantidad) Then
                If nuevaCantidad.ToString() <> "0"c Or nuevaCantidad <> 0 Then
                    ventaItem.Cantidad = nuevaCantidad 'Actualizar la propiedad Cantidad en el objeto VentaItem
                Else
                    MessageBox.Show("La cantidad debe ser mayor a 0.", "Atención")
                    dgvVentaProducto.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ventaItem.Cantidad ' Revertir al valor anterior
                End If
            Else
                MessageBox.Show("Ingrese una cantidad válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvVentaProducto.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ventaItem.Cantidad ' Revertir al valor anterior
            End If

            ActivarDataGridViewVentaItemProducto()
        End If
    End Sub

    Private Sub dgvVentaProducto_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvVentaProducto.DataBindingComplete
        CalcularTotalGeneral()
    End Sub

    ''' <summary>
    '''  Método que suma el total de cada VentaItem y lo muesto en pantalla cada vez que actualiza la grilla
    ''' </summary>''
    Protected Sub CalcularTotalGeneral()
        Dim decValue As Decimal
        Dim total As Decimal = 0

        If dgvVentaProducto.Columns.Contains("PrecioTotal") Then 'Verifico de que la columna "PrecioTotal" existe antes de intentar acceder a ella
            For Each row As DataGridViewRow In dgvVentaProducto.Rows
                If Decimal.TryParse(row.Cells("PrecioTotal").Value, decValue) Then
                    total += decValue
                End If
            Next
        End If
        totalGeneral = total
        lbNumTotalGeneral.Text = Format(total.ToString(), "Currency")
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

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        If VerificarCamposVenta() Then
            If listVentaItemProductos.Count <> 0 Then
                Dim venta As Venta = New Venta().GenerarObjetoVentaParaGuardarEnBd(cbCliente.SelectedValue, If(chkbHoy.Checked, DateTime.Now, dtpFecha.Value), totalGeneral) 'Asigno guardo la venta en la base de datos y recupero el Id de esa venta

                If Not GuardarVentaEnBD(venta).Excepcion.Error Then 'Verifico que el guardado en la base sea correcto de lo contrario muestro un MessageBox de error
                    For Each item As VentaItem In listVentaItemProductos 'Asigno el id de la venta a toda la lista
                        item.Venta.Id = venta.Id
                    Next

                    Dim ventaItem As List(Of VentaItem) = listVentaItemProductos.ToList()

                    If Not GuardarVentaItemEnBD(ventaItem).Excepcion.Error Then
                        MessageBox.Show("Venta guardada con éxito.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el cliente se guardo correctamente'

                        LimpiarControles() 'Limpio los campos Producto y Cantidad para que no quede con datos reciduales'

                        FormVentaPrincipal.ActivarDataGridViewVenta("Todos") 'Refresco la grilla cada vez que haga click en el botón'
                    Else
                        MessageBox.Show("Error al guardar los ItemVenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el cliente no se guardar correctamente'
                    End If
                Else
                    MessageBox.Show("Error al guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el cliente no se guardar correctamente'
                End If
            Else
                MessageBox.Show("No has agregado productos a la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    ''' <summary>
    '''  Método que limpia controles despues de realizar alguna acción
    ''' </summary>''
    Protected Sub LimpiarControles()
        listVentaItemProductos.Clear() 'Cuando se cierre la ventana limpio la variable
        dgvVentaProducto.Columns.Clear() 'Limpio las columnas de la grilla
        dgvVentaProducto.DataSource = Nothing 'Limpio el datasourse de la grilla
        dgvVentaProducto.Rows.Clear() ''Limpio las filas de la grilla
        lbNumTotalGeneral.Text = "$0" 'Limpio la etiqueta para que no quede ningun valor recidual
    End Sub

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Venta desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaEnBD(venta As Venta) As Venta
        Dim manager = New ManagerVenta()

        venta = manager.GuardarVentaEnBD(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto VentaItem desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaItemEnBD(listVemtaItem As List(Of VentaItem)) As VentaItem
        Dim manager = New ManagerVentaItem()
        Dim ventaItem = New VentaItem()

        ventaItem = manager.GuardarVentaItemEnBD(listVemtaItem)

        Return ventaItem
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
    '''  Método que obtiene una collecion tipo ArrayList con todos los datos de un producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerDatosDeProducto(producto)

        Return resultado
    End Function
End Class