using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnObjectPicked;

        public void PickItem()
        {
            OnObjectPicked?.Invoke();
            Destroy(gameObject);
        }
    }
}