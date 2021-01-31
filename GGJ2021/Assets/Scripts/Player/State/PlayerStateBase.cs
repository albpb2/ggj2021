using System;
using Input;
using UnityEngine;

namespace Player.State
{
    public abstract class PlayerStateBase : IPlayerState
    {
        protected readonly PlayerController PlayerController;
        protected readonly InputHandler InputHandler;

        protected abstract string AnimationTriggerName { get; }

        private bool _isShooting;
        private string _shootingAnimation;
        
        public PlayerStateBase(PlayerController playerController, InputHandler inputHandler)
        {
            PlayerController = playerController;
            InputHandler = inputHandler;
        }

        public virtual bool IsCrouched => false;

        public IPlayerState EnterState()
        {
            Debug.Log($"Entering state {this.GetType().Name}");
            if (ShouldPlayEnterAnimation())
            {
                PlayerController.PlayAnimation(AnimationTriggerName);
            }
            InitializeState();
            return this;
        }

        public abstract IPlayerState Update();

        protected virtual bool ShouldPlayEnterAnimation() => true;

        protected virtual void InitializeState()
        {
        }

        protected IPlayerState TransitionToState(IPlayerState newState)
        {
            PlayerController.StopAnimation(AnimationTriggerName);
            if (_isShooting)
                StopShooting();
            return newState.EnterState();
        }

        protected bool ShouldJump() => PlayerController.IsGrounded && InputHandler.IsJumpPressed();
        
        protected bool ShouldShoot() => InputHandler.IsFire1Pressed();
        
        protected bool ShouldStopShooting() => _isShooting && !InputHandler.IsFire1Pressed();

        protected bool IsMovingHorizontally() => InputHandler.GetHorizontalAxisValue() != 0;

        protected bool ShouldCrouch() => InputHandler.GetVerticalAxisValue() < 0;

        protected void Shoot()
        {
            var animation = IsCrouched ? PlayerAnimationTriggers.ShootCrouched : PlayerAnimationTriggers.Shoot;
            
            if (_isShooting && animation != _shootingAnimation)
            {
                PlayerController.StopAnimation(_shootingAnimation);
            }
            
            PlayerController.PlayAnimation(animation);
            _shootingAnimation = animation;
            
            _isShooting = true;
            PlayerController.Shoot();
        }
        
        protected void StopShooting()
        {
            var animation = IsCrouched ? PlayerAnimationTriggers.ShootCrouched : PlayerAnimationTriggers.Shoot;
            PlayerController.StopAnimation(animation);
            _isShooting = false;
        }
    }
}