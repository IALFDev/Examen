Imports Examen.Entidad

Public Class VentaDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Método que guarda en la base datos una nueva Venta en la datos del objeto Venta
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaEnBD(venta As Venta) As Venta
        commandText = venta.GuardarVentaEnBD()

        Try
            venta.Id = ExecuteScalar()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable venta.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            venta.Excepcion.Error = True
            venta.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return venta
    End Function

    ''' <summary>
    '''  Método que guarda la edicion de los datos de la venta ya existente en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de guardado de la venta en la base de datos</returns>
    Public Function EditarVentaEnBd(venta As Venta) As Venta
        commandText = venta.EditarVentaEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable venta.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            venta.Excepcion.Error = True
            venta.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return venta
    End Function

    ''' <summary>
    '''  Método que elimina la venta de manera logica en la base datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de eliminación del venta en la base datos</returns>
    Public Function EliminarVentaEnBd(venta As Venta) As Venta
        commandText = venta.EliminarVentaEnBd()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable venta.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            venta.Excepcion.Error = True
            venta.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return venta
    End Function

    ''' <summary>
    '''  Método que guarda la edicion del Total en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Venta con el resultado de la operación de edición del Total en la base de datos</returns>
    Public Function ActualizarTotalDeLaVenta(venta As Venta) As Venta
        commandText = venta.ActualizarTotalDeLaVenta()

        Try
            ExecuteNonQuery()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable venta.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            venta.Excepcion.Error = True
            venta.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return venta
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList de todos las ventas en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Public Function ObtenerTodasLasVentas() As ArrayList
        commandText = New Venta().ObtenerTodasLasVentas()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion del tipo ArrayList las ventas en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Public Function ObtenerVentas(Optional idVenta As String = "", Optional clienteNombre As String = "", Optional fechaDesde As String = "", Optional fechaHasta As String = "") As ArrayList
        commandText = New Venta().ObtenerVentas(idVenta, clienteNombre, fechaDesde, fechaHasta)

        tipoOp = 1

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodasLasVentas(registers)
            Case 1
                Return ObtenerVentas(registers)
        End Select

        Return New Object
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Venta
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta</returns>
    Protected Function ObtenerTodasLasVentas(registers As IDataReader) As Venta
        Dim venta = New Venta()

        venta.Id = Long.Parse(registers("IDVENTA").ToString())
        venta.Cliente.Id = Long.Parse(registers("IDCLIENTE").ToString())
        venta.Cliente.Cliente = registers("CLIENTE").ToString()
        venta.Fecha = DateTime.Parse(registers("FECHAVENTA").ToString())
        venta.Total = If(String.IsNullOrEmpty(registers("TOTALVENTA").ToString()), 0, Decimal.Parse(registers("TOTALVENTA").ToString()))

        Return venta
    End Function

    ''' <summary>
    '''  Método que almacena todos los datos obtenidos en el objeto del tipo Venta
    ''' </summary>
    ''' <returns>Devuelve un objeto del tipo Venta</returns>
    Protected Function ObtenerVentas(registers As IDataReader) As Venta
        Dim venta = New Venta()

        venta.Id = Long.Parse(registers("IDVENTA").ToString())
        venta.Cliente.Id = Long.Parse(registers("IDCLIENTE").ToString())
        venta.Cliente.Cliente = registers("CLIENTE").ToString()
        venta.Fecha = DateTime.Parse(registers("FECHAVENTA").ToString())
        venta.Total = If(String.IsNullOrEmpty(registers("TOTALVENTA").ToString()), 0, Decimal.Parse(registers("TOTALVENTA").ToString()))

        Return venta
    End Function
End Class
