using Cinematics;
using Input;
using Pause;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaHouseScene : MonoBehaviour
{
    [SerializeField] private Cinematic[] _cinematics;
    
    private InputHandler _inputHandler;
    private PauseManager _pauseManager;

    private bool _isCinematicFinished;
    
    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _pauseManager = FindObjectOfType<PauseManager>();
        
        if (GlobalGameState.Instance.GrandpaHouseCinematicIndex <= _cinematics.Length)
            _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex].Play();
    }

    private void Update()
    {
        if (_pauseManager.IsPaused())
            return;
        
        if (!_isCinematicFinished && _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex].IsFinished())
        {
            _isCinematicFinished = true;
            GlobalGameState.Instance.GrandpaHouseCinematicIndex++;
        }

        if (_isCinematicFinished && ShouldLoadNextScene())
        {
            SceneManager.LoadScene(SceneIds.WarScene);
        }
    }

    private bool ShouldLoadNextScene() => _inputHandler.IsAnyButtonPressed();
}