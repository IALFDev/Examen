Public Class Venta
    Private _id As Long
    Private _cliente As Cliente
    Private _fecha As DateTime
    Private _fechaDesde As DateTime
    Private _fechaHasta As DateTime
    Private _total As Decimal
    Private _excepcion As Excepcion

    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            If IsNothing(_cliente) Then
                _cliente = New Cliente
            End If

            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public ReadOnly Property IdCliente As String 'Propiedad adicional para poder mostrarla en la grilla
        Get
            Return If(_cliente IsNot Nothing, _cliente.Id, String.Empty)
        End Get
    End Property

    Public ReadOnly Property NombreCliente As String 'Propiedad adicional para poder mostrarla en la grilla
        Get
            Return If(_cliente IsNot Nothing, _cliente.Cliente, String.Empty)
        End Get
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property FechaDesde As Date
        Get
            Return _fechaDesde
        End Get
        Set(value As Date)
            _fechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date
        Get
            Return _fechaHasta
        End Get
        Set(value As Date)
            _fechaHasta = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return _total
        End Get
        Set(value As Decimal)
            _total = value
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
    '''  Metodo que devuelve un objeto del tipo Venta con los datos necesarios para guardar la Venta en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta para guardar los datos de la venta en la base de datos</returns>
    Public Function GenerarObjetoVentaParaGuardarEnBd(idCliente As Long, fecha As Date, total As Decimal) As Venta
        Dim venta = New Venta()

        venta.Cliente.Id = idCliente
        venta.Fecha = fecha
        venta.Total = total

        Return venta
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Venta con los datos necesarios para guardar la Venta en la base datos, este caso recibe una sobrecarga más para poder editar la venta en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta para guardar los datos del Venta en la base de datos</returns>
    Public Function GenerarObjetoVentaParaGuardarEnBd(idVenta As Long, idCliente As Long, fecha As Date, total As Decimal) As Venta
        Dim venta = New Venta()

        venta.Id = idVenta
        venta.Cliente.Id = idCliente
        venta.Fecha = fecha
        venta.Total = total

        Return venta
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Venta con los datos necesarios para eliminar de manera logica la venta en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta para guardar los datos del venta en la base de datos</returns>
    Public Function GenerarObjetoVentaParaEliminarEnBd(id As Long) As Venta
        Dim venta = New Venta()

        venta.Id = id

        Return venta
    End Function

    ''' <summary>
    '''  Metodo que devuelve un objeto del tipo Venta con los datos necesarios para actualizar el Total de la venta en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta para actualizar el Total de la venta en la base de datos</returns>
    Public Function GenerarObjetoVentaParaActualizarTotal(id As Long) As Venta
        Dim venta = New Venta()

        venta.Id = id

        Return venta
    End Function


    ''' <summary>
    '''  Método que obtiene un string para guardar los datos de la venta en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar los datos de la venta  en la base de datos</returns>
    Public Function GuardarVentaEnBD()
        Dim totalFormateado As String = Total.ToString(System.Globalization.CultureInfo.InvariantCulture) 'Formateo el nuemro para poder ser guardado en la base de datos como Float'
        Dim cmd = String.Format("INSERT INTO ventas (IDCliente, Fecha, Total) VALUES ({0}, CONVERT(DATETIME, '{1}', 102), {2}) SELECT CAST (SCOPE_IDENTITY() AS INT)", Cliente.Id, Fecha.ToString("yyyy-MM-dd HH:mm:ss"), totalFormateado)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar la edicion de los datos de la venta ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar la edicion de los datos de la venta ya existente la base de datos</returns>
    Public Function EditarVentaEnBd() As String
        Dim cmd = String.Format("UPDATE ventas SET IDCliente = {0}, Fecha = CONVERT(DATETIME, '{1}', 102) WHERE ventas.ID = {2}", Cliente.Id, Fecha.ToString("yyyy-MM-dd HH:mm:ss"), Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para eliminar de manera logica la venta en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para eliminar de manera logica la venta en la base de datos</returns>
    Public Function EliminarVentaEnBd() As String
        Dim cmd = String.Format("UPDATE ventas SET Activo = 0 WHERE ventas.ID = {0}", Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Método que obtiene un string para guardar la edicion del Total en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string para guardar la edicion del Total ya existente la base de datos</returns>
    Public Function ActualizarTotalDeLaVenta() As String
        Dim cmd = String.Format("UPDATE ventas SET Total = (SELECT SUM(vi.PrecioTotal) FROM ventasitems vi INNER JOIN productos p ON vi.IDProducto = p.ID WHERE vi.IDVenta = {0} AND vi.Activo = 1) WHERE ID = {1};", Id, Id)

        Return cmd
    End Function

    ''' <summary>
    '''  Metodo que obtiene un string para la consulta de para obtener todos las ventas en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un string con la consulta para obtener todos los ventas</returns>

    Public Function ObtenerTodasLasVentas() As String
        Dim cmd = "SELECT v.ID AS IDVENTA, c.ID AS IDCLIENTE, c.Cliente AS CLIENTE, v.Fecha AS FECHAVENTA, v.Total AS TOTALVENTA FROM ventas AS v INNER JOIN clientes AS c ON v.IDCliente = c.ID WHERE v.Activo = 1"

        Return cmd
    End Function

    Public Function ObtenerVentas(Optional idVenta As String = "", Optional clienteNombre As String = "", Optional fechaDesde As String = "", Optional fechaHasta As String = "") As String
        Dim sqlQuery As String = "SELECT v.ID AS IDVENTA, c.ID AS IDCLIENTE, c.Cliente AS CLIENTE, v.Fecha AS FECHAVENTA, v.Total AS TOTALVENTA FROM ventas AS v INNER JOIN clientes AS c ON v.IDCliente = c.ID WHERE v.Activo = 1" ' Base de la consulta SQL

        Dim condiciones As New List(Of String) 'Lista para agregar condiciones dinámicas


        If Not String.IsNullOrEmpty(idVenta) Then 'Agrego condiciones solo si los parámetros tienen valor
            condiciones.Add("CAST(v.Id AS VARCHAR) LIKE '%" & idVenta.Replace("'", "''") & "%'") 'Uso LIKE para buscar coincidencias parciales en ID venta
        End If
        If Not String.IsNullOrEmpty(clienteNombre) Then 'Uso LIKE para buscar coincidencias parciales en el nombre del cliente
            condiciones.Add("v.Cliente LIKE '%" & clienteNombre.Replace("'", "''") & "%'")
        End If
        If Not String.IsNullOrEmpty(fechaDesde) AndAlso IsDate(fechaDesde) Then
            condiciones.Add("CONVERT(DATE, v.Fecha) ='" & DateTime.Parse(fechaDesde).ToString("yyyy-MM-dd") & "'") 'Filtro por fecha desde si el valor es una fecha válida
        End If
        If Not String.IsNullOrEmpty(fechaHasta) AndAlso IsDate(fechaHasta) Then
            condiciones.Add("CONVERT(DATE, v.Fecha) ='" & DateTime.Parse(fechaHasta).ToString("yyyy-MM-dd") & "'") 'Filtramos por fecha hasta si el valor es una fecha válida
        End If

        ' Si hay condiciones, las agregamos a la consulta
        If condiciones.Count > 0 Then
            sqlQuery &= " AND " & String.Join(" AND ", condiciones)
        End If

        ' Retornamos el SQL formateado
        Return sqlQuery
    End Function

End Class
