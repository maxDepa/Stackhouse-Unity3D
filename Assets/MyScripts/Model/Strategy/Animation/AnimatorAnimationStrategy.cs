using UnityEngine;

namespace SH.Model {
    public abstract class AnimatorAnimationStrategy : IAnimationStrategy
    {
        protected Animator _animator;

        public AnimatorAnimationStrategy(Animator animator) {
            this._animator = animator;
        }

        public abstract void Update();

    }

}