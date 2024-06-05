namespace SH.Model {
    public class Timer
    {
        private float duration, counter;

        public Timer(float duration) {
            counter = 0;
            this.duration = duration;
        }

        public bool Update(float delta) { 
            counter += delta;
            return counter >= duration;
        }

        public void Reset() {
            counter = 0;
        }
    }
}
