Public Class PDF
    Private _nombre As String
    Private _ruta As String
    Private _tipoReporte As String
    Private _ultimaBusqueda As String
    Private _venta As Venta
    Private _Producto As Producto
    Private _cliente As Cliente
    Private _detalleVenta As VentaItem
    Private _excepcion As Excepcion

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Ruta As String
        Get
            Return _ruta
        End Get
        Set(value As String)
            _ruta = value
        End Set
    End Property

    Public Property TipoReporte As String
        Get
            Return _tipoReporte
        End Get
        Set(value As String)
            _tipoReporte = value
        End Set
    End Property

    Public Property UltimaBusqueda As String
        Get
            Return _ultimaBusqueda
        End Get
        Set(value As String)
            _ultimaBusqueda = value
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
            If _Producto Is Nothing Then
                _Producto = New Producto()
            End If

            Return _Producto
        End Get
        Set(value As Producto)
            _Producto = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            If _cliente Is Nothing Then
                _cliente = New Cliente()
            End If

            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property


    Public Property DetalleVenta As VentaItem
        Get
            If _detalleVenta Is Nothing Then
                _detalleVenta = New VentaItem()
            End If

            Return _detalleVenta
        End Get
        Set(value As VentaItem)
            _detalleVenta = value
        End Set
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
    '''  Metodo que devuelve un objeto del tipo Pdf con los datos necesarios para generación de un reporte en PDF
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo PDF para generar el PDF</returns>
    Public Function GenerarObjetoParaReportePDF(nombre As String, ruta As String, tipoReporte As String, ultimaBusqueda As String, Optional venta As Venta = Nothing, Optional cliente As Cliente = Nothing, Optional producto As Producto = Nothing) As PDF
        Dim pdf = New PDF()

        pdf.Nombre = nombre
        pdf.Ruta = ruta
        pdf.TipoReporte = tipoReporte
        pdf.UltimaBusqueda = ultimaBusqueda
        pdf.Venta = venta
        pdf.Cliente = cliente
        pdf.Producto = producto

        Return pdf

    End Function
End Class
