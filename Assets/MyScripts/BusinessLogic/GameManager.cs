using SH.Dto;
using SH.Model;
using SH.Persistence;
using UnityEngine;

namespace SH.BusinessLogic {
    public class GameManager : MonoSingleton<GameManager> {
        [SerializeField] private GameState _state;

        public Player Player => _state.Player;

        [Header("Initialize")]
        [SerializeField] private PlayerData _playerData;

        private void Start() {
            EventManager.Instance.AddListener(MyEventIndex.OnItemFound, OnItemFound);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.L)) {
                LoadGame();
            }
            else if (Input.GetKeyDown(KeyCode.K)) {
                SaveGame();
            }
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnItemFound, OnItemFound);
        }

        protected override void Initialize() {
            _state = new GameState(
                new Player(_playerData)                
                );
        }

        private void OnItemFound(MyEventArgs arg0) {
            ItemData data = arg0.additionalItemData;

            //Da spostare in una factory
            if (data.GetType() == typeof(WeaponData)) {
                Weapon w = new Weapon((WeaponData)data);
                EventManager.Instance.Cast(MyEventIndex.OnEquippedWeapon, new MyEventArgs(w));
                _state.AddItem(w);
            }
            else if (data.GetType() == typeof(AccessoryData)) { 
                Accessory a = new Accessory((AccessoryData)data);
                _state.AddItem(a);
            }
            else if (data.GetType() == typeof(ConsumableData)) { 
                Consumable c = new Consumable((ConsumableData)data);
                _state.AddItem(c);
            }
            else if (data.GetType() == typeof(KeyData)) {
                Key k = new Key((KeyData)data);
                _state.AddItem(k);
            }
        }

        private void SaveGame() {
            SaveManager.Save(_state);
        }

        private void LoadGame() {
            _state = SaveManager.Load();
        }

        public void UpdateProductivity(int productivity)
        {
            _state.UpdateProductivity(productivity);
        }
    }
}
