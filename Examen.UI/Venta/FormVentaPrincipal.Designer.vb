<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentaPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbIdCliente = New System.Windows.Forms.Label()
        Me.txtIdVenta = New System.Windows.Forms.TextBox()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.lbFechaDesde = New System.Windows.Forms.Label()
        Me.LbFechaHasta = New System.Windows.Forms.Label()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.dgvVenta = New System.Windows.Forms.DataGridView()
        Me.btnRealizarVenta = New System.Windows.Forms.Button()
        Me.btnGenerarReporte = New System.Windows.Forms.Button()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.lbNoResultados = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbIdCliente
        '
        Me.lbIdCliente.AutoSize = True
        Me.lbIdCliente.Location = New System.Drawing.Point(12, 15)
        Me.lbIdCliente.Name = "lbIdCliente"
        Me.lbIdCliente.Size = New System.Drawing.Size(48, 13)
        Me.lbIdCliente.TabIndex = 3
        Me.lbIdCliente.Text = "ID venta"
        '
        'txtIdVenta
        '
        Me.txtIdVenta.Location = New System.Drawing.Point(67, 13)
        Me.txtIdVenta.Name = "txtIdVenta"
        Me.txtIdVenta.Size = New System.Drawing.Size(69, 20)
        Me.txtIdVenta.TabIndex = 4
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(142, 15)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(39, 13)
        Me.lbCliente.TabIndex = 5
        Me.lbCliente.Text = "Cliente"
        '
        'lbFechaDesde
        '
        Me.lbFechaDesde.AutoSize = True
        Me.lbFechaDesde.Location = New System.Drawing.Point(319, 15)
        Me.lbFechaDesde.Name = "lbFechaDesde"
        Me.lbFechaDesde.Size = New System.Drawing.Size(69, 13)
        Me.lbFechaDesde.TabIndex = 7
        Me.lbFechaDesde.Text = "Fecha desde"
        '
        'LbFechaHasta
        '
        Me.LbFechaHasta.AutoSize = True
        Me.LbFechaHasta.Location = New System.Drawing.Point(500, 15)
        Me.LbFechaHasta.Name = "LbFechaHasta"
        Me.LbFechaHasta.Size = New System.Drawing.Size(66, 13)
        Me.LbFechaHasta.TabIndex = 9
        Me.LbFechaHasta.Text = "Fecha hasta"
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Location = New System.Drawing.Point(668, 13)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(120, 23)
        Me.btnBuscarProducto.TabIndex = 11
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'dgvVenta
        '
        Me.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVenta.Location = New System.Drawing.Point(15, 98)
        Me.dgvVenta.Name = "dgvVenta"
        Me.dgvVenta.Size = New System.Drawing.Size(773, 311)
        Me.dgvVenta.TabIndex = 12
        Me.dgvVenta.Visible = False
        '
        'btnRealizarVenta
        '
        Me.btnRealizarVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealizarVenta.Location = New System.Drawing.Point(642, 57)
        Me.btnRealizarVenta.Name = "btnRealizarVenta"
        Me.btnRealizarVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRealizarVenta.Size = New System.Drawing.Size(146, 35)
        Me.btnRealizarVenta.TabIndex = 14
        Me.btnRealizarVenta.Text = "Realizar nueva venta"
        Me.btnRealizarVenta.UseVisualStyleBackColor = True
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.Location = New System.Drawing.Point(12, 415)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(120, 23)
        Me.btnGenerarReporte.TabIndex = 15
        Me.btnGenerarReporte.Text = "Generar reporte"
        Me.btnGenerarReporte.UseVisualStyleBackColor = True
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(187, 11)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(126, 20)
        Me.txtNombreCliente.TabIndex = 16
        '
        'lbNoResultados
        '
        Me.lbNoResultados.AutoSize = True
        Me.lbNoResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNoResultados.Location = New System.Drawing.Point(215, 210)
        Me.lbNoResultados.Name = "lbNoResultados"
        Me.lbNoResultados.Size = New System.Drawing.Size(370, 31)
        Me.lbNoResultados.TabIndex = 19
        Me.lbNoResultados.Text = "No se encontraron resultados"
        Me.lbNoResultados.Visible = False
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.Location = New System.Drawing.Point(395, 13)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaDesde.TabIndex = 20
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.Location = New System.Drawing.Point(572, 13)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaHasta.TabIndex = 21
        '
        'FormVentaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.lbNoResultados)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Controls.Add(Me.btnRealizarVenta)
        Me.Controls.Add(Me.dgvVenta)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.LbFechaHasta)
        Me.Controls.Add(Me.lbFechaDesde)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.txtIdVenta)
        Me.Controls.Add(Me.lbIdCliente)
        Me.Name = "FormVentaPrincipal"
        Me.Text = "Ventas"
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbIdCliente As Label
    Friend WithEvents txtIdVenta As TextBox
    Friend WithEvents lbCliente As Label
    Friend WithEvents lbFechaDesde As Label
    Friend WithEvents LbFechaHasta As Label
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents dgvVenta As DataGridView
    Friend WithEvents btnRealizarVenta As Button
    Friend WithEvents btnGenerarReporte As Button
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents lbNoResultados As Label
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents dtpFechaHasta As DateTimePicker
End Class
