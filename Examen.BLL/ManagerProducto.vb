Imports Examen.DAL

Public Class ManagerProducto

    ''' <summary>
    '''  Metodo que obtiene una collecion de todos los productos desde la capa de conexion a la base de datos
    '''  Procedure, una colección del Tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un Arraylis del Tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        Dim productoDAL = New ProductoDAL()

        Dim resultado = productoDAL.ObtenerTodosLosProductos()

        Return resultado
    End Function
End Class
