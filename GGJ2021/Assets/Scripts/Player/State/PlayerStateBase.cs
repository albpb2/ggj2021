using Input;

namespace Player.State
{
    public abstract class PlayerStateBase : IPlayerState
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        
        public PlayerStateBase(PlayerController playerController, InputHandler inputHandler)
        {
            _playerController = playerController;
            _inputHandler = inputHandler;
        }

        public abstract IPlayerState EnterState();

        public abstract IPlayerState Update();

        protected bool ShouldJump() => _playerController.IsGrounded && _inputHandler.IsJumpPressed();
        
        protected bool ShouldShoot() => _inputHandler.IsFire1Pressed();

        protected bool IsMovingHorizontally() => _inputHandler.GetHorizontalAxisValue() != 0;
    }
}