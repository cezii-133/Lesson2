using UnityEngine;

namespace Lesson2_2
{
    public class Character : MonoBehaviour
    {
        private CharacterStates _characterStates;

        private void Awake() => _characterStates = new CharacterStates();

        private void Update() => _characterStates.Update();
    }
}