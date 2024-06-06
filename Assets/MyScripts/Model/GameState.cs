namespace SH.Model
{
    [System.Serializable]
    public class GameState
    {
        private Player player;
        //Inventory
        //Quest
        //...

        public Player Player => player;

        public GameState(Player player) {
            this.player = player;
        }
    }
}
