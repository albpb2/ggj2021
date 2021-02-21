using FMODUnity;
using Input;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnObjectPicked;
        [SerializeField] private string _itemNameForDisplayText;
        [SerializeField] private StudioEventEmitter _onPickEventEmitter;

        private InGameTextManager _inGameTextManager;
        private InputHandler _inputHandler;

        private bool _canBePicked;

        private void Start()
        {
            _inGameTextManager = FindObjectOfType<InGameTextManager>();
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        private void Update()
        {
            if (ShouldPickItem())
                PickItem();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                _canBePicked = true;
                
                if (ShouldDisplayText())
                    _inGameTextManager.DisplayText($"Pulsa -COGER- para recoger {_itemNameForDisplayText}");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player) && _inGameTextManager != null)
                _inGameTextManager.ClearText();
        }

        public void PickItem()
        {
            PlayOnPickSound();
            
            OnObjectPicked?.Invoke();
            
            Destroy(gameObject);
        }

        private bool ShouldDisplayText() => _inGameTextManager != null && !string.IsNullOrWhiteSpace(_itemNameForDisplayText);
            

        private bool ShouldPickItem() => _canBePicked && _inputHandler.IsFire3Pressed();

        private void PlayOnPickSound()
        {
            if (_onPickEventEmitter != null)
            {
                _onPickEventEmitter.Play();
            }
        }
    }
}