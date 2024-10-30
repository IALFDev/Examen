Imports System.Environment
Imports System.IO
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormProductoPrincipal
    Dim ultimaBusqueda As String = String.Empty 'Guardo cual fue la ultima busqueda para hacer el reporte
    Private Sub FormProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewProducto("Todos")
        ultimaBusqueda = "Todos" 'Acá seria que la ultima busqueda fue "Todos"
        ActivarComboBoxCategoria()
    End Sub

    Private Sub txtIdProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdProducto.KeyPress
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        ActivarDataGridViewProducto("Filtro")
        ultimaBusqueda = "Filtro" 'Acá seria que la ultima busqueda fue "Filtro"
    End Sub

    Private Sub txtIdProducto_LostFocus(sender As Object, e As EventArgs) Handles txtIdProducto.LostFocus
        If Not IsNumeric(txtIdProducto.Text) And Trim(txtIdProducto.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdProducto.Clear() 'Limpio el campo con el dato ingresado incorrecto
        End If
    End Sub

    Private Sub txtRangoDesde_LostFocus(sender As Object, e As EventArgs) Handles txtRangoDesde.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Clear() 'Limpio el campo con el dato ingresado incorrecto
        End If

    End Sub

    Private Sub txtRangoHasta_LostFocus(sender As Object, e As EventArgs) Handles txtRangoHasta.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Clear() 'Limpio el campo con el dato ingresado incorrecto
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        FormAgregarProducto.ShowDialog() 'Muesto el form donde se puede agregar nuevos productos
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Public Sub ActivarDataGridViewProducto(tipoOp As String)
        Dim productos As ArrayList = Nothing

        Select Case tipoOp
            Case "Todos"
                productos = ObtenerTodosLosProductos()
            Case "Filtro"
                productos = ObtenerProductos(txtIdProducto.Text, txtNombreProducto.Text, cbCategoriaProducto.GetItemText(cbCategoriaProducto.SelectedItem), txtRangoDesde.Text, txtRangoHasta.Text)
        End Select

        If productos IsNot Nothing AndAlso productos.Count > 0 Then 'Verifico que "productos" no este vacío y no sea nulo
            dgvProducto.DataSource = productos
            dgvProducto.Visible = True
            lbNoResultados.Visible = False
            btnReporte.Enabled = True

            dgvProducto.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvProducto.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvProducto.Columns("Activo").Visible = False
            End If

            If dgvProducto.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvProducto.Columns("Excepcion").Visible = False
            End If

            If dgvProducto.Columns.Contains("Precio") Then
                dgvProducto.Columns("Precio").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvProducto.Columns("Editar") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales

                'Creo y agrego la columna y el botón "Editar"'
                Dim btnEditar As New DataGridViewButtonColumn()
                btnEditar.Name = "Editar"
                btnEditar.HeaderText = "Editar"
                btnEditar.Text = "Editar"
                btnEditar.UseColumnTextForButtonValue = True
                dgvProducto.Columns.Add(btnEditar)

                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvProducto.Columns.Add(btnEliminar)
            End If
        Else
            dgvProducto.Visible = False
            lbNoResultados.Visible = True
            btnReporte.Enabled = False
        End If

    End Sub

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellClick

        If e.RowIndex >= 0 Then 'Verifico si es una fila válida
            Dim idProducto As Long = Long.Parse(dgvProducto.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim nombreProducto As String = dgvProducto.Rows(e.RowIndex).Cells("Nombre").Value.ToString()
            Dim precioProducto As Decimal = dgvProducto.Rows(e.RowIndex).Cells("Precio").Value.ToString()
            Dim categoriaProducto As String = dgvProducto.Rows(e.RowIndex).Cells("Categoria").Value.ToString()


            If e.ColumnIndex >= 0 Then 'Verifico si es una columna válida
                If dgvProducto.Columns(e.ColumnIndex).Name = "Editar" Then 'Verifico si se hizo click en el botón "Editar"
                    Dim producto = New Producto() 'Creo un objeto Producto para almacenar los datos del producto que quiere editar

                    producto.Id = idProducto
                    producto.Nombre = nombreProducto
                    producto.Precio = precioProducto
                    producto.Categoria = categoriaProducto

                    FormEditarProducto.RellenarDatosProducto(producto) 'llamo al metodo en el otro form para ir almacenando los datos del producto 

                    FormEditarProducto.ShowDialog() 'Muesto el form donde se puede editar los datos del producto

                ElseIf dgvProducto.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                    Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el producto " + nombreProducto + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar el producto
                    If result = DialogResult.Yes Then
                        If Not EliminarProductoEnBd(New Producto().GenerarObjetoProductoParaEliminarEnBd(idProducto)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                            MessageBox.Show("Producto eliminado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el producto se elimino correctamente'
                            ConfigurarContenido()
                        Else
                            MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el producto no se guardar correctamente'
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que rellena el ComboBox de Categoría
    ''' </summary>'' 
    Protected Sub ActivarComboBoxCategoria()
        Dim categorias = ObtenerCategoriaProducto()
        Dim producto = New Producto
        producto.Categoria = "Seleccione una categoría" 'Agrego una opción nueva primera en lista

        categorias.Insert(0, producto)

        If categorias IsNot Nothing AndAlso categorias.Count > 0 Then 'Verifico que "categorias" no este vacío y no sea nulo
            cbCategoriaProducto.DataSource = categorias
            cbCategoriaProducto.DisplayMember = "Categoria"
            cbCategoriaProducto.ValueMember = "Categoria"
        End If
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        MostarSaveDialog()
    End Sub

    ''' <summary>
    '''  Método muestra un ShowOpenDialog obtiene la ruta, nombre y el tipo de reporte para genenar un reporte en PDF
    ''' </summary>
    Public Sub MostarSaveDialog()
        Dim saveFileD As New SaveFileDialog
        saveFileD.InitialDirectory = GetFolderPath(SpecialFolder.Desktop)
        saveFileD.Title = "Guardar reporte"
        saveFileD.FileName = "Reporte Productos"
        saveFileD.CheckPathExists = True
        saveFileD.DefaultExt = "*pdf"
        saveFileD.Filter = "PDF (*.pdf)|*.pdf|All Files|*.*"
        saveFileD.FilterIndex = 1
        saveFileD.RestoreDirectory = True

        Dim diag As DialogResult = saveFileD.ShowDialog()
        Dim producto = New Producto()


        Select Case ultimaBusqueda
            Case "Filtro"
                producto.Id = If(String.IsNullOrEmpty(txtIdProducto.Text), 0, Long.Parse(txtIdProducto.Text))
                producto.Nombre = txtNombreProducto.Text
                producto.Categoria = cbCategoriaProducto.GetItemText(cbCategoriaProducto.SelectedItem)
                producto.PrecioDesde = If(String.IsNullOrEmpty(txtRangoDesde.Text), 0, Long.Parse(txtRangoDesde.Text))
                producto.PrecioHasta = If(String.IsNullOrEmpty(txtRangoHasta.Text), 0, Long.Parse(txtRangoHasta.Text))
        End Select

        If diag = DialogResult.OK Then 'Verifico que el se haya seleccionado la ruta para guardar el reporte

            Dim path = saveFileD.FileName 'Obtengo la dirección completa del reporte a guardar
            Dim directory As String = New FileInfo(path).DirectoryName 'Separo la carpeta donde se va a guardar el reporte
            Dim file As String = New FileInfo(path).Name 'Separo la el nombre del reporte

            If Not GenerarReportePDF(New PDF().GenerarObjetoParaReportePDF(file, directory, "Productos", ultimaBusqueda, Nothing, Nothing, producto, Nothing)).Excepcion.Error Then 'Verifico que el reporte se haya generado correctamente
                MessageBox.Show("Se genero el reporte correctamente", "Genial", MessageBoxButtons.OK, MessageBoxIcon.None) 'Si el reporte se genero correctamente muesto un MessageBox

            ElseIf diag = DialogResult.Cancel Then
                MessageBox.Show("Se cancelo la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si no se selecciono una ruta muesto un MessageBox
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que elimina el producto de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operación de eliminación del producto en la base datos</returns>
    Protected Function EliminarProductoEnBd(producto As Producto) As Producto
        Dim manager = New ManagerProducto()

        producto = manager.EliminarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerTodosLosProductos() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerTodosLosProductos()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de la categoria de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerCategoriaProducto()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion los producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Productos</returns>
    Protected Function ObtenerProductos(Optional idProducto As String = "", Optional nombre As String = "", Optional categoria As String = "", Optional precioMin As String = "", Optional precioMax As String = "") As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerProductos(idProducto, nombre, categoria, precioMin, precioMax)

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