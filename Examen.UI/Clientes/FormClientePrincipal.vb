Imports System.Environment
Imports System.IO
Imports Examen.BLL
Imports Examen.Entidad
Imports Microsoft.Win32

Public Class FormClientePrincipal
    Dim ultimaBusqueda As String = String.Empty 'Guardo cual fue la ultima busqueda para hacer el reporte

    Private Sub FormClientePrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Private Sub txtIdCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdCliente.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefonoCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonoCliente.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarDataGridViewProducto("Todos")
        ultimaBusqueda = "Todos" 'Acá seria que la ultima busqueda fue "Todos"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ActivarDataGridViewProducto("Filtro")
        ultimaBusqueda = "Filtro" 'Acá seria que la ultima busqueda fue "Filtro"
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        FormAgregarCliente.ShowDialog() 'Muesto el form donde se puede agregar nuevos clientes
    End Sub

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>''
    Public Sub ActivarDataGridViewProducto(tipoOp As String)
        Dim clientes As ArrayList = Nothing

        Select Case tipoOp
            Case "Todos"
                clientes = ObtenerTodosLosClientes()
            Case "Filtro"
                clientes = ObtenerClientes(txtIdCliente.Text, txtNombreCliente.Text, txtTelefonoCliente.Text, txtCorreoCliente.Text)
        End Select

        If clientes IsNot Nothing AndAlso clientes.Count > 0 Then
            dgvCliente.Visible = True
            lbNoResultados.Visible = False
            btnGenerarReporte.Enabled = True

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
        Else
            dgvCliente.Visible = False
            lbNoResultados.Visible = True
            btnGenerarReporte.Enabled = False
        End If
    End Sub

    Protected Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellClick

        If e.RowIndex >= 0 Then 'Verifico si es una fila válida
            Dim idCliente As Long = Long.Parse(dgvCliente.Rows(e.RowIndex).Cells("ID").Value.ToString())
            Dim nombreCliente As String = dgvCliente.Rows(e.RowIndex).Cells("Cliente").Value.ToString()
            Dim telefonoPrecio As Decimal = dgvCliente.Rows(e.RowIndex).Cells("Telefono").Value.ToString()
            Dim correoCliente As String = dgvCliente.Rows(e.RowIndex).Cells("Correo").Value.ToString()


            If e.ColumnIndex >= 0 Then 'Verifico si es una columna válida
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
        saveFileD.FileName = "Reporte Clientes"
        saveFileD.CheckPathExists = True
        saveFileD.DefaultExt = "*pdf"
        saveFileD.Filter = "PDF (*.pdf)|*.pdf|All Files|*.*"
        saveFileD.FilterIndex = 1
        saveFileD.RestoreDirectory = True

        Dim diag As DialogResult = saveFileD.ShowDialog()
        Dim cliente = New Cliente()


        Select Case ultimaBusqueda
            Case "Filtro"
                cliente.Id = If(String.IsNullOrEmpty(txtIdCliente.Text), 0, Long.Parse(txtIdCliente.Text))
                cliente.Cliente = txtNombreCliente.Text
                cliente.Telefono = If(String.IsNullOrEmpty(txtIdCliente.Text), 0, Integer.Parse(txtIdCliente.Text))
                cliente.Correo = txtCorreoCliente.Text
        End Select

        If diag = DialogResult.OK Then 'Verifico que el se haya seleccionado la ruta para guardar el reporte

            Dim path = saveFileD.FileName 'Obtengo la dirección completa del reporte a guardar
            Dim directory As String = New FileInfo(path).DirectoryName 'Separo la carpeta donde se va a guardar el reporte
            Dim file As String = New FileInfo(path).Name 'Separo la el nombre del reporte

            If Not GenerarReportePDF(New PDF().GenerarObjetoParaReportePDF(file, directory, "Clientes", ultimaBusqueda, Nothing, cliente)).Excepcion.Error Then 'Verifico que el reporte se haya generado correctamente
                MessageBox.Show("Se genero el reporte correctamente", "Genial", MessageBoxButtons.OK, MessageBoxIcon.None) 'Si el reporte se genero correctamente muesto un MessageBox

            ElseIf diag = DialogResult.Cancel Then
                MessageBox.Show("Se cancelo la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si no se selecciono una ruta muesto un MessageBox
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

    ''' <summary>
    '''  Método que obtiene una collecion los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerClientes(Optional idCliente As String = "", Optional cliente As String = "", Optional telefono As String = "", Optional correo As String = "") As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerClientes(idCliente, cliente, telefono, correo)

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