using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SH.BusinessLogic {
    public class EventManager : MonoSingleton<EventManager>
    {
        private List<MyEvent> _events = new List<MyEvent>();

        protected override void Initialize() {
            for(int i = 0; i < System.Enum.GetValues(typeof(MyEventIndex)).Length; i++) {
                _events.Add(new MyEvent());
            }
        }

        public void AddListener(MyEventIndex index, UnityAction<MyEventArgs> action) {
            _events[(int)index].AddListener(action);
        }

        public void RemoveListener(MyEventIndex index, UnityAction<MyEventArgs> action) {
            _events[(int)index].RemoveListener(action);
        }

        public void Cast(MyEventIndex index, MyEventArgs args = null) {
            _events[(int)index].Invoke(args);
        }
    }
}
