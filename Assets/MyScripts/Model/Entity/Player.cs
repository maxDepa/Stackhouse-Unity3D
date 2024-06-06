using SH.Dto;

namespace SH.Model {
    [System.Serializable]
    public class Player : Entity
    {
        //Movement Variables
        private float movementSpeed;
        private float rotationSpeed;
        private float gravity;
        private float rollSpeed;

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