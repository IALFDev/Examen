Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Examen.Entidad

Public Class FormAgregarCliente
    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then 'Verifico que el campo Teléfono solo se ingrese numeros'
            MessageBox.Show("Debes ingresar solamente valores numéricos.", "Atención")
            e.Handled = True
        End If
    End Sub

    Private Sub txtCorreo_TextChanged(sender As Object, e As EventArgs) Handles txtCorreo.TextChanged
        Dim cliente = New Cliente()
        cliente.Correo = txtCorreo.Text

        If cliente.Verificarcorreo() Then
            lbValidCorreo.BackColor = Color.LimeGreen
            lbValidCorreo.Text = "Correcto"
        Else
            lbValidCorreo.BackColor = Color.Yellow
            lbValidCorreo.Text = "invalido"
        End If
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        If VerificarCampos() Then

        End If
    End Sub
    Protected Function VerificarCampos() As Boolean
        Dim validado As Boolean

        If Not String.IsNullOrEmpty(txtNombre.Text) Then 'Verifico que el campo Nombre no este vacío'
            If Not txtNombre.Text.Length > 255 Then 'Verifico que el campo no tenga más de 255 caracteres'
                validado = True
            Else
                MessageBox.Show("El campo Nombre no debe tener más de 255 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Nombre no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtTelefono.Text) Then 'Verifico que el campo Teléfono no este vacío'
            If Not txtTelefono.Text.Length > 255 Then 'Verifico que el campo no tenga más de 255 caracteres'
                validado = True
            Else
                MessageBox.Show("El campo Teléfono no debe tener más de 255 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Teléfono no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        If Not String.IsNullOrEmpty(txtCorreo.Text) Then 'Verifico que el campo Correo no este vacío'
            If Not txtCorreo.Text.Length > 255 Then 'Verifico que el campo no Correo más de 255 caracteres'
                Dim cliente = New Cliente
                cliente.Correo = txtCorreo.Text

                If cliente.Verificarcorreo() Then 'Verifico que el campo no Correo tengo un formato correcto'
                    validado = True
                Else
                    MessageBox.Show("El campo Correo debe tener un correo correcto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    validado = False

                    Return validado
                End If
            Else
                MessageBox.Show("El campo Correo no debe tener más de 255 caracteres.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                validado = False

                Return validado
            End If
        Else
            MessageBox.Show("El campo Correo no debe estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            validado = False

            Return validado
        End If

        Return validado = True
    End Function
End Class