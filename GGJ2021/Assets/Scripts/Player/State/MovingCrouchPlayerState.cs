using Input;
using UnityEngine;

namespace Player.State
{
    public class MovingCrouchPlayerState : PlayerStateBase
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        private PlayerStateProvider _playerStateProvider;
        
        public MovingCrouchPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.MovingCrouchStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (!ShouldCrouch())
                return _playerStateProvider.GetWalkingState();

            if (!IsMovingHorizontally())
                return _playerStateProvider.GetCrouchState();
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                PlayerController.Shoot();

            return this;
        }
    }
}