Imports Examen.Entidad

Public Class ProductoDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Método que guarda en la base datos un nuevo producto en la datos del objeto Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        commandText = producto.GuardarProductoEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable producto.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            producto.Excepcion.Error = True
            producto.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return producto
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del producto ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operación de guardado del producto en la base de datos</returns>
    Public Function GuardarEdicionProductoEnBd(producto As Producto) As Producto
        commandText = producto.EditarProductoEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable producto.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            producto.Excepcion.Error = True
            producto.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return producto
    End Function

    ''' <summary>
    '''  Método que elimina el producto de manera logica en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operación de eliminación del producto en la base datos</returns>
    Public Function EliminarProductoEnBd(producto As Producto) As Producto
        commandText = producto.EliminarProductoEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable producto.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            producto.Excepcion.Error = True
            producto.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return producto
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de todos los productos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        commandText = New Producto().ObtenerTodosLosProductos()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de la categoria de todos los productos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerCategoriaProducto() As ArrayList
        commandText = New Producto().ObtenerCategoriaProducto()

        tipoOp = 1

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList con ID y Nombre de los productos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerIDYNombreDelProducto() As ArrayList
        commandText = New Producto().ObtenerIDYNombreDelProducto()

        tipoOp = 2

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList con todos los datos de un producto en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        commandText = New Producto().ObtenerDatosDeProducto(producto)

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList los productos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo producto</returns>
    Public Function ObtenerProductos(Optional idProducto As String = "", Optional nombre As String = "", Optional categoria As String = "", Optional precioMin As String = "", Optional precioMax As String = "") As ArrayList
        commandText = New Producto().ObtenerProductos(idProducto, nombre, categoria, precioMin, precioMax)

        tipoOp = 3

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodosLosProductos(registers)
            Case 1
                Return ObtenerCategoriaProducto(registers)
            Case 2
                Return ObtenerIDYNombreDelProducto(registers)
            Case 3
                Return ObtenerClientes(registers)
        End Select

        Return New Object
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>
    Protected Function ObtenerTodosLosProductos(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Id = Long.Parse(registers("IDPRODUCTO").ToString)
        producto.Nombre = registers("NOMBRE").ToString
        producto.Precio = Decimal.Parse(registers("PRECIO").ToString)
        producto.Categoria = registers("CATEGORIA").ToString

        Return producto
    End Function

    ''' <summary>
    '''  Método que almacena la categoria obtenida en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>
    Protected Function ObtenerCategoriaProducto(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Categoria = registers("CATEGORIA").ToString

        Return producto
    End Function

    ''' <summary>
    '''  Método que almacena la ID y Nombre obtenida en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>
    Protected Function ObtenerIDYNombreDelProducto(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Id = Long.Parse(registers("IDPRODUCTO").ToString)
        producto.Nombre = registers("NOMBRE").ToString

        Return producto
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto</returns>
    Protected Function ObtenerClientes(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Id = Long.Parse(registers("IDPRODUCTO").ToString)
        producto.Nombre = registers("NOMBRE").ToString
        producto.Precio = Decimal.Parse(registers("PRECIO").ToString)
        producto.Categoria = registers("CATEGORIA").ToString

        Return producto
    End Function
End Class
