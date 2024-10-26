Imports Examen.Entidad

Public Class ProductoDAL
    Inherits AbstractMapper
    Private tipoOp As Integer

    ''' <summary>
    '''  Metodo que obtiene una collecion de todos los productos de la base de datos
    '''  Procedure, una colección del Tipo Producto
    ''' </summary>
    ''' <returns>Devuelve un Arraylis del Tipo Producto</returns>
    Public Function ObtenerTodosLosProductos() As ArrayList
        commandText = New Producto().ObtenerTodosLosProductos()

        tipoOp = 0

        Dim resultado = AbstractFindAll()

        Return resultado

    End Function

    Public Overrides Function DoLoad(registers As IDataReader) As Object
        Select Case tipoOp
            Case 0
                Return ObtenerTodosLosProductos(registers)
        End Select

        Return New Object
    End Function

    Protected Function ObtenerTodosLosProductos(registers As IDataReader) As Producto
        Dim producto = New Producto()

        producto.Id = Long.Parse(registers("IDPRODUCTO").ToString)
        producto.Nombre = registers("NOMBRE").ToString
        producto.Precio = Decimal.Parse(registers("PRECIO").ToString)
        producto.Categoria = registers("CATEGORIA").ToString

        Return producto
    End Function
End Class
