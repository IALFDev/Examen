Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public MustInherit Class AbstractMapper
    Implements IDisposable

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

#Region "A T R I B U T O S"

    ''' <summary>
    ''' String que indica el nombre del Stored Procedure a ejecutar
    ''' </summary>
    Protected commandText As String

    ''' <summary>
    ''' String que indica la clave de web.config para obtener el ConnectionString 
    ''' </summary>
    Protected connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

#End Region

    ''' <summary>
    '''  Metodo generico para obtener, mediante la ejecucion de un stored
    '''  Procedure, una colección del Tipo TEntidad
    ''' </summary>
    ''' <returns>Devuelve una coleccion Tipo TEntidad</returns>
    Protected Function AbstractFindAll() As ArrayList
        Dim dataReader As IDataReader = Nothing
        Dim list As New ArrayList()
        Try
            Dim conn As New SqlConnection(connectionString)
            conn.Open()

            Dim cmd As New SqlCommand()
            cmd.CommandText = commandText
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text

            dataReader = cmd.ExecuteReader()
            list = LoadAll(dataReader)
            dataReader.Close()

            conn.Close()
        Catch ex As SqlException
            ex.ToString()
        Finally
            ClearDataReader(dataReader)
        End Try
        Return list
    End Function

    Protected Sub AbstractInsert()
        Try
            Dim conn As New SqlConnection(connectionString)
            conn.Open()

            Dim cmd As New SqlCommand()
            cmd.CommandText = commandText
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Protected Sub ExecuteNonQuery()
        Try
            Dim conn As New SqlConnection(connectionString)
            conn.Open()

            Dim cmd As New SqlCommand()
            cmd.CommandText = commandText
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text

            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As SqlException
            Throw ex
        End Try
    End Sub

    Public Function ExecuteScalar() As Long
        Dim id As Long = 0
        Try
            Dim conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand()
            cmd.CommandText = commandText
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text

            id = cmd.ExecuteScalar()

            conn.Close()
            Return id
        Catch ex As SqlException
            Throw ex
        End Try
    End Function

    'Protected ReadOnly Property AbstractFindALL As Object
    '    Get
    '        Dim dataReader As IDataReader = Nothing
    '        Dim result As Object = Nothing

    '        Try
    '            Dim conn As New SqlConnection(connectionString)
    '            conn.Open()

    '            Dim cmd As New SqlCommand()
    '            cmd.CommandText = commandText
    '            cmd.Connection = conn
    '            cmd.CommandType = CommandType.Text

    '            dataReader = cmd.ExecuteReader()
    '            result = DoLoad(dataReader)
    '            dataReader.Close()

    '            conn.Close()
    '        Catch IndexEx As IndexOutOfRangeException
    '            IndexEx.ToString()
    '        Catch nullex As NullReferenceException
    '            nullex.ToString()
    '        Catch sqlEx As SqlException
    '            sqlEx.ToString()
    '        Catch IOEX As IOException
    '            IOEX.ToString()
    '        Catch ex As Exception
    '            ex.ToString()
    '        Finally
    '            ClearDataReader(dataReader)
    '        End Try
    '        Return result
    '    End Get
    'End Property

    Protected Sub ClearDataReader(ByRef dataReader As IDataReader)
        If dataReader IsNot Nothing Then
            dataReader.Close()
            dataReader.Dispose()
            dataReader = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Metodo generico para la carga de una coleccion del tipo TEntidad
    ''' </summary>
    ''' <param name="registers">DataReader con los registros recuperados de la base de datos</param>
    ''' <returns></returns>
    Protected Function LoadAll(ByVal registers As IDataReader) As ArrayList
        Dim list As New ArrayList()
        While registers.Read()
            list.Add(DoLoad(registers))
        End While
        Return list
    End Function

    ''' <summary>
    ''' Metodo Abstracto para realizar la carga de un objeto del tipo TEntidad
    ''' </summary>
    ''' <param name="registers">Un registro de la coreccion recuperada de la base de datos</param>
    ''' <returns></returns>
    Public MustOverride Function DoLoad(ByVal registers As IDataReader) As Object
End Class

