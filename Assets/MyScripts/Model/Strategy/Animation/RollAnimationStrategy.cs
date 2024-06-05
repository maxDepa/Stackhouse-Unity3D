using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class RollAnimationStrategy : IAnimationStrategy
    {
        private Animator _animator;

        public RollAnimationStrategy(Animator animator) {
            _animator = animator;
        }

        public void Initialize() {
            _animator.Play("Roll");
        }

        public void Update() {
            
        }
    }
}
