namespace Lesson2_2
{
    public interface IStateSwitcher
    {
        void ChangeState<T>() where T : IState;
    }
}