using UnityEngine;

namespace Game.Scripts
{
    public class MovementController : TickComponent, IMovement
    {
        [Header("Movement Variables")]

        [SerializeField] [Range(0, 100)] private float _movementSpeed = 0f;
        [SerializeField] [Range(0, 100)] private float _rotationSpeed = 0f;

        public float MovementSpeed => _movementSpeed;
        public float RotationSpeed => _rotationSpeed;

        public void Move(float value)
        {
            var offset = new Vector3(0, 0, value * _movementSpeed) * Time.deltaTime;
            if (offset.IsEqual(Vector3.zero))
                return;

            transform.Translate(offset);
        }

        public void Rotate(float value)
        {
            var offset = new Vector3(0f, value * _rotationSpeed, 0f) * Time.deltaTime;

            if (offset.IsEqual(Vector3.zero))
                return;

            transform.Rotate(offset);
        }
    }
}
