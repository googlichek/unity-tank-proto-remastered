namespace Game.Scripts
{
    public class ActingPlayerNode : BaseEntityNode<PlayerController, States>
    {
        public ActingPlayerNode(PlayerController owner, States state) : base(owner, state)
        {
        }

        protected override void UpdateNextState()
        {
        }

        protected override void UpdateNodeState()
        {
            Owner.MovementController.Move(GameManager.Instance.InputWrapper.Vertical);
            Owner.MovementController.Rotate(GameManager.Instance.InputWrapper.Horizontal);
        }
    }
}
