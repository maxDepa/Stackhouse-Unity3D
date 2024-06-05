using UnityEngine;

namespace SH.Data {
    [CreateAssetMenu(fileName = "CameraData", menuName = "DataStructures/CameraData", order = 1)]
    public class CameraData : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float followSpeed = 1f;

        [Header("Rotation")]
        [SerializeField] private float horizontalAngleSpeed = 1f;
        [SerializeField] private float verticalAngleSpeed = 1f;
        [SerializeField] private float verticalAngleMin = -45;
        [SerializeField] private float verticalAngleMax = 45;

        public float FollowSpeed => followSpeed;
        public float HorizontalAngleSpeed => horizontalAngleSpeed;
        public float VerticalAngleSpeed => verticalAngleSpeed;
        public float VerticalAngleMin => verticalAngleMin;
        public float VerticalAngleMax => verticalAngleMax;
    }
}
