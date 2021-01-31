using Input;
using UnityEngine;

namespace Scenes
{
    public class ClickToQuitGame : MonoBehaviour
    {
        private InputHandler _inputHandler;

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        private void Update()
        {
            if (_inputHandler.IsAnyButtonPressed())
                Application.Quit();
        }
    }
}