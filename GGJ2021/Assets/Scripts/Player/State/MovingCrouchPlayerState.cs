using Input;
using UnityEngine;

namespace Player.State
{
    public class MovingCrouchPlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;
        
        public MovingCrouchPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.MovingCrouchStateEntered;
        public override bool IsCrouched => true;

        public override IPlayerState Update()
        {
            if (!ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetWalkingState());

            if (!IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetCrouchState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }
    }
}