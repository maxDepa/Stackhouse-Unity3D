using SH.Dto;
using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic {
    public class CameraController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform target;
        [SerializeField] private Transform pivot;

        [Header("Variables")]
        [SerializeField] private CameraData data;



        private IMovementStrategy movementStrategy;
        private IRotationStrategy rotationStrategy;

        private void Start() {
            movementStrategy = new FollowMovementStrategy(transform, target, data.FollowSpeed);
            rotationStrategy = new CameraRotationStrategy(transform, pivot, data);
        }

        void Update () {
            float delta = Time.deltaTime;
            movementStrategy.Move(delta);
            rotationStrategy.Rotate(delta);
        }
    }
}