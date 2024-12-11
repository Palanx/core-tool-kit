using UnityEditor;
using UnityEngine;

namespace CoreToolKit.UnityEngine.Attributes.Editor
{
  [CustomPropertyDrawer( typeof( ReadOnlyInspectorAttribute ) )]
  public class ReadOnlyInspectorDrawer : PropertyDrawer
  {
    public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) =>
      EditorGUI.GetPropertyHeight( property, label, true );

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
    {
      GUI.enabled = false;
      EditorGUI.PropertyField( position, property, label, true );
      GUI.enabled = true;
    }
  }
}