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
    '''  Método que obtiene una collecion del tipo ArrayList de todos los productos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Public Function ObtenerTodasLasVentas() As ArrayList
        commandText = New Venta().ObtenerTodasLasVentas()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodasLasVentas(registers)
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
        venta.Cliente.Cliente = registers("CLIENTE").ToString()
        venta.Fecha = DateTime.Parse(registers("FECHAVENTA").ToString())
        venta.Total = Decimal.Parse(registers("TOTALVENTA").ToString())

        Return venta
    End Function
End Class
