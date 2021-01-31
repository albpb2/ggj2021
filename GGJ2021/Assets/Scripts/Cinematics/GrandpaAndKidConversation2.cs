using System.Collections;
using Cinematics;
using UnityEngine;

public class GrandpaAndKidConversation2 : Cinematic
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
    [SerializeField] private DialogText _grandpaDialog3;
    [SerializeField] private DialogText _kidDialog4;
    [SerializeField] private DialogText _grandpaDialog4;        
    [SerializeField] private DialogText _kidDialog5;     
    [SerializeField] private DialogText _kidDialog6;

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
        yield return new Speak(_grandpaDialogBox, _grandpaDialog3);
        yield return new Speak(_kidDialogBox, _kidDialog4);
        yield return new Speak(_grandpaDialogBox, _grandpaDialog4);
        yield return new Speak(_kidDialogBox, _kidDialog5);
        yield return new Speak(_kidDialogBox, _kidDialog6);
        _isFinished = true;
    }
}
