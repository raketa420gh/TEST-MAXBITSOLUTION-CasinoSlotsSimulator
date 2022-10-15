using UnityEngine;

public class ReelSlotsIdleState : ReelSlotsState
{
    private ReelSlots _reelSlots;
    private Rigidbody _rigidbody;
    
    public ReelSlotsIdleState(ReelSlots reelSlots, Rigidbody rigidbody) : base(reelSlots)
    {
        _reelSlots = reelSlots;
        _rigidbody = rigidbody;
    }

    public override void Enter()
    {
        base.Enter();

        _rigidbody.isKinematic = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        _rigidbody.rotation = 
            Quaternion.Lerp(_rigidbody.rotation, 
                _reelSlots.GetClosestEdge(), 0.25f);
    }
}