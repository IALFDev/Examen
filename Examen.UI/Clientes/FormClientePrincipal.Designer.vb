<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClientePrincipal
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
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.txtTelefonoCliente = New System.Windows.Forms.TextBox()
        Me.lbCorreoCliente = New System.Windows.Forms.Label()
        Me.txtCorreoCliente = New System.Windows.Forms.TextBox()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbIdCliente
        '
        Me.lbIdCliente.AutoSize = True
        Me.lbIdCliente.Location = New System.Drawing.Point(12, 9)
        Me.lbIdCliente.Name = "lbIdCliente"
        Me.lbIdCliente.Size = New System.Drawing.Size(18, 13)
        Me.lbIdCliente.TabIndex = 3
        Me.lbIdCliente.Text = "ID"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(36, 6)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCliente.TabIndex = 4
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(142, 9)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(44, 13)
        Me.lbNombre.TabIndex = 5
        Me.lbNombre.Text = "Nombre"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(192, 6)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreCliente.TabIndex = 6
        '
        'lbCategoria
        '
        Me.lbCategoria.AutoSize = True
        Me.lbCategoria.Location = New System.Drawing.Point(298, 9)
        Me.lbCategoria.Name = "lbCategoria"
        Me.lbCategoria.Size = New System.Drawing.Size(49, 13)
        Me.lbCategoria.TabIndex = 7
        Me.lbCategoria.Text = "Teléfono"
        '
        'txtTelefonoCliente
        '
        Me.txtTelefonoCliente.Location = New System.Drawing.Point(356, 6)
        Me.txtTelefonoCliente.Name = "txtTelefonoCliente"
        Me.txtTelefonoCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoCliente.TabIndex = 11
        '
        'lbCorreoCliente
        '
        Me.lbCorreoCliente.AutoSize = True
        Me.lbCorreoCliente.Location = New System.Drawing.Point(462, 9)
        Me.lbCorreoCliente.Name = "lbCorreoCliente"
        Me.lbCorreoCliente.Size = New System.Drawing.Size(38, 13)
        Me.lbCorreoCliente.TabIndex = 12
        Me.lbCorreoCliente.Text = "Correo"
        '
        'txtCorreoCliente
        '
        Me.txtCorreoCliente.Location = New System.Drawing.Point(506, 6)
        Me.txtCorreoCliente.Name = "txtCorreoCliente"
        Me.txtCorreoCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtCorreoCliente.TabIndex = 13
        '
        'dgvProducto
        '
        Me.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducto.Location = New System.Drawing.Point(12, 69)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.Size = New System.Drawing.Size(772, 369)
        Me.dgvProducto.TabIndex = 14
        Me.dgvProducto.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(626, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Location = New System.Drawing.Point(668, 40)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(120, 23)
        Me.btnAgregarCliente.TabIndex = 16
        Me.btnAgregarCliente.Text = "Agregar cliente"
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'FormClientePrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnAgregarCliente)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgvProducto)
        Me.Controls.Add(Me.txtCorreoCliente)
        Me.Controls.Add(Me.lbCorreoCliente)
        Me.Controls.Add(Me.txtTelefonoCliente)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.lbIdCliente)
        Me.Name = "FormClientePrincipal"
        Me.Text = "Clientes"
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbIdCliente As Label
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents lbCategoria As Label
    Friend WithEvents txtTelefonoCliente As TextBox
    Friend WithEvents lbCorreoCliente As Label
    Friend WithEvents txtCorreoCliente As TextBox
    Friend WithEvents dgvProducto As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnAgregarCliente As Button
End Class
