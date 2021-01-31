using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        public float GetHorizontalAxisValue() => UnityInput.GetAxis(InputNames.HorizontalAxis);
        public float GetVerticalAxisValue() => UnityInput.GetAxis(InputNames.VerticalAxis);
        public bool IsJumpPressed() => UnityInput.GetButtonDown(InputNames.Jump);
        public bool IsFire1Pressed() => UnityInput.GetButton(InputNames.Fire1);
        public bool IsAnyButtonPressed() => UnityInput.anyKeyDown;
        public bool IsPauseButtonPressed() => UnityInput.GetButtonDown(InputNames.Pause);
        public bool IsFire3Pressed() => UnityInput.GetButton(InputNames.Fire3);
    }
}