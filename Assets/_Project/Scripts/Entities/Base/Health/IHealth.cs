﻿namespace Game.Scripts
{
    public interface IHealth
    {
        int Id { get; }

        float MaxHealth { get; }
        float Health { get; }

        float Armor { get; }

        void Damage(float value);
    }
}
