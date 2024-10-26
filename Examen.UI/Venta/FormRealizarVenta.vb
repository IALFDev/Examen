Imports Examen.BLL
Imports Examen.Entidad

Public Class FormRealizarVenta
    Private Sub FormRealizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarContenido()
    End Sub

    ''' <summary>
    '''  Metodo que activa distintos elementos al llamar al mismo
    ''' </summary>'' 
    Protected Sub ConfigurarContenido()
        ActivarComboBoxCliente()
    End Sub

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
    '''  Método que obtiene una collecion del tipo ArrayList con el ID y Nombre de los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerIDYNombreDelCliente() As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerIDYNombreDelCliente()

        Return resultado
    End Function
End Class