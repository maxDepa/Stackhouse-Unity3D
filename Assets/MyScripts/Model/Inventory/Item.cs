using SH.Dto;
using UnityEngine;

namespace SH.Model
{
    [System.Serializable]
    public abstract class Item
    {
        protected string id;
        protected Info info;
        protected Sprite sprite;
        protected int maxQuantity;
        protected float weight;
        protected int sellValue;
        protected int quantity = 1;

        public string Id => id;

        public Item(ItemData data) {
            this.id = data.Id;
            this.info = new Info(data.Info);
            this.sprite = data.Sprite;
            this.maxQuantity = data.MaxQuantity;
            this.weight = data.Weight;
            this.sellValue = data.SellValue;
        }

        public void IncrementQuantity(int value = 1) {
            if (quantity >= maxQuantity)
                return;
            quantity = Mathf.Min(quantity + value, maxQuantity);
        }

        public bool DecrementQuantity(int value = 1) { 
            quantity = Mathf.Max(0, quantity - value);
            return quantity == 0;
        }
    }
}
