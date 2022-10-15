using UnityEngine;

public class ReelSlotsSpinningState : ReelSlotsState
{
    private ReelSlots _reelSlots;
    private Rigidbody _rigidbody;
    private Vector3 _torque;
    
    public ReelSlotsSpinningState(ReelSlots reelSlots, Rigidbody rigidbody) : base(reelSlots)
    {
        _reelSlots = reelSlots;
        _rigidbody = rigidbody;
    }

    public override void Enter()
    {
        base.Enter();

        var randomTorque = Random.Range(-30000, -300);
        var randomAngularDrag = Random.Range(0.1f, 0.3f);
        
        _torque = new Vector3(randomTorque, 0, 0);

        _rigidbody.isKinematic = false;
        _rigidbody.angularDrag = randomAngularDrag;
        _rigidbody.AddRelativeTorque(_torque, ForceMode.Impulse);
        
        _reelSlots.ResetAllSlotItems();
        _reelSlots.Stop();
    }
}