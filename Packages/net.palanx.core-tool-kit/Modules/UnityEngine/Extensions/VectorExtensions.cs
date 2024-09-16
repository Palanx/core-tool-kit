using UnityEngine;

namespace CoreToolKit.UnityEngine.Extensions
{
  /// <summary>
  /// Extension methods for <see cref="UnityEngine"/> Vector types.
  /// </summary>
  public static class VectorExtensions
  {
    #region Vector2
    /// <summary>
    /// Instantiate and get a new <see cref="Vector3"/> using the <see cref="Vector2"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector2</term><description>Vector3</description></listheader>
    ///   <item><term>X</term><description>X</description></item>
    ///   <item><term>Y</term><description>Y</description></item>
    ///   <item><term>0</term><description>Z</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector3"/> instance.</returns>
    public static Vector3 GetXY0( this Vector2 vector ) => new( vector.x, vector.y, 0f );

    /// <summary>
    /// Instantiate and get a new <see cref="Vector3"/> using the <see cref="Vector2"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector2</term><description>Vector3</description></listheader>
    ///   <item><term>X</term><description>X</description></item>
    ///   <item><term>0</term><description>Y</description></item>
    ///   <item><term>Y</term><description>Z</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector3"/> instance.</returns>
    public static Vector3 GetX0Y( this Vector2 vector ) => new( vector.x, 0f, vector.y );

    /// <summary>
    /// Instantiate and get a new <see cref="Vector3"/> using the <see cref="Vector2"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector2</term><description>Vector3</description></listheader>
    ///   <item><term>0</term><description>X</description></item>
    ///   <item><term>X</term><description>Y</description></item>
    ///   <item><term>Y</term><description>Z</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector3"/> instance.</returns>
    public static Vector3 Get0XY( this Vector2 vector ) => new( 0f, vector.x, vector.y );
    #endregion Vector2

    #region Vector3
    /// <summary>
    /// Instantiate and get a new <see cref="Vector2"/> using the <see cref="Vector3"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector3</term><description>Vector2</description></listheader>
    ///   <item><term>X</term><description>X</description></item>
    ///   <item><term>Y</term><description>Y</description></item>
    ///   <item><term>Z</term><description>-</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector2"/> instance.</returns>
    public static Vector2 GetXY( this Vector3 vector ) => new( vector.x, vector.y );

    /// <summary>
    /// Instantiate and get a new <see cref="Vector2"/> using the <see cref="Vector3"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector3</term><description>Vector2</description></listheader>
    ///   <item><term>X</term><description>X</description></item>
    ///   <item><term>Y</term><description>-</description></item>
    ///   <item><term>Z</term><description>Y</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector2"/> instance.</returns>
    public static Vector2 GetXZ( this Vector3 vector ) => new( vector.x, vector.z );

    /// <summary>
    /// Instantiate and get a new <see cref="Vector2"/> using the <see cref="Vector3"/> axis as:
    /// <list type="table">
    ///   <listheader><term>Vector3</term><description>Vector2</description></listheader>
    ///   <item><term>X</term><description>-</description></item>
    ///   <item><term>Y</term><description>X</description></item>
    ///   <item><term>Z</term><description>Y</description></item>
    /// </list>
    /// </summary>
    /// <returns>New <see cref="Vector2"/> instance.</returns>
    public static Vector2 GetYZ( this Vector3 vector ) => new( vector.y, vector.z );
    #endregion Vector3
  }
}