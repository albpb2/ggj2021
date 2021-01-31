using System.Collections;
using Cinematics;
using UnityEngine;

public class GrandpaAndKidConversation : Cinematic
{
    [Header("Characters")]
    [SerializeField] private CinematicCharacter _kid;
    [SerializeField] private CinematicCharacter _grandpa;

    [Header("Dialog boxes")] 
    [SerializeField] private DialogBox _kidDialogBox;
    [SerializeField] private DialogBox _grandpaDialogBox;

    [Header("Dialog lines")]
    [SerializeField] private DialogText _kidDialog1;
    [SerializeField] private DialogText _grandpaDialog1;
    [SerializeField] private DialogText _kidDialog2;
    [SerializeField] private DialogText _grandpaDialog2;
    [SerializeField] private DialogText _kidDialog3;  
    [SerializeField] private DialogText _kidDialog4;
    [SerializeField] private DialogText _kidDialog5;
    [SerializeField] private DialogText _grandpaDialog5;
    [SerializeField] private DialogText _kidDialog6;
    [SerializeField] private DialogText _grandpaDialog6;  
    [SerializeField] private DialogText _kidDialog7;
    [SerializeField] private DialogText _grandpaDialog7;  
    [SerializeField] private DialogText _kidDialog8;
    [SerializeField] private DialogText _grandpaDialog8; 
    [SerializeField] private DialogText _kidDialog9;
    [SerializeField] private DialogText _kidDialog10; 
    [SerializeField] private DialogText _grandpaDialog10; 
    [SerializeField] private DialogText _kidDialog11;

    private bool _isFinished;

    public override void Play()
    {
        StartCoroutine(PlayCinematic());
    }

    public override bool IsFinished() => _isFinished;

    private IEnumerator PlayCinematic()
    {
        yield return new Speak(_kidDialogBox, _kidDialog1);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog1);
        yield return new Speak(_kidDialogBox, _kidDialog2);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog2);
        yield return new Speak(_kidDialogBox, _kidDialog3);
        yield return new Speak(_kidDialogBox, _kidDialog4);
        yield return new Speak(_kidDialogBox, _kidDialog5);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog5);
        yield return new Speak(_kidDialogBox, _kidDialog6);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog6);
        yield return new Speak(_kidDialogBox, _kidDialog7);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog7);
        yield return new Speak(_kidDialogBox, _kidDialog8);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog8);
        yield return new Speak(_kidDialogBox, _kidDialog9);
        yield return new Speak(_kidDialogBox, _kidDialog10);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog10);
        yield return new Speak(_kidDialogBox, _kidDialog11);
        _isFinished = true;
    }
}
