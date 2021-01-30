using Input;

namespace Player.State
{
    public class PlayerStateProvider
    {
        private readonly IPlayerState _idleState;
        private readonly IPlayerState _walkingState;
        private readonly IPlayerState _crouchState;
        private readonly IPlayerState _movingCrouchState;

        public PlayerStateProvider(PlayerController playerController, InputHandler inputHandler)
        {
            _idleState = new IdlePlayerState(playerController, inputHandler, this);
            _walkingState = new WalkingPlayerState(playerController, inputHandler, this);
            _crouchState = new CrouchPlayerState(playerController, inputHandler, this);
            _movingCrouchState = new MovingCrouchPlayerState(playerController, inputHandler, this);
        }

        public IPlayerState GetIdleState() => _idleState.EnterState();
        public IPlayerState GetWalkingState() => _walkingState.EnterState();
        public IPlayerState GetCrouchState() => _crouchState.EnterState();
        public IPlayerState GetMovingCrouchState() => _movingCrouchState.EnterState();
    }
}