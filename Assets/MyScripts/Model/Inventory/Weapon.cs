using SH.BusinessLogic;
using SH.Dto;
using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class Weapon : Equipment
    {
        private GameObject fbx;
        private Vector3 spawnPosition;
        private Vector3 spawnRotation;

        public Weapon(WeaponData data) : base(data) {
            this.fbx = data.Fbx;
            this.spawnPosition = data.SpawnPosition;
            this.spawnRotation = data.SpawnRotation;
        }

        public override void Equip(Entity entity) {
            base.Equip(entity);
            EventManager.Instance.Cast(MyEventIndex.OnEquippedWeapon, new MyEventArgs(this));
        }

        public override void Unequip(Entity entity) {
            base.Unequip(entity);
            EventManager.Instance.Cast(MyEventIndex.OnUnequippedWeapon);
        }

        public GameObject Instantiate(WeaponSocket socket) {
            GameObject weaponGo = GameObject.Instantiate(fbx, socket.transform);
            weaponGo.GetComponent<Collider>().isTrigger = true;
            weaponGo.transform.localPosition = spawnPosition;
            weaponGo.transform.localRotation = Quaternion.Euler(spawnRotation);
            return weaponGo;
        }
    }
}
