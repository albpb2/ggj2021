using Input;

namespace Player.State
{
    public class CrouchPlayerState : PlayerStateBase
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        private PlayerStateProvider _playerStateProvider;
        
        public CrouchPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.CrouchStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (!ShouldCrouch())
                return _playerStateProvider.GetIdleState();

            if (IsMovingHorizontally())
                return _playerStateProvider.GetMovingCrouchState();

            if (ShouldShoot())
            {
                PlayerController.Shoot();
                return this;
            }

            return this;
        }
    }
}