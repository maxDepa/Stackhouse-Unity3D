using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    public class CameraController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform target;
        [SerializeField] private Transform pivot;
        [SerializeField] private Transform cam;

        [Header("Variables")]
        [SerializeField] private float followSpeed = 1f;

        [SerializeField] private float horizontalAngleSpeed = 1f;

        [SerializeField] private float verticalAngleSpeed = 1f;
        [SerializeField] private float verticalAngleMin = -45;
        [SerializeField] private float verticalAngleMax = 45;

        private float verticalAngle;
        private float horizontalAngle;

        void Start () {

        }

        void Update () {
            float delta = Time.deltaTime;
            FollowTarget(delta);
            HandleRotation(delta);
        }

        private void FollowTarget(float delta) {
            transform.position = Vector3.Lerp(
                transform.position,
                target.position,
                Time.deltaTime * followSpeed
                );
        }
        private void HandleRotation(float delta) {
            Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            horizontalAngle += (mouseMovement.x * horizontalAngleSpeed) / delta;
            verticalAngle -= (mouseMovement.y * verticalAngleSpeed) / delta;
            verticalAngle = Mathf.Clamp(verticalAngle, verticalAngleMin, verticalAngleMax);

            Vector3 rotation = Vector3.zero;
            rotation.y = horizontalAngle;
            transform.rotation = Quaternion.Euler(rotation);

            rotation = Vector3.zero;
            rotation.x = verticalAngle;
            pivot.localRotation = Quaternion.Euler(rotation);
        }
    }
}