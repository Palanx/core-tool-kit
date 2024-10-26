using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CoreToolKit.UI.TypewriterEffect
{
  public enum TypewriteEffectTimeUseType
  {
    TotalDuration = 0,
    DelayPerCharacter = 1
  }

  /// <summary>
  /// Component that display text in a <see cref="TMPro.TMP_Text"/> component
  /// </summary>
  public class TypewriterEffect : MonoBehaviour
  {
    public const float TimeAsTotalDurationDefaultValue = 1f;
    public const float TimeAsDelayPerCharacterDefaultValue = 0.01f;

    [Header( "Component Fields " )]
    [SerializeField, Tooltip( "Label to apply the typewriter effect" )]
    private TMP_Text _targetLabel;
    /// <summary>
    /// This value is used to calculate the effect duration. <br/>
    /// Each time the <see cref="_timeUseType"/> value is changed, the Component Editor script will change this value to:
    /// <ul>
    ///   <li><see cref="TypewriteEffectTimeUseType.TotalDuration"/>: Set value to <see cref="TimeAsTotalDurationDefaultValue"/></li>
    ///   <li><see cref="TypewriteEffectTimeUseType.DelayPerCharacter"/>: Set value to <see cref="TimeAsDelayPerCharacterDefaultValue"/></li>
    /// </ul>
    /// </summary>
    [SerializeField, Tooltip( "Effect duration time based on the Time Use Type" ), InspectorName( "Time (in seconds)" )]
    private float _time = TimeAsTotalDurationDefaultValue;
    [SerializeField, Tooltip( "How the Time value will be used in the effect (set this value will reset the time to default value)" )]
    private TypewriteEffectTimeUseType _timeUseType;

    public bool IsOnPlay { get; private set; }

    private Sequence _currentEffectSequence;

    private void Awake()
    {
      // TODO: Implement Guards.
      //Guard.State.IsNotNull( _targetLabel, $"Missing reference to {nameof( _targetLabel )}." );

      // The target text could contain a placeholder text, so the state is cleared at the beginning.
      ClearState();
    }

    private void OnDisable() => ClearState();

    /// <summary>
    /// Kill the current effect sequence and clear the target text.
    /// </summary>
    public void ClearState()
    {
      _currentEffectSequence?.Kill( true );
      _targetLabel.SetText( string.Empty );
    }

    /// <summary>
    /// Set the current <see cref="_targetLabel"/> text and start displaying it using a typewriter effect sequence.
    /// Uses the <see cref="_time"/> & <see cref="_timeUseType"/> member values to config the effect duration.
    /// </summary>
    /// <param name="newText">New text to display.</param>
    /// <param name="onCompleteCallback">(Optional) On sequence complete callback.</param>
    public void StartEffectSequence( string newText, Action onCompleteCallback = null ) => StartEffectSequence( newText, _time, _timeUseType, onCompleteCallback );

    /// <summary>
    /// Set the current <see cref="_targetLabel"/> text and start displaying it using a typewriter effect sequence.
    /// Uses the <see cref="_timeUseType"/> member value to config the effect duration.
    /// </summary>
    /// <param name="newText">New text to display.</param>
    /// <param name="time">Effect duration time based on the timeUseType provided.</param>
    /// <param name="onCompleteCallback">(Optional) On sequence complete callback.</param>
    public void StartEffectSequence( string newText, float time, Action onCompleteCallback = null ) => StartEffectSequence( newText, time, _timeUseType, onCompleteCallback );

    /// <summary>
    /// Set the current <see cref="_targetLabel"/> text and start displaying it using a typewriter effect sequence.
    /// </summary>
    /// <param name="newText">New text to display.</param>
    /// <param name="time">Effect duration time based on the timeUseType provided.</param>
    /// <param name="timeUseType">How the Time value will be used in the effect.</param>
    /// <param name="onCompleteCallback">(Optional) On sequence complete callback.</param>
    public void StartEffectSequence( string newText, float time, TypewriteEffectTimeUseType timeUseType, Action onCompleteCallback = null )
    {
      PrepareStateForNewText();

      // Set the new text into the label
      _targetLabel.SetText( newText );

      // Start the typewriter effect
      _currentEffectSequence = CreateEffectSequence( time, timeUseType, onCompleteCallback );
    }

    /// <summary>
    /// Prepare the state for the new text that will be displayed.
    /// </summary>
    private void PrepareStateForNewText()
    {
      _currentEffectSequence?.Kill( true );
      IsOnPlay = true;
      _targetLabel.maxVisibleCharacters = 0;
    }

    /// <summary>
    /// Create a typewriter effect sequence.
    /// </summary>
    /// <param name="time">Effect duration time based on the timeUseType provided.</param>
    /// <param name="timeUseType">How the Time value will be used in the effect.</param>
    /// <param name="onCompleteCallback">On sequence complete callback.</param>
    /// <returns>Typewrite effect sequence.</returns>
    private Sequence CreateEffectSequence( float time, TypewriteEffectTimeUseType timeUseType, Action onCompleteCallback )
    {
      int textLength = _targetLabel.text.Length;
      Sequence sequence = DOTween.Sequence();
      float duration = timeUseType == TypewriteEffectTimeUseType.TotalDuration ? time : time * textLength;
      sequence.Append( DOTween.To( () => _targetLabel.maxVisibleCharacters, value => _targetLabel.maxVisibleCharacters = value, textLength, duration )
        .From( 0 )
        .SetEase( Ease.Linear ) );
      sequence.OnComplete( () =>
      {
        IsOnPlay = false;
        onCompleteCallback?.Invoke();
      } );
      return sequence;
    }

    /// <summary>
    /// Complete the current typewriter effect sequence.
    /// </summary>
    public void CompleteEffectSequence()
    {
      if ( !IsOnPlay )
      {
        return;
      }

      _currentEffectSequence?.Complete( true );
    }
  }
}