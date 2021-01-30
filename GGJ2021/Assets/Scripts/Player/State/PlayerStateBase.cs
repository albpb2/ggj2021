using Input;

namespace Player.State
{
    public abstract class PlayerStateBase : IPlayerState
    {
        protected readonly PlayerController PlayerController;
        protected readonly InputHandler InputHandler;
        
        public PlayerStateBase(PlayerController playerController, InputHandler inputHandler)
        {
            PlayerController = playerController;
            InputHandler = inputHandler;
        }

        public abstract IPlayerState EnterState();

        public abstract IPlayerState Update();

        protected bool ShouldJump() => PlayerController.IsGrounded && InputHandler.IsJumpPressed();
        
        protected bool ShouldShoot() => InputHandler.IsFire1Pressed();

        protected bool IsMovingHorizontally() => InputHandler.GetHorizontalAxisValue() != 0;

        protected bool ShouldCrouch() => InputHandler.GetVerticalAxisValue() < 0;
    }
}