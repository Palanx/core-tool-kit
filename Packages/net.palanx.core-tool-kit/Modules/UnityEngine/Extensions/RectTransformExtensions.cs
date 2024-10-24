using UnityEngine;

namespace CoreToolKit.UnityEngine.Extensions
{
  /// <summary>
  /// <see cref="RectTransform"/> extension methods.
  /// </summary>
  public static class RectTransformExtensions
  {
    /// <summary>
    /// Get pixel-adjusted Rect for a RectTransform based on the canvas's render mode.
    /// If the canvas is in ScreenSpaceOverlay mode it returns the original rect;
    /// otherwise, it adjusts the rect to be pixel-perfect.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="canvas">The canvas that the RectTransform is part of.</param>
    /// <returns>The pixel-adjusted Rect if not in ScreenSpaceOverlay mode; otherwise, the original Rect.</returns>
    public static Rect GetPixelAdjustedRect( this RectTransform rectTransform, Canvas canvas )
    {
      return canvas.renderMode == RenderMode.ScreenSpaceOverlay ? rectTransform.rect : RectTransformUtility.PixelAdjustRect( rectTransform, canvas );
    }

    /// <summary>
    /// Get the world space center position of a RectTransform using a given pixel-adjusted Rect.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The world space center position of the RectTransform.</returns>
    public static Vector3 GetWorldCenterPosition( this RectTransform rectTransform, Rect pixelAdjustedRect )
    {
      Vector3 center = new( pixelAdjustedRect.center.x, pixelAdjustedRect.center.y, 0f );
      return rectTransform.TransformPoint( center );
    }

    /// <summary>
    /// Get the screen center position of a RectTransform using a given pixel-adjusted Rect.
    /// If the camera is null, indicating ScreenSpaceOverlay mode, the method returns the world space position directly.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The screen space center position of the RectTransform.</returns>
    public static Vector2 GetScreenCenterPosition( this RectTransform rectTransform, Camera camera, Rect pixelAdjustedRect )
    {
      Vector3 worldPosition = rectTransform.GetWorldCenterPosition( pixelAdjustedRect );
      if ( camera == null )
      {
        return new( worldPosition.x, worldPosition.y );
      }

      return RectTransformUtility.WorldToScreenPoint( camera, worldPosition );
    }

    /// <summary>
    /// Get the screen space minimum pivot offset (from pivot to bottom-left corner) of a RectTransform using a given pixel-adjusted Rect.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space position.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The screen space position of the minimum pivot point of the RectTransform.</returns>
    public static Vector2 GetScreenMinPivotOffset( this RectTransform rectTransform, Camera camera, Rect pixelAdjustedRect )
    {
      Vector3 localVector = new( pixelAdjustedRect.xMin, pixelAdjustedRect.yMin, 0f );
      Vector3 worldVector = rectTransform.TransformVector( localVector );
      if ( camera == null )
      {
        return new( worldVector.x, worldVector.y );
      }

      return RectTransformUtility.WorldToScreenPoint( camera, worldVector );
    }

    /// <summary>
    /// Get the screen space maximum pivot offset (from pivot to top-right corner) of a RectTransform using a given pixel-adjusted Rect.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space position.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The screen space position of the maximum pivot point of the RectTransform.</returns>
    public static Vector2 GetScreenMaxPivotOffset( this RectTransform rectTransform, Camera camera, Rect pixelAdjustedRect )
    {
      Vector3 localVector = new( pixelAdjustedRect.xMax, pixelAdjustedRect.yMax, 0f );
      Vector3 worldVector = rectTransform.TransformVector( localVector );
      if ( camera == null )
      {
        return new( worldVector.x, worldVector.y );
      }

      return RectTransformUtility.WorldToScreenPoint( camera, worldVector );
    }

    /// <summary>
    /// Get the world space minimum corner position (bottom-left corner) of a RectTransform, using a given pixel-adjusted Rect.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The world space position of the minimum corner position of the RectTransform.</returns>
    public static Vector3 GetWorldMinCorner( this RectTransform rectTransform, Rect pixelAdjustedRect )
    {
      Vector3 localPosition = new( pixelAdjustedRect.x, pixelAdjustedRect.y, 0f );
      Matrix4x4 localToWorldMatrix = rectTransform.localToWorldMatrix;
      return localToWorldMatrix.MultiplyPoint( localPosition );
    }

    /// <summary>
    /// Get the screen space minimum corner position (bottom-left corner) of a RectTransform, using a given pixel-adjusted Rect.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space position.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The screen space position of the minimum corner position of the RectTransform.</returns>
    public static Vector2 GetScreenMinCorner( this RectTransform rectTransform, Camera camera, Rect pixelAdjustedRect )
    {
      Vector3 worldPosition = rectTransform.GetWorldMinCorner( pixelAdjustedRect );
      if ( camera == null )
      {
        return new( worldPosition.x, worldPosition.y );
      }

      return RectTransformUtility.WorldToScreenPoint( camera, worldPosition );
    }

