using System;
using System.Text.RegularExpressions;
using CoreToolKit.Logger;
using CoreToolKit.NET_System.Delegate.Extensions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ILogger = CoreToolKit.Logger.ILogger;

namespace CoreToolKit.Tests.EditMode.NET_System.Delegates.Extensions
{
  public class DelegateExtensionsTest
  {
    private const string LogMessage = "Exception thrown while safe invoking";

    #region Action Safe Invoke

    [Test]
    public void ActionSafeInvoke_ThrowExceptionInAction_LogExceptions()
    {
      ILogger log = GetLogger( LogType.Exception );

      Action action = () => throw new Exception();
      action.SafeInvoke( log );

      LogAssert.Expect( LogType.Exception, new Regex( LogMessage ) );
    }

    [Test]
    public void ActionSafeInvoke_CompleteAction_ExceptionNotThrown()
    {
      ILogger log = GetLogger( LogType.Exception );

      Action action = () => { };
      action.SafeInvoke( log );

      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public void ActionSafeInvoke_NullAction_ActionNotInvoked()
    {
      ILogger log = GetLogger( LogType.Exception );

      (( Action ) null).SafeInvoke( log );

      LogAssert.NoUnexpectedReceived();
    }

    #endregion Action Safe Invoke

    #region Action<T> Safe Invoke

    [Test]
    public void ActionWithArgSafeInvoke_ThrowExceptionInAction_LogExceptions()
    {
      ILogger log = GetLogger( LogType.Exception );

      Action<int> action = _ => throw new Exception();
      const int arg = 1;
      action.SafeInvoke( arg, log );

      LogAssert.Expect( LogType.Exception, new Regex( LogMessage ) );
    }

    [Test]
    public void ActionWithArgSafeInvoke_CompleteAction_ExceptionNotThrown()
    {
      ILogger log = GetLogger( LogType.Exception );

      Action<int> action = _ => { };
      const int arg = 1;
      action.SafeInvoke( arg, log );

      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public void ActionWithArgSafeInvoke_NullAction_ActionNotInvoked()
    {
      ILogger log = GetLogger( LogType.Exception );

      const int arg = 1;
      (( Action<int> ) null).SafeInvoke( arg, log );

      LogAssert.NoUnexpectedReceived();
    }

    #endregion Action<T> Safe Invoke

    #region Delegate with Invoker Safe Invoke

    private delegate void TestDelegate();

    [Test]
    public void DelegateWithInvokerSafeInvoke_ThrowExceptionInDelegate_LogExceptions()
    {
      ILogger log = GetLogger( LogType.Exception );

      TestDelegate @delegate = () => throw new Exception();
      void Invoker( TestDelegate del ) => del.Invoke();
      @delegate.SafeInvoke( Invoker, log );

      LogAssert.Expect( LogType.Exception, new Regex( LogMessage ) );
    }

    [Test]
    public void DelegateWithInvokerSafeInvoke_ThrowExceptionInInvoker_LogExceptions()
    {
      ILogger log = GetLogger( LogType.Exception );

      TestDelegate @delegate = () => {};
      void Invoker( TestDelegate _ ) => throw new Exception();
      @delegate.SafeInvoke( Invoker, log );

      LogAssert.Expect( LogType.Exception, new Regex( LogMessage ) );
    }

    [Test]
    public void DelegateWithInvokerSafeInvoke_CompleteDelegate_ExceptionNotThrown()
    {
      ILogger log = GetLogger( LogType.Exception );

      TestDelegate @delegate = () => {};
      void Invoker( TestDelegate del ) => del.Invoke();
      @delegate.SafeInvoke( Invoker, log );

      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public void DelegateWithInvokerSafeInvoke_NullDelegate_DelegateNotInvoked()
    {
      ILogger log = GetLogger( LogType.Exception );

      void Invoker( TestDelegate del ) => del.Invoke();
      (( TestDelegate ) null).SafeInvoke( Invoker, log );

      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public void DelegateWithInvokerSafeInvoke_NullInvoker_DelegateNotInvoked()
    {
      ILogger log = GetLogger( LogType.Exception );

      TestDelegate @delegate = () => {};
      @delegate.SafeInvoke( null, log );

      LogAssert.NoUnexpectedReceived();
    }

    #endregion Delegate Safe Invoke

    private ILogger GetLogger( LogType logType )
    {
      LogManager logManager = new( Debug.unityLogger.logHandler, logType );
      return logManager.GetLogger( GetType() );
    }
  }
}