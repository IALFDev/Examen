Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerProducto
    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Producto desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        Dim productoDAL = New ProductoDAL()

        producto = productoDAL.GuardarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del producto ya existente en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarEdicionProductoEnBd(producto As Producto) As Producto
        Dim productoDAL = New ProductoDAL()

        producto = productoDAL.GuardarEdicionProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Método que elimina el producto de manera logica en la base datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto con el resultado de la operacion de eliminación en la base datos</returns>
    Public Function EliminarProductoEnBd(producto As Producto) As Producto
        Dim productoDAL = New ProductoDAL()

        producto = productoDAL.EliminarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de todos los productos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerTodosLosProductos()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList con ID y Nombre de los productos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerIDYNombreDelProducto() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerIDYNombreDelProducto()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList con todos los datos de un producto desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerDatosDeProducto(producto As Producto) As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerDatosDeProducto(producto)

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de la categoria de todos los productos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerCategoriaProducto() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerCategoriaProducto()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList los producto desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerProductos(Optional idProducto As String = "", Optional nombre As String = "", Optional categoria As String = "", Optional precioMin As String = "", Optional precioMax As String = "") As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerProductos(idProducto, nombre, categoria, precioMin, precioMax)

        Return resultado
    End Function
End Class
