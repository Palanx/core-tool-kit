using System;
using System.Globalization;
using CoreToolKit.Logger;

// ReSharper disable once CheckNamespace
namespace CoreToolKit.UI.Utils
{
  /// <summary>
  /// Utils class to format values.
  /// </summary>
  public static class DisplayFormatUtils
  {
    /// <summary>
    /// Try to format a string value into a string long value, if the input value has decimals, the number will be rounded.
    /// EX: "1000000" => "1,000,000", "1000.55" => "1,001".
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="formattedValue">Output formatted value.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <param name="log">Used to log possible errors.</param>
    /// <returns>If the value was formatted.</returns>
    public static bool TryFormatLongStringValue( string value, out string formattedValue, CultureInfo cultureInfo, ILogger log )
    {
      if ( !long.TryParse( value, out long longResult ) )
      {
        if ( !double.TryParse( value, out double doubleResult ) )
        {
          log.Warning( $"Value of {value} can't be cast to Long or Double before formatting." );
          formattedValue = string.Empty;
          return false;
        }

        // N0 = Number with commas, 0 decimals, and rounded
        formattedValue = FormatDoubleValueAsLong( doubleResult, cultureInfo );
        return true;
      }

      formattedValue = FormatLongValue( longResult, cultureInfo );
      return true;
    }

    /// <summary>
    /// Format double into a string long value, the number will be rounded.
    /// EX: 1000.55d => "1,001".
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <returns>Value formatted.</returns>
    public static string FormatDoubleValueAsLong( double value, CultureInfo cultureInfo ) =>
      // N0 = Number with commas, 0 decimals, and rounded
      value.ToString( "N0", cultureInfo );

    /// <summary>
    /// Format long into a string long value.
    /// EX: 1000000 => "1,000,000".
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <returns>Value formatted.</returns>
    public static string FormatLongValue( long value, CultureInfo cultureInfo ) =>
      // N0 = Number with commas
      value.ToString( "N0", cultureInfo );

    /// <summary>
    /// Try to format a string value into a string percentage value and truncate decimals.
    /// EX: "0.452658" => "45.26%".
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="amountOfDecimals">Amount of decimals to preserve.</param>
    /// <param name="formattedValue">Output formatted value.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <param name="log">Used to log possible errors.</param>
    /// <returns>If the value was formatted.</returns>
    public static bool TryFormatPercentageStringValue( string value, int amountOfDecimals, out string formattedValue, CultureInfo cultureInfo, ILogger log )
    {
      if ( !double.TryParse( value, out double doubleResult ) )
      {
        log.Warning( $"Value of {value} can't be cast to Double before formatting." );
        formattedValue = string.Empty;
        return false;
      }

      formattedValue = FormatDoubleValueAsPercentage( doubleResult, amountOfDecimals, cultureInfo );
      return true;
    }

    /// <summary>
    /// Format double into a string percentage value and truncate decimals.
    /// EX: 0.452658d => "45.26%".
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="amountOfDecimals">Amount of decimals to preserve.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <returns>Value formatted.</returns>
    public static string FormatDoubleValueAsPercentage( double value, int amountOfDecimals, CultureInfo cultureInfo )
    {
      double percentage = value * 100;
      double truncateFactor = Math.Pow( 10, amountOfDecimals );
      // Truncate decimals
      percentage = Math.Truncate( percentage * truncateFactor ) / truncateFactor;

      return $"{percentage.ToString( $"N{amountOfDecimals}", cultureInfo )}%";
    }

    /// <summary>
    /// Try to format a string value into a string double value that separate the hundredths by culture and truncate decimals.
    /// EX: "1000000.6543" => "1,000,000.65"
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="amountOfDecimals">Amount of decimals to preserve.</param>
    /// <param name="formattedValue">Output formatted value.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <param name="log">Used to log possible errors.</param>
    /// <returns>If the value was formatted.</returns>
    public static bool TryFormatDoubleStringValue( string value, int amountOfDecimals, out string formattedValue, CultureInfo cultureInfo, ILogger log )
    {
      if ( !double.TryParse( value, out double doubleResult ) )
      {
        log.Warning( $"Value of {value} can't be cast to Double before formatting." );
        formattedValue = string.Empty;
        return false;
      }

      formattedValue = FormatDoubleValue( doubleResult, amountOfDecimals, cultureInfo );
      return true;
    }

    /// <summary>
    /// Format double into a string double value and truncate decimals.
    /// EX: 1000000.6543d => "1,000,000.65"
    /// </summary>
    /// <param name="value">Value to format.</param>
    /// <param name="amountOfDecimals">Amount of decimals to preserve.</param>
    /// <param name="cultureInfo">Culture used to format the output.</param>
    /// <returns>Value formatted.</returns>
    public static string FormatDoubleValue( double value, int amountOfDecimals, CultureInfo cultureInfo )
    {
      double truncateFactor = Math.Pow( 10, amountOfDecimals );
      // Truncate decimals
      value = Math.Truncate( value * truncateFactor ) / truncateFactor;

      return value.ToString( $"N{amountOfDecimals}", cultureInfo );
    }
  }
}