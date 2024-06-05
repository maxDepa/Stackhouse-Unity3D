using SH.BusinessLogic;

namespace SH.Model {
    public abstract class PlayerState : State<PlayerController>
    {
        protected PlayerState(PlayerController owner) : base(owner) {

        }

        protected void GoToMove() {
            owner.GoToMove();
        }
        
        protected void GoToAttack() {
            owner.GoToAttack();
        }

        protected void GoToRoll() {
            owner.GoToRoll();
        }
    }
}
