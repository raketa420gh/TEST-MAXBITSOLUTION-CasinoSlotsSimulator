using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelSlotsController : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private Button _spinButton;
    [SerializeField] private List<ReelSlots> _reels = new List<ReelSlots>();
    [SerializeField] private AudioSource _audioSourceSpinning;

    private void OnEnable()
    {
        _spinButton.onClick.AddListener(OnSpinButtonClicked);
        _reels[_reels.Capacity-1].OnSpinFinished += OnLastReelSpinFinished;
    }

    private void Start()
    {
        _reels[0].Setup(_settings.SpinTimeReel1);
        _reels[1].Setup(_settings.SpinTimeReel2);
        _reels[2].Setup(_settings.SpinTimeReel3);
        _reels[3].Setup(_settings.SpinTimeReel4);
        _reels[4].Setup(_settings.SpinTimeReel5);
        
        foreach (var reel in _reels)
            reel.SetStartRandomReelEdge();
    }

    private void OnDisable()
    {
        _spinButton.onClick.RemoveListener(OnSpinButtonClicked);
        _reels[_reels.Capacity-1].OnSpinFinished += OnLastReelSpinFinished;
    }

    private void OnSpinButtonClicked() => Spin();

    private void Spin()
    {
        foreach (var reelSlots in _reels)
            reelSlots.Spin();

        _spinButton.interactable = false;
        _audioSourceSpinning.PlayOneShot(_audioSourceSpinning.clip);
    }

    private void OnLastReelSpinFinished()
    {
        _spinButton.interactable = true;
        _audioSourceSpinning.Stop();
    }
}