using Input;

namespace Player.State
{
    public class IdlePlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;
        
        public IdlePlayerState(
            PlayerController playerController, 
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider)
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.IdleStateEntered;

        public override IPlayerState Update()
        {
            if (IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetWalkingState());

            if (ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetCrouchState());

            if (ShouldJump())
                return TransitionToState(_playerStateProvider.GetJumpingState());

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }
    }
}