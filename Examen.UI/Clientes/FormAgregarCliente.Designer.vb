<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAgregarCliente
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
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lbTelefono = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.lbCorreo = New System.Windows.Forms.Label()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.lbValidCorreo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Location = New System.Drawing.Point(12, 9)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(39, 13)
        Me.lbCliente.TabIndex = 1
        Me.lbCliente.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(68, 6)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(286, 20)
        Me.txtCliente.TabIndex = 2
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(68, 32)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(286, 20)
        Me.txtTelefono.TabIndex = 3
        '
        'lbTelefono
        '
        Me.lbTelefono.AutoSize = True
        Me.lbTelefono.Location = New System.Drawing.Point(12, 35)
        Me.lbTelefono.Name = "lbTelefono"
        Me.lbTelefono.Size = New System.Drawing.Size(49, 13)
        Me.lbTelefono.TabIndex = 4
        Me.lbTelefono.Text = "Teléfono"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(68, 58)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(241, 20)
        Me.txtCorreo.TabIndex = 5
        '
        'lbCorreo
        '
        Me.lbCorreo.AutoSize = True
        Me.lbCorreo.Location = New System.Drawing.Point(12, 61)
        Me.lbCorreo.Name = "lbCorreo"
        Me.lbCorreo.Size = New System.Drawing.Size(38, 13)
        Me.lbCorreo.TabIndex = 6
        Me.lbCorreo.Text = "Correo"
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCliente.Location = New System.Drawing.Point(15, 106)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(339, 70)
        Me.btnAgregarCliente.TabIndex = 7
        Me.btnAgregarCliente.Text = "Agregar cliente"
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'lbValidCorreo
        '
        Me.lbValidCorreo.AutoSize = True
        Me.lbValidCorreo.Location = New System.Drawing.Point(315, 61)
        Me.lbValidCorreo.Name = "lbValidCorreo"
        Me.lbValidCorreo.Size = New System.Drawing.Size(0, 13)
        Me.lbValidCorreo.TabIndex = 8
        '
        'FormAgregarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 188)
        Me.Controls.Add(Me.lbValidCorreo)
        Me.Controls.Add(Me.btnAgregarCliente)
        Me.Controls.Add(Me.lbCorreo)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.lbTelefono)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.lbCliente)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(392, 227)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(392, 227)
        Me.Name = "FormAgregarCliente"
        Me.Text = "Agregar cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbCliente As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lbTelefono As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents lbCorreo As Label
    Friend WithEvents btnAgregarCliente As Button
    Friend WithEvents lbValidCorreo As Label
End Class
