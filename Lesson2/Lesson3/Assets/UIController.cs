using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    public event Action<MovingType> OnMovingTypeChanged;

    public MovingType movingType;

    public void SetRunningType() => OnMovingTypeChanged?.Invoke(MovingType.Running);

    public void SetFastRunningType() => OnMovingTypeChanged?.Invoke(MovingType.FastRunning);

    public void SetWalkingType() => OnMovingTypeChanged?.Invoke(MovingType.Walking);
}
public enum MovingType {
    Running,
    FastRunning,
    Walking,
}
