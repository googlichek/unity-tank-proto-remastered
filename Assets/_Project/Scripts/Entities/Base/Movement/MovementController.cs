using UnityEngine;

namespace Game.Scripts
{
    public class MovementController : TickComponent, IMovement
    {
        [Header("Movement Variables")]
        [SerializeField] [Range(0, 100)] protected float movementSpeed = 0f;
        [SerializeField] [Range(0, 100)] protected float rotationSpeed = 0f;

        [Header("Obstacle Detection Variables")]
        [SerializeField] [Range(0, 3)] protected float castHeight = 1;
        [SerializeField] [Range(0, 10)] protected float rayDistance = 4;
        [SerializeField] [Range(0, 1)] protected float sphereRadius = 0.5f;
        [SerializeField] protected LayerMask layerMask = LayerMask.GetMask();

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;

        public virtual void Move(float value)
        {
            var offset = new Vector3(0, 0, value * movementSpeed) * Time.deltaTime;
            if (offset.IsEqual(Vector3.zero))
                return;

            if (CheckIfMovementIsPossible(value))
                transform.Translate(offset);
        }

        public virtual void Rotate(float value)
        {
            var offset = new Vector3(0f, value * rotationSpeed, 0f) * Time.deltaTime;

            if (offset.IsEqual(Vector3.zero))
                return;

            transform.Rotate(offset);
        }

        private bool CheckIfMovementIsPossible(float deltaZ)
        {
            var rayOrigin = new Vector3(transform.position.x, castHeight, transform.position.z);

            var ray = deltaZ < 0 ? new Ray(rayOrigin, -transform.forward) : new Ray(rayOrigin, transform.forward);

            var isHit = Physics.SphereCast(ray, sphereRadius, out var hitTarget, rayDistance, layerMask);
            return !isHit || !(hitTarget.distance <= rayDistance);
        }
    }
}
