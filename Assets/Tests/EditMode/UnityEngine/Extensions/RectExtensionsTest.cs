using CoreToolKit.UnityEngine.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace CoreToolKit.Tests.EditMode.UnityEngine.Extensions
{
  public class RectExtensionsTest
  {
    [Test]
    public void RectPivotOffset_CreateRect_GetPivotOffset_Valid()
    {
      Rect rectWithPivotInLeftBottom = new( new Vector2( 0f, 0f ), new Vector2( 10f, 10f ) );

      Vector2 pivotOffsetToCenter = rectWithPivotInLeftBottom.GetPivotOffsetToCenter();
      Vector2 expectedPivotOffsetToCenter = new( 5f, 5f );

      Assert.AreEqual( pivotOffsetToCenter, expectedPivotOffsetToCenter, $"The current offset is {pivotOffsetToCenter} and it should be {expectedPivotOffsetToCenter}" );
    }
  }
}