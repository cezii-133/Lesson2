using UnityEngine;

namespace Lesson2_2
{
    public class WorkingState : IState
    {
        private CharacterStates _characterStates;
        private StateMachineData _stateMachineData;

        public WorkingState(CharacterStates characterStates, StateMachineData stateMachineData)
        {
            _characterStates = characterStates;
            _stateMachineData = stateMachineData;
        }

        public void Enter()
        {
            _stateMachineData.Time = 2;
            Debug.LogError($"Enter " + GetType());
        }

        public void Exit()
        {
            Debug.LogError($"Exit " + GetType());
        }

        public void Update()
        {
            Debug.Log($"Working: {_stateMachineData.Time.ToString("f1")} seconds");

            if (_stateMachineData.Time >= 0)
                return;

            _characterStates.ChangeState<MovingToRestState>();
        }
    }
}