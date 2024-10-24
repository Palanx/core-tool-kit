using TMPro;
using UnityEngine;

namespace CoreToolKit.TextMeshPro.Extensions
{
{
  public static class TMP_TextExtensions
  {
    /// <summary>
    /// Try to find a <see cref="TMP_LinkInfo"/> in the ScreenPoint provided in this <see cref="TMP_Text"/>.
    /// </summary>
    /// <param name="mousePosition">ScreenPoint in the text where to extract the <see cref="TMP_LinkInfo"/>.</param>
    /// <param name="linkInfo"><see cref="TMP_LinkInfo"/> found in the ScreenPoint.</param>
    /// <returns>If was possible to get the <see cref="TMP_LinkInfo"/>.</returns>
    public static bool TryGetLinkInfo( this TMP_Text text, Vector3 mousePosition, out TMP_LinkInfo linkInfo ) => text.TryGetLinkInfo( mousePosition, null, out linkInfo );

    /// <summary>
    /// Try to find a <see cref="TMP_LinkInfo"/> in the ScreenPoint provided in this <see cref="TMP_Text"/>.
    /// </summary>
    /// <param name="mousePosition">ScreenPoint in the text where to extract the <see cref="TMP_LinkInfo"/>.</param>
    /// <param name="camera">Camera used to transform ScreenPoint to <see cref="Ray"/>.</param>
    /// <param name="linkInfo"><see cref="TMP_LinkInfo"/> found in the ScreenPoint.</param>
    /// <returns>If was possible to get the <see cref="TMP_LinkInfo"/>.</returns>
    public static bool TryGetLinkInfo( this TMP_Text text, Vector3 mousePosition, Camera camera, out TMP_LinkInfo linkInfo )
    {
      linkInfo = default;

      int linkIndex = TMP_TextUtilities.FindIntersectingLink( text, mousePosition, camera );
      if ( linkIndex == -1 )
      {
        return false;
      }

      linkInfo = text.textInfo.linkInfo[ linkIndex ];
      return true;
    }

    /// <summary>
    /// Get the world center position of the <see cref="TMP_LinkInfo"/> provided in this <see cref="TMP_Text"/>.
    /// </summary>
    /// <param name="linkInfo">Used to calculate the world center position.</param>
    /// <returns><see cref="TMP_LinkInfo"/> world center position.</returns>
    public static Vector3 GetLinkInfoWorldCenterPosition( this TMP_Text text, TMP_LinkInfo linkInfo )
    {
      // Accessing the text information of the TMP_Text component
      TMP_TextInfo textInfo = text.textInfo;

      // Getting the index of the first character in the link
      int firstCharacterIndex = linkInfo.linkTextfirstCharacterIndex;
      // Calculating the index of the last character in the link
      int lastCharacterIndex = linkInfo.linkTextfirstCharacterIndex + linkInfo.linkTextLength - 1;

      // Retrieving the information of the first character in the link
      TMP_CharacterInfo firstCharInfo = textInfo.characterInfo[ firstCharacterIndex ];
      // Retrieving the information of the last character in the link
      TMP_CharacterInfo lastCharInfo = textInfo.characterInfo[ lastCharacterIndex ];

      // Getting the bottom-left position of the first character
      Vector3 firstCharPos = firstCharInfo.bottomLeft;
      // Getting the top-right position of the last character
      Vector3 lastCharPos = lastCharInfo.topRight;

      // Calculating the center position between the first and last characters
      Vector3 centerPosition = ( firstCharPos + lastCharPos ) / 2;

      // Transforming the local position of the center to world space
      centerPosition = text.transform.TransformPoint( centerPosition );

      // Returning the center position in world space
      return centerPosition;
    }
  }
}