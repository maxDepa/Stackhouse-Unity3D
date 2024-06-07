using SH.BusinessLogic;

namespace SH.Model {
    public abstract class EntityTimedState : EntityState
    {
        private Timer timer;
        private IAnimationStrategy animationStrategy;

        protected EntityTimedState(PlayerController owner, float duration, IAnimationStrategy animationStrategy) : base(owner) {
            timer = new Timer(duration);
            this.animationStrategy = animationStrategy;
        }


        public override void Initialize() {
            timer.Reset();
            animationStrategy.Initialize();
        }

        public override void Execute(float delta) {
            if(timer.Update(delta)) {
                GoToMove();
            }
            animationStrategy.Update();
        }
    }
}
