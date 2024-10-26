Public Class Excepcion
    Inherits Exception
    Private _mensaje As String
    Private _error As Boolean

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property

    Public Property [Error] As Boolean
        Get
            Return _error
        End Get
        Set(value As Boolean)
            _error = value
        End Set
    End Property
End Class
