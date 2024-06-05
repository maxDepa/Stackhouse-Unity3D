using SH.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public abstract class PlayerState : State<PlayerController>
    {
        protected PlayerState(PlayerController owner) : base(owner) {

        }
    }
}
