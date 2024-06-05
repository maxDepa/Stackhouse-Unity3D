using SH.BusinessLogic;
using UnityEngine;

namespace SH.Model {
    public class PlayerTransformRotationStrategy : IRotationStrategy
    {
        private Vector3 rotation;
        private Transform camera;
        private Transform player;
        private float speed;

        private Vector2 MoveInput => InputManager.Instance.InputAxis;

        public PlayerTransformRotationStrategy(Transform player, Transform camera, float speed) {
            this.player = player;
            this.camera = camera;
            this.speed = speed;
        }

        public void Rotate(float delta) {
            rotation = camera.forward * MoveInput.y;
            rotation += camera.right * MoveInput.x;
            rotation.Normalize();
            rotation.y = 0;

            if (rotation == Vector3.zero) {
                rotation = player.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(rotation);
            player.rotation = Quaternion.Lerp(player.rotation, targetRotation, delta * speed);

        }
    }
}
