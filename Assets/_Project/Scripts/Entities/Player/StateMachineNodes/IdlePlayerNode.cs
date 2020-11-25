namespace Game.Scripts
{
    public class IdlePlayerNode : BaseEntityNode<PlayerController, States>
    {
        public IdlePlayerNode(PlayerController owner, States state) : base(owner, state)
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
