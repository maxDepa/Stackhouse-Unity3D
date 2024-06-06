using SH.Dto;
using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class Player : Entity
    {
        //Movement Variables
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float gravity;
        [SerializeField] private float rollSpeed;

        public float MovementSpeed => movementSpeed;

        public float RotationSpeed => rotationSpeed;

        public float Gravity => gravity;

        public float RollSpeed => rollSpeed;

        public Player(PlayerData data) : base(data) {
            movementSpeed = data.MovementSpeed;
            rotationSpeed = data.RotationSpeed;
            gravity = data.Gravity;
            rollSpeed = data.RollSpeed;
        }
    }

}