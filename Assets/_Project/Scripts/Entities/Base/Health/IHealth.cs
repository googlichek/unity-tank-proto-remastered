namespace Game.Scripts
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float Health { get; }

        float Armor { get; }

        void Damage(float value);
    }
}
