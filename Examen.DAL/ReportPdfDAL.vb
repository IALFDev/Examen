Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Examen.Entidad
Imports iTextSharp.text.html

Public Class ReportPdfDAL

    ''' <summary>
    '''  Método para genenar un reporte en PDF
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo PDF con el resultado de la operación que genera el PDF</returns>
    Public Function GenerarPDF(pdf As PDF, lista As ArrayList) As PDF
        Try
            Dim document As New Document(PageSize.LETTER) 'Especifico el tipo de pagina
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(pdf.Ruta + "/" + pdf.Nombre, FileMode.Create)) 'Especifico donde se va a guardar el archivo


            Select Case pdf.TipoReporte 'Establecar titulo del archivo
                Case "Ventas"
                    document.AddTitle("Reporte ventas")
                Case "Clientes"
                    document.AddTitle("Reporte clientes")
                Case "Productos"
                    Select Case pdf.UltimaBusqueda
                        Case "ReporteVentas"
                            document.AddTitle("Reporte venta productos")
                        Case Else
                            document.AddTitle("Reporte productos")
                    End Select

                Case "DetalleVenta"
                    document.AddTitle(String.Format("Reporte Detalle Venta #{0}", pdf.VentaItem.Venta.Id))
            End Select

            document.AddAuthor("Ignacio Andrés Alfonso") 'Establesco el autor del archivo

            document.Open()

            Select Case pdf.TipoReporte 'Establecar titulo dentro del archivo
                Case "Ventas"
                    Dim parrafo2 As New Paragraph("Reporte ventas", New Font(Font.FontFamily.HELVETICA, 16))
                    parrafo2.SpacingBefore = -40
                    parrafo2.SpacingAfter = 0
                    parrafo2.Alignment = 1
                    document.Add(parrafo2)
                    document.Add(Chunk.NEWLINE)

                Case "Clientes"
                    Dim parrafo2 As New Paragraph("Reporte clientes", New Font(Font.FontFamily.HELVETICA, 16))
                    parrafo2.SpacingBefore = -40
                    parrafo2.SpacingAfter = 0
                    parrafo2.Alignment = 1
                    document.Add(parrafo2)
                    document.Add(Chunk.NEWLINE)

                Case "Productos"
                    Select Case pdf.UltimaBusqueda
                        Case "ReporteVentas"
                            Dim parrafo2 As New Paragraph("Reporte ventas productos", New Font(Font.FontFamily.HELVETICA, 16))
                            parrafo2.SpacingBefore = -40
                            parrafo2.SpacingAfter = 0
                            parrafo2.Alignment = 1
                            document.Add(parrafo2)
                            document.Add(Chunk.NEWLINE)
                        Case Else
                            Dim parrafo2 As New Paragraph("Reporte productos", New Font(Font.FontFamily.HELVETICA, 16))
                            parrafo2.SpacingBefore = -40
                            parrafo2.SpacingAfter = 0
                            parrafo2.Alignment = 1
                            document.Add(parrafo2)
                            document.Add(Chunk.NEWLINE)
                    End Select

                Case "DetalleVenta"
                    Dim parrafo2 As New Paragraph(String.Format("Reporte detalle venta #{0}", pdf.VentaItem.Venta.Id), New Font(Font.FontFamily.HELVETICA, 16))
                    parrafo2.SpacingBefore = -40
                    parrafo2.SpacingAfter = 0
                    parrafo2.Alignment = 1
                    document.Add(parrafo2)
                    document.Add(Chunk.NEWLINE)

            End Select

            Dim salto As New Paragraph(" ")
            document.Add(salto)

            Select Case pdf.TipoReporte 'Establecar información dentro del archivo
                Case "Productos"
                    Select Case pdf.UltimaBusqueda
                        Case "ReporteVentas"
                            document.Add(New Paragraph(String.Format("Ventas realizadas entre {0} y {1}", pdf.VentaItem.Venta.FechaDesde.ToString("dd/MM/yyyy"), pdf.VentaItem.Venta.FechaHasta.ToString("dd/MM/yyyy"))))
                    End Select
                Case "DetalleVenta"
                    document.Add(New Paragraph(String.Format("Cliente: {0}", CType(lista(0), VentaItem).Venta.Cliente.Cliente)))
                    document.Add(New Paragraph(String.Format("Teléfono: {0}", CType(lista(0), VentaItem).Venta.Cliente.Telefono)))
                    document.Add(New Paragraph(String.Format("Correo: {0}", CType(lista(0), VentaItem).Venta.Cliente.Correo)))
            End Select

            document.Add(salto)

            Select Case pdf.TipoReporte 'Establecar tavba con información dentro del archivo
                Case "Ventas"
                    Dim table As New PdfPTable(4)

                    table.AddCell("#")
                    table.AddCell("Cliente")
                    table.AddCell("Fecha venta")
                    table.AddCell("Total")

                    For i As Integer = 0 To lista.Count - 1

                        Dim cellIdVenta As New PdfPCell(New Phrase(CType(lista(i), Venta).Id, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellNombreCliente As New PdfPCell(New Phrase(CType(lista(i), Venta).Cliente.Cliente, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellFecha As New PdfPCell(New Phrase(CType(lista(i), Venta).Fecha.ToString("dd/MM/yyyy"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellTotal As New PdfPCell(New Phrase(Format(CType(lista(i), Venta).Total.ToString(), "Currency"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK))) 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'

                        table.AddCell(cellIdVenta)
                        table.AddCell(cellNombreCliente)
                        table.AddCell(cellFecha)
                        table.AddCell(cellTotal)
                    Next

                    table.AddCell("")
                    table.AddCell("")
                    table.AddCell("")

                    For i As Integer = 0 To lista.Count - 1

                        Dim cellIdVenta As New PdfPCell(New Phrase(CType(lista(i), Venta).Id, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellNombreCliente As New PdfPCell(New Phrase(CType(lista(i), Venta).Cliente.Cliente, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellFecha As New PdfPCell(New Phrase(CType(lista(i), Venta).Fecha.ToString("dd/MM/yyyy"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellTotal As New PdfPCell(New Phrase(Format(CType(lista(i), Venta).Total.ToString(), "Currency"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK))) 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'
                    Next

                    Dim decValue As Decimal
                    Dim total As Decimal = 0

                    For Each v As Venta In lista.OfType(Of Venta) 'Calculo el Total general
                        If Decimal.TryParse(v.Total, decValue) Then
                            total += decValue
                        End If
                    Next

                    table.AddCell("Total general: " + Format(total.ToString(), "Currency")) 

                    table.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    table.TotalWidth = 550.0F
                    table.LockedWidth = True

                    document.Add(table)
                Case "Clientes"
                    Dim table As New PdfPTable(4)

                    table.AddCell("#")
                    table.AddCell("Cliente")
                    table.AddCell("Teléfono")
                    table.AddCell("Correo")

                    For i As Integer = 0 To lista.Count - 1

                        Dim cellIdCliente As New PdfPCell(New Phrase(CType(lista(i), Cliente).Id, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellNombreCliente As New PdfPCell(New Phrase(CType(lista(i), Cliente).Cliente, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellTelefono As New PdfPCell(New Phrase(CType(lista(i), Cliente).Telefono, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellCorreo As New PdfPCell(New Phrase(CType(lista(i), Cliente).Correo, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        table.AddCell(cellIdCliente)
                        table.AddCell(cellNombreCliente)
                        table.AddCell(cellTelefono)
                        table.AddCell(cellCorreo)
                    Next

                    table.AddCell("")
                    table.AddCell("")
                    table.AddCell("")

                    table.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    table.TotalWidth = 550.0F
                    table.LockedWidth = True

                    document.Add(table)
                Case "Productos"
                    Select Case pdf.UltimaBusqueda
                        Case "ReporteVentas"
                            Dim table As New PdfPTable(2)

                            table.AddCell("Producto")
                            table.AddCell("Cantidad vendidos")


                            For i As Integer = 0 To lista.Count - 1

                                Dim cellNombreProducto As New PdfPCell(New Phrase(CType(lista(i), VentaItem).Producto.Nombre, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                                Dim cellCamtidadVendida As New PdfPCell(New Phrase(CType(lista(i), VentaItem).Cantidad, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                                table.AddCell(cellNombreProducto)
                                table.AddCell(cellCamtidadVendida)
                            Next

                            table.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                            table.TotalWidth = 550.0F
                            table.LockedWidth = True

                            document.Add(table)
                        Case Else
                            Dim table As New PdfPTable(4)

                            table.AddCell("#")
                            table.AddCell("Producto")
                            table.AddCell("Precio")
                            table.AddCell("Categoría")

                            For i As Integer = 0 To lista.Count - 1

                                Dim cellIdCliente As New PdfPCell(New Phrase(CType(lista(i), Producto).Id, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                                Dim cellNombreProducto As New PdfPCell(New Phrase(CType(lista(i), Producto).Nombre, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                                Dim cellPrecio As New PdfPCell(New Phrase(Format(CType(lista(i), Producto).Precio.ToString(), "Currency"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK))) 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'

                                Dim cellCategoria As New PdfPCell(New Phrase(CType(lista(i), Producto).Categoria, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                                table.AddCell(cellIdCliente)
                                table.AddCell(cellNombreProducto)
                                table.AddCell(cellPrecio)
                                table.AddCell(cellCategoria)
                            Next

                            table.AddCell("")
                            table.AddCell("")
                            table.AddCell("")

                            table.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                            table.TotalWidth = 550.0F
                            table.LockedWidth = True

                            document.Add(table)
                    End Select

                Case "DetalleVenta"
                    Dim table As New PdfPTable(4)

                    table.AddCell("Producto")
                    table.AddCell("Precio unitario")
                    table.AddCell("Cantidad")
                    table.AddCell("Precio total")

                    For i As Integer = 0 To lista.Count - 1

                        Dim cellNombreProducto As New PdfPCell(New Phrase(CType(lista(i), VentaItem).Producto.Nombre, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellNombreCliente As New PdfPCell(New Phrase(Format(CType(lista(i), VentaItem).PrecioUnitario.ToString(), "Currency"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK))) 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'

                        Dim cellCantidad As New PdfPCell(New Phrase(CType(lista(i), VentaItem).Cantidad, New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK)))

                        Dim cellPrecioTotal As New PdfPCell(New Phrase(Format(CType(lista(i), VentaItem).PrecioTotal.ToString(), "Currency"), New Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK))) 'Convierto el tipo de dato a tipo "Currency" que es tipo de dato moneda'

                        table.AddCell(cellNombreProducto)
                        table.AddCell(cellNombreCliente)
                        table.AddCell(cellCantidad)
                        table.AddCell(cellPrecioTotal)


                    Next

                    table.AddCell("")
                    table.AddCell("")
                    table.AddCell("")

                    Dim decValue As Decimal
                    Dim total As Decimal = 0

                    For Each vi As VentaItem In lista.OfType(Of VentaItem) 'Calculo Total
                        If Decimal.TryParse(vi.PrecioTotal, decValue) Then
                            total += decValue
                        End If
                    Next


                    table.AddCell("Total : " + Format(total.ToString(), "Currency"))

                    table.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    table.TotalWidth = 550.0F
                    table.LockedWidth = True

                    document.Add(table)
            End Select

            document.Add(New Paragraph("Creado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"))) 'Establesco cuando se creo el archivo

            document.Close() 'Se cierra el archvio
            writer.Close() 'Se guarda la información dentro del archivo

        Catch ex As Exception
            pdf.Excepcion.Error = True
            pdf.Excepcion.Mensaje = ex.ToString()
        End Try

        Return pdf
    End Function

End Class
