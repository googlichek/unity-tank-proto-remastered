namespace Game.Scripts
{
    public class ScoreManager : TickBehaviour
    {
        private int _score;

        public int Score => _score;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;
        }

        public void ScorePoints(int value)
        {
            _score += value;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
