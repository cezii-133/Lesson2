using System;

public class StateMachineData
{
    public StateMachineData(UIController uIController)
    {
        uIController.OnMovingTypeChanged += ChangeState;
    }
    public float XVelocity;
    public float YVelocity;

    public MovingType movingType;

    private float _speed;
    private float _xInput;

    public float XInput
    {
        get => _xInput;
        set
        {
            if(value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    private void ChangeState(MovingType movingType) => this.movingType = movingType;
}
