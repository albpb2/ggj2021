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
    [SerializeField] private DialogText _kidDialogLine1;

    private bool _isFinished;

    public override void Play()
    {
        StartCoroutine(PlayCinematic());
    }

    public override bool IsFinished() => _isFinished;

    private IEnumerator PlayCinematic()
    {
        yield return new Speak(_kidDialogBox, _kidDialogLine1);
        _isFinished = true;
    }
}