    /// <summary>
    /// Get the world space maximum corner position (top-right corner) of a RectTransform, using a given pixel-adjusted Rect.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The world space position of the maximum corner position of the RectTransform.</returns>
    public static Vector3 GetWorldMaxCorner( this RectTransform rectTransform, Rect pixelAdjustedRect )
    {
      Vector3 localPosition = new( pixelAdjustedRect.xMax, pixelAdjustedRect.yMax, 0f );
      Matrix4x4 localToWorldMatrix = rectTransform.localToWorldMatrix;
      return localToWorldMatrix.MultiplyPoint( localPosition );
    }

    /// <summary>
    /// Get the screen space maximum corner position (top-right corner) of a RectTransform, using a given pixel-adjusted Rect.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space position.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="pixelAdjustedRect">The pixel-adjusted Rect of the RectTransform.</param>
    /// <returns>The screen space position of the maximum corner position of the RectTransform.</returns>
    public static Vector2 GetScreenMaxCorner( this RectTransform rectTransform, Camera camera, Rect pixelAdjustedRect )
    {
      Vector3 worldPosition = rectTransform.GetWorldMaxCorner( pixelAdjustedRect );
      if ( camera == null )
      {
        return new( worldPosition.x, worldPosition.y );
      }

      return RectTransformUtility.WorldToScreenPoint( camera, worldPosition );
    }

    /// <summary>
    /// Converts a screen space position to world space for a RectTransform.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and it treats the screen position as already being in world space.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the conversion. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="screenPosition">The screen space position to be converted.</param>
    /// <returns>The world space position corresponding to the given screen space position.</returns>
    public static Vector3 ScreenToWorldPoint( this RectTransform rectTransform, Camera camera, Vector2 screenPosition )
    {
      Vector3 screen3DPosition = new( screenPosition.x, screenPosition.y, 0f );
      if ( camera == null )
      {
        return screen3DPosition;
      }

      Vector3 worldPosition = camera.ScreenToWorldPoint( screen3DPosition );
      // Moving the Z axis to the correct value
      worldPosition.z = rectTransform.position.z;

      return worldPosition;
    }

    /// <summary>
    /// Converts a world space vector to screen space vector for a RectTransform.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space vector.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <param name="worldVector">The local vector to be converted.</param>
    /// <returns>The screen space vector corresponding to the given world space vector.</returns>
    public static Vector2 WorldToScreenVector( this RectTransform rectTransform, Camera camera, Vector3 worldVector )
    {
      if ( camera == null )
      {
        return new( worldVector.x, worldVector.y );
      }

      Vector3 rectTransformPosition = rectTransform.position;
      Vector2 originPosition = RectTransformUtility.WorldToScreenPoint( camera, rectTransformPosition );
      Vector2 finalPosition = RectTransformUtility.WorldToScreenPoint( camera, rectTransformPosition + worldVector );

      return finalPosition - originPosition;
    }

    /// <summary>
    /// Get the pivot offset to the center of the RectTransform, using a given pixel-adjusted size.
    /// The coordinate space of the given pixel-adjusted size will be the resultant coordinate space.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="pixelAdjustedRectSize">The pixel-adjusted size of the RectTransform.</param>
    /// <returns>The pivot offset to the center of the RectTransform.</returns>
    public static Vector2 GetPivotOffsetToCenter( this RectTransform rectTransform, Vector2 pixelAdjustedRectSize )
    {
      Vector2 pivot = rectTransform.pivot;
      return new( ( 0.5f - pivot.x ) * pixelAdjustedRectSize.x, ( 0.5f - pivot.y ) * pixelAdjustedRectSize.y );
    }

    /// <summary>
    /// Get a screen space Rect based on the given rectTransform pixel-adjusted Rect.
    /// If the camera is null, the method assumes ScreenSpaceOverlay mode and returns the world space Rect.
    /// </summary>
    /// <param name="rectTransform">Extension instance.</param>
    /// <param name="canvas">The canvas that the RectTransform is part of.</param>
    /// <param name="camera">The camera used for the transformation. Null implies ScreenSpaceOverlay mode.</param>
    /// <returns>The screen space Rect corresponding to the given rectTransform pixel-adjusted Rect.</returns>
    public static Rect GetScreenRect( this RectTransform rectTransform, Canvas canvas, Camera camera )
    {
      // Get pixel-adjusted local Rect
      Rect pixelAdjustedLocalRect = rectTransform.GetPixelAdjustedRect( canvas );

      // Get rect screen size
      Vector3 localSize = new( pixelAdjustedLocalRect.size.x, pixelAdjustedLocalRect.size.y, 0f );
      Vector3 worldSize = rectTransform.TransformVector( localSize );
      Vector2 screenSize = rectTransform.WorldToScreenVector( camera, worldSize );

      // Get rect min screen vector
      Vector2 screenMin = rectTransform.GetScreenMinPivotOffset( camera, pixelAdjustedLocalRect );

      return new( screenMin, screenSize );
    }
  }
}