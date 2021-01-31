using Input;
using UnityEngine;

namespace Player.State
{
    public class FallingPlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;

        private float _initialHeight;
        
        public FallingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.FallingStateEntered;

        public override IPlayerState Update()
        {
            if (PlayerController.IsGrounded)
            {
                PlayerController.HandleFall(_initialHeight);
                return TransitionToState(_playerStateProvider.GetLandingState());
            }
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }

        protected override void InitializeState()
        {
            _initialHeight = PlayerController.transform.position.y;
        }
    }
}