using UnityEngine;

namespace SH.Dto {
    [CreateAssetMenu(fileName = "WeaponData", menuName = "DataStructures/Items/WeaponData", order = 2)]
    public class WeaponData : EquipmentData
    {
        [Header("Weapon")]
        [SerializeField] private GameObject fbx;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private Vector3 spawnRotation;

        public GameObject Fbx => fbx;
        public Vector3 SpawnPosition => spawnPosition;
        public Vector3 SpawnRotation => spawnRotation;
    }
}
