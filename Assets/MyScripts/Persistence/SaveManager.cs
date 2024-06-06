using SH.Model;
using UnityEngine;

namespace SH.Persistence {
    public static class SaveManager
    {
        private static string savePath;

        public static void Save(GameState state) {
            Debug.LogWarning("Trying to save state...");
            //FileStream fs = new FileStream(savePath, FileMode.Create);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Serialize()
        }

        public static GameState Load() {
            Debug.LogWarning("Trying to load state...");
            return null;
        }
    }

}