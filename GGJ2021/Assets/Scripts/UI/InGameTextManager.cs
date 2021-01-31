using TMPro;
using UnityEngine;

public class InGameTextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void DisplayText(string text)
    {
        _text.text = text;
    }

    public void ClearText()
    {
        _text.text = null;
    }
}