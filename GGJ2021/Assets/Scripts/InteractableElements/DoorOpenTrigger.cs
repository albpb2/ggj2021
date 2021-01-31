using InteractableElements;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private DoorCardSystem _doorCardSystem;

    private void Start()
    {
        _doorCardSystem = FindObjectOfType<DoorCardSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Player) && _doorCardSystem.TrySpendDoorCard())
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        _door.Open();
    }
}