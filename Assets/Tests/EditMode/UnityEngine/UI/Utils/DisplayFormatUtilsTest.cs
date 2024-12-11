using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CoreToolKit.Logger;
using CoreToolKit.NET_System.Delegate.Extensions;
using CoreToolKit.UI.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ILogger = CoreToolKit.Logger.ILogger;

namespace CoreToolKit.Tests.EditMode.UnityEngine.UI.Utils
{
  public class DisplayFormatUtilsTest
  {
    private const string LogMessage = "can't be cast";

    private readonly CultureInfo _usCultureInfo = new("en-US");

    #region String Parameter

    [Test]
    public void IntegerUSFormat_PassValidIntegerString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "1000000";
      string expectedOutput = "1,000,000";

      DisplayFormatUtils.TryFormatLongStringValue( input, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void IntegerUSFormat_PassValidDecimalString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "1000.55";
      string expectedOutput = "1,001";

      DisplayFormatUtils.TryFormatLongStringValue( input, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void IntegerUSFormat_PassInvalidString_NotFormated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "invalid-string-number";
      string expectedOutput = string.Empty;

      DisplayFormatUtils.TryFormatLongStringValue( input, out string output, _usCultureInfo, log );

      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void DecimalUSFormat_PassValidIntegerString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "1000000";
      string expectedOutput = "1,000,000.000";
      int amountOfDecimals = 3;

      DisplayFormatUtils.TryFormatDoubleStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void DecimalUSFormat_PassValidDecimalString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "1000000.6543";
      string expectedOutput = "1,000,000.654";
      int amountOfDecimals = 3;

      DisplayFormatUtils.TryFormatDoubleStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void DecimalUSFormat_PassInvalidString_NotFormated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "invalid-string-number";
      string expectedOutput = string.Empty;
      int amountOfDecimals = 3;

      DisplayFormatUtils.TryFormatDoubleStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void PercentUSFormat_PassValidIntegerString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "1";
      string expectedOutput = "100.00%";
      int amountOfDecimals = 2;

      DisplayFormatUtils.TryFormatPercentageStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void PercentUSFormat_PassValidDecimalString_Formated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "0.452658";
      string expectedOutput = "45.26%";
      int amountOfDecimals = 2;

      DisplayFormatUtils.TryFormatPercentageStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.NoUnexpectedReceived();
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void PercentUSFormat_PassInvalidString_NotFormated()
    {
      ILogger log = GetLogger( LogType.Exception );

      string input = "invalid-string-number";
      string expectedOutput = string.Empty;
      int amountOfDecimals = 2;

      DisplayFormatUtils.TryFormatPercentageStringValue( input, amountOfDecimals, out string output, _usCultureInfo, log );

      LogAssert.Expect( LogType.Warning, new Regex( LogMessage ) );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    #endregion String Parameter

    #region Integer Parameter

    [Test]
    public void IntegerUSFormat_PassInteger_Formated()
    {
      long input = 1000000;
      string expectedOutput = "1,000,000";

      string output = DisplayFormatUtils.FormatLongValue( input, _usCultureInfo );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    #endregion Integer Parameter

    #region Decimal Parameter

    [Test]
    public void IntegerUSFormat_PassDecimal_Formated()
    {
      double input = 1000.55;
      string expectedOutput = "1,001";

      string output = DisplayFormatUtils.FormatDoubleValueAsLong( input, _usCultureInfo );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void DecimalUsFormat_PassDecimal_Formated()
    {
      double input = 1000000.6543;
      string expectedOutput = "1,000,000.654";
      int amountOfDecimals = 3;

      string output = DisplayFormatUtils.FormatDoubleValue( input, amountOfDecimals, _usCultureInfo );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    [Test]
    public void PercentUSFormat_PassDecimal_Formated()
    {
      double input = 0.452658;
      string expectedOutput = "45.26%";
      int amountOfDecimals = 2;

      string output = DisplayFormatUtils.FormatDoubleValueAsPercentage( input, amountOfDecimals, _usCultureInfo );
      Assert.AreEqual( output, expectedOutput, $"The output was '{output}', not '{expectedOutput}'." );
    }

    #endregion Decimal Parameter

    private ILogger GetLogger( LogType logType )
    {
      LogManager logManager = new( Debug.unityLogger.logHandler, logType );
      return logManager.GetLogger( GetType() );
    }
  }
}