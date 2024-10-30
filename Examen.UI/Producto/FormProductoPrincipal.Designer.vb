<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductoPrincipal
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
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.txtNombreProducto = New System.Windows.Forms.TextBox()
        Me.lbIdProducto = New System.Windows.Forms.Label()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.cbCategoriaProducto = New System.Windows.Forms.ComboBox()
        Me.lbRango = New System.Windows.Forms.Label()
        Me.txtRangoDesde = New System.Windows.Forms.TextBox()
        Me.txtRangoHasta = New System.Windows.Forms.TextBox()
        Me.lbA = New System.Windows.Forms.Label()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lbNoResultados = New System.Windows.Forms.Label()
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
        'txtNombreProducto
        '
        Me.txtNombreProducto.Location = New System.Drawing.Point(192, 4)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreProducto.TabIndex = 1
        '
        'lbIdProducto
        '
        Me.lbIdProducto.AutoSize = True
        Me.lbIdProducto.Location = New System.Drawing.Point(12, 9)
        Me.lbIdProducto.Name = "lbIdProducto"
        Me.lbIdProducto.Size = New System.Drawing.Size(63, 13)
        Me.lbIdProducto.TabIndex = 2
        Me.lbIdProducto.Text = "ID producto"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.Location = New System.Drawing.Point(81, 6)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(55, 20)
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
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Location = New System.Drawing.Point(483, 4)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarProducto.TabIndex = 6
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'dgvProducto
        '
        Me.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducto.Location = New System.Drawing.Point(16, 69)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.Size = New System.Drawing.Size(772, 336)
        Me.dgvProducto.TabIndex = 7
        Me.dgvProducto.Visible = False
        '
        'cbCategoriaProducto
        '
        Me.cbCategoriaProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoriaProducto.FormattingEnabled = True
        Me.cbCategoriaProducto.Location = New System.Drawing.Point(356, 4)
        Me.cbCategoriaProducto.Name = "cbCategoriaProducto"
        Me.cbCategoriaProducto.Size = New System.Drawing.Size(121, 21)
        Me.cbCategoriaProducto.TabIndex = 8
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
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProducto.Location = New System.Drawing.Point(645, 29)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(143, 33)
        Me.btnAgregarProducto.TabIndex = 13
        Me.btnAgregarProducto.Text = "Agregar producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Location = New System.Drawing.Point(16, 415)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(120, 23)
        Me.btnReporte.TabIndex = 14
        Me.btnReporte.Text = "Generar reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lbNoResultados
        '
        Me.lbNoResultados.AutoSize = True
        Me.lbNoResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNoResultados.Location = New System.Drawing.Point(220, 223)
        Me.lbNoResultados.Name = "lbNoResultados"
        Me.lbNoResultados.Size = New System.Drawing.Size(370, 31)
        Me.lbNoResultados.TabIndex = 18
        Me.lbNoResultados.Text = "No se encontraron resultados"
        Me.lbNoResultados.Visible = False
        '
        'FormProductoPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lbNoResultados)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.lbA)
        Me.Controls.Add(Me.txtRangoHasta)
        Me.Controls.Add(Me.txtRangoDesde)
        Me.Controls.Add(Me.lbRango)
        Me.Controls.Add(Me.cbCategoriaProducto)
        Me.Controls.Add(Me.dgvProducto)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.lbIdProducto)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lbNombre)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(816, 489)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(816, 489)
        Me.Name = "FormProductoPrincipal"
        Me.Text = "Productos"
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbNombre As Label
    Friend WithEvents txtNombreProducto As TextBox
    Friend WithEvents lbIdProducto As Label
    Friend WithEvents txtIdProducto As TextBox
    Friend WithEvents lbCategoria As Label
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents dgvProducto As DataGridView
    Friend WithEvents cbCategoriaProducto As ComboBox
    Friend WithEvents lbRango As Label
    Friend WithEvents txtRangoDesde As TextBox
    Friend WithEvents txtRangoHasta As TextBox
    Friend WithEvents lbA As Label
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents lbNoResultados As Label
End Class
