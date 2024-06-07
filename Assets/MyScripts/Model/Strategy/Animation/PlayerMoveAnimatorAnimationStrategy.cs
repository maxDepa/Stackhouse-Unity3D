using SH.BusinessLogic;
using UnityEngine;

namespace SH.Model {
    public class PlayerMoveAnimatorAnimationStrategy : AnimatorAnimationStrategy
    {
        public PlayerMoveAnimatorAnimationStrategy(Animator animator, string animationState) : base(animator, animationState) {
        }

        public override void Update() {
            _animator.SetFloat("Speed", InputManager.Instance.InputAxis.magnitude);
        }
    }

}