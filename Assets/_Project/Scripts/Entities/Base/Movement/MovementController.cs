using UnityEngine;

namespace Game.Scripts
{
    public class MovementController : TickComponent, IMovement
    {
        [Header("Movement Variables")]
        [SerializeField] [Range(0, 100)] private float _movementSpeed = 0f;
        [SerializeField] [Range(0, 100)] private float _rotationSpeed = 0f;

        [Header("Obstacle Detection Variables")]
        [SerializeField] [Range(0, 3)] private float _castHeight = 1;
        [SerializeField] [Range(0, 10)] private float _rayDistance = 4;
        [SerializeField] [Range(0, 1)] private float _sphereRadius = 0.5f;
        [SerializeField] private LayerMask _layerMask = LayerMask.GetMask();

        public float MovementSpeed => _movementSpeed;
        public float RotationSpeed => _rotationSpeed;

        public void Move(float value)
        {
            var offset = new Vector3(0, 0, value * _movementSpeed) * Time.deltaTime;
            if (offset.IsEqual(Vector3.zero))
                return;

            if (CheckIfMovementIsPossible(value))
                transform.Translate(offset);
        }

        public void Rotate(float value)
        {
            var offset = new Vector3(0f, value * _rotationSpeed, 0f) * Time.deltaTime;

            if (offset.IsEqual(Vector3.zero))
                return;

            transform.Rotate(offset);
        }

        private bool CheckIfMovementIsPossible(float deltaZ)
        {
            var rayOrigin = new Vector3(transform.position.x, _castHeight, transform.position.z);

            var ray = deltaZ < 0 ? new Ray(rayOrigin, -transform.forward) : new Ray(rayOrigin, transform.forward);

            var isHit = Physics.SphereCast(ray, _sphereRadius, out var hitTarget, _rayDistance, _layerMask);
            return !isHit || !(hitTarget.distance <= _rayDistance);
        }
    }
}
