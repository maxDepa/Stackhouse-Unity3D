using SH.Dto;
using UnityEngine;

namespace SH.Model
{
    [System.Serializable]
    public abstract class Item
    {
        protected Info info;
        protected Sprite sprite;
        protected int maxQuantity;
        protected float weight;
        protected int sellValue;

        public Item(ItemData data) {
            this.info = new Info(data.Info);
            this.sprite = data.Sprite;
            this.maxQuantity = data.MaxQuantity;
            this.weight = data.Weight;
            this.sellValue = data.SellValue;
        }
    }
}
