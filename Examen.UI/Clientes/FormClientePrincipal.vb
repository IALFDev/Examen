Imports Examen.BLL
Imports Examen.Entidad

Public Class FormClientePrincipal
    Private Sub FormClientePrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewProducto()
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        FormAgregarCliente.ShowDialog() 'Muesto el form donde se puede agregar nuevos clientes
    End Sub

    Public Sub ActivarDataGridViewProducto()
        Dim clientes = ObtenerTodosLosClientes()
        If clientes IsNot Nothing AndAlso clientes.Count > 0 Then
            dgvCliente.DataSource = clientes
            dgvCliente.Visible = True

            dgvCliente.ReadOnly = True 'Establesco que toda la grilla sea de solo lectura

            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvCliente.Columns.Contains("Telefono") Then 'Si la grilla contiene la columna "Telefono" la renombro a "Teléfono"
                dgvCliente.Columns("Telefono").HeaderText = "Teléfono"
            End If

            If dgvCliente.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvCliente.Columns("Activo").Visible = False
            End If

            If dgvCliente.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvCliente.Columns("Excepcion").Visible = False
            End If

            If dgvCliente.Columns.Contains("Precio") Then
                dgvCliente.Columns("Precio").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvCliente.Columns("Editar") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales

                'Creo y agrego la columna y el botón "Editar"'
                Dim btnEditar As New DataGridViewButtonColumn()
                btnEditar.Name = "Editar"
                btnEditar.HeaderText = "Editar"
                btnEditar.Text = "Editar"
                btnEditar.UseColumnTextForButtonValue = True
                dgvCliente.Columns.Add(btnEditar)

                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvCliente.Columns.Add(btnEliminar)
            End If
        End If

    End Sub

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellClick
        ' Verificar si es una fila válida
        If e.RowIndex >= 0 Then
            Dim idCliente As Long = Long.Parse(dgvCliente.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim nombreCliente As String = dgvCliente.Rows(e.RowIndex).Cells("Cliente").Value.ToString()
            Dim telefonoPrecio As Decimal = dgvCliente.Rows(e.RowIndex).Cells("Telefono").Value.ToString()
            Dim correoCliente As String = dgvCliente.Rows(e.RowIndex).Cells("Correo").Value.ToString()


            If dgvCliente.Columns(e.ColumnIndex).Name = "Editar" Then 'Verifico si se hizo click en el botón "Editar"
                Dim cliente = New Cliente() 'Creo un objeto Cliente para almacenar los datos del cliente que quiere editar

                cliente.Id = idCliente
                cliente.Cliente = nombreCliente
                cliente.Telefono = Integer.Parse(telefonoPrecio)
                cliente.Correo = correoCliente

                FormEditarCliente.RellenarDatosCliente(cliente) 'llamo al metodo en el otro form para ir almacenando los datos del cliente 

                FormEditarCliente.ShowDialog() 'Muesto el form donde se puede editar los datos del cliente


            ElseIf dgvCliente.Columns(e.ColumnIndex).Name = "Eliminar" Then 'Verifico si se hizo click en el botón "Eliminar"
                Dim result As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el cliente " + nombreCliente + " ?", "Atención", MessageBoxButtons.YesNo) 'Verifico si es correcto que quiere eliminar el cliente
                If result = DialogResult.Yes Then
                    If Not EliminarClienteEnBd(New Cliente().GenerarObjetoClienteParaEliminarEnBd(idCliente)).Excepcion.Error Then 'Verifico que la eliminación en la base sea correcto de lo contrario muestro un MessageBox de error
                        MessageBox.Show("Cliente eliminado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el cliente se elimino correctamente'
                        ConfigurarContenido()
                    Else
                        MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el cliente no se guardar correctamente'
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que elimina el cliente de manera logica en la base datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operación de eliminación del cliente en la base datos</returns>
    Protected Function EliminarClienteEnBd(cliente As Cliente) As Cliente
        Dim manager = New ManagerCliente()

        cliente = manager.EliminarClienteEnBd(cliente)

        Return cliente
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todos los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerTodosLosClientes() As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerTodosLosClientes()

        Return resultado
    End Function
End Class