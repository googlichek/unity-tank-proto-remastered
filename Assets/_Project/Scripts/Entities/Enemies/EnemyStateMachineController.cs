namespace Game.Scripts
{
    public class EnemyStateMachineController : BaseStateMachineController<EnemyController, States>
    {
        public override void Init()
        {
            base.Init();

            CreateNode<IdleEnemyNode>(States.Idle);
            CreateNode<ActingEnemyNode>(States.Acting);
            CreateNode<DeadEnemyNode>(States.Dead);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = States.Idle;
            base.ResetState();
        }
    }
}
