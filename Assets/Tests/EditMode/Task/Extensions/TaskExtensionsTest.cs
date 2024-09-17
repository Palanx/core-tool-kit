using System;
using System.Text.RegularExpressions;
using CoreToolKit.Logger;
using CoreToolKit.Task.Extensions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ILogger = CoreToolKit.Logger.ILogger;

namespace CoreToolKit.Tests.EditMode.Task.Extensions
{
  using System.Threading.Tasks;

  public class TaskExtensionsTest
  {
    private const string ExceptionMessage = "Exception thrown!";
    private const int MsDelay = 1;

    private TaskCompletionSource<bool> _waitTCS;

    [SetUp]
    public void Init()
    {
      _waitTCS = new TaskCompletionSource<bool>();
    }

    [Test]
    public async Task FireAndForget_StartTaskAndForget_ExceptionHandledAndObserved()
    {
      ILogger log = GetLogger( LogType.Exception );
      PerformDelayAndThrowExceptionAsync().Forget( log );

      await _waitTCS.Task;
      LogAssert.Expect( LogType.Exception, new Regex( ExceptionMessage ) );
    }

    [Test]
    public async Task FireAndForget_StartTaskAndForget_TaskDoneWithoutException()
    {
      ILogger log = GetLogger( LogType.Exception );
      PerformDelayAsync().Forget( log );

      await _waitTCS.Task;
      LogAssert.NoUnexpectedReceived();
    }

    private ILogger GetLogger( LogType logType )
    {
      LogManager logManager = new( Debug.unityLogger.logHandler, logType );
      return logManager.GetLogger( GetType() );
    }

    private async Task PerformDelayAndThrowExceptionAsync()
    {
      await Task.Delay( MsDelay );
      try
      {
        throw new Exception( ExceptionMessage );
      }
      finally
      {
        _waitTCS.TrySetResult( true );
      }
    }

    private async Task PerformDelayAsync()
    {
      await Task.Delay( MsDelay );
      _waitTCS.TrySetResult( true );
    }
  }
}