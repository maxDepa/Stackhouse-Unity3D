using UnityEngine;

namespace SH.Model {
    public class AnimatorAnimationStrategy : IAnimationStrategy
    {
        protected Animator _animator;
        protected string _animationState;
           
        public AnimatorAnimationStrategy(Animator animator, string animationState) {
            this._animator = animator;
            this._animationState = animationState;
        }

        public virtual void Initialize()
        {
            _animator.Play(_animationState);
        }

        public virtual void Update()
        {

        }

    }

}