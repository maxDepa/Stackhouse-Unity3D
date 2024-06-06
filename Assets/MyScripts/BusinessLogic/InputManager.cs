using UnityEngine;
using static UnityEngine.Input;

namespace SH.BusinessLogic {
    public class InputManager : MonoSingleton<InputManager>
    {
        public Vector2 InputAxis => new Vector2(GetAxis("Horizontal"), GetAxis("Vertical"));

        public bool IsMovingAxis => InputAxis.magnitude > 0;

        private KeyCode[] arrowKeys = new KeyCode[] {
            KeyCode.RightArrow,
            KeyCode.UpArrow,
            KeyCode.LeftArrow,
            KeyCode.DownArrow
        };

        public KeyCode LastArrowUp { get; private set; }

        public KeyCode LastArrowDown { get; private set; }


        protected override void Initialize() {
            //
        }

        private void Update() {
            //foreach(KeyCode key in arrowKeys) {
            //    if(GetKeyDown(key)) {
            //        LastArrowDown = key;
            //    }
            //    else if(GetKeyUp(key)) {
            //        LastArrowUp = key;
            //    }
            //}

            if (GetMouseButton(0))
                EventManager.Instance.Cast(MyEventIndex.OnMouseLeftClick);

            if (GetKeyDown(KeyCode.LeftControl))
                EventManager.Instance.Cast(MyEventIndex.OnLeftCtrl);

            if (GetKeyDown(KeyCode.E))
                EventManager.Instance.Cast(MyEventIndex.OnInputExamine);

        }
    }
}
