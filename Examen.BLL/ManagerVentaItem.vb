Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerVentaItem
    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto VentaItem desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaItemEnBD(listVemtaItem As List(Of VentaItem)) As VentaItem
        Dim ventaItemDAL = New VentaItemDAL()
        Dim errorInsert As Boolean
        Dim ventaitem = New VentaItem()

        For Each ventaItems In listVemtaItem
            ventaItems = ventaItemDAL.GuardarVentaItemEnBD(ventaItems)

            If Not ventaItems.Excepcion.Error Then errorInsert = True Else errorInsert = False
        Next

        ventaitem.Excepcion.Error = Not errorInsert

        Return ventaitem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos del ventaItem ya existente en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function EditarVentaItemEnBd(ventaItem As VentaItem) As VentaItem
        Dim ventaItemDAL = New VentaItemDAL()

        ventaItem = ventaItemDAL.EditarVentaItemEnBd(ventaItem)

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion del Total en la base de datos desde la capa de conexion a la base de datos //Reveer este texto
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function ActualizarTotalDeLaVenta(ventaItem As VentaItem) As VentaItem
        Dim ventaDAL = New VentaItemDAL()

        ventaItem = ventaDAL.ActualizarTotalDeLaVenta(ventaItem)

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de todos las ventasItem desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Public Function ObtenerTodasLasVentasItem() As ArrayList
        Dim ventaItemDAL = New VentaItemDAL()

        Dim resultado = ventaItemDAL.ObtenerTodasLasVentasItem()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion tipo ArrayList de todos las ventasItem desde la capa de conexion a la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Public Function ObtenerVentasItemId(ventaItem As VentaItem) As ArrayList
        Dim ventaItemDAL = New VentaItemDAL()

        Dim resultado = ventaItemDAL.ObtenerVentasItemId(ventaItem)

        Return resultado
    End Function
End Class
