using UnityEngine;
using System.Collections;

namespace Dress.Core
{

    public class EventTimer
    {
        private bool started;

        public delegate void EndEventHandler();
        public event EndEventHandler endEventHandler;
        private float startTime;
        private float duration;

        public void Update(float deltaTime)
        {
            if (started == false)
            {
                return;
            }

            if ((Time.time - startTime) >= duration)
            {
                if (endEventHandler != null)
                {
                    endEventHandler();
                }

                Stop();
            }
        }

        public void Start(float duration)
        {
            started = true;
            startTime = Time.time;
            this.duration = duration;
        }

        public void Stop()
        {
            started = false;
        }

}
}
