using System;
using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class FillableStat : Stat {
        [SerializeField] protected int maxValue;

        public int MaxValue => maxValue;

        public FillableStat(FillableStat stat) : base(stat) {
            this.maxValue = stat.MaxValue;
        }

        public FillableStat(int value) : base(value) {
            maxValue = value;
        }

        public override void Buff(int value) {
            base.Buff(value);
            maxValue += value;
        }

        public bool Increment(int value) {
            this.value = Mathf.Clamp(this.value + value, 0, maxValue);
            return this.value == maxValue;
        }
        
        public bool Decrement(int value) {
            this.value = Mathf.Clamp(this.value - value, 0, maxValue);
            return this.value == 0;
        }

        public void Reset() {
            value = 0;
        }
    }
}

