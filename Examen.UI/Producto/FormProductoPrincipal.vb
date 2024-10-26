Imports Examen.BLL
Imports Examen.Entidad

Public Class FormProductoPrincipal
    Private Sub FormProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewProducto()
        ActivarComboBoxCategoria()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

    End Sub
    Private Sub txtIdProducto_LostFocus(sender As Object, e As EventArgs) Handles txtIdProducto.LostFocus
        If Not IsNumeric(txtIdProducto.Text) And Trim(txtIdProducto.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdProducto.Clear() 'Limpio el campo con el dato ingresado incorrecto'
        End If
    End Sub

    Private Sub txtRangoDesde_TextChanged(sender As Object, e As EventArgs) Handles txtRangoDesde.TextChanged

    End Sub

    Private Sub txtRangoDesde_LostFocus(sender As Object, e As EventArgs) Handles txtRangoDesde.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Clear() 'Limpio el campo con el dato ingresado incorrecto'
        End If

    End Sub

    Private Sub txtRangoHasta_TextChanged(sender As Object, e As EventArgs) Handles txtRangoHasta.TextChanged

    End Sub

    Private Sub txtRangoHasta_LostFocus(sender As Object, e As EventArgs) Handles txtRangoHasta.LostFocus
        If Not IsNumeric(txtRangoHasta.Text) And Trim(txtRangoHasta.Text) <> "" Then 'Verifico que sea numerico, que no tenga espacios al principio ni al final, y no este vació'
            MessageBox.Show("Debes ingresar solamente valores numericos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRangoHasta.Clear() 'Limpio el campo con el dato ingresado incorrecto'
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        FormAgregarProducto.ShowDialog()
    End Sub

    ''' <summary>
    '''  Metodo que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Public Sub ActivarDataGridViewProducto()
        Dim productos = ObtenerTodosLosProductos()
        If productos IsNot Nothing AndAlso productos.Count > 0 Then
            dgvProducto.DataSource = productos
            dgvProducto.Visible = True

            dgvProducto.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura'

            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvProducto.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto'
                dgvProducto.Columns("Activo").Visible = False
            End If

            If dgvProducto.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto'
                dgvProducto.Columns("Excepcion").Visible = False
            End If

            ' Asegurarse de que solo se configuren una vez las columnas adicionales'
            If dgvProducto.Columns("Editar") Is Nothing Then
                ' Configurar la columna "Activo" como de solo lectura


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
        End If

    End Sub

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellClick
        ' Verificar si es una fila válida
        If e.RowIndex >= 0 Then
            Dim idProducto As Long = Long.Parse(dgvProducto.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim nombreProducto As String = dgvProducto.Rows(e.RowIndex).Cells("Nombre").Value.ToString()
            Dim precioProducto As Decimal = dgvProducto.Rows(e.RowIndex).Cells("Precio").Value.ToString()
            Dim categoriaProducto As String = dgvProducto.Rows(e.RowIndex).Cells("Categoria").Value.ToString()

            ' Determinar si se hizo clic en el botón "Editar"
            If dgvProducto.Columns(e.ColumnIndex).Name = "Editar" Then
                ' Llamar al método de edición aquí, pasando el ID del producto
                'EditarProducto(idProducto)

                Dim producto = New Producto()

                producto.Id = idProducto
                producto.Nombre = nombreProducto
                producto.Precio = precioProducto
                producto.Categoria = categoriaProducto

                FormEditarProducto.RellenarDatosProducto(producto)

                FormEditarProducto.ShowDialog()

                ' Determinar si se hizo clic en el botón "Eliminar"
            ElseIf dgvProducto.Columns(e.ColumnIndex).Name = "Eliminar" Then
                ' Llamar al método de eliminación aquí, pasando el ID del producto
                Dim result As DialogResult = MessageBox.Show("message", "caption", MessageBoxButtons.YesNo)
                If result = DialogResult.Cancel Then
                    MessageBox.Show("Cancel pressed")
                ElseIf result = DialogResult.No Then
                    MessageBox.Show("No pressed")
                ElseIf result = DialogResult.Yes Then
                    MessageBox.Show("Yes pressed")
                    'EliminarProducto(idProducto)
                    ConfigurarContenido()
                End If
            End If
        End If
    End Sub

    ''' <summary>
    '''  Metodo que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Protected Sub ActivarComboBoxCategoria()
        Dim categorias = ObtenerCategoriaProducto()
        Dim producto = New Producto
        producto.Categoria = "Seleccione una categoria"

        categorias.Insert(0, producto)

        If Not categorias.Count <= 0 Then
            cbCategoria.DataSource = categorias
            cbCategoria.DisplayMember = "Categoria"
            cbCategoria.ValueMember = "Categoria"
        End If
    End Sub

    ''' <summary>
    '''  Metodo que obtiene una collecion de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerTodosLosProductos() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerTodosLosProductos

        Return resultado
    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion de la categoria de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerCategoriaProducto

        Return resultado
    End Function
End Class