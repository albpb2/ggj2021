using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pause
{
    public class ConfirmQuitPanel : MonoBehaviour
    {
        [SerializeField] private Button _cancelButton;

        private InputHandler _inputHandler;

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _cancelButton.onClick.AddListener(Disable);
        }

        private void Update()
        {
            if (_inputHandler.IsPauseButtonPressed())
                Disable();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_cancelButton.gameObject);
        }

        public void Disable()
        {
            _cancelButton.onClick.RemoveListener(Disable);
            gameObject.SetActive(false);
        }
    }
}