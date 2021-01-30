﻿using Input;
using UnityEngine;

namespace Player.State
{
    public class WalkingPlayerState : PlayerStateBase
    {
        private PlayerStateProvider _playerStateProvider;
        
        public WalkingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerStateProvider = playerStateProvider;
        }
        
        public override IPlayerState EnterState()
        {
            PlayerController.TriggerAnimation(PlayerAnimationTriggers.WalkingStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            if (!IsMovingHorizontally())
                return _playerStateProvider.GetIdleState();

            if (ShouldCrouch())
                return _playerStateProvider.GetMovingCrouchState();
            
            PlayerController.SetMovement(new Vector2(InputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldJump())
                PlayerController.Jump();

            if (ShouldShoot())
                PlayerController.Shoot();

            return this;
        }
    }
}