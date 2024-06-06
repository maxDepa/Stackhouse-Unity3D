using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class Stat
    {
        [SerializeField] protected int value;

        public int Value => value;

        public Stat(Stat stat) {
            this.value = stat.value;
        }

        public Stat(int value) {
            this.value = value;
        }

        public virtual void Buff(int value) { 
            this.value += value;
        }

        public virtual void Debuff(int value) { 
            this.value -= value;
            this.value = Mathf.Max(0, this.value);
        }
    }

}