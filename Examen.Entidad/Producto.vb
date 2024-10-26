Public Class Producto
    Private _id As Long
    Private _nombre As String
    Private _precio As Decimal
    Private _categoria As String
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
    '''  Metodo que devuelve un objeto del tipo Producto con los datos necesarios para guardar en la base datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos del producto en la base de datos</returns>
    Public Function GenerarObjetoProductoParaGuardarEnBd(nombre As String, precio As Decimal, categoria As String) As Producto
        Dim producto = New Producto()
        producto.Nombre = nombre
        producto.Precio = precio
        producto.Categoria = categoria

        Return producto
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener todos los productos de la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener todos los productos</returns>
    Public Function ObtenerTodosLosProductos() As String
        Dim cmd = String.Format("SELECT p.ID AS IDPRODUCTO, p.Nombre AS NOMBRE, p.Precio AS PRECIO, p.Categoria AS CATEGORIA FROM dbo.productos AS p WHERE p.Activo = 1")

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener la categoria de los productos en la base de datos
    '''  Procedure, un string de consulta
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener la categoria de los productos</returns>
    Public Function ObtenerCategoriaProducto() As String
        Dim cmd = String.Format("SELECT DISTINCT p.Categoria AS CATEGORIA FROM dbo.productos AS p WHERE p.Activo = 1")

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para guardar los datos del producto en la base de datos
    '''  Procedure, un string de consulta
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos del producto en la base de datos</returns>
    Public Function GuardarProductoEnBd() As String
        Dim precioFormateado As String = Precio.ToString(System.Globalization.CultureInfo.InvariantCulture)
        Dim cmd = String.Format("INSERT INTO dbo.productos (Nombre, Precio, Categoria) VALUES ('{0}', {1}, '{2}')", Nombre, precioFormateado, Categoria)

        Return cmd
    End Function
End Class
