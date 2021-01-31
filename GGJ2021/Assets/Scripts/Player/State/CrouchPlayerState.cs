using Input;

namespace Player.State
{
    public class CrouchPlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;
        
        public CrouchPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }
        
        protected override string AnimationTriggerName => PlayerAnimationTriggers.CrouchStateEntered;

        public override bool IsCrouched => true;

        public override IPlayerState Update()
        {
            if (!ShouldCrouch())
                return TransitionToState(_playerStateProvider.GetIdleState());

            if (ShouldShoot())
            {
                Shoot();
                return this;
            }

            if (ShouldStopShooting())
                StopShooting();

            if (IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetMovingCrouchState());

            return this;
        }
    }
}