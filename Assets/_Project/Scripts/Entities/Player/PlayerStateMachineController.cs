namespace Game.Scripts
{
    public class PlayerStateMachineController : BaseStateMachineController<PlayerController, States>
    {
        public override void Init()
        {
            base.Init();

            CreateNode<IdlePlayerNode>(States.Idle);
            CreateNode<ActingPlayerNode>(States.Acting);
            CreateNode<DeadPlayerNode>(States.Dead);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = States.Idle;
            base.ResetState();
        }
    }
}
