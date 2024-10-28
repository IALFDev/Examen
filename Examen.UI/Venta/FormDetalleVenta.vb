Imports Examen.BLL
Imports Examen.Entidad

Public Class FormDetalleVenta
    Protected IdVenta As Long 'Variable para almacenar el IdVenta de la Venta 
    Private Sub FormDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVentaItem()
    End Sub

    ''' <summary>
    '''  Método que obtiene un objeto tipo Venta para rellenar los camplos con la información  del mismo
    ''' </summary>''
    Public Sub RellenarDatosVenta(venta As Venta)
        IdVenta = venta.Id
        lbNombreCliente.Text = venta.Cliente.Cliente
        lbFechaVenta.Text = venta.Fecha.ToString("dd/MM/yyyy")
        lbTotalVenta.Text = Format(venta.Total, "Currency") 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewVentaItem()
        Dim ventasItem = ObtenerVentasItemId(New VentaItem() With {.Id = IdVenta})
        If ventasItem IsNot Nothing AndAlso ventasItem.Count > 0 Then
            dgvVentaItem.DataSource = ventasItem
            dgvVentaItem.Visible = True

            dgvVentaItem.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvVentaItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvVentaItem.Columns.Contains("Venta") Then 'Si la grilla contiene la columna "Venta" la oculto
                dgvVentaItem.Columns("Venta").Visible = False 'Oculto la columna de objeto Venta
            End If

            If dgvVentaItem.Columns.Contains("IdProducto") Then 'Si la grilla contiene la columna "IdProducto" la oculto
                dgvVentaItem.Columns("IdProducto").Visible = False 'Oculto la columna de objeto IdProducto
            End If

            If dgvVentaItem.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaItem.Columns("Producto").Visible = False 'Oculto la columna de objeto Producto
            End If

            If dgvVentaItem.Columns.Contains("NombreProducto") Then 'Si la grilla contiene la columna "NombreProducto" la oculto
                dgvVentaItem.Columns("NombreProducto").HeaderText = "Producto" 'Renombro la columna "NombreProducto" por "Producto"
            End If

            If dgvVentaItem.Columns.Contains("PrecioUnitario") Then
                dgvVentaItem.Columns("PrecioUnitario").HeaderText = "Precio Unitario" 'Renombro la columna "PrecioUnitario" por "Precio Unitario"
                dgvVentaItem.Columns("PrecioUnitario").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVentaItem.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaItem.Columns("Activo").Visible = False
            End If

            If dgvVentaItem.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaItem.Columns("Excepcion").Visible = False
            End If

            If dgvVentaItem.Columns.Contains("PrecioTotal") Then
                dgvVentaItem.Columns("PrecioTotal").HeaderText = "Precio Total" 'Renombro la columna "PrecioTotal" por "Precio Total"
                dgvVentaItem.Columns("PrecioTotal").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que obtiene una collecion de ventasItem por ID desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Protected Function ObtenerVentasItemId(ventasItem As VentaItem) As ArrayList
        Dim manager = New ManagerVentaItem()

        Dim resultado = manager.ObtenerVentasItemId(ventasItem)

        Return resultado
    End Function
End Class