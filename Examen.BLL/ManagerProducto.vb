Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerProducto
    ''' <summary>
    '''  Metodo que guarda en la base datos los datos del objeto Producto desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Producto</returns>
    Public Function GuardarProductoEnBd(producto As Producto) As Producto
        Dim productoDAL = New ProductoDAL()

        producto = productoDAL.GuardarProductoEnBd(producto)

        Return producto
    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion tipo ArrayList de todos los productos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerTodosLosProductos()

        Return resultado
    End Function

    ''' <summary>
    '''  Metodo que obtiene una collecion tipo ArrayList de la categoria de todos los productos desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerCategoriaProducto() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerCategoriaProducto()

        Return resultado
    End Function
End Class
