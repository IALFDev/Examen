Imports Examen.BLL
Imports Examen.Entidad

Public Class FormEditarVenta
    Protected IdVenta As Long 'Variable para almacenar el IdVenta de la Venta 
    Private Sub FormDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVentaItem()
        ActivarComboBoxCliente()
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(venta As Venta)
        IdVenta = venta.Id
        'lbNombreCliente.Text = venta.Cliente.Cliente
        dtpFecha.Text = venta.Fecha.ToString("dd/MM/yyyy")
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewVentaItem()
        Dim ventasItem = ObtenerTodasLasVentasItem()
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
        End If

        CalcularTotalGeneral()
    End Sub

    Protected Sub CalcularTotalGeneral()
        Dim decValue As Decimal
        Dim total As Decimal
        For Each row As DataGridViewRow In dgvItemVenta.Rows
            If Decimal.TryParse(row.Cells(6).Value, decValue) Then
                total += decValue
            End If
        Next

        lbTotalVenta.Text = Format(total.ToString(), "Currency") 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda
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
    '''  Método que obtiene una collecion de todas las ventasItem desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Protected Function ObtenerTodasLasVentasItem() As ArrayList
        Dim manager = New ManagerVentaItem()

        Dim resultado = manager.ObtenerTodasLasVentasItem()

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