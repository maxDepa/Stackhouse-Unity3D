using UnityEngine;

namespace SH.Dto {
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DataStructures/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement Variables")]
        [SerializeField] private float movementSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private float gravity = 9.8f;

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float Gravity => gravity;
    }

}