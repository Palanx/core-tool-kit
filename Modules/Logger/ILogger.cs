using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoreToolKit.Logger
{
  /// <summary>
  /// Interface to implement <see cref="ILogManager"/> loggers.
  /// </summary>
  public interface ILogger
  {
    /// <summary>
    /// Get the owner <see cref="Type"/> of this logger.
    /// </summary>
    Type OwnerType { get; }
    
    /// <summary>
    /// Get the local <see cref="ILogHandler"/>.
    /// </summary>
    ILogHandler LogHandler { get; }

    /// <summary>
    /// Used to selective enable debug log message.
    /// </summary>
    LogType FilterLogType { get; }
    
    /// <summary>
    /// Gets a value indicating whether the logger is currently enabled.
    /// </summary>
    bool IsEnabled { get; }

    /// <summary>
    /// Check if logs will be logged based on the provided LogType.
    /// </summary>
    /// <param name="logType">Used to check</param>
    /// <returns>If logs of LogType will be logged or not.</returns>
    bool IsLogTypeAllowed(LogType logType);

    /// <summary>
    /// Enable or disable the logger.
    /// </summary>
    /// <param name="active"></param>
    void SetActive( bool active );
    
    /// <summary>
    /// Log an informative message.
    /// </summary>
    /// <param name="message">Informative message.</param>
    void Info( string message );
    
    /// <summary>
    /// Log an informative message specifying the caller Unity <see cref="Object"/>.
    /// </summary>
    /// <param name="message">Informative message.</param>
    /// <param name="context">Caller Unity <see cref="Object"/>.</param>
    void Info( string message, Object context );
    
    /// <summary>
    /// Log a warning message.
    /// </summary>
    /// <param name="message">Warning message.</param>
    void Warning( string message );
    
    /// <summary>
    /// Log a warning message specifying the caller Unity <see cref="Object"/>.
    /// </summary>
    /// <param name="message">Warning message.</param>
    /// <param name="context">Caller Unity <see cref="Object"/>.</param>
    void Warning( string message, Object context );
    
    /// <summary>
    /// Log an error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    void Error( string message );
    
    /// <summary>
    /// Log an error message specifying the caller Unity <see cref="Object"/>.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="context">Caller Unity <see cref="Object"/>.</param>
    void Error( string message, Object context );
    
    /// <summary>
    /// Log an exception message.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="ex">Exception thrown.</param>
    void Exception( string message, Exception ex );
    
    /// <summary>
    /// Log an exception message specifying the caller Unity <see cref="Object"/>.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="ex">Exception thrown.</param>
    /// <param name="context">Caller Unity <see cref="Object"/>.</param>
    void Exception( string message, Exception ex, Object context );
  }
}