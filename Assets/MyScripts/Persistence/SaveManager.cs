using SH.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SH.Persistence {
    public static class SaveManager
    {
        private static string savePath  => Application.persistentDataPath + "/game.stackhouse";

        public static void Save(GameState state) {
            Debug.LogWarning("Trying to save state...");
            FileStream file = new FileStream(savePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, state);
            file.Close();
        }

        public static GameState Load() {
            Debug.LogWarning("Trying to load state...");
            FileStream file = new FileStream(savePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try {
                GameState state = (GameState)bf.Deserialize(file);
                return state;
            }
            catch (System.Exception e) {
                Debug.LogError("RILEVATI SALVATAGGI VECCHI");
                return new GameState();
            }
            finally {
                file.Close();
            }
        }
    }

}