using UnityEngine;

namespace Game.Scripts
{
    public class EnemyMovementController : MovementController
    {
        private PlayerController _target;

        public override void Enable()
        {
            base.Enable();

            _target = FindObjectOfType<PlayerController>();
        }

        public override void Move(float value)
        {
            if (_target == null)
                return;

            base.Move(value);
        }

        public override void Rotate(float value)
        {
            if (_target == null)
                return;

            transform.LookAt(_target.transform);
        }
    }
}
