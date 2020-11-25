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
            HandleMovement();
            HandleWeaponChange();
        }

        private void HandleMovement()
        {
            Owner.MovementController.Move(GameManager.Instance.InputWrapper.Vertical);
            Owner.MovementController.Rotate(GameManager.Instance.InputWrapper.Horizontal);
        }

        private void HandleWeaponChange()
        {
            if (!Owner.WeaponController.IsWeaponInteractionEnabled)
                return;

            if (GameManager.Instance.InputWrapper.IsShootHeld)
            {
                Owner.WeaponController.Shoot();
                Owner.AudioController.PlayClip(
                    Owner.WeaponController.CurrentWeapon == Weapons.Primary
                        ? Owner.AudioController.PrimaryShot
                        : Owner.AudioController.SecondaryShot);
            }

            if (GameManager.Instance.InputWrapper.IsSwitchLeftPressed)
            {
                Owner.WeaponController.RotateCylinder(false);
                Owner.WeaponController.UpdateCurrentWeapon();
                Owner.AudioController.PlayClip(Owner.AudioController.WeaponChange);
            }

            if (GameManager.Instance.InputWrapper.IsSwitchRightPressed)
            {
                Owner.WeaponController.RotateCylinder(true);
                Owner.WeaponController.UpdateCurrentWeapon();
                Owner.AudioController.PlayClip(Owner.AudioController.WeaponChange);
            }
        }
    }
}
