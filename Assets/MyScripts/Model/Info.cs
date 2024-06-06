using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class Info
    {
        [SerializeField] private string name;
        [SerializeField] private string description;

        public string Name => name;
        public string Description => description;

        public Info(string name, string description) {
            this.name = name;
            this.description = description;
        }
        
        public Info(Info info) {
            this.name = info.name;
            this.description = info.description;
        }
    }
}
