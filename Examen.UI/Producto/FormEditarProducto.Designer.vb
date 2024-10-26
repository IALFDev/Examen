<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditarProducto
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
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lbPrecio = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(53, 12)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(296, 20)
        Me.txtNombre.TabIndex = 2
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(3, 12)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(44, 13)
        Me.lbNombre.TabIndex = 3
        Me.lbNombre.Text = "Nombre"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(53, 38)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(296, 20)
        Me.txtPrecio.TabIndex = 4
        '
        'lbPrecio
        '
        Me.lbPrecio.AutoSize = True
        Me.lbPrecio.Location = New System.Drawing.Point(3, 41)
        Me.lbPrecio.Name = "lbPrecio"
        Me.lbPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lbPrecio.TabIndex = 5
        Me.lbPrecio.Text = "Precio"
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(65, 64)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(284, 20)
        Me.txtCategoria.TabIndex = 9
        '
        'lbCategoria
        '
        Me.lbCategoria.AutoSize = True
        Me.lbCategoria.Location = New System.Drawing.Point(3, 71)
        Me.lbCategoria.Name = "lbCategoria"
        Me.lbCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lbCategoria.TabIndex = 10
        Me.lbCategoria.Text = "Categoria"
        '
        'cbCategoria
        '
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(65, 102)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(284, 21)
        Me.cbCategoria.TabIndex = 11
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(10, 145)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(339, 69)
        Me.btnEditar.TabIndex = 12
        Me.btnEditar.Text = "Editar producto"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'FormEditarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 226)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.cbCategoria)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.lbPrecio)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Name = "FormEditarProducto"
        Me.Text = "Edtiar producto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents lbPrecio As Label
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents lbCategoria As Label
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents btnEditar As Button
End Class
