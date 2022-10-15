public interface IState
{
    StateMachine StateMachine { get; set; }
    void Enter();
    void Update();
    void FixedUpdate();
    void Exit();
}