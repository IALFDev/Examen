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
        Me.lbProducto = New System.Windows.Forms.Label()
        Me.cbProducto = New System.Windows.Forms.ComboBox()
        Me.chkbHoy = New System.Windows.Forms.CheckBox()
        Me.lbCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.dgvVentaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(14, 15)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(97, 13)
        Me.lbCliente.TabIndex = 0
        Me.lbCliente.Text = "Seleccionar cliente"
        '
        'cbCliente
        '
        Me.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(117, 10)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(136, 21)
        Me.cbCliente.TabIndex = 1
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Location = New System.Drawing.Point(269, 15)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(37, 13)
        Me.lbFecha.TabIndex = 2
        Me.lbFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(312, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'dgvVentaProducto
        '
        Me.dgvVentaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentaProducto.Location = New System.Drawing.Point(12, 97)
        Me.dgvVentaProducto.Name = "dgvVentaProducto"
        Me.dgvVentaProducto.Size = New System.Drawing.Size(776, 341)
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
        'lbProducto
        '
        Me.lbProducto.Location = New System.Drawing.Point(14, 68)
        Me.lbProducto.Name = "lbProducto"
        Me.lbProducto.Size = New System.Drawing.Size(116, 13)
        Me.lbProducto.TabIndex = 0
        Me.lbProducto.Text = "Seleccionar producto"
        '
        'cbProducto
        '
        Me.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProducto.FormattingEnabled = True
        Me.cbProducto.Location = New System.Drawing.Point(132, 65)
        Me.cbProducto.Name = "cbProducto"
        Me.cbProducto.Size = New System.Drawing.Size(134, 21)
        Me.cbProducto.TabIndex = 15
        '
        'chkbHoy
        '
        Me.chkbHoy.AutoSize = True
        Me.chkbHoy.Checked = True
        Me.chkbHoy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbHoy.Location = New System.Drawing.Point(429, 14)
        Me.chkbHoy.Name = "chkbHoy"
        Me.chkbHoy.Size = New System.Drawing.Size(88, 17)
        Me.chkbHoy.TabIndex = 16
        Me.chkbHoy.Text = "Fecha actual"
        Me.chkbHoy.UseVisualStyleBackColor = True
        '
        'lbCantidad
        '
        Me.lbCantidad.AutoSize = True
        Me.lbCantidad.Location = New System.Drawing.Point(281, 68)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbCantidad.TabIndex = 17
        Me.lbCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad.Location = New System.Drawing.Point(336, 65)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 18
        Me.txtCantidad.Text = "1"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(442, 63)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 19
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'FormRealizarVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 529)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.chkbHoy)
        Me.Controls.Add(Me.cbProducto)
        Me.Controls.Add(Me.lbProducto)
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
    Friend WithEvents lbProducto As Label
    Friend WithEvents cbProducto As ComboBox
    Friend WithEvents chkbHoy As CheckBox
    Friend WithEvents lbCantidad As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents btnAgregar As Button
End Class
