﻿using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class ActingEnemyNode : BaseEntityNode<EnemyController, States>
    {
        public ActingEnemyNode(EnemyController owner, States state) : base(owner, state)
        {
        }

        protected override void UpdateNextState()
        {
            if (Owner.HealthController.Health <= 0)
                NextState = States.Dead;
        }

        protected override void UpdateNodeState()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Owner.MovementController.Move(Owner.MovementController.MovementSpeed);
            Owner.MovementController.Rotate(Random.Range(-1, 1));
        }
    }
}
