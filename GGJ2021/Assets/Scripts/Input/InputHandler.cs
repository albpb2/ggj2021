using UnityEngine;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        public float GetHorizontalAxisValue() => UnityEngine.Input.GetAxis(InputNames.Horizontal);
        public bool IsForwardPressed() => GetHorizontalAxisValue() > 0;
        public bool BackPressed() => GetHorizontalAxisValue() < 0;
    }
}