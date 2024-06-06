using SH.Dto;

namespace SH.Model {
    [System.Serializable]
    public class Accessory : Equipment
    {
        public Accessory(AccessoryData data) : base(data) {

        }
    }

}