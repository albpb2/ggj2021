using Cinematics;
using UnityEngine;

public class Speak : CustomYieldInstruction
{
    private DialogLine _dialogLine;
    
    public Speak(DialogLine dialogLine)
    {
        _dialogLine = dialogLine;
        _dialogLine.dialogBox.StartDialog(_dialogLine.text);
    }

    public override bool keepWaiting => !_dialogLine.dialogBox.Finished;
}