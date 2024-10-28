Imports System.ComponentModel
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormVentaPrincipal
    Private Sub FormVentaPrincial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub
    Private Sub FormVentaPrincial_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LimpiarControles()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewVenta()
        ActivarComboBoxCliente()
    End Sub

    Private Sub btnRealizarVenta_Click(sender As Object, e As EventArgs) Handles btnRealizarVenta.Click
        FormRealizarVenta.ShowDialog() 'Muesto el form donde se puede realziar las nuevas ventas
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewVenta()
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

            If dgvVenta.Columns.Contains("IdCliente") Then 'Si la grilla contiene la columna "IdCliente" la oculto
                dgvVenta.Columns("IdCliente").Visible = False 'Renombro la columna "NombreCliente" por "Cliente"
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

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellClick

        If e.RowIndex >= 0 Then 'Verifico si es una fila válida
            Dim idVenta As Long = Long.Parse(dgvVenta.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim IdCliente As Long = dgvVenta.Rows(e.RowIndex).Cells("IdCliente").Value.ToString()
            Dim nombreCliente As String = dgvVenta.Rows(e.RowIndex).Cells("NombreCliente").Value.ToString()
            Dim fechaVenta As DateTime = dgvVenta.Rows(e.RowIndex).Cells("Fecha").Value.ToString()
            Dim TotalVenta As Decimal = dgvVenta.Rows(e.RowIndex).Cells("Total").Value.ToString()


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
                    If Not EliminarVentaEnBd(New Venta().GenerarObjetoVentaParaEliminarEnBd(idVenta)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                        MessageBox.Show("Venta eliminada.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que la venta se elimino correctamente'
                        ConfigurarContenido()
                    Else
                        MessageBox.Show("Error al eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que la venta no se guardar correctamente'
                    End If
                End If
            End If
        End If
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
        dgvVenta.Columns.Clear() 'Limpio las columnas de la grilla
        dgvVenta.DataSource = Nothing 'Limpio el datasourse de la grilla
        dgvVenta.Rows.Clear() ''Limpio las filas de la grilla
    End Sub

    ''' <summary>
    '''  Método que elimina la venta de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de eliminación del venta en la base datos</returns>
    Protected Function EliminarVentaEnBd(venta As Venta) As Venta
        Dim manager = New ManagerVenta()

        venta = manager.EliminarVentaEnBd(venta)

        Return venta
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
End Class