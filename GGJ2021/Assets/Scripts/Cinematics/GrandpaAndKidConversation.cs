using System.Collections;
using Cinematics;
using UnityEngine;

public class GrandpaAndKidConversation : Cinematic
{
    [Header("Positions")]
    [SerializeField] private Movement _childrenGettingCloseToGrandpa;

    [Header("Characters")]
    [SerializeField] private CinematicCharacter _kid;
    [SerializeField] private CinematicCharacter _grandpa;

    [Header("Dialog boxes")] 
    [SerializeField] private DialogBox _kidDialogBox;

    [Header("Dialog lines")]
    [SerializeField] private DialogText _kidDialog;

    private bool _isFinished;

    public override void Play()
    {
        StartCoroutine(PlayCinematic());
    }

    public override bool IsFinished() => _isFinished;

    private IEnumerator PlayCinematic()
    {
        yield return new MoveCharacter(_kid, _childrenGettingCloseToGrandpa);
        yield return new Speak(_kidDialogBox, _kidDialog);
        _isFinished = true;
    }
}
