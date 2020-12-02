using UnityEngine;

namespace Game.Scripts
{
    public class BodyDamageDealer : TickComponent, IDamageDealer
    {
        [SerializeField] [Range(0, 500)] private int _damage;

        [Space]

        [SerializeField] private LayerMask _layerMask = LayerMask.GetMask();

        public int OwnerId => id;
        public int Damage => _damage;

        void OnTriggerEnter(Collider bump)
        {
            if (!_layerMask.HasLayer(bump.gameObject.layer))
                return;

            var damageReciever = bump.gameObject.GetComponent<IHealth>();
            if (damageReciever == null || damageReciever.Id == id)
                return;

            damageReciever.Damage(Damage);
        }
    }
}
