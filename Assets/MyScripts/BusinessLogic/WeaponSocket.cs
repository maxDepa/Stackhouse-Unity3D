using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic {
    public class WeaponSocket : MonoBehaviour
    {
        private GameObject currentWeapon;

        private void Start() {
            EventManager.Instance.AddListener(MyEventIndex.OnEquippedWeapon, OnEquippedWeapon);
            EventManager.Instance.AddListener(MyEventIndex.OnUnequippedWeapon, OnUnequippedWeapon);
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnEquippedWeapon, OnEquippedWeapon);
            EventManager.Instance.RemoveListener(MyEventIndex.OnUnequippedWeapon, OnUnequippedWeapon);
        }

        private void OnEquippedWeapon(MyEventArgs arg0) {
            SpawnWeapon(arg0.additionalWeapon);
        }

        private void OnUnequippedWeapon(MyEventArgs arg0) {
            DestroyWeapon();
        }

        public void SpawnWeapon(Weapon weapon) {
            DestroyWeapon();
            currentWeapon = weapon.Instantiate(this);
        }

        public void DestroyWeapon() {
            if (currentWeapon == null)
                return;
            Destroy(currentWeapon);
        }
    }
            
}
