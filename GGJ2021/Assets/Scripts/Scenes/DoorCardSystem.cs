using UnityEngine;

public class DoorCardSystem: MonoBehaviour
{
    private int _pickedCardsCount;

    public void PickCard() => _pickedCardsCount++;
    
    public bool TrySpendDoorCard()
    {
        if (_pickedCardsCount > 0)
        {
            _pickedCardsCount--;
            Debug.Log("Can spend card");
            return true;
        }

        Debug.Log("Cannot spend card");
        return false;
    }
}