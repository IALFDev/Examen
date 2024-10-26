<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentaPrincial
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
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.lbFechaDesde = New System.Windows.Forms.Label()
        Me.txtFechaDesde = New System.Windows.Forms.TextBox()
        Me.LbFechaHasta = New System.Windows.Forms.Label()
        Me.txtFechaHasta = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.btnRealizarVenta = New System.Windows.Forms.Button()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbIdCliente
        '
        Me.lbIdCliente.AutoSize = True
        Me.lbIdCliente.Location = New System.Drawing.Point(12, 15)
        Me.lbIdCliente.Name = "lbIdCliente"
        Me.lbIdCliente.Size = New System.Drawing.Size(18, 13)
        Me.lbIdCliente.TabIndex = 3
        Me.lbIdCliente.Text = "ID"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(36, 11)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCliente.TabIndex = 4
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
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(192, 12)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(121, 21)
        Me.cbCliente.TabIndex = 6
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
        'txtFechaDesde
        '
        Me.txtFechaDesde.Location = New System.Drawing.Point(394, 12)
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaDesde.TabIndex = 8
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
        'txtFechaHasta
        '
        Me.txtFechaHasta.Location = New System.Drawing.Point(572, 12)
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaHasta.TabIndex = 10
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Location = New System.Drawing.Point(713, 11)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarProducto.TabIndex = 11
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'dgvProducto
        '
        Me.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducto.Location = New System.Drawing.Point(15, 69)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.Size = New System.Drawing.Size(773, 369)
        Me.dgvProducto.TabIndex = 12
        Me.dgvProducto.Visible = False
        '
        'btnRealizarVenta
        '
        Me.btnRealizarVenta.Location = New System.Drawing.Point(668, 40)
        Me.btnRealizarVenta.Name = "btnRealizarVenta"
        Me.btnRealizarVenta.Size = New System.Drawing.Size(120, 23)
        Me.btnRealizarVenta.TabIndex = 14
        Me.btnRealizarVenta.Text = "Realizar nueva venta"
        Me.btnRealizarVenta.UseVisualStyleBackColor = True
        '
        'FormVentaPrincial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnRealizarVenta)
        Me.Controls.Add(Me.dgvProducto)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.txtFechaHasta)
        Me.Controls.Add(Me.LbFechaHasta)
        Me.Controls.Add(Me.txtFechaDesde)
        Me.Controls.Add(Me.lbFechaDesde)
        Me.Controls.Add(Me.cbCliente)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.lbIdCliente)
        Me.Name = "FormVentaPrincial"
        Me.Text = "Ventas"
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbIdCliente As Label
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents lbCliente As Label
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents lbFechaDesde As Label
    Friend WithEvents txtFechaDesde As TextBox
    Friend WithEvents LbFechaHasta As Label
    Friend WithEvents txtFechaHasta As TextBox
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents dgvProducto As DataGridView
    Friend WithEvents btnRealizarVenta As Button
End Class
