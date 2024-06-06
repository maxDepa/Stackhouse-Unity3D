using UnityEngine;

namespace SH.Dto {
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DataStructures/Entities/PlayerData", order = 0)]
    public class PlayerData : EntityData
    {
        [Header("Player")]
        [SerializeField] private float movementSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private float gravity = 9.8f;
        [SerializeField] private float rollSpeed = 1f;

        public float MovementSpeed => movementSpeed;

        public float RotationSpeed => rotationSpeed;

        public float Gravity => gravity;

        public float RollSpeed => rollSpeed;
    }

}