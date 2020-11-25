namespace Game.Scripts
{
    public class PlayerController : TickBehaviour
    {
        private PlayerStateMachineController _stateMachineController;
        private MovementController _movementController;
        private HealthController _healthController;

        public PlayerStateMachineController StateMachineController => _stateMachineController;
        public MovementController MovementController => _movementController;
        public HealthController HealthController => _healthController;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;

            _stateMachineController = GetComponent<PlayerStateMachineController>();
            _movementController = GetComponent<MovementController>();
            _healthController = GetComponent<HealthController>();

            AttachComponent(_stateMachineController);
            AttachComponent(_movementController);
        }
    }
}
