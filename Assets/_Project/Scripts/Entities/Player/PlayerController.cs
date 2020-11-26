namespace Game.Scripts
{
    public class PlayerController : TickBehaviour
    {
        private PlayerStateMachineController _stateMachineController;
        private MovementController _movementController;
        private HealthController _healthController;
        private BodyDamageDealer _bodyDamageDealer;
        private PlayerWeaponController _weaponController;
        private PlayerAudioController _audioController;

        public PlayerStateMachineController StateMachineController => _stateMachineController;
        public MovementController MovementController => _movementController;
        public HealthController HealthController => _healthController;
        public BodyDamageDealer BodyDamageDealer => _bodyDamageDealer;
        public PlayerWeaponController WeaponController => _weaponController;
        public PlayerAudioController AudioController => _audioController;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;

            _stateMachineController = GetComponent<PlayerStateMachineController>();
            _movementController = GetComponent<MovementController>();
            _healthController = GetComponent<HealthController>();
            _bodyDamageDealer = GetComponent<BodyDamageDealer>();
            _weaponController = GetComponent<PlayerWeaponController>();
            _audioController = GetComponent<PlayerAudioController>();

            AttachComponent(_stateMachineController);
            AttachComponent(_movementController);
            AttachComponent(_healthController);
            AttachComponent(_bodyDamageDealer);
            AttachComponent(_weaponController);
            AttachComponent(_audioController);
        }
        
        public override void Dispose()
        {
            DetachComponent(_stateMachineController);
            DetachComponent(_movementController);
            DetachComponent(_healthController);
            DetachComponent(_bodyDamageDealer);
            DetachComponent(_weaponController);
            DetachComponent(_audioController);

            base.Dispose();
        }
    }
}
