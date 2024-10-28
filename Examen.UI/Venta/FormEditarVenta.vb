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

    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVentaItem()
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(venta As Venta)
        ActivarComboBoxCliente()

        IdVenta = venta.Id
        cbCliente.SelectedIndex = venta.Cliente.Id
        dtpFecha.Text = venta.Fecha.ToString("dd/MM/yyyy")
    End Sub

    Private Sub btnGuardarVenta_Click(sender As Object, e As EventArgs) Handles btnGuardarVenta.Click
        If VerificarCamposVenta() Then
            If Not EditarVentaEnBd(New Venta().GenerarObjetoVentaParaGuardarEnBd(IdVenta, cbCliente.SelectedValue, dtpFecha.Value, 0)).Excepcion.Error Then
                MessageBox.Show("Venta guardada.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la venta se edito correctamente

                FormVentaPrincipal.ActivarDataGridViewVenta() 'Refresco la grilla cada vez que haga click en el botón'
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
        Dim ventasItem = ObtenerVentasItemId(New VentaItem() With {.Id = IdVenta})
        If ventasItem IsNot Nothing AndAlso ventasItem.Count > 0 Then
            dgvItemVenta.DataSource = ventasItem
            dgvItemVenta.Visible = True

            dgvItemVenta.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvItemVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

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


            If dgvItemVenta.Columns(e.ColumnIndex).Name = "Editar" Then 'Verifico si se hizo click en el botón "Editar"
                Dim ventaItem = New VentaItem() 'Creo un objeto VentaItem para almacenar los datos de la venta que quiere editar

                ventaItem.Id = idVentaItem
                ventaItem.Venta.Id = IdVenta
                ventaItem.Producto.Id = idProducto
                ventaItem.Cantidad = cantidadProducto

                FormEditarVentaItemProducto.RellenarDatosVenta(ventaItem) 'llamo al metodo en el otro form para ir almacenando los datos de la ventaItem

                FormEditarVentaItemProducto.ShowDialog() 'Muesto el form donde se puede editar los datos de la ventaItem

            ElseIf dgvItemVenta.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                'Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el cliente " + nombreCliente + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar el cliente
                'If result = DialogResult.Yes Then
                '    If Not EliminarClienteEnBd(New Cliente().GenerarObjetoClienteParaEliminarEnBd(idCliente)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                '        MessageBox.Show("Cliente eliminado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el cliente se elimino correctamente'
                '        ConfigurarContenido()
                '    Else
                '        MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el cliente no se guardar correctamente'
                '    End If
                'End If
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
    '''  Método que limpia controles despues de realizar alguna acción
    ''' </summary>''
    Protected Sub LimpiarControles()
        dgvItemVenta.Columns.Clear() 'Limpio las columnas de la grilla
        dgvItemVenta.DataSource = Nothing 'Limpio el datasourse de la grilla
        dgvItemVenta.Rows.Clear() ''Limpio las filas de la grilla
    End Sub

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
    '''  Método que obtiene una collecion de ventasItem por ID desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Protected Function ObtenerVentasItemId(ventasItem As VentaItem) As ArrayList
        Dim manager = New ManagerVentaItem()

        Dim resultado = manager.ObtenerVentasItemId(ventasItem)

        Return resultado
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
End Class