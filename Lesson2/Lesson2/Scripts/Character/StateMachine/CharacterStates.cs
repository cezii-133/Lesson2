using System.Linq;
using System.Collections.Generic;

namespace Lesson2_2
{
    public class CharacterStates : IStateSwitcher
    {
        private List<IState> _states = new List<IState>();
        private IState _currentState;

        private StateMachineData _stateMachineData;

        public CharacterStates()
        {
            _stateMachineData = new StateMachineData();

            _states = new List<IState>()
        {
            new MovingToWorkState(this, _stateMachineData),
            new WorkingState(this, _stateMachineData),
            new MovingToRestState(this, _stateMachineData),
            new RestingState(this, _stateMachineData),
        };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void ChangeState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Update();
            _stateMachineData.Update();
        }
    }
}