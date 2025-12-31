Imports NLog

''' <summary>
''' Módulo wrapper para logging centralizado usando NLog.
''' Provee métodos helper para facilitar el registro de eventos.
''' </summary>
Public Module AppLogger
    Private ReadOnly Logger As Logger = LogManager.GetCurrentClassLogger()

    ''' <summary>
    ''' Registra un mensaje de información.
    ''' </summary>
    Public Sub Info(message As String)
        Logger.Info(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de información con formato.
    ''' </summary>
    Public Sub Info(format As String, ParamArray args As Object())
        Logger.Info(format, args)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de debug.
    ''' </summary>
    Public Sub LogDebug(message As String)
        Logger.Debug(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de debug con formato.
    ''' </summary>
    Public Sub LogDebug(format As String, ParamArray args As Object())
        Logger.Debug(format, args)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de advertencia (alias de Warn).
    ''' </summary>
    Public Sub LogWarn(message As String)
        Logger.Warn(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de advertencia con formato (alias de Warn).
    ''' </summary>
    Public Sub LogWarn(format As String, ParamArray args As Object())
        Logger.Warn(format, args)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de error (alias de Error).
    ''' </summary>
    Public Sub LogError(message As String)
        Logger.Error(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de error con formato (alias de Error).
    ''' </summary>
    Public Sub LogError(format As String, ParamArray args As Object())
        Logger.Error(format, args)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de advertencia.
    ''' </summary>
    Public Sub Warn(message As String)
        Logger.Warn(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de advertencia con formato.
    ''' </summary>
    Public Sub Warn(format As String, ParamArray args As Object())
        Logger.Warn(format, args)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de error.
    ''' </summary>
    Public Sub [Error](message As String)
        Logger.Error(message)
    End Sub

    ''' <summary>
    ''' Registra un mensaje de error con formato.
    ''' </summary>
    Public Sub [Error](format As String, ParamArray args As Object())
        Logger.Error(format, args)
    End Sub

    ''' <summary>
    ''' Registra un error con excepción.
    ''' </summary>
    Public Sub [Error](ex As Exception, message As String)
        Logger.Error(ex, message)
    End Sub

    ''' <summary>
    ''' Registra un error fatal.
    ''' </summary>
    Public Sub Fatal(message As String)
        Logger.Fatal(message)
    End Sub

    ''' <summary>
    ''' Registra un error fatal con excepción.
    ''' </summary>
    Public Sub Fatal(ex As Exception, message As String)
        Logger.Fatal(ex, message)
    End Sub

    ''' <summary>
    ''' Registra entrada a un método (para tracing).
    ''' </summary>
    Public Sub TraceMethodEntry(methodName As String)
        Logger.Trace("Entrando a: {0}", methodName)
    End Sub

    ''' <summary>
    ''' Registra salida de un método (para tracing).
    ''' </summary>
    Public Sub TraceMethodExit(methodName As String)
        Logger.Trace("Saliendo de: {0}", methodName)
    End Sub

    ''' <summary>
    ''' Registra una operación de base de datos/archivo.
    ''' </summary>
    Public Sub LogOperation(operation As String, details As String)
        Logger.Info("[{0}] {1}", operation, details)
    End Sub

    ''' <summary>
    ''' Registra una operación de base de datos/archivo con formato.
    ''' </summary>
    Public Sub LogOperation(operation As String, format As String, ParamArray args As Object())
        Dim allArgs(args.Length) As Object
        allArgs(0) = operation
        Array.Copy(args, 0, allArgs, 1, args.Length)
        Logger.Info("[{0}] " & format, allArgs)
    End Sub
End Module
