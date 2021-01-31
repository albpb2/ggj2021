using Input;
using UnityEngine;

namespace Pause
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private PausePanel _pausePanel;
    
        private InputHandler _inputHandler;
    
        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        private void Update()
        {
            if (!IsPaused() && ShouldPause())
                Pause();
        }

        private void OnEnable()
        {
            _pausePanel.OnPausePanelClosed += Unpause;
        }

        private void OnDisable()
        {
            _pausePanel.OnPausePanelClosed -= Unpause;
        }

        public bool IsPaused() => Time.timeScale <= GlobalConstants.FloatTolerance;

        private bool ShouldPause() => _inputHandler.IsPauseButtonPressed();

        private void Pause()
        {
            _pausePanel.Enable();
            Time.timeScale = 0;
        }

        private void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}