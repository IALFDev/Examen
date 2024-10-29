Imports Examen.DAL
Imports Examen.Entidad

Public Class ManagerPDF
    ''' <summary>
    '''  Método que obtiene una collecion de todas las ventas desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto Tipo PDF con el resultado de la operación que genera el PD</returns>
    Public Function GenerarReportePDF(pdf As PDF) As PDF
        Dim pdfDAL = New ReportPdfDAL()
        Dim aLista As ArrayList = Nothing

        Select Case pdf.TipoReporte
            Case "Ventas"
                Select Case pdf.UltimaBusqueda
                    Case "Todos"
                        aLista = ObtenerTodasLasVentas()
                    Case "Filtro"
                        aLista = ObtenerVentas(If(String.IsNullOrEmpty(pdf.Venta.Id) Or pdf.Venta.Id = "0", "", pdf.Venta.Id), pdf.Venta.Cliente.Cliente, pdf.Venta.FechaDesde, pdf.Venta.FechaHasta)
                End Select
            Case "Clientes"
                Select Case pdf.UltimaBusqueda
                    Case "Todos"
                        aLista = ObtenerTodosLosClientes()
                    Case "Filtro"
                        aLista = ObtenerClientes(If(String.IsNullOrEmpty(pdf.Cliente.Id) Or pdf.Cliente.Id = "0", "", pdf.Cliente.Id), pdf.Cliente.Cliente, If(String.IsNullOrEmpty(pdf.Cliente.Telefono) Or pdf.Cliente.Telefono = "0", "", pdf.Cliente.Telefono), pdf.Cliente.Correo)
                End Select
            Case "Productos"
                Select Case pdf.UltimaBusqueda
                    Case "Todos"
                        aLista = ObtenerTodosLosProductos()
                    Case "Filtro"
                        aLista = ObtenerProductos(If(String.IsNullOrEmpty(pdf.Producto.Id) Or pdf.Producto.Id = "0", "", pdf.Cliente.Id), pdf.Producto.Nombre, If(String.IsNullOrEmpty(pdf.Producto.PrecioDesde) Or pdf.Producto.PrecioDesde = "0", "", pdf.Cliente.Id), If(String.IsNullOrEmpty(pdf.Producto.PrecioHasta) Or pdf.Producto.PrecioHasta = "0", "", pdf.Producto.PrecioHasta))
                End Select
        End Select

        pdf = pdfDAL.GenerarPDF(pdf, aLista)

        Return pdf
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todas las ventas desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Protected Function ObtenerTodasLasVentas() As ArrayList
        Dim manager = New ManagerVenta()

        Dim resultado = manager.ObtenerTodasLasVentas()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion los venta desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Venta</returns>
    Protected Function ObtenerVentas(Optional idVenta As String = "", Optional clienteNombre As String = "", Optional fechaDesde As String = "", Optional fechaHasta As String = "") As ArrayList
        Dim manager = New ManagerVenta()

        Dim resultado = manager.ObtenerVentas(idVenta, clienteNombre, fechaDesde, fechaHasta)

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todos los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerTodosLosClientes() As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerTodosLosClientes()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion los clientes desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Cliente</returns>
    Protected Function ObtenerClientes(Optional idCliente As String = "", Optional cliente As String = "", Optional telefono As String = "", Optional correo As String = "") As ArrayList
        Dim manager = New ManagerCliente()

        Dim resultado = manager.ObtenerClientes(idCliente, cliente, telefono, correo)

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion de todos los productos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Producto</returns>
    Protected Function ObtenerTodosLosProductos() As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerTodosLosProductos()

        Return resultado
    End Function

    ''' <summary>
    '''  Método que obtiene una collecion los producto desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Arraylist de objetos tipo Productos</returns>
    Protected Function ObtenerProductos(Optional idProducto As String = "", Optional nombre As String = "", Optional categoria As String = "", Optional precioMin As String = "", Optional precioMax As String = "") As ArrayList
        Dim manager = New ManagerProducto()

        Dim resultado = manager.ObtenerProductos(idProducto, nombre, categoria, precioMin, precioMax)

        Return resultado
    End Function
End Class
