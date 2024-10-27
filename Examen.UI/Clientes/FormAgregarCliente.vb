Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Examen.BLL
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
        If VerificarCampos() Then 'Verifico que los Cliente, Teléfono y Correo no esten vacíos'
            If Not VerificarSiYaExisteElCliente(New Cliente().GenerarObjetoClienteParaVerificarSiExiste(txtCorreo.Text)) Then 'Verifico si el cliente ya existe en la base de datos
                If Not GuardarClienteEnBd(New Cliente().GenerarObjetoClienteParaGuardarEnBd(txtCliente.Text, Integer.Parse(txtTelefono.Text), txtCorreo.Text)).Excepcion.Error Then 'Verifico que el guardado en la base sea correcto de lo contrario muestro un MessageBox de error
                    MessageBox.Show("Cliente guardado.", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si todo salio correcto muestro un MessageBox diciendo que el cliente se guardo correctamente'

                    LimpiarControles() 'Limpio los campos Cliente, Teléfono y Correo para que no quede con datos reciduales'

                    FormClientePrincipal.ActivarDataGridViewProducto() 'Refresco la grilla cada vez que haga click en el botón'
                Else
                    MessageBox.Show("Error al guardar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Si todo salio mal muestro un MessageBox diciendo que el cliente no se guardar correctamente'
                End If
            Else
                MessageBox.Show("El cliente ya existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) 'Si el cliente ya existe muestro un MessageBox'
            End If
        End If
    End Sub

    ''' <summary>
    '''  Método que verifica que los campos Cliente, Teléfono y Coreo no esten vacíos al momento de querer guardarlos en la base de datos
    ''' </summary>
    ''' <returns>Devuelve bool de acuerdo a la verificación</returns>
    Protected Function VerificarCampos() As Boolean
        Dim validado As Boolean

        If Not String.IsNullOrEmpty(txtCliente.Text) Then 'Verifico que el campo Nombre no este vacío'
            If Not txtCliente.Text.Length > 255 Then 'Verifico que el campo no tenga más de 255 caracteres'
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

    ''' <summary>
    '''  Método que limpia controles despues de realizar alguna acción
    ''' </summary>''
    Protected Sub LimpiarControles()
        txtCliente.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        lbValidCorreo.Text = String.Empty
    End Sub

    ''' <summary>
    '''  Método que guarda en la base datos los datos del objeto Cliente desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un objeto tipo Cliente con el resultado de la operacion de guardado en la base datos</returns>
    Public Function GuardarClienteEnBd(cliente As Cliente) As Cliente
        Dim manager = New ManagerCliente()

        cliente = manager.GuardarClienteEnBd(cliente)

        Return cliente
    End Function

    ''' <summary>
    '''  Método que verifica si el cliente ya existe en la base de datos desde el "gestor" o "manager" de la capa de negocios
    ''' </summary>
    ''' <returns>Devuelve un Boolean si el cliente ya existe en la base de datos</returns>
    Public Function VerificarSiYaExisteElCliente(cliente As Cliente) As Boolean
        Dim manager = New ManagerCliente()
        Dim existe As Boolean

        existe = manager.VerificarSiYaExisteElCliente(cliente)

        Return existe
    End Function
End Class