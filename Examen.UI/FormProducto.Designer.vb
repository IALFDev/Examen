<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProducto
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
        Me.lbIdProducto = New System.Windows.Forms.Label()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.lbRango = New System.Windows.Forms.Label()
        Me.txtRangoDesde = New System.Windows.Forms.TextBox()
        Me.txtRangoHasta = New System.Windows.Forms.TextBox()
        Me.lbA = New System.Windows.Forms.Label()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(142, 8)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(44, 13)
        Me.lbNombre.TabIndex = 0
        Me.lbNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(192, 4)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(100, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lbIdProducto
        '
        Me.lbIdProducto.AutoSize = True
        Me.lbIdProducto.Location = New System.Drawing.Point(12, 9)
        Me.lbIdProducto.Name = "lbIdProducto"
        Me.lbIdProducto.Size = New System.Drawing.Size(18, 13)
        Me.lbIdProducto.TabIndex = 2
        Me.lbIdProducto.Text = "ID"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.Location = New System.Drawing.Point(36, 6)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtIdProducto.TabIndex = 3
        '
        'lbCategoria
        '
        Me.lbCategoria.AutoSize = True
        Me.lbCategoria.Location = New System.Drawing.Point(298, 8)
        Me.lbCategoria.Name = "lbCategoria"
        Me.lbCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lbCategoria.TabIndex = 4
        Me.lbCategoria.Text = "Categoria"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(483, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvProducto
        '
        Me.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducto.Location = New System.Drawing.Point(16, 69)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.Size = New System.Drawing.Size(772, 369)
        Me.dgvProducto.TabIndex = 7
        Me.dgvProducto.Visible = False
        '
        'cbCategoria
        '
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(356, 4)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(121, 21)
        Me.cbCategoria.TabIndex = 8
        '
        'lbRango
        '
        Me.lbRango.AutoSize = True
        Me.lbRango.Location = New System.Drawing.Point(13, 44)
        Me.lbRango.Name = "lbRango"
        Me.lbRango.Size = New System.Drawing.Size(86, 13)
        Me.lbRango.TabIndex = 9
        Me.lbRango.Text = "Rango de precio"
        '
        'txtRangoDesde
        '
        Me.txtRangoDesde.Location = New System.Drawing.Point(105, 41)
        Me.txtRangoDesde.Name = "txtRangoDesde"
        Me.txtRangoDesde.Size = New System.Drawing.Size(100, 20)
        Me.txtRangoDesde.TabIndex = 10
        '
        'txtRangoHasta
        '
        Me.txtRangoHasta.Location = New System.Drawing.Point(226, 41)
        Me.txtRangoHasta.Name = "txtRangoHasta"
        Me.txtRangoHasta.Size = New System.Drawing.Size(100, 20)
        Me.txtRangoHasta.TabIndex = 11
        '
        'lbA
        '
        Me.lbA.AutoSize = True
        Me.lbA.Location = New System.Drawing.Point(207, 44)
        Me.lbA.Name = "lbA"
        Me.lbA.Size = New System.Drawing.Size(13, 13)
        Me.lbA.TabIndex = 12
        Me.lbA.Text = "a"
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Location = New System.Drawing.Point(668, 39)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(120, 23)
        Me.btnAgregarProducto.TabIndex = 13
        Me.btnAgregarProducto.Text = "Agregar Producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'FormProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.lbA)
        Me.Controls.Add(Me.txtRangoHasta)
        Me.Controls.Add(Me.txtRangoDesde)
        Me.Controls.Add(Me.lbRango)
        Me.Controls.Add(Me.cbCategoria)
        Me.Controls.Add(Me.dgvProducto)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.lbIdProducto)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lbNombre)
        Me.Name = "FormProducto"
        Me.Text = "FormProducto"
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lbIdProducto As Label
    Friend WithEvents txtIdProducto As TextBox
    Friend WithEvents lbCategoria As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dgvProducto As DataGridView
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents lbRango As Label
    Friend WithEvents txtRangoDesde As TextBox
    Friend WithEvents txtRangoHasta As TextBox
    Friend WithEvents lbA As Label
    Friend WithEvents btnAgregarProducto As Button
End Class
