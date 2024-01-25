public class FallingState : AirbornState
{
    private readonly GroundChecker _groundChecker;
    private StateMachineData _data;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) { 
         _groundChecker = character.GroundChecker;
        _data = data;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
            else
            {
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
    }
}
