using SH.BusinessLogic;

namespace SH.Model {
    public abstract class EntityState : State<EntityController>
    {
        protected EntityState(EntityController owner) : base(owner) {

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
