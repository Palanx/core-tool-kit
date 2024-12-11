using UnityEngine;

namespace CoreToolKit.UnityEngine.Extensions
{
  /// <summary>
  /// <see cref="Rect"/> extension methods.
  /// </summary>
  public static class RectExtensions
  {
    /// <summary>
    /// Get the pivot offset to the center of the Rect.
    /// </summary>
    /// <param name="rect">Extension instance.</param>
    /// <returns>The pivot offset to the center.</returns>
    public static Vector2 GetPivotOffsetToCenter( this Rect rect ) => rect == Rect.zero ? Vector2.zero : new Vector2( rect.width / 2f, rect.height / 2f ) + rect.min;
  }
}