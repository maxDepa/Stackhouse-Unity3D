using System.Collections;
using UnityEngine;

namespace SH.Model {
    public abstract class State<T> : IState where T : MonoBehaviour
    {

        protected T owner;

        public State(T owner) {
            this.owner = owner;
        }

        public abstract void Initialize();
        
        public abstract void Execute(float delta);
        
        public abstract void LateExecute();

        public abstract void Exit();
    }

}