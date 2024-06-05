using SH.Dto;

namespace SH.Model {
    [System.Serializable]
    public class Player
    {
        //Name
        //Description

        //Atk
        //Def
        //Speed

        //Movement Variables
        private float movementSpeed;
        private float rotationSpeed;
        private float gravity;

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float Gravity => gravity;

        public Player(PlayerData data) {
            movementSpeed = data.MovementSpeed;
            rotationSpeed = data.RotationSpeed;
            gravity = data.Gravity;
        }

        public void LevelUp() { 
            //Aggiorno statistiche
        }
    }

}