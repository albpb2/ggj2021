using Input;
using UnityEngine;

namespace Player.State
{
    public class WalkingPlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;
        
        public WalkingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.WalkingStateEntered;

        public override IPlayerState Update()
        {
            if (PlayerController.IsFalling)
                return TransitionToState(_playerStateProvider.GetFallingState());

            if (!IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetIdleState());

            if (ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetMovingCrouchState());

            if (ShouldJump())
                return TransitionToState(_playerStateProvider.GetJumpingState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
            {
                Shoot();
                return TransitionToState(_playerStateProvider.GetIdleState());
            }

            return this;
        }
    }
}