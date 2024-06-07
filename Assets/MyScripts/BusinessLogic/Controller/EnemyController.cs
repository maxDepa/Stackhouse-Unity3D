using SH.Model;
using UnityEngine;
using UnityEngine.AI;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : EntityController
    {
        [Header("Enemy")]
        [SerializeField] private NavMeshAgent agent;
        //[SerializeField] private Transform target;
        [SerializeField] private WorkingHotspot workingHotspot;
        [SerializeField] public uint productivity = 1;


        protected override void InitializeStateMachine() {
            AddState(EntityStateIndex.Move, new EntityState_Move(this,
                new NavMeshFollowMovementStrategy(agent, workingHotspot.transform),
                new EnemyMoveAnimatorAnimationStrategy(agent, animator, "Move")));

            AddState(EntityStateIndex.Working, new EntityState_Working(this,
             new AnimatorAnimationStrategy(animator, "Working"),
             () => { EventManager.Instance.Cast(MyEventIndex.OnNpcWorking, new MyEventArgs(this)); },
             () => { EventManager.Instance.Cast(MyEventIndex.OnNpcNotWorking, new MyEventArgs(this)); }
             )
             );


            GoToMove();
        }

    }
}
