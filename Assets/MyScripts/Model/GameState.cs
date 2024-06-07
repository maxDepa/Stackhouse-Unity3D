using UnityEngine;

namespace SH.Model
{
    [System.Serializable]
    public class GameState
    {
        [SerializeField] private Player player;
        [SerializeField] private Inventory inventory;
        [SerializeField] private int productivity;

        public Player Player => player;

        public GameState() { 
        
        }

        public GameState(Player player) {
            this.player = player;
            inventory = new Inventory();
        }

        public void AddItem(Item item) {
            inventory.Add(item);
        }

        public void RemoveItem(Item item) {
            inventory.Remove(item);
        }

        public void UpdateProductivity(int productivity)
        {
            this.productivity += productivity;
        }
    }
}
