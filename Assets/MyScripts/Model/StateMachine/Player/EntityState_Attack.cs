using SH.BusinessLogic;

namespace SH.Model {
    public class EntityState_Attack : EntityTimedState
    {
        public EntityState_Attack(PlayerController owner, float duration, IAnimationStrategy animationStrategy) : base(owner, duration, animationStrategy) {

        }

        public override void LateExecute() {

        }

        public override void Exit() {

        }

    }
}
