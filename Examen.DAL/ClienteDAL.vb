Imports Examen.Entidad

Public Class ClienteDAL
    Inherits AbstractMapper
    Private tipoOp As Integer 'Variable para saber que método se va a ejecutar

    ''' <summary>
    '''  Método que guarda en la base datos un nuevo Cliente en la datos del objeto Cliente
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarClienteEnBd(cliente As Cliente) As Cliente
        commandText = cliente.GuardarClienteEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable cliente.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            cliente.Excepcion.Error = True
            cliente.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return cliente
    End Function

    ''' <summary>
    '''  Método que guarda la edición de los datos del cliente ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo cliente con el resultado de la operación de guardado del cliente en la base de datos</returns>
    Public Function GuardarEdicionClienteEnBd(cliente As Cliente) As Cliente
        commandText = cliente.EditarCliente()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable producto.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            cliente.Excepcion.Error = True
            cliente.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return cliente
    End Function

    ''' <summary>
    '''  Método que elimina el cliente de manera logica en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operación de eliminación del cliente en la base datos</returns>
    Public Function EliminarClienteEnBd(cliente As Cliente) As Cliente
        commandText = cliente.EliminarClienteEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable producto.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            cliente.Excepcion.Error = True
            cliente.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return cliente
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList del objeto Cliente 
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Public Function VerificarSiYaExisteElCliente(cliente As Cliente) As ArrayList
        commandText = cliente.VerificarSiYaExisteElCliente()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de todos los clientes en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Public Function ObtenerTodosLosClientes() As ArrayList
        commandText = New Cliente().ObtenerTodosLosClientes()

        tipoOp = 1

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return VerificarSiYaExisteElCliente(registers)
            Case 1
                Return ObtenerTodosLosProductos(registers)
        End Select

        Return New Object
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Cliente
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Cliente</returns>
    Protected Function VerificarSiYaExisteElCliente(registers As IDataReader) As Cliente
        Dim cliente = New Cliente()

        cliente.Correo = registers("CORREO").ToString

        Return cliente
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Cliente
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Cliente</returns>
    Protected Function ObtenerTodosLosProductos(registers As IDataReader) As Cliente
        Dim cliente = New Cliente()

        cliente.Id = Long.Parse(registers("IDCLIENTE").ToString)
        cliente.Cliente = registers("CLIENTE").ToString
        cliente.Telefono = Integer.Parse(registers("TELEFONO").ToString)
        cliente.Correo = registers("CORREO").ToString

        Return cliente
    End Function
End Class
