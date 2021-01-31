using Input;
using UnityEngine;

namespace Player.State
{
    public class JumpingPlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;

        public JumpingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }
        
        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.JumpingStateEntered);
            PlayerController.Jump();
            return this;
        }

        public override IPlayerState Update()
        {
            if (PlayerController.IsFalling)
                return _playerStateProvider.GetFallingState();
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                PlayerController.Shoot();

            return this;
        }
    }
}