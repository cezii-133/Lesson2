namespace Lesson2_2
{
    public class StateMachineData
    {
        private float _timer;

        public float Time
        {
            get => _timer;
            set
            {
                _timer = value;
            }
        }

        public void Update()
        {
            _timer -= UnityEngine.Time.deltaTime; // Почему-то на Time.deltaTime с директивой UnityEngine выдает ошибку
        }
    }
}