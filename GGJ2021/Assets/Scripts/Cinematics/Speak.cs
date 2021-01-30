using Cinematics;
using UnityEngine;

public class Speak : CustomYieldInstruction
{
    private DialogBox _dialogBox;
    
    public Speak(DialogBox dialogBox, DialogText dialogText)
    {
        _dialogBox = dialogBox;
        _dialogBox.StartDialog(dialogText);
    }

    public override bool keepWaiting => !_dialogBox.Finished;
}