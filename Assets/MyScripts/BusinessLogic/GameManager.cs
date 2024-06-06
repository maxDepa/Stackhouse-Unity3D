using SH.Dto;
using SH.Model;
using SH.Persistence;
using UnityEngine;

namespace SH.BusinessLogic {
    public class GameManager : MonoSingleton<GameManager> {
        private GameState _state;

        public Player Player => _state.Player;

        [Header("Initialize")]
        [SerializeField] private PlayerData _playerData;

        protected override void Initialize() {
            _state = new GameState(
                new Player(_playerData)                
                );
        }

        private void SaveGame() {
            SaveManager.Save(_state);
        }

        private void LoadGame() {
            _state = SaveManager.Load();
        }
    }
}
