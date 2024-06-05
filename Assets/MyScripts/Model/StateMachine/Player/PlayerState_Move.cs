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
            EventManager.Instance.AddListener(MyEventIndex.OnMouseLeftClick, OnMouseLeftClick);
            EventManager.Instance.AddListener(MyEventIndex.OnLeftCtrl, OnLeftCtrl);
            animationStrategy.Initialize();
        }

        public override void Execute(float delta) {
            movementStrategy.Move(delta);
            rotationStrategy.Rotate(delta);
            animationStrategy.Update();
        }

        public override void LateExecute() {
            
        }

        public override void Exit() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnMouseLeftClick, OnMouseLeftClick);
            EventManager.Instance.AddListener(MyEventIndex.OnLeftCtrl, OnLeftCtrl);
        }

        private void OnMouseLeftClick(MyEventArgs arg0) {
            GoToAttack();
        }

        private void OnLeftCtrl(MyEventArgs arg0) {
            GoToRoll();
        }
    }
}
