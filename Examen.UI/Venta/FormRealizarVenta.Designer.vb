<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRealizarVenta
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
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvVentaProducto = New System.Windows.Forms.DataGridView()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        CType(Me.dgvVentaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(14, 15)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(39, 13)
        Me.lbCliente.TabIndex = 0
        Me.lbCliente.Text = "Cliente"
        '
        'cbCliente
        '
        Me.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(59, 12)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(121, 21)
        Me.cbCliente.TabIndex = 1
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Location = New System.Drawing.Point(196, 16)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(37, 13)
        Me.lbFecha.TabIndex = 2
        Me.lbFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(239, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'dgvVentaProducto
        '
        Me.dgvVentaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentaProducto.Location = New System.Drawing.Point(12, 69)
        Me.dgvVentaProducto.Name = "dgvVentaProducto"
        Me.dgvVentaProducto.Size = New System.Drawing.Size(776, 369)
        Me.dgvVentaProducto.TabIndex = 13
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProducto.Location = New System.Drawing.Point(12, 447)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(776, 70)
        Me.btnAgregarProducto.TabIndex = 14
        Me.btnAgregarProducto.Text = "Realizar venta"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'FormRealizarVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 529)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.dgvVentaProducto)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.cbCliente)
        Me.Controls.Add(Me.lbCliente)
        Me.Name = "FormRealizarVenta"
        Me.Text = "Realizar venta"
        CType(Me.dgvVentaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbCliente As Label
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents lbFecha As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents dgvVentaProducto As DataGridView
    Friend WithEvents btnAgregarProducto As Button
End Class
