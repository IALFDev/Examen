Imports System.Text.RegularExpressions

Public Class Cliente
    Private _id As Long
    Private _cliente As String
    Private _telefono As Integer
    Private _correo As String
    Private _activo As Boolean
    Private _excepcion As Excepcion
    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property Telefono As Integer
        Get
            Return _telefono
        End Get
        Set(value As Integer)
            _telefono = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return _activo
        End Get
        Set(value As Boolean)
            _activo = value
        End Set
    End Property

    Public Property Excepcion As Excepcion
        Get
            If IsNothing(_excepcion) Then
                _excepcion = New Excepcion
            End If

            Return _excepcion
        End Get
        Set(value As Excepcion)
            _excepcion = value
        End Set
    End Property

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Cliente con los datos necesarios para guardar el Cliente en la base datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos del Cliente en la base de datos</returns>
    Public Function GenerarObjetoClienteParaGuardarEnBd(cliente As String, telefono As Integer, correo As String) As Cliente
        Dim oCliente = New Cliente

        oCliente.Cliente = cliente
        oCliente.Telefono = telefono
        oCliente.Correo = correo

        Return oCliente
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Cliente con los datos necesarios para guardar el Cliente en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Cliente para guardar los datos del Cliente en la base de datos</returns>
    Public Function GenerarObjetoClienteParaGuardarEnBd(id As Long, cliente As String, telefono As Integer, correo As String) As Cliente
        Dim oCliente = New Cliente

        oCliente.Id = id
        oCliente.Cliente = cliente
        oCliente.Telefono = telefono
        oCliente.Correo = correo

        Return oCliente
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Cliente con los datos necesarios para guardar el cliente en la base datos, este caso recibe una sobrecarga más para poder editar el producto en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Cliente para guardar los datos del cliente en la base de datos</returns>
    Public Function GenerarObjetoClienteParaVerificarSiExiste(correo As String) As Cliente
        Dim cliente = New Cliente

        cliente.Correo = correo

        Return cliente
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Cliente con los datos necesarios para eliminar de manera logica el cliente en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Cliente para guardar los datos del cliente en la base de datos</returns>
    Public Function GenerarObjetoClienteParaEliminarEnBd(id As Long) As Cliente
        Dim cliente = New Cliente()

        cliente.Id = id

        Return cliente
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener todos los clientes en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener todos los clientes</returns>

    Public Function ObtenerTodosLosClientes() As String
        Dim cmd = "SELECT c.ID AS IDCLIENTE, c.Cliente AS CLIENTE, c.Telefono as TELEFONO, c.Correo AS CORREO, c.Activo AS ACTIVO FROM clientes AS c where c.Activo = 1"

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener el ID y Nombre de los clientes en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener todos los clientes</returns>
    Public Function ObtenerIDYNombreDelCliente() As String
        Dim cmd = "SELECT c.ID AS IDCLIENTE, c.Cliente AS CLIENTE FROM clientes AS c where c.Activo = 1"

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar los datos del cliente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos del cliente en la base de datos</returns>
    Public Function GuardarClienteEnBd() As String
        Dim cmd = String.Format("INSERT INTO dbo.clientes (Cliente, Telefono, Correo) VALUES ('{0}', {1}, '{2}')", Cliente, Telefono, Correo)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar la edicion de los datos del cliente ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar la edicion de los datos del cliente ya existente la base de datos</returns>
    Public Function EditarCliente() As String
        Dim cmd = String.Format("UPDATE clientes SET Cliente = '{0}' ,Telefono = {1},Correo = '{2}' WHERE clientes.ID = {3}", Cliente, Telefono, Correo, Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para eliminar de manera logica el cliente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para eliminar de manera logica el cliente en la base de datos</returns>
    Public Function EliminarClienteEnBd() As String
        Dim cmd = String.Format("UPDATE clientes SET Activo = 0 WHERE clientes.ID = {0}", Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para verificar si el cliente ya existe en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para verificar si el cliente ya existe en la base de datos</returns>
    Public Function VerificarSiYaExisteElCliente() As String
        Dim cmd = String.Format("SELECT c.Correo AS CORREO FROM clientes AS c where c.Correo = '{0}' AND c.Activo = 1", Correo)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un bool al validar si el string ingresado tiene el formato correcto para un correo electrónico
    ''' </summary>
    ''' <returns>Devuelve un bool si el correo es valido o no</returns>
    Public Function Verificarcorreo() As Boolean
        Dim patronRegex As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" 'Patron para validar si el string ingresado es un correo
        Dim emailAddressMatch As Match = Regex.Match(Correo, patronRegex)
        If emailAddressMatch.Success Then 'Verifica si el string ingresado es un correo
            Verificarcorreo = True
        Else
            Verificarcorreo = False
        End If
    End Function
End Class
