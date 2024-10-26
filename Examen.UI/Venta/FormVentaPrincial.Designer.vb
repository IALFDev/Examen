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
        Me.lbIdProducto = New System.Windows.Forms.Label()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.btnRealizarVenta = New System.Windows.Forms.Button()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbIdProducto
        '
        Me.lbIdProducto.AutoSize = True
        Me.lbIdProducto.Location = New System.Drawing.Point(12, 15)
        Me.lbIdProducto.Name = "lbIdProducto"
        Me.lbIdProducto.Size = New System.Drawing.Size(18, 13)
        Me.lbIdProducto.TabIndex = 3
        Me.lbIdProducto.Text = "ID"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.Location = New System.Drawing.Point(36, 12)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtIdProducto.TabIndex = 4
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(142, 15)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(44, 13)
        Me.lbNombre.TabIndex = 5
        Me.lbNombre.Text = "Nombre"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(192, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nombre"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(369, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(475, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nombre"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(525, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 10
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Location = New System.Drawing.Point(631, 12)
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
        Me.btnRealizarVenta.Text = "Realizar venta"
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
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.lbIdProducto)
        Me.Name = "FormVentaPrincial"
        Me.Text = "Ventas"
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbIdProducto As Label
    Friend WithEvents txtIdProducto As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents dgvProducto As DataGridView
    Friend WithEvents btnRealizarVenta As Button
End Class
