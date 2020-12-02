using UnityEngine;

namespace Game.Scripts
{
    public class HealthController : TickComponent, IHealth
    {
        [Header("Health Variables")]
        [SerializeField] [Range(0, 1000)] private float _maxHealth = 150;
        [SerializeField] [Range(0, 1)] private float _armor = 0.5f;

        private float _health;

        public float MaxHealth => _maxHealth;
        public float Health => _health;

        public float Armor => _armor;

        public override void Enable()
        {
            _health = _maxHealth;
        }

        public void Damage(float value)
        {
            _health = Mathf.Clamp(_health - (1 - _armor) * value, 0, _maxHealth);
        }
    }
}
