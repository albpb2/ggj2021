using System.Collections;
using Cinematics;
using UnityEngine;

public class KidInsideBrainConversation : Cinematic
{
    [Header("Characters")]
    [SerializeField] private CinematicCharacter _kid;
    [SerializeField] private CinematicCharacter _grandpa;

    [Header("Dialog boxes")] 
    [SerializeField] private DialogBox _kidDialogBox;

    [Header("Dialog lines")]
    [SerializeField] private DialogText _kidDialog1;
    [SerializeField] private DialogText _kidDialog2;
    [SerializeField] private DialogText _kidDialog3;
    [SerializeField] private DialogText _kidDialog4;

    private bool _isFinished;

    public override void Play()
    {
        StartCoroutine(PlayCinematic());
    }

    public override bool IsFinished() => _isFinished;

    private IEnumerator PlayCinematic()
    {
        yield return new Speak(_kidDialogBox, _kidDialog1);
        yield return new Speak(_kidDialogBox, _kidDialog2);
        yield return new Speak(_kidDialogBox, _kidDialog3);
        yield return new Speak(_kidDialogBox, _kidDialog4);
        _isFinished = true;
    }
}
