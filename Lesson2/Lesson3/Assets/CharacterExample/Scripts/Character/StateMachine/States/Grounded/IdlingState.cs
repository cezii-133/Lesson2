public class IdlingState : GroundedState
{
    private readonly RunningStateConfig _config;
    private StateMachineData _data;
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) { 
         _config = character.Config.RunningStateConfig;
        _data = data;
    }
    public override void Enter()
    {
        base.Enter();

        View.StartIdling();

        Data.Speed = 0;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        switch (_data.movingType)
        {
            case MovingType.Running:
                StateSwitcher.SwitchState<RunningState>();
                break;

            case MovingType.FastRunning:
                StateSwitcher.SwitchState<FastRunningState>();
                break;

            case MovingType.Walking:
                StateSwitcher.SwitchState<WalkingState>();
                break;
        }
    }
}
