using Input;

namespace Player.State
{
    public class PlayerStateProvider
    {
        private readonly IPlayerState _idlePlayerState;
        private readonly IPlayerState _walkingPlayerState;

        public PlayerStateProvider(PlayerController playerController, InputHandler inputHandler)
        {
            _idlePlayerState = new IdlePlayerState(playerController, inputHandler, this);
            _walkingPlayerState = new WalkingPlayerState(playerController, inputHandler, this);
        }

        public IPlayerState GetIdleState() => _idlePlayerState.EnterState();
        public IPlayerState GetWalkingState() => _walkingPlayerState.EnterState();
    }
}