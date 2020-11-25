using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayerWeaponController : TickComponent
    {
        private const int CylinderRotationAngle = 180;

        [Header("Arsenal Variables")]
        [SerializeField] private GameObject _cylinder = null;
        [SerializeField] private Transform _projectileStartPosition = null;

        [Space]

        [SerializeField] [Range(0, 1)] private float _weaponChangeDuration = 0.5f;

        [SerializeField] private Ease _changeEase = Ease.Linear;

        private Weapons _currentWeapon = Weapons.None;

        private bool _isWeaponInteractionEnabled = true;

        public Weapons CurrentWeapon => _currentWeapon;
        public bool IsWeaponInteractionEnabled => _isWeaponInteractionEnabled;

        public override void Init()
        {
        }

        public void UpdateCurrentWeapon()
        {
            switch (_currentWeapon)
            {
                case Weapons.Primary:
                    _currentWeapon = Weapons.Secondary;
                    break;
                case Weapons.Secondary:
                    _currentWeapon = Weapons.Primary;
                    break;
            }
        }

        public void RotateCylinder(bool isRotationClockwise)
        {
            _isWeaponInteractionEnabled = false;

            var angle = isRotationClockwise ? -CylinderRotationAngle : CylinderRotationAngle;
            var rotationVector = _cylinder.transform.localRotation.eulerAngles + new Vector3(0, 0, angle);

            _cylinder.transform.DOLocalRotate(rotationVector, _weaponChangeDuration).SetEase(_changeEase).OnComplete(() => _isWeaponInteractionEnabled = true);
        }
    }
}
