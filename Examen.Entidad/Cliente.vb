Imports System.Text.RegularExpressions

Public Class Cliente
    Private _id As Long
    Private _cliente As String
    Private _telefono As Integer
    Private _correo As String

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

    ''' <summary>
    '''  Metodo que obtiene un string para guardar los datos del cliente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos del cliente en la base de datos</returns>
    Public Function GuardarClienteEnBd() As String
        Dim cmd = String.Format("INSERT INTO dbo.clientes (Cliente, Telefono, Correo) VALUES ('{0}', {1}, '{2}')", Cliente, Telefono, Correo)

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un bool al validar si el string ingresado tiene el formato correcto para un correo electrónico
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
