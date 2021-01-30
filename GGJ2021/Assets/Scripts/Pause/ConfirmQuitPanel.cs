using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pause
{
    public class ConfirmQuitPanel : MonoBehaviour
    {
        public delegate void QuitCancelledEventHandler();
        public event QuitCancelledEventHandler OnQuitCancelled;
        
        [SerializeField] private Button _cancelButton;

        private void OnEnable()
        {
            _cancelButton.onClick.AddListener(Disable);
        }

        private void OnDisable()
        {
            _cancelButton.onClick.RemoveListener(Disable);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_cancelButton.gameObject);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            OnQuitCancelled?.Invoke();
        }
    }
}