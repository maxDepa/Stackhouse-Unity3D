using SH.BusinessLogic;

namespace SH.Model {
    public abstract class PlayerState : State<PlayerController>
    {
        protected PlayerState(PlayerController owner) : base(owner) {

        }
    }
}
