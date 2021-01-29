using Input;
using UnityEngine;

namespace Player.State
{
    public class WalkingPlayerState : IPlayerState
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        
        public WalkingPlayerState(PlayerController playerController, InputHandler inputHandler)
        {
            _playerController = playerController;
            _inputHandler = inputHandler;
        }
        
        public IPlayerState EnterState()
        {
            return this;
        }

        public IPlayerState Update()
        {
            _playerController.SetMovement(new Vector2(_inputHandler.GetHorizontalAxisValue(), 0));
            return this;
        }
    }
}