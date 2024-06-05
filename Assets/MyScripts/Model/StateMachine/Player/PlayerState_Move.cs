using SH.BusinessLogic;

namespace SH.Model {
    public class PlayerState_Move : PlayerState
    {
        private IMovementStrategy movementStrategy;
        private IRotationStrategy rotationStrategy;
        private IAnimationStrategy animationStrategy;

        public PlayerState_Move(PlayerController owner, 
            IMovementStrategy movementStrategy, 
            IRotationStrategy rotationStrategy,
            IAnimationStrategy animationStrategy) : base(owner) {
            this.movementStrategy = movementStrategy;
            this.rotationStrategy = rotationStrategy;
            this.animationStrategy = animationStrategy;
        }

        public override void Initialize() {

        }

        public override void Execute(float delta) {
            movementStrategy.Move(delta);
            rotationStrategy.Rotate(delta);
            animationStrategy.Update();
            CheckExitConditions();
        }

        public override void LateExecute() {
            
        }

        public override void Exit() {

        }

        private void CheckExitConditions() {

        }

    }
}
