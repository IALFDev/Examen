Public Class VentaItem
    Private _id As Long
    Private _venta As Venta
    Private _producto As Producto
    Private _precioUnitario As Decimal
    Private _cantidad As Integer
    Private _excepcion As Excepcion

    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
        End Set
    End Property

    Public Property Venta As Venta
        Get
            If _venta Is Nothing Then
                _venta = New Venta()
            End If

            Return _venta
        End Get
        Set(value As Venta)
            _venta = value
        End Set
    End Property

    Public Property Producto As Producto
        Get
            If _producto Is Nothing Then
                _producto = New Producto()
            End If

            Return _producto
        End Get
        Set(value As Producto)
            _producto = value
        End Set
    End Property

    Public ReadOnly Property IdProducto As String 'Propiedad adicional para poder mostrarla en la grilla
        Get
            Return If(_producto IsNot Nothing, _producto.Id, String.Empty)
        End Get
    End Property

    Public ReadOnly Property NombreProducto As String 'Propiedad adicional para poder mostrarla en la grilla
        Get
            Return If(_producto IsNot Nothing, _producto.Nombre, String.Empty)
        End Get
    End Property

    Public Property PrecioUnitario As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(value As Decimal)
            _precioUnitario = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public ReadOnly Property PrecioTotal As Decimal
        Get
            Return _precioUnitario * _cantidad
        End Get
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
    '''  Metodo que devuelve un objeto del tipo VentaItem con los datos necesarios para guardar la VentaItem en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo VentaItem para guardar los datos de la venta en la base de datos</returns>
    Public Function GenerarObjetoVentaItemParaGuardarEnBd(idVenta As Long, idProducto As Long, precioUniario As Decimal, cantidad As Integer) As VentaItem
        Dim ventaItem = New VentaItem()

        ventaItem.Venta.Id = idVenta
        ventaItem.Producto.Id = idProducto
        ventaItem.PrecioUnitario = precioUniario
        ventaItem.Cantidad = cantidad

        Return ventaItem
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo VentaItem con los datos necesarios para guardar la VentaItem en la base datos, este caso recibe una sobrecarga más para poder editar la VentaItem en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo VentaItem para guardar los datos del VentaItem en la base de datos</returns>
    Public Function GenerarObjetoVentaItemParaGuardarEnBd(idVentaItem As Long, idVenta As Long, idProducto As Long, precioUniario As Decimal, cantidad As Integer) As VentaItem
        Dim ventaItem = New VentaItem()

        ventaItem.Id = idVentaItem
        ventaItem.Venta.Id = idVenta
        ventaItem.Producto.Id = idProducto
        ventaItem.PrecioUnitario = precioUniario
        ventaItem.Cantidad = cantidad

        Return ventaItem
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo VentaItem con los datos necesarios para eliminar de manera logica el VentaItem en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo VentaItem para guardar los datos del VentaItem en la base de datos</returns>
    Public Function GenerarObjetoVentaItemParaEliminarEnBd(idVentaItem As Long) As VentaItem
        Dim ventaItem = New VentaItem()

        ventaItem.Id = idVentaItem

        Return ventaItem
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar los datos de la ventaItem en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto para guardar los datos de la ventaItem en la base de datos</returns>
    Public Function GuardarVentaItemEnBD()
        Dim precioUnitarioFormateado As String = PrecioUnitario.ToString(System.Globalization.CultureInfo.InvariantCulture) 'Formateo el nuemro para poder ser guardado en la base de datos como Float'
        Dim precioTotalFormateado As String = PrecioTotal.ToString(System.Globalization.CultureInfo.InvariantCulture) 'Formateo el nuemro para poder ser guardado en la base de datos como Float'
        Dim cmd = String.Format("INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES ({0}, {1}, {2}, {3}, {4})", Venta.Id, Producto.Id, precioUnitarioFormateado, Cantidad, precioTotalFormateado)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar la edicion de los datos de la ventaItem ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Producto para guardar la edicion de los datos de la ventaItem ya existente la base de datos</returns>
    Public Function EditarVentaItemEnBd() As String
        Dim precioUnitarioFormateado As String = PrecioUnitario.ToString(System.Globalization.CultureInfo.InvariantCulture) 'Formateo el nuemro para poder ser guardado en la base de datos como Float'
        Dim precioTotalFormateado As String = PrecioTotal.ToString(System.Globalization.CultureInfo.InvariantCulture) 'Formateo el nuemro para poder ser guardado en la base de datos como Float'
        Dim cmd = String.Format("UPDATE ventasitems SET IDProducto = {0}, PrecioUnitario = {1}, Cantidad = {2}, PrecioTotal = {3} WHERE ventasitems.ID = {4}", Producto.Id, precioUnitarioFormateado, Cantidad, precioTotalFormateado, Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para eliminar de manera logica la ventaItem en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para eliminar de manera logica la ventaItem en la base de datos</returns>
    Public Function EliminarVentaItemEnBd() As String
        Dim cmd = String.Format("UPDATE ventasitems SET Activo = 0 WHERE ventasitems.ID = {0}", Id)

        Return cmd
    End Function


    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener todos las ventasItem en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener todos los ventasItem</returns>
    Public Function ObtenerTodasLasVentasItem() As String
        Dim cmd = "SELECT vi.ID AS IDVENTAITEM, p.ID AS IDPRODUCTO, p.Nombre AS PRODUCTO, vi.PrecioUnitario AS PRECIOUNITARIO, vi.Cantidad AS CANTIDAD, vi.PrecioTotal AS PRECIOTOTAL FROM ventasitems vi INNER JOIN productos AS p ON vi.IDProducto = p.ID WHERE vi.Activo = 1"

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener las ventasItem por Id en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener los ventasItem</returns>
    Public Function ObtenerVentasItemId(ventaItem As VentaItem) As String
        Dim cmd = String.Format("SELECT vi.ID AS IDVENTAITEM, p.ID AS IDPRODUCTO, p.Nombre AS PRODUCTO, vi.PrecioUnitario AS PRECIOUNITARIO, vi.Cantidad AS CANTIDAD, vi.PrecioTotal AS PRECIOTOTAL FROM ventasitems vi INNER JOIN productos AS p ON vi.IDProducto = p.ID WHERE vi.IDVenta = {0} AND vi.Activo = 1", ventaItem.Id)

        Return cmd
    End Function
End Class
