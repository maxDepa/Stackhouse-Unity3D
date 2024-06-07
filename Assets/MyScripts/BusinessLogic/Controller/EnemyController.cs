using SH.Model;
using UnityEngine;
using UnityEngine.AI;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : EntityController
    {
        [Header("Enemy")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform target;


        protected override void InitializeStateMachine() {
            AddState(EntityStateIndex.Move, new EntityState_Move(this,
                new NavMeshFollowMovementStrategy(agent, target),
                new EnemyMoveAnimatorAnimationStrategy(agent, animator)));
            GoToMove();
        }

    }
}
