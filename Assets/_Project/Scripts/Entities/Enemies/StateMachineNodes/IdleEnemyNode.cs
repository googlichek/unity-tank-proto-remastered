namespace Game.Scripts
{
    public class IdleEnemyNode : BaseEntityNode<EnemyController, States>
    {
        public IdleEnemyNode(EnemyController owner, States state) : base(owner, state)
        {
        }

        protected override void UpdateNextState()
        {
            NextState = States.Acting;
        }

        protected override void UpdateNodeState()
        {
        }
    }
}
