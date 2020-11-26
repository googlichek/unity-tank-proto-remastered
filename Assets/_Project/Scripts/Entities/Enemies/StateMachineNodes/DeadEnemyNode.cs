namespace Game.Scripts
{
    public class DeadEnemyNode : BaseEntityNode<EnemyController, States>
    {
        public DeadEnemyNode(EnemyController owner, States state) : base(owner, state)
        {
        }

        public override void Enter(States from)
        {
            base.Enter(from);

            GameManager.Instance.ScoreManager.ScorePoints(Owner.ScorePoints);
            Owner.AudioSource.Play();
        }

        protected override void UpdateNextState()
        {
        }

        protected override void UpdateNodeState()
        {
        }
    }
}
