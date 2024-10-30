Imports Examen.BLL
Imports Examen.Entidad
Imports System.Environment
Imports System.IO

Public Class FormGenerarReporteProductos

    Private Sub FormGenerarReporteProductos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConfigurarContenido()
    End Sub

    Protected Sub ConfigurarContenido()
        EstablecarFechas()
    End Sub

    Protected Sub EstablecarFechas()
        Dim fechaActual As DateTime = DateTime.Now 'Obtengo la fecha actual
        Dim primerDiaMes As DateTime = New DateTime(fechaActual.Year, fechaActual.Month, 1) 'Primer día del mes
        Dim ultimoDiaMes As DateTime = primerDiaMes.AddMonths(1).AddDays(-1) 'Último día del mes

        dtpFechaDesde.Value = primerDiaMes
        dtpFechaHasta.Value = ultimoDiaMes
    End Sub

    Private Sub btnReporteVentasProductos_Click(sender As Object, e As EventArgs) Handles btnReporteVentasProductos.Click
        MostarSaveDialog()
    End Sub

    ''' <summary>
    '''  Método muestra un ShowOpenDialog obtiene la ruta, nombre y el tipo de reporte para genenar un reporte en PDF
    ''' </summary>
    Public Sub MostarSaveDialog()
        Dim saveFileD As New SaveFileDialog
        saveFileD.InitialDirectory = GetFolderPath(SpecialFolder.Desktop)
        saveFileD.Title = "Guardar reporte"
        saveFileD.FileName = "Reporte Ventas Productos"
        saveFileD.CheckPathExists = True
        saveFileD.DefaultExt = "*pdf"
        saveFileD.Filter = "PDF (*.pdf)|*.pdf|All Files|*.*"
        saveFileD.FilterIndex = 1
        saveFileD.RestoreDirectory = True

        Dim diag As DialogResult = saveFileD.ShowDialog()
        Dim ventaItem = New VentaItem()

        ventaItem.Venta.FechaDesde = dtpFechaDesde.Value
        ventaItem.Venta.FechaHasta = dtpFechaHasta.Value

        If diag = DialogResult.OK Then 'Verifico que el se haya seleccionado la ruta para guardar el reporte

            Dim path = saveFileD.FileName 'Obtengo la dirección completa del reporte a guardar
            Dim directory As String = New FileInfo(path).DirectoryName 'Separo la carpeta donde se va a guardar el reporte
            Dim file As String = New FileInfo(path).Name 'Separo la el nombre del reporte

            If Not GenerarReportePDF(New PDF().GenerarObjetoParaReportePDF(file, directory, "Productos", "ReporteVentas", Nothing, Nothing, Nothing, ventaItem)).Excepcion.Error Then 'Verifico que el reporte se haya generado correctamente
                MessageBox.Show("Se genero el reporte correctamente", "Genial", MessageBoxButtons.OK, MessageBoxIcon.None) 'Si el reporte se genero correctamente muesto un MessageBox

            ElseIf diag = DialogResult.Cancel Then
                MessageBox.Show("Se cancelo la generación del reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si no se selecciono una ruta muesto un MessageBox
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método reporte para genenar un reporte en PDF desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo PDF con el resultado de la operación que genera el PDF</returns>
    Protected Function GenerarReportePDF(pdf As PDF) As PDF
        Dim manager = New ManagerPDF()

        pdf = manager.GenerarReportePDF(pdf)

        Return pdf
    End Function
End Class