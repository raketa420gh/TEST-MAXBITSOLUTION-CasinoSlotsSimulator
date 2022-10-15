using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]

public class ReelSlots : MonoBehaviour
{
    public event Action OnSpinFinished;
    
    private float _spinningTime = 1f;
    private StateMachine _stateMachine;
    private ReelSlotsIdleState _idleState;
    private ReelSlotsSpinningState _spinningState;
    private Rigidbody _rigidbody;
    private ISlotItem[] _slotItems;
    private Vector3[] _edgesEulers = new Vector3[12];
    private Quaternion[] _edgesRotations = new Quaternion[12];
    private Quaternion _closestEdge;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _slotItems = GetComponentsInChildren<ISlotItem>();
        
        InitializeEdges();
        InitializeStates();
    }

    private void Update() => _stateMachine.CurrentState.Update();

    private void FixedUpdate() => _stateMachine.CurrentState.FixedUpdate();

    public void Setup(float spinningTime) => _spinningTime = spinningTime;

    public void Spin() => _stateMachine.ChangeState(_spinningState);

    public void Stop() => Invoke(nameof(StopSpinning), _spinningTime);

    public void ResetAllSlotItems()
    {
        foreach (var slotItem in _slotItems)
            slotItem.Reset();
    }

    public Quaternion GetClosestEdge() 
    {
        var minAngle = Mathf.Infinity;

        foreach (var edgeRotation in _edgesRotations)
        {
            var edgeAngle = Quaternion.Angle(transform.rotation, edgeRotation);
            
            if (edgeAngle <= minAngle) 
            {
                minAngle = edgeAngle;
                _closestEdge = edgeRotation;
            }
        }
        
        return _closestEdge;
    }

    public void SetIdleState() => _stateMachine.ChangeState(_idleState);

    public void SetStartRandomReelEdge() => _rigidbody.rotation = _edgesRotations[Random.Range(0, 12)];

    private void InitializeStates()
    {
        _stateMachine = new StateMachine();
        _idleState = new ReelSlotsIdleState(this, _rigidbody);
        _spinningState = new ReelSlotsSpinningState(this, _rigidbody);
        
        _stateMachine.ChangeState(_idleState);
    }

    private void InitializeEdges()
    {
        float edgeEulerX = 0;

        for (var i = 0; i < _edgesEulers.Length; i++)
        {
            _edgesEulers[i] = new Vector3(edgeEulerX, 0, 0);
            edgeEulerX += 30;
        }
        
        for (var i = 0; i < _edgesEulers.Length; i++)
            _edgesRotations[i] = Quaternion.Euler(_edgesEulers[i]);
    }

    private void StopSpinning()
    {
        if (_stateMachine.CurrentState == _spinningState)
            _stateMachine.ChangeState(_idleState);

        OnSpinFinished?.Invoke();
    }
}