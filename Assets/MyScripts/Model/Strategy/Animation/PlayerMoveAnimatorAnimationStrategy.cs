using SH.BusinessLogic;
using UnityEngine;

namespace SH.Model {
    public class PlayerMoveAnimatorAnimationStrategy : AnimatorAnimationStrategy
    {
        public PlayerMoveAnimatorAnimationStrategy(Animator animator) : base(animator) {

        }

        public override void Update() {
            _animator.SetFloat("Speed", InputManager.Instance.InputAxis.magnitude);
        }
    }

}