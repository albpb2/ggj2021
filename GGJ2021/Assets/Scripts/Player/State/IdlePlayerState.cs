using Input;

namespace Player.State
{
    public class IdlePlayerState : PlayerStateBase
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        private PlayerStateProvider _playerStateProvider;
        
        public IdlePlayerState(
            PlayerController playerController, 
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider)
            : base(playerController, inputHandler)
        {
            _playerController = playerController;
            _inputHandler = inputHandler;
            _playerStateProvider = playerStateProvider;
        }

        public override IPlayerState EnterState()
        {
            _playerController.TriggerAnimation(PlayerAnimationTriggers.IdleStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (IsMovingHorizontally())
                return _playerStateProvider.GetWalkingState();

            if (ShouldJump())
            {
                _playerController.Jump();
                return this;
            }

            if (ShouldShoot())
            {
                _playerController.Shoot();
                return this;
            }

            return this;
        }
    }
}