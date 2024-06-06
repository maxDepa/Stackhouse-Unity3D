using UnityEngine;
using UnityEngine.AI;

namespace SH.Model {
    public class NavMeshFollowMovementStrategy : IMovementStrategy
    {
        private NavMeshAgent agent;
        private Transform target;

        public NavMeshFollowMovementStrategy(NavMeshAgent agent, Transform target) {
            this.agent = agent;
            this.target = target;
        }

        public void Move(float delta) {
            agent.destination = target.position;
        }
    }
}
