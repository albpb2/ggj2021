using Input;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToCutScene : MonoBehaviour
{
    private InputHandler _inputHandler;

    private bool _transitionToNextSceneIsEnabled;

    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        if (ShouldLoadNextScene())
            SceneManager.LoadScene(SceneIds.GrandpaHouse);
    }

    public void EnableTransitionToNextScene()
    {
        _transitionToNextSceneIsEnabled = true;
    }

    private bool ShouldLoadNextScene() => _transitionToNextSceneIsEnabled && _inputHandler.IsAnyButtonPressed();
}