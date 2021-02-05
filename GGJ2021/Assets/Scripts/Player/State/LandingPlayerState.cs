using System;
using Input;
using UnityEngine;

namespace Player.State
{
    public class LandingPlayerState : PlayerStateBase
    {
        private const float MinVelocityToRoll = .5f;
        
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
        
        public override IPlayerState Update()
        {
            if (!PlayerController.IsLanding) 
                return TransitionToState(_playerStateProvider.GetWalkingState());

            if (!HasEnoughVelocityToRoll() || ShouldShoot())
                return TransitionToState(_playerStateProvider.GetWalkingState());

            if (ShouldJump())
                return TransitionToState(_playerStateProvider.GetJumpingState());

            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            return this;
        }

        protected override void InitializeState()
        {
            if (ShouldRoll()) 
                PlayerController.StartLanding();
        }

        protected override bool ShouldPlayEnterAnimation() => ShouldRoll();
        
        private bool ShouldRoll() => HasEnoughVelocityToRoll() && !ShouldShoot() && !ShouldJump();

        private bool HasEnoughVelocityToRoll() => Math.Abs(PlayerController.Velocity.x) >= MinVelocityToRoll;
    }
}