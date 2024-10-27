Imports Examen.Entidad

Public Class VentaItemDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Método que guarda en la base datos una nueva VentaItem en la datos del objeto Venta
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo VentaItem con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarVentaEnBD(ventaItem As VentaItem) As VentaItem
        commandText = ventaItem.GuardarVentaItemEnBD()

        Try
            Venta.Id = ExecuteScalar()
        Catch ex As Exception 'Si hay un error lo almaceno en la variable venta.Excepcion.Mensaje el mensaje de la Excepcion ocurrida para si se quiere mostrar en pantalla o guardar en una tabla si se quiere
            Venta.Excepcion.Error = True
            Venta.Excepcion.Mensaje = ex.Message.ToString
        End Try

        Return Venta
    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Throw New NotImplementedException()
    End Function
End Class
