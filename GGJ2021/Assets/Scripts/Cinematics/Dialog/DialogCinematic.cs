using System.Collections;
using Cinematics;
using UnityEngine;

public class DialogCinematic : Cinematic
{
    [SerializeField] private DialogLine[] _lines;

    private bool _isFinished;

    public override void Play()
    {
        StartCoroutine(PlayDialog());
    }

    public override bool IsFinished() => _isFinished;

    private IEnumerator PlayDialog()
    {
        if (_lines != null)
        {
            for (var i = 0; i < _lines.Length; i++)
            {
                yield return new Speak(_lines[i]);
            }
        }

        _isFinished = true;
    }
}