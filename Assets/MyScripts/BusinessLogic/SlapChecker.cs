using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic
{
    public class SlapChecker : MonoBehaviour
    {
        private int removedHP = 10;

        public void Start() { }

        private void OnTriggerEnter(Collider enemy)
        {
            if (enemy.GetComponent<EnemyController>() == null)
                return;

            EventManager.Instance.Cast(MyEventIndex.OnNpcSlapped, new MyEventArgs(-10));
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<EnemyController>() == null)
                return;

            // EventManager.Instance.RemoveListener(MyEventIndex.OnInputExamine, OnNpcSlapped);
        }

        public void ActivateCollider()
        {
            this.gameObject.SetActive(true);
        }

        public void DeactivateCollider()
        {
            this.gameObject.SetActive(false);
        }
    }
}
