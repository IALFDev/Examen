<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAgregarProducto
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
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lbPrecio = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(12, 12)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(44, 13)
        Me.lbNombre.TabIndex = 0
        Me.lbNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(58, 9)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(296, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lbPrecio
        '
        Me.lbPrecio.AutoSize = True
        Me.lbPrecio.Location = New System.Drawing.Point(12, 48)
        Me.lbPrecio.Name = "lbPrecio"
        Me.lbPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lbPrecio.TabIndex = 2
        Me.lbPrecio.Text = "Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(58, 45)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(296, 20)
        Me.txtPrecio.TabIndex = 3
        '
        'lbCategoria
        '
        Me.lbCategoria.AutoSize = True
        Me.lbCategoria.Location = New System.Drawing.Point(12, 83)
        Me.lbCategoria.Name = "lbCategoria"
        Me.lbCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lbCategoria.TabIndex = 4
        Me.lbCategoria.Text = "Categoria"
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProducto.Location = New System.Drawing.Point(15, 154)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(339, 70)
        Me.btnAgregarProducto.TabIndex = 6
        Me.btnAgregarProducto.Text = "Agregar producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'cbCategoria
        '
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(70, 118)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(284, 21)
        Me.cbCategoria.TabIndex = 7
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(70, 83)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(284, 20)
        Me.txtCategoria.TabIndex = 8
        '
        'FormAgregarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 236)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.cbCategoria)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lbPrecio)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lbNombre)
        Me.Name = "FormAgregarProducto"
        Me.Text = "Agregar producto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lbPrecio As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents lbCategoria As Label
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents txtCategoria As TextBox
End Class
