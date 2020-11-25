using Rewired;

namespace Game.Scripts
{
    public class InputWrapper : TickBehaviour
    {
        private Rewired.Player _player;

        private int _playerId = 0;

        private float _horizontal;
        private float _vertical;

        private bool _isSwitchLeftPressed;
        private bool _isSwitchLeftReleased;
        private bool _isSwitchLeftHeld;

        private bool _isSwitchRightPressed;
        private bool _isSwitchRightReleased;
        private bool _isSwitchRightHeld;
        
        private bool _isShootPressed;
        private bool _isShootReleased;
        private bool _isShootHeld;

        private bool _isTimeToReset;

        public float Horizontal => _horizontal;
        public float Vertical => _vertical;

        public bool IsSwitchLeftPressed => _isSwitchLeftPressed;
        public bool IsSwitchLeftReleased => _isSwitchLeftReleased;
        public bool IsSwitchLeftHeld => _isSwitchLeftHeld;

        public bool IsSwitchRightPressed => _isSwitchRightPressed;
        public bool IsSwitchRightReleased => _isSwitchRightReleased;
        public bool IsSwitchRightHeld => _isSwitchRightHeld;

        public bool IsShootPressed => _isShootPressed;
        public bool IsShootReleased => _isShootReleased;
        public bool IsShootHeld => _isShootHeld;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;

            _player = ReInput.players.GetPlayer(_playerId);
        }

        public override void PhysicsTick()
        {
            base.PhysicsTick();

            _isTimeToReset = true;
        }

        public override void Tick()
        {
            base.Tick();

            ResetInput();

            _isTimeToReset = false;

            HandleInput();
        }

        private void ResetInput()
        {
            if (!_isTimeToReset)
                return;

            _horizontal = 0;
            _vertical = 0;

            _isSwitchLeftPressed = false;
            _isSwitchLeftReleased = false;
            _isSwitchLeftHeld = false;

            _isSwitchRightPressed = false;
            _isSwitchRightReleased = false;
            _isSwitchRightHeld = false;

            _isShootPressed = false;
            _isShootReleased = false;
            _isShootHeld = false;
        }

        private void HandleInput()
        {
            _horizontal += _player.GetAxis(InputActions.Horizontal);
            _vertical += _player.GetAxis(InputActions.Vertical);

            _isSwitchLeftPressed = _isSwitchLeftPressed || _player.GetButtonDown(InputActions.SwitchLeft);
            _isSwitchLeftReleased = _isSwitchLeftReleased || _player.GetButtonUp(InputActions.SwitchLeft);
            _isSwitchLeftHeld = _isSwitchLeftHeld || _player.GetButton(InputActions.SwitchLeft);

            _isSwitchRightPressed = _isSwitchRightPressed || _player.GetButtonDown(InputActions.SwitchRight);
            _isSwitchRightReleased = _isSwitchRightReleased || _player.GetButtonUp(InputActions.SwitchRight);
            _isSwitchRightHeld = _isSwitchRightHeld || _player.GetButton(InputActions.SwitchRight);

            _isShootPressed = _isShootPressed || _player.GetButtonDown(InputActions.Shoot);
            _isShootReleased = _isShootReleased || _player.GetButtonUp(InputActions.Shoot);
            _isShootHeld = _isShootHeld || _player.GetButton(InputActions.Shoot);
        }
    }
}
