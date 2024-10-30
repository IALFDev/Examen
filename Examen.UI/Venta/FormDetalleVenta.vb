Imports System.Environment
Imports System.IO
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
        Dim ventasItem = ObtenerVentasItemId(New VentaItem() With {.Venta = New Venta() With {.Id = IdVenta}})
        If ventasItem IsNot Nothing AndAlso ventasItem.Count > 0 Then
            dgvVentaItem.DataSource = ventasItem
            dgvVentaItem.Visible = True

            dgvVentaItem.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvVentaItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvVentaItem.Columns.Contains("Id") Then 'Si la grilla contiene la columna "Id" la oculto
                dgvVentaItem.Columns("Id").Visible = False 'Oculto la columna de objeto Id
            End If

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

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        MostarSaveDialog()
    End Sub

    ''' <summary>
    '''  Método muestra un ShowOpenDialog obtiene la ruta, nombre y el tipo de reporte para genenar un reporte en PDF
    ''' </summary>
    Public Sub MostarSaveDialog()
        Dim saveFileD As New SaveFileDialog
        saveFileD.InitialDirectory = GetFolderPath(SpecialFolder.Desktop)
        saveFileD.Title = "Guardar reporte"
        saveFileD.FileName = String.Format("Reporte Detalle Venta #{0}", IdVenta)
        saveFileD.CheckPathExists = True
        saveFileD.DefaultExt = "*pdf"
        saveFileD.Filter = "PDF (*.pdf)|*.pdf|All Files|*.*"
        saveFileD.FilterIndex = 1
        saveFileD.RestoreDirectory = True

        Dim diag As DialogResult = saveFileD.ShowDialog()
        Dim ventaItem = New VentaItem()
        ventaItem.Venta.Id = IdVenta

        If diag = DialogResult.OK Then 'Verifico que el se haya seleccionado la ruta para guardar el reporte

            Dim path = saveFileD.FileName 'Obtengo la dirección completa del reporte a guardar
            Dim directory As String = New FileInfo(path).DirectoryName 'Separo la carpeta donde se va a guardar el reporte
            Dim file As String = New FileInfo(path).Name 'Separo la el nombre del reporte

            If Not GenerarReportePDF(New PDF().GenerarObjetoParaReportePDF(file, directory, "DetalleVenta", String.Empty, Nothing, Nothing, Nothing, ventaItem)).Excepcion.Error Then 'Verifico que el reporte se haya generado correctamente
                MessageBox.Show("Se genero el reporte correctamente", "Genial", MessageBoxButtons.OK, MessageBoxIcon.None) 'Si el reporte se genero correctamente muesto un MessageBox

            ElseIf diag = DialogResult.Cancel Then
                MessageBox.Show("Se cancelo la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si no se selecciono una ruta muesto un MessageBox
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

    ''' <summary>
    '''  Método reporte para genenar un reporte en PDF desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo PDF con el resultado de la operación que genera el PDF</returns>
    Protected Function GenerarReportePDF(pdf As PDF) As PDF
        Dim manager = New ManagerPDF()

        pdf = manager.GenerarReportePDF(pdf)

        Return pdf
    End Function
End Class