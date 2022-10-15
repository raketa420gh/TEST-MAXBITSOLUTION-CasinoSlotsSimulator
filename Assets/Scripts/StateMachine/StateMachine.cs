public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    private void Update()
    {
        CurrentState?.Update();
    }

    public void ChangeState(BaseState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;

        if (CurrentState == null)
            return;

        CurrentState.StateMachine = this;
        CurrentState.Enter();
    }
}