using SH.BusinessLogic;
using UnityEngine.Events;

namespace SH.Model {
    public class EntityState_Working : EntityState
    {
        private IAnimationStrategy animationStrategy;

        private UnityAction entryAction, exitAction;

        public EntityState_Working(EntityController owner, 
            IAnimationStrategy animationStrategy,
            UnityAction entryAction = null,
            UnityAction exitAction = null
            ) : base(owner) {
            this.animationStrategy = animationStrategy;
            this.entryAction = entryAction;
            this.exitAction = exitAction;
        }

        public override void Initialize() {
            entryAction?.Invoke();
            animationStrategy.Initialize();
        }

        public override void Execute(float delta) {
            animationStrategy.Update();
        }

        public override void LateExecute() {
            
        }

        public override void Exit() {
            exitAction?.Invoke();
        }
    }
}
