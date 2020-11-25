using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class EndScreenController : TickBehaviour
    {
        [SerializeField] private Text _scoreText = null;

        public override void Tick()
        {
            base.Tick();

            UpdateScorePoints();
        }

        private void UpdateScorePoints()
        {
            _scoreText.text = string.Format($"SCORE: {GameManager.Instance.ScoreManager.Score}");
        }
	}
}
