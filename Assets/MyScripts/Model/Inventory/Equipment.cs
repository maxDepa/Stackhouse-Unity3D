using SH.Model;

namespace SH.Dto {
    public abstract class Equipment : Item
    {
        private StatsUpdater stats;

        protected Equipment(EquipmentData data) : base(data) {
            this.stats = new StatsUpdater(data.Stats);
        }

        public virtual void Equip(Entity entity) {
            entity.Buff(stats);
        }

        public virtual void Unequip(Entity entity) {
            entity.Debuff(stats);
        }
    }
}
