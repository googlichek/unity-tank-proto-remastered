using UnityEngine;

namespace Game.Scripts
{
    public class EnemyController : TickBehaviour, IResource
    {
        [SerializeField] private ResourceType _type = ResourceType.None;

        [Space]

        [SerializeField] [Range(0, 500)] private int _scorePoints = 0;

        private EnemyStateMachineController _stateMachineController;
        private MovementController _movementController;
        private HealthController _healthController;
        private BodyDamageDealer _damageDealer;

        public GameObject GameObject => gameObject;
        public ResourceType Type => _type;
        public bool IsValid => _healthController.Health > 0;

        public EnemyStateMachineController StateMachineController => _stateMachineController;
        public MovementController MovementController => _movementController;
        public HealthController HealthController => _healthController;
        public BodyDamageDealer DamageDealer => _damageDealer;

        public int ScorePoints => _scorePoints;

        public override void Init()
        {
            base.Init();

            _stateMachineController = GetComponent<EnemyStateMachineController>();
            _movementController = GetComponent<MovementController>();
            _healthController = GetComponent<HealthController>();
            _damageDealer = GetComponent<BodyDamageDealer>();

            AttachComponent(_stateMachineController);
            AttachComponent(_movementController);
            AttachComponent(_healthController);
            AttachComponent(_damageDealer);
        }

        public override void Dispose()
        {
            DetachComponent(_stateMachineController);
            DetachComponent(_movementController);
            DetachComponent(_healthController);
            DetachComponent(_damageDealer);

            base.Dispose();
        }
    }
}
