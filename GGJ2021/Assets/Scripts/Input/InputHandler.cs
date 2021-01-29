using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        public float GetHorizontalAxisValue() => UnityInput.GetAxis(InputNames.HorizontalAxis);
        public bool IsJumpPressed() => UnityInput.GetButtonDown(InputNames.Jump);
    }
}