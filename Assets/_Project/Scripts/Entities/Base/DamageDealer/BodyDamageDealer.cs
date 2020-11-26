using UnityEngine;

namespace Game.Scripts
{
    public class BodyDamageDealer : TickComponent, IDamageDealer
    {
        [SerializeField] [Range(0, 500)] private int _damage;

        public int OwnerId => id;
        public int Damage => _damage;
    }
}
