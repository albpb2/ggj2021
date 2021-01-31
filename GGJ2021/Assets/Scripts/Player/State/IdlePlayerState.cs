using Input;

namespace Player.State
{
    public class IdlePlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;
        
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
            if (ShouldJump())
                return TransitionToState(_playerStateProvider.GetJumpingState());

            if (ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetCrouchState());
            
            if (ShouldShoot())
            {
                Shoot();
                return this;
            }
            
            if (ShouldStopShooting())
                StopShooting();

            if (IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetWalkingState());

            return this;
        }
    }
}