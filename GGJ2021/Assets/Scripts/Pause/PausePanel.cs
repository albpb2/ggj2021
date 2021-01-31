using Input;
using UnityEngine;
using UnityEngine.UI;

namespace Pause
{
    public class PausePanel : MonoBehaviour
    {
        public delegate void PausePanelClosedEventHandler();
        public event PausePanelClosedEventHandler OnPausePanelClosed;
        
        [SerializeField] private Button _quitButton;

        private InputHandler _inputHandler;

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        private void Update()
        {
            if (_inputHandler.IsPauseButtonPressed())
                Disable();
            if (_inputHandler.IsJumpPressed())
                Quit();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
            OnPausePanelClosed?.Invoke();
        }

        private void Quit()
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}