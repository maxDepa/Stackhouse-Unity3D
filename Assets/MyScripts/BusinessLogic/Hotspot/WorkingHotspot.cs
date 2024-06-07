using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    public class WorkingHotspot : Hotspot
    {
        private void OnCollisionEnter(Collision collision)
        {
            
            if(collision.collider.name == "EnemyController")
            {
                Debug.Log("enemy collided");
            }
        }
    }
}
