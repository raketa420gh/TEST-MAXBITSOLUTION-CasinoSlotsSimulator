using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class VfxFinishSpin : MonoBehaviour
{
    [SerializeField] private ReelSlots _reelSlots;
    
    private ParticleSystem _particleSystem;

    private void Awake() => _particleSystem = GetComponent<ParticleSystem>();

    private void OnEnable() => _reelSlots.OnSpinFinished += OnSpinFinished;

    private void OnDisable() => _reelSlots.OnSpinFinished -= OnSpinFinished;

    private void OnSpinFinished() => _particleSystem.Play();
}