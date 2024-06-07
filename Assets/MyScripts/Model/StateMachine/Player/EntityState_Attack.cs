using SH.BusinessLogic;
using UnityEngine;

namespace SH.Model
{
    public class EntityState_Attack : EntityTimedState
    {
        private GameObject slapChecker;

        public EntityState_Attack(
            PlayerController owner,
            float duration,
            IAnimationStrategy animationStrategy,
            GameObject slap
        ) : base(owner, duration, animationStrategy)
        {  
            this.slapChecker = slap;
        }

        public override void Initialize()
        {
            base.Initialize();
            slapChecker.gameObject.SetActive(true);
        }

        public override void LateExecute() { }

        public override void Exit()
        {
            slapChecker.gameObject.SetActive(false);
        }
    }
}
