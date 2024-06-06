using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<Item> items = new List<Item>();

        public void Add(Item item) {
            foreach(Item i in items) {
                if (item.Id == i.Id) {
                    i.IncrementQuantity();
                    return;
                }
            }
            items.Add(item);
        }

        public void Remove(Item item) {
            foreach(Item i in items) {
                if(item.Id == i.Id) {
                    if (i.DecrementQuantity()) { 
                        items.Remove(i);
                    }
                    return;
                }
            }
        }
    }
}
