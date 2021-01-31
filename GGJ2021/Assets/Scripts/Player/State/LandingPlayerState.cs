using System;
using Input;
using UnityEngine;

namespace Player.State
{
    public class LandingPlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;
        
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
            const float expectedDurationSeconds = .5f;
            if (Time.time - _startTime > expectedDurationSeconds)
                return TransitionToState(_playerStateProvider.GetWalkingState());
            
            if (!IsMovingHorizontally())
                return TransitionToState(_playerStateProvider.GetIdleState());

            return this;
        }

        protected override void InitializeState()
        {
            _startTime = Time.time;
        }

        protected override bool ShouldPlayEnterAnimation() => Math.Abs(InputHandler.GetHorizontalAxisValue()) > 0.01;
    }
}