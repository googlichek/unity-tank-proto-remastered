using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class UIManager : TickBehaviour
    {
        [SerializeField] private List<GameObject> _screens = new List<GameObject>();

        private int _currentScreenIndex = -1;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;
        }

        public override void Tick()
        {
            base.Tick();
            UpdateCurrentScreen();
        }

        private void UpdateCurrentScreen()
        {
            var currentScreenIndex = GameManager.Instance.SceneLoadingManager.CurrentSceneIndex;
            if (_currentScreenIndex == currentScreenIndex)
                return;

            _currentScreenIndex = currentScreenIndex;
            for (var i = 0; i < _screens.Count; i++)
                _screens[i].SetActive(i == _currentScreenIndex);
        }
    }
}
