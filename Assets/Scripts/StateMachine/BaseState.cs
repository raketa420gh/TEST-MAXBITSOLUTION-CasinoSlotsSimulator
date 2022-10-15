public abstract class BaseState : IState
{
    public StateMachine StateMachine { get; set; }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Exit()
    {
            
    }
}