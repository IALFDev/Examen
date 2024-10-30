<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormGenerarReporteProductos
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
        Me.btnReporteVentasProductos = New System.Windows.Forms.Button()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lbA = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lbRangoFecha = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnReporteVentasProductos
        '
        Me.btnReporteVentasProductos.Location = New System.Drawing.Point(257, 29)
        Me.btnReporteVentasProductos.Name = "btnReporteVentasProductos"
        Me.btnReporteVentasProductos.Size = New System.Drawing.Size(128, 23)
        Me.btnReporteVentasProductos.TabIndex = 0
        Me.btnReporteVentasProductos.Text = "Generar reporte"
        Me.btnReporteVentasProductos.UseVisualStyleBackColor = True
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.Location = New System.Drawing.Point(12, 32)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaDesde.TabIndex = 1
        '
        'lbA
        '
        Me.lbA.AutoSize = True
        Me.lbA.Location = New System.Drawing.Point(119, 34)
        Me.lbA.Name = "lbA"
        Me.lbA.Size = New System.Drawing.Size(13, 13)
        Me.lbA.TabIndex = 2
        Me.lbA.Text = "a"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.Location = New System.Drawing.Point(138, 32)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaHasta.TabIndex = 3
        '
        'lbRangoFecha
        '
        Me.lbRangoFecha.AutoSize = True
        Me.lbRangoFecha.Location = New System.Drawing.Point(9, 9)
        Me.lbRangoFecha.Name = "lbRangoFecha"
        Me.lbRangoFecha.Size = New System.Drawing.Size(373, 13)
        Me.lbRangoFecha.TabIndex = 4
        Me.lbRangoFecha.Text = "Selecciona el rango de fechas par genrerar el reporte de ventas de productos"
        '
        'FormGenerarReporteProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 69)
        Me.Controls.Add(Me.lbRangoFecha)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.lbA)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.btnReporteVentasProductos)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(413, 108)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(413, 108)
        Me.Name = "FormGenerarReporteProductos"
        Me.Text = "Reporte ventas productos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReporteVentasProductos As Button
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents lbA As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents lbRangoFecha As Label
End Class
