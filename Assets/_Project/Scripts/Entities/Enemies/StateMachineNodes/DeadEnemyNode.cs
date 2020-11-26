namespace Game.Scripts
{
    public class DeadEnemyNode : BaseEntityNode<EnemyController, States>
    {
        public DeadEnemyNode(EnemyController owner, States state) : base(owner, state)
        {
        }

        protected override void UpdateNextState()
        {
        }

        protected override void UpdateNodeState()
        {
        }
    }
}
