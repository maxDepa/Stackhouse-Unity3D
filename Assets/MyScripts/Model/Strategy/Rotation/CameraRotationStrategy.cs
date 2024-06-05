using SH.Data;
using UnityEngine;

namespace SH.Model {
    public class CameraRotationStrategy : IRotationStrategy
    {
        private Vector2 mouseMovement => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        private Transform horizontal, vertical;
        private CameraData data;

        private float verticalAngle;
        
        private float horizontalAngle;

        public CameraRotationStrategy(Transform horizontal, Transform vertical, CameraData data) {
            this.horizontal = horizontal;
            this.vertical = vertical;
            this.data = data;
        }
        
        public void Rotate(float delta) {

            horizontalAngle += (mouseMovement.x * data.HorizontalAngleSpeed) / delta;
            verticalAngle -= (mouseMovement.y * data.VerticalAngleSpeed) / delta;
            verticalAngle = Mathf.Clamp(verticalAngle, data.VerticalAngleMin, data.VerticalAngleMax);

            Vector3 rotation = Vector3.zero;
            rotation.y = horizontalAngle;
            horizontal.rotation = Quaternion.Euler(rotation);

            rotation = Vector3.zero;
            rotation.x = verticalAngle;
            vertical.localRotation = Quaternion.Euler(rotation);
        }
    }
}