Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerCliente
    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Cliente desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarClienteEnBd(cliente As Cliente) As Cliente
        Dim clienteDAL = New ClienteDAL()

        cliente = clienteDAL.GuardarClienteEnBd(cliente)

        Return cliente
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del cliente ya existente en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarEdicionProductoEnBd(cliente As Cliente) As Cliente
        Dim clienteDAL = New ClienteDAL()

        cliente = clienteDAL.GuardarEdicionClienteEnBd(cliente)

        Return cliente
    End Function

    ''' <summary>
    '''  Método que elimina el cliente de manera logica en la base datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo cliente con el resultado de la operacion de eliminación en la base datos</returns>
    Public Function EliminarClienteEnBd(cliente As Cliente) As Cliente
        Dim clienteDAL = New ClienteDAL()

        cliente = clienteDAL.EliminarClienteEnBd(cliente)

        Return cliente
    End Function

    ''' <summary>
    '''  Método que verifica si el cliente ya existe en la base de datos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Boolean si el cliente ya existe en la base de datos</returns>
    Public Function VerificarSiYaExisteElCliente(cliente As Cliente) As Boolean
        Dim clienteDAL = New ClienteDAL()
        Dim existe As Boolean
        Dim aCliente = clienteDAL.VerificarSiYaExisteElCliente(cliente) 'Verifico que "aCliente" no este vacío y no sea nulo

        If aCliente IsNot Nothing AndAlso aCliente.Count > 0 Then
            existe = True
        End If

        Return existe
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de todos los clientes desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Public Function ObtenerTodosLosClientes() As ArrayList
        Dim clienteDAL = New ClienteDAL()

        Dim resultado = clienteDAL.ObtenerTodosLosClientes()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList con el ID y Nombre de los clientes desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Public Function ObtenerIDYNombreDelCliente() As ArrayList
        Dim clienteDAL = New ClienteDAL()

        Dim resultado = clienteDAL.ObtenerIDYNombreDelCliente()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList los clientes desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Public Function ObtenerClientes(Optional idCliente As String = "", Optional cliente As String = "", Optional telefono As String = "", Optional correo As String = "") As ArrayList
        Dim clienteDAL = New ClienteDAL()

        Dim resultado = clienteDAL.ObtenerClientes(idCliente, cliente, telefono, correo)

        Return resultado
    End Function
End Class
