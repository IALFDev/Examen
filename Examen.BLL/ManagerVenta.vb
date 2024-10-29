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
    '''  Método que elimina la venta de manera logica en la base datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo venta con el resultado de la operacion de eliminación en la base datos</returns>
    Public Function EliminarVentaEnBd(venta As Venta) As Venta
        Dim ventaDal = New VentaDAL()

        venta = ventaDal.EliminarVentaEnBd(venta)

        Return venta
    End Function

    ''' <summary>
    '''  Método que guarda la edicion del Total en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Public Function ActualizarTotalDeLaVenta(venta As Venta) As Venta
        Dim ventaDal = New VentaDAL()

        venta = ventaDal.ActualizarTotalDeLaVenta(venta)

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

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList los venta desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Public Function ObtenerVentas(Optional idVenta As String = "", Optional clienteNombre As String = "", Optional fechaDesde As String = "", Optional fechaHasta As String = "") As ArrayList
        Dim ventaDAL = New VentaDAL()

        Dim resultado = ventaDAL.ObtenerVentas(idVenta, clienteNombre, fechaDesde, fechaHasta)

        Return resultado
    End Function
End Class
