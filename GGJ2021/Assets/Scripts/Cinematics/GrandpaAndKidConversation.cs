using System.Collections;
using System.Collections.Generic;
using Cinematics;
using UnityEngine;

public class GrandpaAndKidConversation : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Movement _childrenGettingCloseToGrandpa;

    [Header("Characters")] 
    [SerializeField] private CinematicCharacter _kid;
    [SerializeField] private CinematicCharacter _grandpa;

    public void StartCinematic()
    {
        StartCoroutine(PlayCinematic());
    }

    private IEnumerator PlayCinematic()
    {
        yield return new MoveCharacter(_kid, _childrenGettingCloseToGrandpa);
    }
}
