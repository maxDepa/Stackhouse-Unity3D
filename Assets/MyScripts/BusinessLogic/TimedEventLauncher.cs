using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic
{
    public class TimedEventLauncher: MonoBehaviour
    {
        [SerializeField] private MyEventIndex eventIndex;
        [SerializeField] private float duration;

        private Timer timer;

        public TimedEventLauncher(float duration)
        {
            this.duration = duration;
        }

        public void Start()
        {
            this.timer = new Timer(duration);
        }

        public void Update()
        {
            if (timer.Update(duration))
            {
                EventManager.Instance.Cast(eventIndex);
                timer.Reset();
            }
        }
    }
}
