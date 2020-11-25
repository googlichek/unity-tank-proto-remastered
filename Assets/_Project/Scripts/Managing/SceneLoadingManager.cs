using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class SceneLoadingManager : TickBehaviour
    {
        public override void Init()
        {
            base.Init();

            priority = TickPriority.High;
        }

        public void LoadScene(int sceneIndex)
        {
            if (sceneIndex < 0 ||
                sceneIndex > SceneManager.sceneCountInBuildSettings - 1) return;

            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadNextScene()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex >= SceneManager.sceneCountInBuildSettings - 1) return;

            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
