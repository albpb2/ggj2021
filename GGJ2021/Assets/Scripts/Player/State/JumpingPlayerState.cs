using Input;
using UnityEngine;

namespace Player.State
{
    public class JumpingPlayerState : PlayerStateBase
    {
        private readonly PlayerStateProvider _playerStateProvider;

        private float _startTime;

        public JumpingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.JumpingStateEntered;

        public override IPlayerState Update()
        {
            if (PlayerController.IsFalling)
                return TransitionToState(_playerStateProvider.GetFallingState());

            if (HasJumped() && PlayerController.IsGrounded)
                return TransitionToState(_playerStateProvider.GetIdleState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldShoot())
                Shoot();
            else if (ShouldStopShooting())
                StopShooting();

            return this;
        }

        protected override void InitializeState()
        {
            PlayerController.Jump();
            _startTime = Time.time;
        }

        private bool HasJumped()
        {
            const float minJumpLengthMs = .2f;
            return Time.time - _startTime > minJumpLengthMs;
        }
    }
}