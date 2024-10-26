Imports Examen.Entidad

Public Class ProductoDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Metodo que guarda en la base datos los datos del objeto Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        commandText = producto.GuardarProductoEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception
            producto.Excepcion.Error = True
            producto.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return producto
    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion del tipo ArrayList de todos los productos de la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        commandText = New Producto().ObtenerTodosLosProductos()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado

    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion del tipo ArrayList de la categoria de todos los productos de la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerCategoriaProducto() As ArrayList
        commandText = New Producto().ObtenerCategoriaProducto()

        tipoOp = 1

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodosLosProductos(registers)
            Case 1
                Return ObtenerCategoriaProducto(registers)
        End Select

        Return New Object
    End Function

    ''' <summary>
    '''  Metodo que almacena todos los datos obtenidos en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>

    Protected Function ObtenerTodosLosProductos(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Id = Long.Parse(registers("IDPRODUCTO").ToString)
        producto.Nombre = registers("NOMBRE").ToString
        producto.Precio = Decimal.Parse(registers("PRECIO").ToString)
        producto.Categoria = registers("CATEGORIA").ToString
        producto.Activo = Boolean.Parse(registers("ACTIVO").ToString)

        Return producto
    End Function

    ''' <summary>
    '''  Metodo que almacena la categoria obtenida en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Categoria = registers("CATEGORIA").ToString

        Return producto
    End Function
End Class
