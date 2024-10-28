<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditarVentaItemProducto
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
        Me.lbProducto = New System.Windows.Forms.Label()
        Me.cbProducto = New System.Windows.Forms.ComboBox()
        Me.lbCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbProducto
        '
        Me.lbProducto.AutoSize = True
        Me.lbProducto.Location = New System.Drawing.Point(12, 17)
        Me.lbProducto.Name = "lbProducto"
        Me.lbProducto.Size = New System.Drawing.Size(109, 13)
        Me.lbProducto.TabIndex = 0
        Me.lbProducto.Text = "Seleccionar Producto"
        '
        'cbProducto
        '
        Me.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProducto.FormattingEnabled = True
        Me.cbProducto.Location = New System.Drawing.Point(127, 13)
        Me.cbProducto.Name = "cbProducto"
        Me.cbProducto.Size = New System.Drawing.Size(222, 21)
        Me.cbProducto.TabIndex = 1
        '
        'lbCantidad
        '
        Me.lbCantidad.AutoSize = True
        Me.lbCantidad.Location = New System.Drawing.Point(12, 53)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbCantidad.TabIndex = 2
        Me.lbCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(69, 49)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(280, 20)
        Me.txtCantidad.TabIndex = 3
        '
        'BtnEditar
        '
        Me.BtnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Location = New System.Drawing.Point(15, 109)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnEditar.Size = New System.Drawing.Size(334, 105)
        Me.BtnEditar.TabIndex = 4
        Me.BtnEditar.Text = "Editar producto"
        Me.BtnEditar.UseVisualStyleBackColor = True
        '
        'FormEditarVentaItemProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 226)
        Me.Controls.Add(Me.BtnEditar)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.cbProducto)
        Me.Controls.Add(Me.lbProducto)
        Me.Name = "FormEditarVentaItemProducto"
        Me.Text = "Editar venta producto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbProducto As Label
    Friend WithEvents cbProducto As ComboBox
    Friend WithEvents lbCantidad As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents BtnEditar As Button
End Class
