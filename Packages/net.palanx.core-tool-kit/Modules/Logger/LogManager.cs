using System;
using UnityEngine;

namespace CoreToolKit.Logger
{
  /// <summary>
  /// Manager that handles <see cref="ILogger"/> instances for specific types.
  /// </summary>
  public class LogManager : ILogManager
  {
    /// <inheritdoc cref="ILogManager.LogHandler"/>
    public ILogHandler LogHandler { get; }
    
    /// <inheritdoc cref="ILogManager.FilterLogType"/>
    public LogType FilterLogType { get; }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logHandler"><inheritdoc cref="ILogManager.LogHandler"/></param>
    /// <param name="filterLogType"><inheritdoc cref="ILogManager.FilterLogType"/></param>
    public LogManager( ILogHandler logHandler, LogType filterLogType )
    {
      LogHandler = logHandler;
      FilterLogType = filterLogType;
    }

    /// <inheritdoc cref="ILogManager.GetLogger{T}"/>
    public ILogger GetLogger<T>() where T : notnull =>
      new Logger( typeof( T ), LogHandler, FilterLogType );
    
    /// <inheritdoc cref="ILogManager.GetLogger"/>
    public ILogger GetLogger( Type type ) =>
      new Logger( type, LogHandler, FilterLogType );
  }
}