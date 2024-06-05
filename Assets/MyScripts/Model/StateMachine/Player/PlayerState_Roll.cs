using SH.BusinessLogic;

namespace SH.Model {
    public class PlayerState_Roll : PlayerTimedState
    {
        public PlayerState_Roll(PlayerController owner, float duration, IAnimationStrategy animationStrategy) : base(owner, duration, animationStrategy) {

        }

        public override void LateExecute() {

        }

        public override void Exit() {

        }

    }

}