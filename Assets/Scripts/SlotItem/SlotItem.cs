using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlotItem : MonoBehaviour, ISlotItem
{
    private Animator _animator;

    private void Awake() => 
        _animator = GetComponent<Animator>();

    public void Select() => 
        _animator.SetBool(AnimationParametersNames.Selected, true);

    public void Reset() => 
        _animator.SetBool(AnimationParametersNames.Selected, false);
}