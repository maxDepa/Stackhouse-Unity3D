using SH.BusinessLogic;
using UnityEngine;
using UnityEngine.AI;

namespace SH.Model {
    public class EnemyMoveAnimatorAnimationStrategy : AnimatorAnimationStrategy
    {
        private NavMeshAgent _agent;

        public EnemyMoveAnimatorAnimationStrategy(NavMeshAgent agent, Animator animator) : base(animator) {
            _agent = agent;
        }

        public override void Initialize() {
            _animator.Play("Move");
        }

        public override void Update() {
            float magnitude = _agent.velocity.normalized.magnitude;
            
            _animator.SetFloat("Speed", magnitude);
        }
    }

}