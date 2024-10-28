Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerVenta

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Venta desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaEnBD(venta As Venta) As Venta
        Dim ventaDAL = New VentaDAL()

        venta = ventaDAL.GuardarVentaEnBD(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del venta ya existente en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Public Function EditarVentaEnBd(venta As Venta) As Venta
        Dim ventaDAL = New VentaDAL()

        venta = ventaDAL.EditarVentaEnBd(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de todos las ventas desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Public Function ObtenerTodasLasVentas() As ArrayList
        Dim ventaDAL = New VentaDAL()

        Dim resultado = ventaDAL.ObtenerTodasLasVentas()

        Return resultado
    End Function
End Class
