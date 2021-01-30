using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pause
{
    public class PausePanel : MonoBehaviour
    {
        public delegate void PausePanelClosedEventHandler();
        public event PausePanelClosedEventHandler OnPausePanelClosed;
        
        [SerializeField] private Button _quitButton;

        private InputHandler _inputHandler;

        private ConfirmQuitPanel _confirmQuitPanel;
        
        private bool _isConfirming;

        private void Awake()
        {
            _confirmQuitPanel = GetComponentInChildren<ConfirmQuitPanel>(true);
        }

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        private void Update()
        {
            if (!_isConfirming && _inputHandler.IsPauseButtonPressed())
                Disable();
        }

        private void OnEnable()
        {
            _quitButton.onClick.AddListener(OpenConfirmQuitPanel);
            _confirmQuitPanel.OnQuitCancelled += HandleQuitCancelled;
        }

        private void OnDisable()
        {
            _quitButton.onClick.RemoveListener(OpenConfirmQuitPanel);
            _confirmQuitPanel.OnQuitCancelled -= HandleQuitCancelled;
        }

        public void Enable()
        {
            SelectButton();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
            OnPausePanelClosed?.Invoke();
        }

        private void OpenConfirmQuitPanel()
        {
            _isConfirming = true;
            _confirmQuitPanel.Enable();
        }

        private void HandleQuitCancelled()
        {
            _isConfirming = false;
            SelectButton();
        }

        private void SelectButton()
        {
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_quitButton.gameObject);
        }
    }
}