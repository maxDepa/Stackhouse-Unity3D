using UnityEngine;

namespace SH.BusinessLogic {
    public class MyEventArgs
    {
        public string additionalString;
        public int additionalInt;
        public Vector2Int additionalVector2;
        //...

        public MyEventArgs(int additionalInt) { 
            this.additionalInt = additionalInt;
        }

        public MyEventArgs(Vector2Int additionalVector2) {
            this.additionalVector2 = additionalVector2;
        }

    }
}
