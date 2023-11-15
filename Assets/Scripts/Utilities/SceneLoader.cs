using UnityEngine.SceneManagement;

namespace Utilities
{
    public struct SceneLoader
    {
        private readonly int _sceneIndex;

        public SceneLoader(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
        }

        public void LoadSceneByBuildIndex()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}
