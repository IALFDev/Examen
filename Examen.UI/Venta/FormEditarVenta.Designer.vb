<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditarVenta
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
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.lbTotalVenta = New System.Windows.Forms.Label()
        Me.dgvItemVenta = New System.Windows.Forms.DataGridView()
        CType(Me.dgvItemVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(13, 13)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(42, 13)
        Me.lbCliente.TabIndex = 16
        Me.lbCliente.Text = "Cliente:"
        '
        'cbCliente
        '
        Me.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(61, 10)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(155, 21)
        Me.cbCliente.TabIndex = 17
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Location = New System.Drawing.Point(231, 13)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(70, 13)
        Me.lbFecha.TabIndex = 18
        Me.lbFecha.Text = "Fecha venta:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(308, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(101, 20)
        Me.dtpFecha.TabIndex = 19
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Location = New System.Drawing.Point(415, 13)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(34, 13)
        Me.lbTotal.TabIndex = 20
        Me.lbTotal.Text = "Total:"
        '
        'lbTotalVenta
        '
        Me.lbTotalVenta.AutoSize = True
        Me.lbTotalVenta.Location = New System.Drawing.Point(455, 13)
        Me.lbTotalVenta.Name = "lbTotalVenta"
        Me.lbTotalVenta.Size = New System.Drawing.Size(61, 13)
        Me.lbTotalVenta.TabIndex = 21
        Me.lbTotalVenta.Text = "Total venta"
        '
        'dgvItemVenta
        '
        Me.dgvItemVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemVenta.Location = New System.Drawing.Point(16, 37)
        Me.dgvItemVenta.Name = "dgvItemVenta"
        Me.dgvItemVenta.Size = New System.Drawing.Size(772, 401)
        Me.dgvItemVenta.TabIndex = 22
        '
        'FormEditarVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvItemVenta)
        Me.Controls.Add(Me.lbTotalVenta)
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.cbCliente)
        Me.Controls.Add(Me.lbCliente)
        Me.Name = "FormEditarVenta"
        Me.Text = "Editar venta"
        CType(Me.dgvItemVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbCliente As Label
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents lbFecha As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents lbTotal As Label
    Friend WithEvents lbTotalVenta As Label
    Friend WithEvents dgvItemVenta As DataGridView
End Class
