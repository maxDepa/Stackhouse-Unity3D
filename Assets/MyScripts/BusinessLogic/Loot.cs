using SH.Dto;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(BoxCollider))]
    public class Loot : MonoBehaviour
    {
        [SerializeField] private ItemData data;

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<PlayerController>() == null)
                return;

            EventManager.Instance.AddListener(MyEventIndex.OnInputExamine, OnExamine);
        }

        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<PlayerController>() == null)
                return;

            EventManager.Instance.RemoveListener(MyEventIndex.OnInputExamine, OnExamine);
        }

        private void OnExamine(MyEventArgs arg0) {
            EventManager.Instance.Cast(MyEventIndex.OnItemFound, new MyEventArgs(data));
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputExamine, OnExamine);
            Destroy(gameObject);
        }
    }

}