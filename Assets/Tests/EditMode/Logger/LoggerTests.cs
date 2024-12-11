using System;
using System.Text.RegularExpressions;
using CoreToolKit.Logger;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ILogger = CoreToolKit.Logger.ILogger;

namespace CoreToolKit.Tests.EditMode.Logger
{
  
  public class LoggerTests
  {
    private const string LogMessage = "Random log";
    
    #region Log Info
    [Test]
    public void LogInfo_GetLoggerForExceptionType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Exception );
      log.Info( LogMessage );
      
      LogAssert.Expect( LogType.Log, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogInfo_GetLoggerForLogType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Log );
      log.Info( LogMessage );
      
      LogAssert.Expect( LogType.Log, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogInfo_GetLoggerForWarningType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Warning );
      log.Info( LogMessage );
      
      LogAssert.NoUnexpectedReceived();
    }
    
    [Test]
    public void LogInfo_GetLoggerForErrorType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Error );
      log.Info( LogMessage );
      
      LogAssert.NoUnexpectedReceived();
    }
    #endregion Log Info
    
    #region Log Warning
    [Test]
    public void LogWarning_GetLoggerForExceptionType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Exception );
      log.Warning( LogMessage );
      
      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogWarning_GetLoggerForLogType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Log );
      log.Warning( LogMessage );
      
      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogWarning_GetLoggerForWarningType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Warning );
      log.Warning( LogMessage );
      
      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogWarning_GetLoggerForErrorType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Error );
      log.Warning( LogMessage );
      
      LogAssert.NoUnexpectedReceived();
    }
    #endregion Log Warning
    
    #region Log Error
    [Test]
    public void LogError_GetLoggerForExceptionType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Exception );
      log.Error( LogMessage );
      
      LogAssert.Expect( LogType.Error, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogError_GetLoggerForLogType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Log );
      log.Error( LogMessage );
      
      LogAssert.Expect( LogType.Error, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogError_GetLoggerForWarningType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Warning );
      log.Error( LogMessage );
      
      LogAssert.Expect( LogType.Error, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogError_GetLoggerForErrorType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Error );
      log.Error( LogMessage );
      
      LogAssert.Expect( LogType.Error, new Regex( LogMessage ) );
    }
    #endregion Log Error
    
    #region Log Exception
    [Test]
    public void LogException_GetLoggerForExceptionType_LogLogged()
    {
      ILogger log = GetLogger( LogType.Exception );
      log.Exception( LogMessage, new Exception( LogMessage )  );
      
      LogAssert.Expect( LogType.Exception, new Regex( LogMessage ) );
    }
    
    [Test]
    public void LogException_GetLoggerForLogType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Log );
      log.Exception( LogMessage, new Exception( LogMessage )  );
      
      LogAssert.NoUnexpectedReceived();
    }
    
    [Test]
    public void LogException_GetLoggerForWarningType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Warning );
      log.Exception( LogMessage, new Exception( LogMessage )  );
      
      LogAssert.NoUnexpectedReceived();
    }
    
    [Test]
    public void LogException_GetLoggerForErrorType_LogNotLogged()
    {
      ILogger log = GetLogger( LogType.Error );
      log.Exception( LogMessage, new Exception( LogMessage )  );
      
      LogAssert.NoUnexpectedReceived();
    }
    #endregion Log Exception
    
    private ILogger GetLogger( LogType logType )
    {
      LogManager logManager = new( Debug.unityLogger.logHandler, logType );
      return logManager.GetLogger( GetType() );
    }
  }
}