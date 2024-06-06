using SH.BusinessLogic;

namespace SH.Model {
    public class PlayerState_Roll : PlayerTimedState
    {
        private IMovementStrategy _movementStrategy;

        public PlayerState_Roll(PlayerController owner, float duration, IAnimationStrategy animationStrategy, IMovementStrategy movementStrategy) : base(owner, duration, animationStrategy) {
            this._movementStrategy = movementStrategy;
        }

        public override void Execute(float delta) {
            base.Execute(delta);
            _movementStrategy.Move(delta);
        }

        public override void LateExecute() {

        }

        public override void Exit() {

        }

    }

}