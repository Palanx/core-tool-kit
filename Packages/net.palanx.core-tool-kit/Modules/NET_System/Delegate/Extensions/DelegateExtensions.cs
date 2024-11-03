using System;
using System.Collections.Generic;
using System.Linq;
using CoreToolKit.Logger;

namespace CoreToolKit.NET_System.Delegate.Extensions
{
  /// <summary>
  /// Method extensions for delegates.
  /// </summary>
  public static class DelegateExtensions
  {
    /// <summary>
    /// Invoke an <see cref="Action"/> handling the possible exceptions.
    /// </summary>
    /// <param name="action">This.</param>
    /// <param name="log">Used to log the possible exceptions.</param>
    public static void SafeInvoke( this Action action, ILogger log )
    {
      if ( action == null )
      {
        return;
      }

      IEnumerable<Action> invocations = action.GetInvocationList().Cast<Action>();
      foreach ( Action invocation in invocations )
      {
        try
        {
          invocation.Invoke();
        }
        catch ( Exception ex )
        {
         log.Exception( $"Exception thrown while safe invoking {invocation.Method.Name}.", ex );
        }
      }
    }

    /// <summary>
    /// Invoke an <see cref="Action{T}"/> handling the possible exceptions.
    /// </summary>
    /// <param name="action">This.</param>
    /// <param name="arg">Arguments to invoke the <see cref="Action{T}"/>.</param>
    /// <param name="log">Used to log the possible exceptions.</param>
    /// <typeparam name="T">Type of the <see cref="Action{T}"/> argument.</typeparam>
    public static void SafeInvoke<T>( this Action<T> action, T arg, ILogger log  )
    {
      if ( action == null )
      {
        return;
      }

      IEnumerable<Action<T>> invocations = action.GetInvocationList().Cast<Action<T>>();
      foreach ( Action<T> invocation in invocations )
      {
        try
        {
          invocation.Invoke( arg );
        }
        catch ( Exception ex )
        {
          log.Exception( $"Exception thrown while safe invoking {invocation.Method.Name}.", ex );
        }
      }
    }

    /// <summary>
    /// Invoke a multicast <see cref="Delegate"/> handling the possible exceptions.
    /// </summary>
    /// <param name="delegate">This.</param>
    /// <param name="delegateInvoker">An action that defines how to invoke the invocations.</param>
    /// <param name="log">Used to log the possible exceptions.</param>
    /// <typeparam name="TDelegate"></typeparam>
    public static void SafeInvoke<TDelegate>( this TDelegate @delegate, Action<TDelegate> delegateInvoker, ILogger log  )
      where TDelegate : System.Delegate
    {
      if ( @delegate == null || delegateInvoker == null )
      {
        return;
      }

      IEnumerable<TDelegate> invocations = @delegate.GetInvocationList().Cast<TDelegate>();
      foreach ( TDelegate invocation in invocations )
      {
        try
        {
          delegateInvoker( invocation );
        }
        catch ( Exception ex )
        {
          log.Exception( $"Exception thrown while safe invoking {invocation.Method.Name}.", ex );
        }
      }
    }
  }
}