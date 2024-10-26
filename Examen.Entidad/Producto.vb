Public Class Producto
    Private _id As Long
    Private _nombre As String
    Private _precio As Decimal
    Private _categoria As String
    Private _activo As Boolean

    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Precio As Decimal
        Get
            Return _precio
        End Get
        Set(value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property Categoria As String
        Get
            Return _categoria
        End Get
        Set(value As String)
            _categoria = value
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

    Public Function ObtenerTodosLosProductos() As String
        Dim cmd = String.Format("SELECT p.ID AS IDPRODUCTO, p.Nombre AS NOMBRE, p.Precio AS PRECIO, p.Categoria AS CATEGORIA FROM dbo.productos AS p WHERE p.Activo = 1")

        Return cmd
    End Function
End Class
