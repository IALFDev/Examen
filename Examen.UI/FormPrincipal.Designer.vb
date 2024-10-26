<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(12, 12)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(75, 30)
        Me.btnProducto.TabIndex = 0
        Me.btnProducto.Text = "Productos"
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.Location = New System.Drawing.Point(93, 12)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(75, 30)
        Me.btnCliente.TabIndex = 1
        Me.btnCliente.Text = "Clientes"
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Location = New System.Drawing.Point(174, 12)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(75, 30)
        Me.btnVentas.TabIndex = 2
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnVentas)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.btnProducto)
        Me.Name = "FormPrincipal"
        Me.Text = "Examen"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnProducto As Button
    Friend WithEvents btnCliente As Button
    Friend WithEvents btnVentas As Button
End Class
