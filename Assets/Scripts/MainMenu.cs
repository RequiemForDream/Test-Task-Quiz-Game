using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    private void Awake()
    {
        Extensions.Subscribe(_startGameButton, StartGame);
    }

    private void StartGame()
    {
        var sceneLoader = new SceneLoader(DataClass.MainSceneIndex);
        sceneLoader.LoadSceneByBuildIndex();
    }
}
