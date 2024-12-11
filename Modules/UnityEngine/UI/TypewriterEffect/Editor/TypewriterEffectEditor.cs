using UnityEditor;
using UnityEngine;

namespace CoreToolKit.UI.TypewriterEffect.Editor
{
  /// <summary>
  /// <see cref="TypewriterEffect"/> Editor script to set default Time value and add Test controls.
  /// </summary>
  [CustomEditor( typeof( TypewriterEffect ) )]
  public class TypewriterEffectEditor : UnityEditor.Editor
  {
    private MonoScript _editorScript;
    private string _textToSet =
      "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
    private SerializedProperty _time;
    private SerializedProperty _timeUseType;
    private int _previousTimeUseType;
    private bool _showTypewriterEditorLayout;

    private void OnEnable()
    {
      _time = serializedObject.FindProperty( "_time" );
      _timeUseType = serializedObject.FindProperty( "_timeUseType" );
      _previousTimeUseType = _timeUseType.intValue;
      _editorScript = MonoScript.FromScriptableObject( this );
      _showTypewriterEditorLayout = Application.isPlaying;
    }

    public override void OnInspectorGUI()
    {
      EditorGUI.BeginDisabledGroup( true );
      EditorGUILayout.ObjectField( "Editor Script", _editorScript, typeof( MonoScript ), false );
      EditorGUI.EndDisabledGroup();
      DrawDefaultInspector();

      // If the _timeUseType value changes, the _time will change to a default value
      int currentTimeUseType = _timeUseType.enumValueFlag;
      if ( currentTimeUseType != _previousTimeUseType )
      {
        _previousTimeUseType = currentTimeUseType;
        SetTimeValue();
      }

      EditorGUILayout.Space();

      _showTypewriterEditorLayout = EditorGUILayout.Foldout( _showTypewriterEditorLayout, "Test & Debug (only PlayMode)", true, EditorStyles.foldoutHeader );
      if ( !_showTypewriterEditorLayout )
      {
        return;
      }

      TypewriterEffect typewriterEffect = (TypewriterEffect) target;

      EditorGUILayout.BeginVertical( "box" );
      EditorGUILayout.LabelField( "Test Controls", EditorStyles.boldLabel );

      EditorGUILayout.BeginHorizontal();
      EditorGUILayout.LabelField( "Text to Set", GUILayout.Width( 120 ) );
      _textToSet = EditorGUILayout.TextArea( _textToSet, EditorStyles.textArea, GUILayout.Height( 100 ) );
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginHorizontal();
      bool disableButtons = !Application.isPlaying;
      EditorGUILayout.LabelField( "Execute", GUILayout.Width( 120 ) );
      if ( disableButtons )
      {
        EditorGUI.BeginDisabledGroup( true );
      }
      if ( GUILayout.Button( "StartEffectSequence( TextToSet )" ) )
      {
        typewriterEffect.StartEffectSequence( _textToSet );
      }
      if ( GUILayout.Button( "CompleteEffectSequence()" ) )
      {
        typewriterEffect.CompleteEffectSequence();
      }
      if ( disableButtons )
      {
        EditorGUI.EndDisabledGroup();
      }
      EditorGUILayout.EndHorizontal();
      EditorGUILayout.EndVertical();

      EditorGUILayout.Space();

      EditorGUILayout.BeginVertical( "box" );
      EditorGUILayout.LabelField( "Status", EditorStyles.boldLabel );
      EditorGUILayout.LabelField( "Is On Play", typewriterEffect.IsOnPlay.ToString() );
      EditorGUILayout.EndVertical();
    }

    /// <summary>
    /// Change the _time default value depending on the current _timeUseType.
    /// </summary>
    private void SetTimeValue()
    {
      switch ( (TypewriteEffectTimeUseType) _previousTimeUseType )
      {
        case TypewriteEffectTimeUseType.TotalDuration:
          _time.floatValue = TypewriterEffect.TimeAsTotalDurationDefaultValue;
          break;
        case TypewriteEffectTimeUseType.DelayPerCharacter:
          _time.floatValue = TypewriterEffect.TimeAsDelayPerCharacterDefaultValue;
          break;
      }
      serializedObject.ApplyModifiedProperties();
    }
  }
}