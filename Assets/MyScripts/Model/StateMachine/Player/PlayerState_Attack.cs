using SH.BusinessLogic;

namespace SH.Model {
    public class PlayerState_Attack : PlayerTimedState
    {
        public PlayerState_Attack(PlayerController owner, float duration, IAnimationStrategy animationStrategy) : base(owner, duration, animationStrategy) {

        }

        public override void LateExecute() {

        }

        public override void Exit() {

        }

    }
}
