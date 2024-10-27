Public Class VentaItem
    Private _id As Long
    Private _venta As Venta
    Private _producto As Producto
    Private _precioUnitario As Decimal
    Private _cantidad As Integer

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
End Class
