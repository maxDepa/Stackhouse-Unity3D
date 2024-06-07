using SH.BusinessLogic;
using UnityEngine.Events;

namespace SH.Model {
    public class EntityState_Move : EntityState
    {
        private IMovementStrategy movementStrategy;
        private IRotationStrategy rotationStrategy;
        private IAnimationStrategy animationStrategy;

        private UnityAction entryAction, exitAction;

        public EntityState_Move(EntityController owner, 
            IMovementStrategy movementStrategy,
            IAnimationStrategy animationStrategy,
            IRotationStrategy rotationStrategy = null,
            UnityAction entryAction = null,
            UnityAction exitAction = null
            ) : base(owner) {
            this.movementStrategy = movementStrategy;
            this.animationStrategy = animationStrategy;
            this.rotationStrategy = rotationStrategy;
            this.entryAction = entryAction;
            this.exitAction = exitAction;
        }

        public override void Initialize() {
            entryAction?.Invoke();
            animationStrategy.Initialize();
        }

        public override void Execute(float delta) {
            movementStrategy.Move(delta);
            rotationStrategy?.Rotate(delta);
            animationStrategy.Update();
        }

        public override void LateExecute() {
            
        }

        public override void Exit() {
            exitAction?.Invoke();
        }
    }
}
