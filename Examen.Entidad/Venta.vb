Public Class Venta
    Private _id As Long
    Private _cliente As Cliente
    Private _fecha As DateTime
    Private _total As Decimal

    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            If IsNothing(_cliente) Then
                _cliente = New Cliente
            End If

            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return _total
        End Get
        Set(value As Decimal)
            _total = value
        End Set
    End Property
End Class
