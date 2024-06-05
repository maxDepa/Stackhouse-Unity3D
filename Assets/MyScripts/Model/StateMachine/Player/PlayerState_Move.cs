using SH.BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class PlayerState_Move : PlayerState
    {
        private IMovementStrategy movementStrategy;

        public PlayerState_Move(PlayerController owner, IMovementStrategy movementStrategy) : base(owner) {
            //this.movementStrategy = movementStrategy;
        }

        public override void Initialize() {
            //owner.MyPlayerAnimatorUpdater.GoToMoveBlendTree();
        }



        public override void LateExecute() {
            
        }

        public override void Exit() {

        }

        private void Move() {
            //owner.MyPlayerAnimatorUpdater.UpdateMoveAnimations();
            //movementStrategy.Move(owner);
        }

        private void CheckExitConditions() {
            //if (!InputManager.Instance.IsMovingAxis)
            //    owner.GoToIdleState();
        }

        public override void Execute(float delta) {

        }
    }
}
