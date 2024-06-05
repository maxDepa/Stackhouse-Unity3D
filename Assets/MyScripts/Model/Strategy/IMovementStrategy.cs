using SH.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public interface IMovementStrategy
    {
        void Move(PlayerController player);
    }
}
