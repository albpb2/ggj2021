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

        protected override string AnimationTriggerName => PlayerAnimationTriggers.JumpingStateEntered;

        public override IPlayerState Update()
        {
            if (PlayerController.IsFalling)
                return TransitionToState(_playerStateProvider.GetFallingState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }

        protected override void InitializeState()
        {
            PlayerController.Jump();
        }
    }
}