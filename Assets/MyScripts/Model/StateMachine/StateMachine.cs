using System.Collections.Generic;

namespace SH.Model
{
    public class StateMachine<T> where T : System.Enum
    {
        private Dictionary<T, IState> states = new Dictionary<T, IState>();
        private IState currentState;

        private T currentStateKey;
        public T CurrentStateKey => currentStateKey;

        public StateMachine() { 

        }

        public void AddState(T key, IState state) {
            states.Add(key, state);
        }

        public void Execute(float delta) {
            currentState?.Execute(delta);
        }

        public void LateExecute() {
            currentState?.LateExecute();
        }

        public void ChangeState(T key) {
            currentState?.Exit();
            currentState = states[key];
            currentState.Initialize();
            currentStateKey = key;
        }
    }
}
