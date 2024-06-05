using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class AttackAnimationStrategy : IAnimationStrategy
    {
        private Animator _animator;

        public AttackAnimationStrategy(Animator animator) {
            _animator = animator;
        }

        public void Initialize() {
            _animator.Play("Attack");
        }

        public void Update() {
            
        }
    }
}
