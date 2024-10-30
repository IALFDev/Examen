<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDetalleVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvVentaItem = New System.Windows.Forms.DataGridView()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.lbNombreCliente = New System.Windows.Forms.Label()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.lbFechaVenta = New System.Windows.Forms.Label()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.lbTotalVenta = New System.Windows.Forms.Label()
        Me.btnGenerarReporte = New System.Windows.Forms.Button()
        CType(Me.dgvVentaItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVentaItem
        '
        Me.dgvVentaItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentaItem.Location = New System.Drawing.Point(12, 56)
        Me.dgvVentaItem.Name = "dgvVentaItem"
        Me.dgvVentaItem.Size = New System.Drawing.Size(776, 341)
        Me.dgvVentaItem.TabIndex = 14
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(13, 13)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(42, 13)
        Me.lbCliente.TabIndex = 15
        Me.lbCliente.Text = "Cliente:"
        '
        'lbNombreCliente
        '
        Me.lbNombreCliente.AutoSize = True
        Me.lbNombreCliente.Location = New System.Drawing.Point(61, 13)
        Me.lbNombreCliente.Name = "lbNombreCliente"
        Me.lbNombreCliente.Size = New System.Drawing.Size(39, 13)
        Me.lbNombreCliente.TabIndex = 16
        Me.lbNombreCliente.Text = "Cliente"
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Location = New System.Drawing.Point(115, 13)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(70, 13)
        Me.lbFecha.TabIndex = 17
        Me.lbFecha.Text = "Fecha venta:"
        '
        'lbFechaVenta
        '
        Me.lbFechaVenta.AutoSize = True
        Me.lbFechaVenta.Location = New System.Drawing.Point(191, 13)
        Me.lbFechaVenta.Name = "lbFechaVenta"
        Me.lbFechaVenta.Size = New System.Drawing.Size(68, 13)
        Me.lbFechaVenta.TabIndex = 18
        Me.lbFechaVenta.Text = "Fecha Venta"
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Location = New System.Drawing.Point(265, 13)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(34, 13)
        Me.lbTotal.TabIndex = 19
        Me.lbTotal.Text = "Total:"
        '
        'lbTotalVenta
        '
        Me.lbTotalVenta.AutoSize = True
        Me.lbTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVenta.Location = New System.Drawing.Point(305, 13)
        Me.lbTotalVenta.Name = "lbTotalVenta"
        Me.lbTotalVenta.Size = New System.Drawing.Size(72, 13)
        Me.lbTotalVenta.TabIndex = 20
        Me.lbTotalVenta.Text = "Total venta"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.Location = New System.Drawing.Point(12, 415)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(120, 23)
        Me.btnGenerarReporte.TabIndex = 21
        Me.btnGenerarReporte.Text = "Generar reporte"
        Me.btnGenerarReporte.UseVisualStyleBackColor = True
        '
        'FormDetalleVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Controls.Add(Me.lbTotalVenta)
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.lbFechaVenta)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.lbNombreCliente)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.dgvVentaItem)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(816, 489)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(816, 489)
        Me.Name = "FormDetalleVenta"
        Me.Text = "Detalle venta"
        CType(Me.dgvVentaItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvVentaItem As DataGridView
    Friend WithEvents lbCliente As Label
    Friend WithEvents lbNombreCliente As Label
    Friend WithEvents lbFecha As Label
    Friend WithEvents lbFechaVenta As Label
    Friend WithEvents lbTotal As Label
    Friend WithEvents lbTotalVenta As Label
    Friend WithEvents btnGenerarReporte As Button
End Class
