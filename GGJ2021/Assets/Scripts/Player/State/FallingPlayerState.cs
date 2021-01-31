using Input;
using UnityEngine;

namespace Player.State
{
    public class FallingPlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;
        
        public FallingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }
        
        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.FallingStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (PlayerController.IsGrounded)
                return _playerStateProvider.GetIdleState();
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                PlayerController.Shoot();

            return this;
        }
    }
}