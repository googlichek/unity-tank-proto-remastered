using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class HUDController : TickBehaviour
    {
        [SerializeField] private Text _healthText = null;
        [SerializeField] private Text _scoreText = null;

        private PlayerController _player;

        public override void Enable()
        {
            base.Enable();

            _player = FindObjectOfType<PlayerController>();
        }

        public override void Tick()
        {
            base.Tick();

            UpdatePlayer();
            UpdateHealthPoints();
            UpdateScorePoints();
        }

        private void UpdatePlayer()
        {
            if (_player == null)
                _player = FindObjectOfType<PlayerController>();
        }

        private void UpdateHealthPoints()
        {
            var health = _player == null ? 0 : _player.HealthController.Health;
            _healthText.text = string.Format($"HEALTH: {health}");
        }

        private void UpdateScorePoints()
        {
            _scoreText.text = string.Format($"SCORE: {GameManager.Instance.ScoreManager.Score}");
        }
	}
}
