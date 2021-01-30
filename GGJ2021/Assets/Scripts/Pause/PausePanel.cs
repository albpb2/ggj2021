using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pause
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Button _quitButton;

        private InputHandler _inputHandler;

        private ConfirmQuitPanel _confirmQuitPanel;

        private Action _unpauseCallback;

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _confirmQuitPanel = FindObjectOfType<ConfirmQuitPanel>(true);
            
            _quitButton.onClick.AddListener(OpenConfirmQuitPanel);
        }

        private void Update()
        {
            if (_inputHandler.IsPauseButtonPressed())
                Disable();
        }

        public void Enable(Action unpauseCallback)
        {
            _unpauseCallback = unpauseCallback;
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_quitButton.gameObject);
        }

        public void Disable()
        {
            _quitButton.onClick.RemoveListener(_confirmQuitPanel.Enable);
            gameObject.SetActive(false);
            _unpauseCallback();
        }

        public void OpenConfirmQuitPanel()
        {
            _confirmQuitPanel.Enable();
        }
    }
}