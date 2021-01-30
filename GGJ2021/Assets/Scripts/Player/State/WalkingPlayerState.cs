﻿using Input;
using UnityEngine;

namespace Player.State
{
    public class WalkingPlayerState : PlayerStateBase
    {
        private PlayerController _playerController;
        private InputHandler _inputHandler;
        private PlayerStateProvider _playerStateProvider;
        
        public WalkingPlayerState(
            PlayerController playerController,
            InputHandler inputHandler,
            PlayerStateProvider playerStateProvider) 
            : base(playerController, inputHandler)
        {
            _playerController = playerController;
            _inputHandler = inputHandler;
            _playerStateProvider = playerStateProvider;
        }
        
        public override IPlayerState EnterState()
        {
            _playerController.TriggerAnimation(PlayerAnimationTriggers.WalkingStateEntered);
            return this;
        }

        public override IPlayerState Update()
        {
            _playerController.SetMovement(new Vector2(_inputHandler.GetHorizontalAxisValue(), 0));

            if (ShouldJump())
                _playerController.Jump();

            if (ShouldShoot())
                _playerController.Shoot();

            if (!IsMovingHorizontally())
                return _playerStateProvider.GetIdleState();

            return this;
        }
    }
}