using SH.BusinessLogic;
using UnityEngine;

namespace SH.Model {
    public class PlayerRigidbodyMovementStrategy : IMovementStrategy
    {
        private Rigidbody player;
        private Transform camera;

        private float speed;

        private Vector3 direction;

        private Vector2 MoveInput => InputManager.Instance.InputAxis;

        public PlayerRigidbodyMovementStrategy(Rigidbody player, Transform camera, float speed) {
            this.player = player;
            this.camera = camera;
            this.speed = speed;
        }

        public void Move(float delta) {
            direction = camera.forward * MoveInput.y;
            direction += camera.right * MoveInput.x;
            direction.Normalize();
            direction.y = 0;
            player.velocity = direction * speed;
        }
    }

}