using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class ForwardMovementStrategy : IMovementStrategy
    {
        private Rigidbody _rigidbody;
        private float speed;

        public ForwardMovementStrategy(Rigidbody rigidbody, float speed) {
            _rigidbody = rigidbody;
            this.speed = speed;
        }

        public void Move(float delta) {
            _rigidbody.velocity = _rigidbody.transform.forward * speed;
        }
    }
}
