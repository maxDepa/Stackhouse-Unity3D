using SH.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class RigidbodyMovementStrategy : IMovementStrategy
    {
        public void Move(PlayerController player) {
            //player.MyRigidbody2D.velocity = InputManager.Instance.InputAxis * player.Speed;
        }
    }

}