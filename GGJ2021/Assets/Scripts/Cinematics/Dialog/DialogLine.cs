using System;
using Cinematics;
using UnityEngine;

[Serializable]
public class DialogLine
{
    [TextArea(1, 2)]
    public string text;

    public DialogBox dialogBox;
}