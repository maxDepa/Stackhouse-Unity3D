using SH.Dto;

namespace SH.Model {
    [System.Serializable]
    public abstract class Entity
    {
        private Info info;
        private StatsUpdater stats;

        public Info Info => info;
        public StatsUpdater Stats => stats;

        public Entity(EntityData data) {
            this.info = new Info(data.Info);
            this.stats = new StatsUpdater(data.Stats);
        }

        public void LevelUp() {
            stats.LevelUp();
        }

        public void Debuff(StatsUpdater stats) {
            this.stats.Debuff(stats);
        }

        public void Buff(StatsUpdater stats) {
            this.stats.Buff(stats);
        }
    }
}
