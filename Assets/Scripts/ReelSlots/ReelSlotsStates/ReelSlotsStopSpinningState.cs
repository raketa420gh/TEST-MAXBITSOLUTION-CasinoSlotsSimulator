using UnityEngine;

public class ReelSlotsStopSpinningState : ReelSlotsState
{
    private ReelSlots _reelSlots;
    private Rigidbody _rigidbody;
    
    public ReelSlotsStopSpinningState(ReelSlots reelSlots, Rigidbody rigidbody) : base(reelSlots)
    {
        _reelSlots = reelSlots;
        _rigidbody = rigidbody;
    }

    public override void Enter()
    {
        base.Enter();
        
        _reelSlots.SetIdleState();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        //if (_rigidbody.rotation == _reelSlots.GetClosestEdge())
            //_reelSlots.SetIdleState();
    }
}