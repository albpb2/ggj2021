using UnityEngine;

namespace Cinematics
{
    public class MoveCharacter : CustomYieldInstruction
    {
        private CinematicCharacter _character;
        private Movement _movement;

        public override bool keepWaiting => _character.CurrentMovement != null;

        public MoveCharacter(CinematicCharacter character, Movement movement)
        {
            _character = character;
            _movement = movement;
            _character.Move(movement);
        }
    }
}