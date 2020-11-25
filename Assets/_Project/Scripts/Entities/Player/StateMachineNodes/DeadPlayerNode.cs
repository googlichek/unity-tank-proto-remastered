namespace Game.Scripts
{
    public class DeadPlayerNode : BaseEntityNode<PlayerController, States>
    {
        public DeadPlayerNode(PlayerController owner, States state) : base(owner, state)
        {
        }

        protected override void UpdateNextState()
        {
        }

        protected override void UpdateNodeState()
        {
            GameManager.Instance.SceneLoadingManager.LoadScene((int)Scenes.End);
        }
    }
}
