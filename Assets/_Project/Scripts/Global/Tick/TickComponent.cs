using UnityEngine;

namespace Game.Scripts
{
    public class TickComponent : MonoBehaviour, ITickComponent
    {
        protected int id;

        public int Id => id;

        public void SetId(int tickId)
        {
            id = tickId;
        }

        public virtual void Init()
        {
        }

        public virtual void Enable()
        {
        }

        public virtual void PhysicsTick()
        {
        }

        public virtual void Tick()
        {
        }

        public virtual void CameraTick()
        {
        }

        public virtual void Disable()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
