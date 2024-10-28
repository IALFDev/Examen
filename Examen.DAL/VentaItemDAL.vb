Imports Examen.Entidad

Public Class VentaItemDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Método que guarda en la base datos una nueva VentaItem en la datos del objeto Venta
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaItemEnBD(ventaItem As VentaItem) As VentaItem
        commandText = ventaItem.GuardarVentaItemEnBD()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable ventaItem.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            ventaItem.Excepcion.Error = True
            ventaItem.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos de la ventaItem ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operación de guardado del producto en la base de datos</returns>
    Public Function EditarVentaItemEnBd(ventaItem As VentaItem) As VentaItem
        commandText = ventaItem.EditarVentaItemEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable ventaItem.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            ventaItem.Excepcion.Error = True
            ventaItem.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que guarda la edicion del Total en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operación de edición del Total en la base de datos</returns>
    Public Function ActualizarTotalDeLaVenta(ventaItem As VentaItem) As VentaItem
        commandText = ventaItem.ActualizarTotalDeLaVenta()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable ventaItem.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            ventaItem.Excepcion.Error = True
            ventaItem.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de todos las ventaItem en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Public Function ObtenerTodasLasVentasItem() As ArrayList
        commandText = New VentaItem().ObtenerTodasLasVentasItem()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de  las ventaItem por Id en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo VentaItem</returns>
    Public Function ObtenerVentasItemId(itemVenta As VentaItem) As ArrayList
        commandText = New VentaItem().ObtenerVentasItemId(itemVenta)

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodasLasVentasItem(registers)
        End Select

        Return New Object
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo VentaItem
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo VentaItem</returns>
    Protected Function ObtenerTodasLasVentasItem(registers As IDataReader) As VentaItem
        Dim ventaItem = New VentaItem()

        ventaItem.Id = Long.Parse(registers("IDVENTAITEM").ToString())
        ventaItem.Producto.Id = Long.Parse(registers("IDPRODUCTO").ToString())
        ventaItem.Producto.Nombre = registers("PRODUCTO").ToString()
        ventaItem.PrecioUnitario = Decimal.Parse(registers("PRECIOUNITARIO").ToString())
        ventaItem.Cantidad = Integer.Parse(registers("CANTIDAD").ToString())

        Return ventaItem
    End Function
End Class
