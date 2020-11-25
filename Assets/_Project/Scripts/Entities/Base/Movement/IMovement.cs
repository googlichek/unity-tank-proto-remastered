namespace Game.Scripts
{
    public interface IMovement
    {
        float MovementSpeed { get; }
        float RotationSpeed { get; }

        void Move(float value);

        void Rotate(float value);
    }
}
