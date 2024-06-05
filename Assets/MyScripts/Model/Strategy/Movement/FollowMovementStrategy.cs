using UnityEngine;

namespace SH.Model {
    public class FollowMovementStrategy : IMovementStrategy
    {
        private Transform target, transform;
        private float speed;

        public FollowMovementStrategy(Transform transform, Transform target, float speed) {
            this.target = target;
            this.transform = transform;
            this.speed = speed;
        }

        public void Move(float delta) {
            transform.position = Vector3.Lerp(
                transform.position,
                target.position,
                delta * speed
            );
        }
    }
}
