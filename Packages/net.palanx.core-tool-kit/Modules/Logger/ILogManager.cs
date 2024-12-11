using System;
using UnityEngine;

namespace CoreToolKit.Logger
{
  /// <summary>
  /// Interface to handle <see cref="ILogger"/> instances for specific types.
  /// </summary>
  public interface ILogManager
  {
    /// <summary>
    /// Get the local <see cref="ILogHandler"/>.
    /// </summary>
    ILogHandler LogHandler { get; }
    
    /// <summary>
    /// Used to selective enable debug log message.
    /// </summary>
    LogType FilterLogType { get; }
    
    /// <summary>
    /// Get a new <see cref="ILogger"/> instance for the provided Type logs.
    /// </summary>
    /// <typeparam name="T">Type to which the <see cref="ILogger"/> belongs.</typeparam>
    /// <returns>A <see cref="ILogger"/> for the provided Type logs.</returns>
    ILogger GetLogger<T>() where T : notnull;

    /// <summary>
    /// Get a new <see cref="ILogger"/> instance for the provided Type logs.
    /// </summary>
    /// <param name="type">Type to which the <see cref="ILogger"/> belongs.</param>
    /// <returns>A <see cref="ILogger"/> for the provided Type logs.</returns>
    ILogger GetLogger( Type type );
  }
}