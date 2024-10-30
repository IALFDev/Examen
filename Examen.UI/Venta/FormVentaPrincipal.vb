Imports System.ComponentModel
Imports System.Environment
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormVentaPrincipal
    Dim ultimaBusqueda As String = String.Empty 'Guardo cual fue la ultima busqueda para hacer el reporte

    Private Sub FormVentaPrincial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub
    Private Sub FormVentaPrincial_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LimpiarControles()
    End Sub

    Private Sub txtIdVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdVenta.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub txtRangoDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRangoDesde.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub txtRangoHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRangoHasta.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVenta("Todos")
        ultimaBusqueda = "Todos" 'Acá seria que la ultima busqueda fue "Todos"
        EstablecarFechas()
    End Sub

    Protected Sub EstablecarFechas()
        Dim fechaActual As DateTime = DateTime.Now 'Obtengo la fecha actual
        Dim primerDiaMes As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, 1) 'Primer día del mes
        Dim ultimoDiaMes As DateTime = primerDiaMes.AddMonths(1).AddDays(-1) 'Último día del mes

        dtpFechaDesde.Value = primerDiaMes
        dtpFechaHasta.Value = ultimoDiaMes
    End Sub

    Private Sub btnRealizarVenta_Click(sender As Object, e As EventArgs) Handles btnRealizarVenta.Click
        FormRealizarVenta.ShowDialog() 'Muesto el form donde se puede realziar las nuevas ventas
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        ActivarDataGridViewVenta("Filtro")
        ultimaBusqueda = "Filtro" 'Acá seria que la ultima busqueda fue "Filtro"
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewVenta(tipoOp As String)
        Dim ventas As ArrayList = Nothing

        Select Case tipoOp
            Case "Todos"
                ventas = ObtenerTodasLasVentas()
            Case "Filtro"
                ventas = ObtenerVentas(txtIdVenta.Text, txtNombreCliente.Text, dtpFechaDesde.Text, dtpFechaHasta.Text, txtRangoDesde.Text, txtRangoHasta.Text)
        End Select

        If ventas IsNot Nothing AndAlso ventas.Count > 0 Then
            dgvVenta.DataSource = ventas
            dgvVenta.Visible = True
            lbNoResultados.Visible = False
            btnGenerarReporte.Enabled = True

            dgvVenta.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvVenta.Columns.Contains("Cliente") Then 'Si la grilla contiene la columna "Clinte" la oculto
                dgvVenta.Columns("Cliente").Visible = False 'Oculto la columna de objeto Clinte
            End If

            If dgvVenta.Columns.Contains("NombreCliente") Then 'Si la grilla contiene la columna "NombreCliente" la oculto
                dgvVenta.Columns("NombreCliente").HeaderText = "Cliente" 'Renombro la columna "NombreCliente" por "Cliente"
            End If

            If dgvVenta.Columns.Contains("Fecha") Then
                dgvVenta.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy" 'Convierto el tipo de dato a tipo "dd/MM/yyyy"
            End If

            If dgvVenta.Columns.Contains("FechaDesde") Then 'Si la grilla contiene la columna "FechaDesde" la oculto
                dgvVenta.Columns("FechaDesde").Visible = False
            End If

            If dgvVenta.Columns.Contains("FechaHasta") Then 'Si la grilla contiene la columna "FechaHasta" la oculto
                dgvVenta.Columns("FechaHasta").Visible = False
            End If

            If dgvVenta.Columns.Contains("IdCliente") Then 'Si la grilla contiene la columna "IdCliente" la oculto
                dgvVenta.Columns("IdCliente").Visible = False
            End If

            If dgvVenta.Columns.Contains("TotalMinimo") Then 'Si la grilla contiene la columna "IdCliente" la oculto
                dgvVenta.Columns("TotalMinimo").Visible = False
            End If

            If dgvVenta.Columns.Contains("TotalMaximo") Then 'Si la grilla contiene la columna "IdCliente" la oculto
                dgvVenta.Columns("TotalMaximo").Visible = False
            End If

            If dgvVenta.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVenta.Columns("Activo").Visible = False
            End If

            If dgvVenta.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVenta.Columns("Excepcion").Visible = False
            End If

            If dgvVenta.Columns.Contains("Total") Then
                dgvVenta.Columns("Total").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVenta.Columns("Detalles") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales

                'Creo y agrego la columna y el botón "Detalles"'
                Dim btnDetalles As New DataGridViewButtonColumn()
                btnDetalles.Name = "Detalles"
                btnDetalles.HeaderText = "Detalles"
                btnDetalles.Text = "Detalles"
                btnDetalles.UseColumnTextForButtonValue = True
                dgvVenta.Columns.Add(btnDetalles)

                'Creo y agrego la columna y el botón "Editar"'
                Dim btnEditar As New DataGridViewButtonColumn()
                btnEditar.Name = "Editar"
                btnEditar.HeaderText = "Editar"
                btnEditar.Text = "Editar"
                btnEditar.UseColumnTextForButtonValue = True
                dgvVenta.Columns.Add(btnEditar)

                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvVenta.Columns.Add(btnEliminar)
            End If
        Else
            dgvVenta.Visible = False
            lbNoResultados.Visible = True
            btnGenerarReporte.Enabled = False
        End If
    End Sub

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellClick

        If e.RowIndex >= 0 Then 'Verifico si es una fila válida
            Dim idVenta As Long = Long.Parse(dgvVenta.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim IdCliente As Long = dgvVenta.Rows(e.RowIndex).Cells("IdCliente").Value.ToString()
            Dim nombreCliente As String = dgvVenta.Rows(e.RowIndex).Cells("NombreCliente").Value.ToString()
            Dim fechaVenta As DateTime = dgvVenta.Rows(e.RowIndex).Cells("Fecha").Value.ToString()
            Dim TotalVenta As Decimal = dgvVenta.Rows(e.RowIndex).Cells("Total").Value.ToString()

            If e.ColumnIndex >= 0 Then 'Verifico si es una columna válida
                If dgvVenta.Columns(e.ColumnIndex).Name = "Detalles" Then 'Verifico si se hizo click en el botón "Editar"
                    Dim venta = New Venta() 'Creo un objeto Venta para almacenar los datos de la venta que quiere editar

                    venta.Id = idVenta
                    venta.Cliente.Cliente = nombreCliente
                    venta.Fecha = fechaVenta
                    venta.Total = TotalVenta

                    FormDetalleVenta.RellenarDatosVenta(venta) 'llamo al metodo en el otro form para ir almacenando los datos de la venta 

                    FormDetalleVenta.ShowDialog() 'Muesto el form donde se puede editar los datos de la venta

                ElseIf dgvVenta.Columns(e.ColumnIndex).Name = "Editar" Then 'Verifico si se hizo click en el botón "Editar"
                    Dim venta = New Venta() 'Creo un objeto Venta para almacenar los datos de la venta que quiere editar

                    venta.Id = idVenta
                    venta.Cliente.Id = IdCliente
                    venta.Fecha = fechaVenta
                    venta.Total = TotalVenta

                    FormEditarVenta.RellenarDatosVenta(venta) 'llamo al metodo en el otro form para ir almacenando los datos de la venta 

                    FormEditarVenta.ShowDialog() 'Muesto el form donde se puede editar los datos de la venta

                ElseIf dgvVenta.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                    Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar la venta con el Id " + idVenta.ToString() + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar la venta
                    If result = DialogResult.Yes Then
                        If Not EliminarVentaItemPorIdVentaEnBd(New VentaItem().GenerarObjetoVentaItemPorIdVentaParaEliminarEnBd(idVenta)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                            If Not EliminarVentaEnBd(New Venta().GenerarObjetoVentaParaEliminarEnBd(idVenta)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                                MessageBox.Show("Venta eliminada.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la venta se elimino correctamente'
                                ConfigurarContenido()
                            Else
                                MessageBox.Show("Error al eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que la venta no se guardar correctamente'
                            End If
                        Else
                            MessageBox.Show("Error al eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que la venta no se guardar correctamente'
                        End If
                    End If
                End If
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
        saveFileD.FileName = "Reporte Ventas"
        saveFileD.CheckPathExists = True
        saveFileD.DefaultExt = "*pdf"
        saveFileD.Filter = "PDF (*.pdf)|*.pdf|All Files|*.*"
        saveFileD.FilterIndex = 1
        saveFileD.RestoreDirectory = True

        Dim diag As DialogResult = saveFileD.ShowDialog()
        Dim venta = New Venta()


        Select Case ultimaBusqueda
            Case "Filtro"
                venta.Id = If(String.IsNullOrEmpty(txtIdVenta.Text), 0, Long.Parse(txtIdVenta.Text))
                venta.Cliente.Cliente = txtNombreCliente.Text
                venta.FechaDesde = dtpFechaDesde.Value
                venta.FechaHasta = dtpFechaHasta.Value
                venta.TotalMinimo = If(String.IsNullOrEmpty(txtRangoDesde.Text), 0, Long.Parse(txtRangoDesde.Text))
                venta.TotalMaximo = If(String.IsNullOrEmpty(txtRangoHasta.Text), 0, Long.Parse(txtRangoHasta.Text))
        End Select

        If diag = DialogResult.OK Then 'Verifico que el se haya seleccionado la ruta para guardar el reporte

            Dim path = saveFileD.FileName 'Obtengo la dirección completa del reporte a guardar
            Dim directory As String = New FileInfo(path).DirectoryName 'Separo la carpeta donde se va a guardar el reporte
            Dim file As String = New FileInfo(path).Name 'Separo la el nombre del reporte

            If Not GenerarReportePDF(New PDF().GenerarObjetoParaReportePDF(file, directory, "Ventas", ultimaBusqueda, venta, Nothing, Nothing, Nothing)).Excepcion.Error Then 'Verifico que el reporte se haya generado correctamente
                MessageBox.Show("Se genero el reporte correctamente", "Genial", MessageBoxButtons.OK, MessageBoxIcon.None) 'Si el reporte se genero correctamente muesto un MessageBox

            ElseIf diag = DialogResult.Cancel Then
                MessageBox.Show("Se cancelo la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si no se selecciono una ruta muesto un MessageBox
            End If
        End If
    End Sub

    Private Sub btnGenerarReporteProductos_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteProductos.Click
        FormGenerarReporteProductos.ShowDialog()
    End Sub

    ''' <summary>
    '''  Método que limpia controles despues de realizar alguna acción
    ''' </summary>''
    Protected Sub LimpiarControles()
        dgvVenta.Columns.Clear() 'Limpio las columnas de la grilla
        dgvVenta.DataSource = Nothing 'Limpio el datasourse de la grilla
        dgvVenta.Rows.Clear() ''Limpio las filas de la grilla
    End Sub

    ''' <summary>
    '''  Método que elimina la venta de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de eliminación la ventaItem en la base datos</returns>
    Protected Function EliminarVentaEnBd(venta As Venta) As Venta
        Dim manager = New ManagerVenta()

        venta = manager.EliminarVentaEnBd(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que elimina la ventaItem por Id de venta de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operación de eliminación la ventaItem en la base datos</returns>
    Protected Function EliminarVentaItemPorIdVentaEnBd(ventaItem As VentaItem) As VentaItem
        Dim manager = New ManagerVentaItem()

        ventaItem = manager.EliminarVentaItemPorIdVentaEnBd(ventaItem)

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todas las ventas desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Protected Function ObtenerTodasLasVentas() As ArrayList
        Dim manager = New ManagerVenta()

        Dim resultado = manager.ObtenerTodasLasVentas()

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

    ''' <summary>
    '''  Método que obtiene una collecion los venta desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Protected Function ObtenerVentas(Optional idVenta As String = "", Optional clienteNombre As String = "", Optional fechaDesde As String = "", Optional fechaHasta As String = "", Optional totalMinimo As String = "", Optional totalMaximo As String = "") As ArrayList
        Dim manager = New ManagerVenta()

        Dim resultado = manager.ObtenerVentas(idVenta, clienteNombre, fechaDesde, fechaHasta, totalMinimo, totalMaximo)

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