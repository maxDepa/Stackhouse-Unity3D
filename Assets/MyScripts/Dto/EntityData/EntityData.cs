using SH.Model;
using UnityEngine;

namespace SH.Dto {
    public abstract class EntityData : ScriptableObject
    {
        [Header("Entity")]
        [SerializeField] private Info info;
        [SerializeField] private StatsUpdater stats;

        public Info Info => info;
        public StatsUpdater Stats => stats;
    }
}
