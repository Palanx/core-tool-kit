using System;
using System.Globalization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoreToolKit.Logger
{
  /// <summary>
  /// Logger that implements <see cref="ILogger"/>.
  /// </summary>
  public class Logger : ILogger
  {
    private readonly string _ownerTypeName;
    
    /// <inheritdoc cref="ILogger.OwnerType"/>
    public Type OwnerType { get; }
    
    /// <inheritdoc cref="ILogger.LogHandler"/>
    public ILogHandler LogHandler { get; }
    
    /// <inheritdoc cref="ILogger.FilterLogType"/>
    public LogType FilterLogType { get; }

    private bool _isEnabled = true;
    /// <inheritdoc cref="ILogger.IsEnabled"/>
    bool ILogger.IsEnabled => _isEnabled;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="ownerType"><inheritdoc cref="ILogger.OwnerType"/></param>
    /// <param name="logHandler"><inheritdoc cref="ILogger.LogHandler"/></param>
    /// <param name="filterLogType"><inheritdoc cref="ILogger.FilterLogType"/></param>
    public Logger( Type ownerType, ILogHandler logHandler, LogType filterLogType )
    {
      OwnerType = ownerType;
      LogHandler = logHandler;
      FilterLogType = filterLogType;

      _ownerTypeName = ownerType.FullName;
    }

    /// <inheritdoc cref="ILogger.IsLogTypeAllowed"/>
    public bool IsLogTypeAllowed( LogType logType )
    {
      if ( !_isEnabled )
        return false;

      return logType <= FilterLogType;
    }

    /// <inheritdoc cref="ILogger.SetActive"/>
    public void SetActive( bool active )
    {
      _isEnabled = active;
    }

    /// <inheritdoc cref="ILogger.Info(string)"/>
    public void Info( string message )
    {
      if ( !IsLogTypeAllowed( LogType.Log ) )
        return;

      LogHandler.LogFormat( LogType.Log, null, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Info(string, Object)"/>
    public void Info( string message, Object context )
    {
      if ( !IsLogTypeAllowed( LogType.Log ) )
        return;

      LogHandler.LogFormat( LogType.Log, context, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Warning(string)"/>
    public void Warning( string message )
    {
      if ( !IsLogTypeAllowed( LogType.Warning ) )
        return;

      LogHandler.LogFormat( LogType.Warning, null, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Warning(string, Object)"/>
    public void Warning( string message, Object context )
    {
      if ( !IsLogTypeAllowed( LogType.Warning ) )
        return;

      LogHandler.LogFormat( LogType.Warning, context, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Error(string)"/>
    public void Error( string message )
    {
      if ( !IsLogTypeAllowed( LogType.Error ) )
        return;

      LogHandler.LogFormat( LogType.Error, null, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Error(string, Object)"/>
    public void Error( string message, Object context )
    {
      if ( !IsLogTypeAllowed( LogType.Error ) )
        return;

      LogHandler.LogFormat( LogType.Error, context, $"<b>[{_ownerTypeName}]</b>\n{{0}}", GetString( message ) );
    }

    /// <inheritdoc cref="ILogger.Exception(string, System.Exception)"/>
    public void Exception( string message, Exception ex )
    {
      if ( !IsLogTypeAllowed( LogType.Exception ) )
        return;

      LogHandler.LogFormat( LogType.Exception, null, $"<b>[{_ownerTypeName}]</b>\n{{0}}\n{{1}}", GetString( message ), ex.ToString() );
    }

    /// <inheritdoc cref="ILogger.Exception(string, System.Exception, Object)"/>
    public void Exception( string message, Exception ex, Object context )
    {
      if ( !IsLogTypeAllowed( LogType.Exception ) )
        return;

      LogHandler.LogFormat( LogType.Exception, context, $"<b>[{_ownerTypeName}]</b>\n{{0}}\n{{1}}", GetString( message ), ex.ToString() );
    }

    /// <summary>
    /// Get the log string from the provided message object.
    /// </summary>
    /// <param name="message">Used to get the log string.</param>
    /// <returns>The log string.</returns>
    private static string GetString( object message )
    {
      if ( message == null )
        return "Null";

      return message is IFormattable formattable
        ? formattable.ToString( null, CultureInfo.InvariantCulture )
        : message.ToString();
    }
  }
}