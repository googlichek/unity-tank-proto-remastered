using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    /// <summary>
    /// Entry point for any updatable mono behaviour.
    /// Main component of the game object should be inherited from this.
    /// </summary>
    public class TickBehaviour : MonoBehaviour, ITick
    {
        protected readonly List<ITickComponent> Components = new List<ITickComponent>();

        protected TickPriority priority = TickPriority.Normal;

        protected int id;

        public TickPriority Priority => priority;

        public int Id => id;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            if (GameManager.CantBeActive)
                return;

            if (GameManager.Instance.CheckIfAttached(this))
                Enable();
        }

        private void OnDisable()
        {
            if (GameManager.CantBeActive)
                return;

            if (GameManager.Instance.CheckIfDetached(this))
                Disable();
        }

        private void OnDestroy()
        {
            Dispose();
        }

        public void SetId(int tickId)
        {
            id = tickId;

            for (var i = 0; i < Components.Count; i++)
                Components[i].SetId(id);
        }

        public virtual void Init()
        {
        }

        public virtual void Enable()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].Enable();
        }

        public virtual void PhysicsTick()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].PhysicsTick();
        }

        public virtual void Tick()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].Tick();
        }

        public virtual void CameraTick()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].CameraTick();
        }

        public virtual void Disable()
        {
            for (var i = 0; i < Components.Count; i++)
                Components[i].Disable();
        }

        public virtual void Dispose()
        {
        }

        /// <summary>
        /// Adds <see cref="ITickComponent"/> to the list of updating components.
        /// </summary>
        /// <param name="component"></param>
        protected void AttachComponent(ITickComponent component)
        {
            if (Components.Contains(component))
                return;

            Components.Add(component);
            component.Init();
        }

        /// <summary>
        /// Removes <see cref="ITickComponent"/> from the list of updating components.
        /// </summary>
        protected void DetachComponent(ITickComponent component)
        {
            if (!Components.Contains(component))
                return;

            component.Dispose();
            Components.Remove(component);
        }
    }
}