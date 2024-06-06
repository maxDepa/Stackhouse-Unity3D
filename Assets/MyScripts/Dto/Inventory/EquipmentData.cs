using SH.Model;
using UnityEngine;

namespace SH.Dto {
    public abstract class EquipmentData : ItemData
    {
        [Header("Equipment")]
        [SerializeField] private StatsUpdater stats;

        public StatsUpdater Stats => stats;
    }

}