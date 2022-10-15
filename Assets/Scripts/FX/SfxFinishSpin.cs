using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SfxFinishSpin : MonoBehaviour
{
    [SerializeField] private ReelSlots _reelSlots;
    [SerializeField] private AudioClip _audioClip;
    
    private AudioSource _audioSource;
    
    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable() => _reelSlots.OnSpinFinished += OnSpinFinished;
    
    private void OnDisable() => _reelSlots.OnSpinFinished -= OnSpinFinished;

    private void OnSpinFinished() => _audioSource.PlayOneShot(_audioClip);
}