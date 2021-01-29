using Input;

namespace Player.State
{
    public class PlayerStateProvider
    {
        private readonly IPlayerState _walkingPlayerState;

        public PlayerStateProvider(PlayerController playerController, InputHandler inputHandler)
        {
            _walkingPlayerState = new WalkingPlayerState(playerController, inputHandler);
        }

        public IPlayerState GetWalkingState() => _walkingPlayerState.EnterState();
    }
}