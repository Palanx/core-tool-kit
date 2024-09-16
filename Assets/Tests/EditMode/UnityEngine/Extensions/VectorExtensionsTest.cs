using CoreToolKit.UnityEngine.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace CoreToolKit.Tests.EditMode.UnityEngine.Extensions
{
    public class VectorExtensionsTest
    {
        #region Vector2
        [Test]
        public void TransformVector_FromVector2_ToVector3AsXY0()
        {
            Vector2 vector2 = new( 1, 2 );
            Vector3 vector3 = vector2.GetXY0();
            Assert.AreEqual( vector3, new Vector3( 1, 2, 0 ) );
        }
        
        [Test]
        public void TransformVector_FromVector2_ToVector3AsX0Y()
        {
            Vector2 vector2 = new( 1, 2 );
            Vector3 vector3 = vector2.GetX0Y();
            Assert.AreEqual( vector3, new Vector3( 1, 0, 2 ) );
        }
        
        [Test]
        public void TransformVector_FromVector2_ToVector3As0XY()
        {
            Vector2 vector2 = new( 1, 2 );
            Vector3 vector3 = vector2.Get0XY();
            Assert.AreEqual( vector3, new Vector3( 0, 1, 2 ) );
        }
        #endregion Vector2
        
        #region Vector3
        [Test]
        public void TransformVector_FromVector3_ToVector2AsXY()
        {
            Vector3 vector3 = new( 1, 2, 3 );
            Vector2 vector2 = vector3.GetXY();
            Assert.AreEqual( vector2, new Vector2( 1, 2 ) );
        }
        
        [Test]
        public void TransformVector_FromVector3_ToVector2AsXZ()
        {
            Vector3 vector3 = new( 1, 2, 3 );
            Vector2 vector2 = vector3.GetXZ();
            Assert.AreEqual( vector2, new Vector2( 1, 3 ) );
        }
        
        [Test]
        public void TransformVector_FromVector3_ToVector2AsYZ()
        {
            Vector3 vector3 = new( 1, 2, 3 );
            Vector2 vector2 = vector3.GetYZ();
            Assert.AreEqual( vector2, new Vector2( 2, 3 ) );
        }
        #endregion Vector3
    }
}
