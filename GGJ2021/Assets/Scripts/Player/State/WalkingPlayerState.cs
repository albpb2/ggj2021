using Input;
using UnityEngine;

namespace Player.State
{
    public class WalkingPlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;
        
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
            if (!IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetIdleState());

            if (ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetMovingCrouchState());

            if (ShouldJump())
                return TransitionToState(_playerStateProvider.GetJumpingState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }
    }
}