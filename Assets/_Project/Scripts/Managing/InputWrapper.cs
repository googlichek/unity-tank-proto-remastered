using Rewired;

namespace Game.Scripts
{
    public class InputWrapper : TickBehaviour
    {
        private Player _player;

        private int _playerId = 0;

        private bool _isUpPressed;
        private bool _isUpReleased;
        private bool _isUpHeld;

        private bool _isDownPressed;
        private bool _isDownReleased;
        private bool _isDownHeld;

        private bool _isLeftPressed;
        private bool _isLeftReleased;
        private bool _isLeftHeld;
        
        private bool _isRightPressed;
        private bool _isRightReleased;
        private bool _isRightHeld;

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

        public bool IsUpPressed => _isUpPressed;
        public bool IsUpReleased => _isUpReleased;
        public bool IsUpHeld => _isUpHeld;

        public bool IsDownPressed => _isDownPressed;
        public bool IsDownReleased => _isDownReleased;
        public bool IsDownHeld => _isDownHeld;

        public bool IsLeftPressed => _isLeftPressed;
        public bool IsLeftReleased => _isLeftReleased;
        public bool IsLeftHeld => _isLeftHeld;

        public bool IsRightPressed => _isRightPressed;
        public bool IsRightReleased => _isRightReleased;
        public bool IsRightHeld => _isRightHeld;

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

            _player = ReInput.players.GetPlayer(_playerId);
        }

        public override void PhysicsTick()
        {
            _isTimeToReset = true;
        }

        public override void Tick()
        {
            ResetInput();

            _isTimeToReset = false;

            HandleInput();
        }

        private void ResetInput()
        {
            if (!_isTimeToReset)
                return;

            _isUpPressed = false;
            _isUpReleased = false;
            _isUpHeld = false;

            _isDownPressed = false;
            _isDownReleased = false;
            _isDownHeld = false;
            
            _isUpPressed = false;
            _isUpReleased = false;
            _isUpHeld = false;

            _isDownPressed = false;
            _isDownReleased = false;
            _isDownHeld = false;

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
            _isUpPressed = _isUpPressed || _player.GetButtonDown(InputActions.Up);
            _isUpReleased = _isUpReleased || _player.GetButtonUp(InputActions.Up);
            _isUpHeld = _isUpHeld || _player.GetButton(InputActions.Up);

            _isDownPressed = _isDownPressed || _player.GetButtonDown(InputActions.Down);
            _isDownReleased = _isDownReleased || _player.GetButtonUp(InputActions.Down);
            _isDownHeld = _isDownHeld || _player.GetButton(InputActions.Down);

            _isLeftPressed = _isLeftPressed || _player.GetButtonDown(InputActions.Left);
            _isLeftReleased = _isLeftReleased || _player.GetButtonUp(InputActions.Left);
            _isLeftHeld = _isLeftHeld || _player.GetButton(InputActions.Left);

            _isRightPressed = _isRightPressed || _player.GetButtonDown(InputActions.Right);
            _isRightReleased = _isRightReleased || _player.GetButtonUp(InputActions.Right);
            _isRightHeld = _isRightHeld || _player.GetButton(InputActions.Right);

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
