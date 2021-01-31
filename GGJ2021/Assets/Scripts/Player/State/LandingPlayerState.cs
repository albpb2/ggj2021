using System;
using Input;
using UnityEngine;

namespace Player.State
{
    public class LandingPlayerState : PlayerStateBase
    {
        private const float MinVelocityToRoll = 1f;
        
        private readonly PlayerStateProvider _playerStateProvider;
        
        public LandingPlayerState(
            PlayerController playerController, 
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }

        protected override string AnimationTriggerName => PlayerAnimationTriggers.LandingStateEntered;

        private float _startTime;
        
        public override IPlayerState Update()
        {
            Debug.Log($"Horizontal velocity: {PlayerController.Velocity.x}");

            if (!HasEnoughVelocityToRoll() || ShouldShoot())
                return TransitionToState(_playerStateProvider.GetWalkingState());
            
            const float expectedDurationSeconds = .5f;
            if (Time.time - _startTime > expectedDurationSeconds)
                return TransitionToState(_playerStateProvider.GetWalkingState());
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            return this;
        }

        protected override void InitializeState()
        {
            _startTime = Time.time;
        }

        protected override bool ShouldPlayEnterAnimation() => HasEnoughVelocityToRoll() && !ShouldShoot();

        private bool HasEnoughVelocityToRoll() => Math.Abs(PlayerController.Velocity.x) >= MinVelocityToRoll;
    }
}