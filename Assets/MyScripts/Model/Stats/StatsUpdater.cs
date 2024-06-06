using UnityEngine;

namespace SH.Model {
    [System.Serializable]
    public class StatsUpdater
    {
        [SerializeField] private FillableStat level;

        [SerializeField] private FillableStat hp;
        [SerializeField] private FillableStat mp;
        [SerializeField] private FillableStat exp;

        [SerializeField] private Stat atk;
        [SerializeField] private Stat def;

        public StatsUpdater(StatsUpdater stats) {
            this.level = new FillableStat(stats.level);
            this.hp = new FillableStat(stats.hp);
            this.mp = new FillableStat(stats.mp);
            this.exp = new FillableStat(stats.exp);
            this.atk = new Stat(stats.atk);
            this.def = new Stat(stats.def);
        }

        public void LevelUp() {
            level.Buff(1);
            
            hp.Buff(10);
            mp.Buff(5);
            exp.Buff(100);
            exp.Reset();

            atk.Buff(3);
            def.Buff(2);
        }
    }
}
