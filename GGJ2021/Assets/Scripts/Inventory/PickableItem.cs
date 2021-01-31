using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnObjectPicked;
        [SerializeField] private string _itemNameForDisplayText;

        private InGameTextManager _inGameTextManager;

        private void Start()
        {
            _inGameTextManager = FindObjectOfType<InGameTextManager>();
        }

        public void PickItem()
        {
            OnObjectPicked?.Invoke();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player) && _inGameTextManager != null && !string.IsNullOrWhiteSpace(_itemNameForDisplayText))
                _inGameTextManager.DisplayText($"USA -COGER- para recoger {_itemNameForDisplayText}");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player) && _inGameTextManager != null)
                _inGameTextManager.ClearText();
        }
    }
}