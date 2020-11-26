using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class SceneLoadingManager : TickBehaviour
    {
        private int _currentSceneIndex;

        public int CurrentSceneIndex => _currentSceneIndex;

        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;

            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void LoadScene(int sceneIndex)
        {
            if (sceneIndex < 0 || sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
                return;

            _currentSceneIndex = sceneIndex;
            SceneManager.LoadScene(_currentSceneIndex);
        }

        public void LoadNextScene()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex >= SceneManager.sceneCountInBuildSettings - 1)
                return;

            sceneIndex++;
            _currentSceneIndex = sceneIndex;
            SceneManager.LoadScene(_currentSceneIndex);
        }
    }
}
