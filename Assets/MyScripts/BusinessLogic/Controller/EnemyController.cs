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
            //stateMachine.AddState(Model.PlayerStateIndex.Move, );
        }

        //DEBUG!!! Va spostata dentro uno stato move
        IMovementStrategy strategy;

        protected override void Start() {
            base.Start();
            strategy = new NavMeshFollowMovementStrategy(agent, target);
        }

        protected override void Update() {
            //base.Update();
            strategy.Move(Time.deltaTime);
        }
    }
}
