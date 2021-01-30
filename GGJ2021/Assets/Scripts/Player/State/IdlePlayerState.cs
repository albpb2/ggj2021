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

        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.IdleStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (IsMovingHorizontally())
                return _playerStateProvider.GetWalkingState();

            if (ShouldCrouch())
                return _playerStateProvider.GetCrouchState();

            if (ShouldJump())
            {
                PlayerController.Jump();
                return this;
            }

            if (ShouldShoot())
            {
                PlayerController.Shoot();
                return this;
            }

            return this;
        }
    }
}