Imports System.ComponentModel
Imports System.Net.Mime.MediaTypeNames
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Examen.BLL
Imports Examen.Entidad

Public Class FormRealizarVenta
    Protected productos As BindingList(Of VentaItem) = New BindingList(Of VentaItem)() 'Variable para almacenar los prouctos en la grilla

    Private Sub FormRealizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    Private Sub FormRealizarVenta_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        productos.Clear() 'Cuando se cierre la ventana limpio la variable
        dgvVentaProducto.DataSource = Nothing 'Tambien cuando se cierre la ventana limpio la grilla
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarComboBoxCliente()
        ActivarComboBoxProducto()
    End Sub

    Private Sub chkbHoy_CheckedChanged(sender As Object, e As EventArgs) Handles chkbHoy.CheckedChanged
        dtpFecha.Enabled = Not chkbHoy.Checked
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then 'Verifico que el campo Teléfono solo se ingrese numeros'
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If VerificarCampos() Then
            productos.Add(New VentaItem() With {
                .Producto = New Producto() With {.Id = Long.Parse(cbProducto.SelectedValue.ToString())},
                .Cantidad = Long.Parse(txtCantidad.Text)
            })

            cbProducto.Refresh()
            txtCantidad.Text = "1"

            ActivarDataGridViewProducto()
        End If
    End Sub

    ''' <summary>
    '''  Método que busca en la base de datos los datos del producto por el Id
    ''' </summary>
    Protected Function RellenarDatosProducto(productos As BindingList(Of VentaItem)) As BindingList(Of VentaItem)

        For Each dato In productos
            Dim productoDatos As ArrayList = ObtenerDatosDeProducto(New Producto() With {.Id = dato.Producto.Id})

            Dim productoCoincidente = productoDatos.Cast(Of Producto)().FirstOrDefault(Function(pd) pd.Id = dato.Producto.Id) 'Buscar el producto correspondiente en el ArrayList

            If productoCoincidente IsNot Nothing Then
                dato.PrecioUnitario = productoCoincidente.Precio
                dato.Producto.Nombre = productoCoincidente.Nombre
            End If
        Next

        Return productos
    End Function

    ''' <summary>
    '''  Método que rellena una Grilla (DataGridView)
    ''' </summary>'' 
    Public Sub ActivarDataGridViewProducto()
        If productos IsNot Nothing AndAlso productos.Count <> 0 Then

            productos = RellenarDatosProducto(productos)

            dgvVentaProducto.DataSource = productos

            dgvVentaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill 'Establesco que las columas ocupen todo el ancho de la grilla

            If dgvVentaProducto.Columns.Contains("Venta") Then 'Si la grilla contiene la columna "Venta" la oculto
                dgvVentaProducto.Columns("Venta").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Id") Then 'Si la grilla contiene la columna "Id" la oculto
                dgvVentaProducto.Columns("Id").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("Producto").Visible = False ' Elimina la columna de objeto Producto
            End If

            If dgvVentaProducto.Columns.Contains("NombreProducto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("NombreProducto").HeaderText = "Producto" 'Renombro la columna "NombreProducto" por "Producto"
            End If

            If dgvVentaProducto.Columns.Contains("Producto") Then 'Si la grilla contiene la columna "Producto" la oculto
                dgvVentaProducto.Columns("Producto").Visible = False ' Elimina la columna de objeto Producto
            End If

            If dgvVentaProducto.Columns.Contains("PrecioUnitario") Then
                dgvVentaProducto.Columns("PrecioUnitario").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVentaProducto.Columns.Contains("PrecioTotal") Then
                dgvVentaProducto.Columns("PrecioTotal").DefaultCellStyle.Format = "C" 'Convierto el tipo de dato a tipo "C" que es tipo de dato moneda como "Currency"'
            End If

            If dgvVentaProducto.Columns.Contains("Activo") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaProducto.Columns("Activo").Visible = False
            End If

            If dgvVentaProducto.Columns.Contains("Excepcion") Then 'Si la grilla contiene la columna "Excepcion" la oculto
                dgvVentaProducto.Columns("Excepcion").Visible = False
            End If

            If dgvVentaProducto.Columns("Eliminar") Is Nothing Then 'Verifico de que solo se configuren una vez las columnas adicionales
                'Creo y agrego la columna y el botón "Eliminar"'
                Dim btnEliminar As New DataGridViewButtonColumn()
                btnEliminar.Name = "Eliminar"
                btnEliminar.HeaderText = "Eliminar"
                btnEliminar.Text = "Eliminar"
                btnEliminar.UseColumnTextForButtonValue = True
                dgvVentaProducto.Columns.Add(btnEliminar)
             End If

                dgvVentaProducto.AllowUserToAddRows = False ' Desactivar la fila de nueva fila

                CalcularTotalGeneral()
            End If
    End Sub

    Protected Sub CalcularTotalGeneral()
        Dim decValue As Decimal
        Dim total As Decimal
        For Each row As DataGridViewRow In dgvVentaProducto.Rows
            If Decimal.TryParse(row.Cells(4).Value, decValue) Then
                total += decValue
            End If
        Next

        lbNumTotalGeneral.Text = total.ToString()
    End Sub

    ''' <summary>
    '''  Método que verifica que los campos Producto(ComboBox), Cantidad(Texbox) y Fecha(DatePiker) no esten vacíos al momento de querer guardarlos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve bool de acuerdo a la verificación</returns>
    Protected Function VerificarCampos() As Boolean
        Dim validado As Boolean

        If cbProducto.SelectedValue <> 0 Then
            validado = True
        Else
            MessageBox.Show("Debes seleccionar una opción en el campo Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtCantidad.Text) Then 'Verifico que el campo Precio no este vacío'
            validado = True
        Else
            MessageBox.Show("El campo Cantidad no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        Return validado = True
    End Function

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
    '''  Método que rellena el ComboBox de Producto
    ''' </summary>'' 
    Protected Sub ActivarComboBoxProducto()
        Dim productos = ObtenerIDYNombreDelProducto()
        Dim producto = New Producto
        producto.Nombre = "Seleccione un producto" 'Agrego una opción nueva primera en lista

        productos.Insert(0, producto)

        If productos IsNot Nothing AndAlso productos.Count > 0 Then 'Verifico que "categorias" no este vacío y no sea nulo
            cbProducto.DataSource = productos
            cbProducto.DisplayMember = "Nombre"
            cbProducto.ValueMember = "Id"
        End If
    End Sub

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
    '''  Método que obtiene una collecion tipo ArrayList con ID y Nombre de los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerIDYNombreDelProducto() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerIDYNombreDelProducto()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList con todos los datos de un producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerDatosDeProducto(producto)

        Return resultado
    End Function

End Class