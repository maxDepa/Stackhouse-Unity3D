using SH.Dto;

namespace SH.Model {
    [System.Serializable]
    public class Consumable : Item
    {
        public Consumable(ConsumableData data) : base(data) {

        }

        public void Use() { 
            //
        }
    }

}