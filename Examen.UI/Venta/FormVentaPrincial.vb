Imports Examen.BLL

Public Class FormVentaPrincial
    Private Sub FormVentaPrincial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewProducto()
    End Sub

    Private Sub btnRealizarVenta_Click(sender As Object, e As EventArgs) Handles btnRealizarVenta.Click
        FormRealizarVenta.ShowDialog() 'Muesto el form donde se puede realziar las nuevas ventas
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewProducto()
        Dim ventas = ObtenerTodasLasVentas()
        If ventas IsNot Nothing AndAlso ventas.Count > 0 Then
            dgvVenta.DataSource = ventas
            dgvVenta.Visible = True

            dgvVenta.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvVenta.Columns.Contains("Cliente") Then 'Si la grilla contiene la columna "Clinte" la oculto
                dgvVenta.Columns("Cliente").Visible = False 'Oculto la columna de objeto Clinte
            End If

            If dgvVenta.Columns.Contains("NombreCliente") Then 'Si la grilla contiene la columna "NombreCliente" la oculto
                dgvVenta.Columns("NombreCliente").HeaderText = "Cliente" 'Renombro la columna "NombreCliente" por "Cliente"
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
        End If

    End Sub

    ''' <summary>
    '''  Método que obtiene una collecion de todas las ventas desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Protected Function ObtenerTodasLasVentas() As ArrayList
        Dim manager = New ManagerVenta()

        Dim resultado = manager.ObtenerTodasLasVentas()

        Return resultado
    End Function
End Class