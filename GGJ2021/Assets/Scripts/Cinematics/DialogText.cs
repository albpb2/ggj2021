using System;
using UnityEngine;

namespace Cinematics
{
    [Serializable]
    public class DialogText
    {
        [TextArea(1, 2)]
        public string text;
    }
}