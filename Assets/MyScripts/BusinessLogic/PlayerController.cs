using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        //Components
        [SerializeField] private Transform cam;
        [SerializeField] private Animator anim;
        [SerializeField] private new Rigidbody rigidbody;

        //Data
        [SerializeField] private float movementSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private float gravity = 9.8f;

        private Vector3 direction;
        private Vector3 rotation;

        public Vector2 MoveInput => new Vector2(
            Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        private void Update() {
            float delta = Time.deltaTime;
            UpdateMovement(delta);
            UpdateRotation(delta);
            UpdateGravity(delta);
            UpdateAnimator();
        }

        private void UpdateMovement(float delta) {
            direction = cam.forward * MoveInput.y;
            direction += cam.right * MoveInput.x;
            direction.Normalize();
            direction.y = 0;
            rigidbody.velocity = direction * movementSpeed;
        }

        private void UpdateRotation(float delta) {
            rotation = cam.forward * MoveInput.y;
            rotation += cam.right * MoveInput.x;
            rotation.Normalize();
            rotation.y = 0;

            if (rotation == Vector3.zero) {
                rotation = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(rotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, delta * rotationSpeed);
        }

        private void UpdateGravity(float delta) {
            rigidbody.AddForce(Vector3.down * gravity);
        }


        private void UpdateAnimator() {
            anim.SetFloat("Speed", MoveInput.normalized.sqrMagnitude);
        }
    }
}
