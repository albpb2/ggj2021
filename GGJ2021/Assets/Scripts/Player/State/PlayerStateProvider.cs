using Input;

namespace Player.State
{
    public class PlayerStateProvider
    {
        private readonly IPlayerState _idleState;
        private readonly IPlayerState _walkingState;
        private readonly IPlayerState _crouchState;
        private readonly IPlayerState _movingCrouchState;
        private readonly IPlayerState _jumpingState;
        private readonly IPlayerState _fallingState;
        private readonly IPlayerState _landingState;

        public PlayerStateProvider(PlayerController playerController, InputHandler inputHandler)
        {
            _idleState = new IdlePlayerState(playerController, inputHandler, this);
            _walkingState = new WalkingPlayerState(playerController, inputHandler, this);
            _crouchState = new CrouchPlayerState(playerController, inputHandler, this);
            _movingCrouchState = new MovingCrouchPlayerState(playerController, inputHandler, this);
            _jumpingState = new JumpingPlayerState(playerController, inputHandler, this);
            _fallingState = new FallingPlayerState(playerController, inputHandler, this);
            _landingState = new LandingPlayerState(playerController, inputHandler, this);
        }

        public IPlayerState GetIdleState() => _idleState;
        public IPlayerState GetWalkingState() => _walkingState;
        public IPlayerState GetCrouchState() => _crouchState;
        public IPlayerState GetMovingCrouchState() => _movingCrouchState;
        public IPlayerState GetJumpingState() => _jumpingState;
        public IPlayerState GetFallingState() => _fallingState;
        public IPlayerState GetLandingState() => _landingState;
    }
}