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

    private bool _currentCinematicIsFinished;
    private Cinematic _currentCinematic;
    
    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _pauseManager = FindObjectOfType<PauseManager>();

        _currentCinematic = GlobalGameState.Instance.GrandpaHouseCinematicIndex < _cinematics.Length
            ? _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex]
            : null;
        if (_currentCinematic != null)
            _currentCinematic.Play();
        else
            _currentCinematicIsFinished = true;
    }

    private void Update()
    {
        if (_pauseManager.IsPaused())
            return;
        
        if (!_currentCinematicIsFinished && HasCurrentCinematicFinished())
        {
            _currentCinematicIsFinished = true;
            GlobalGameState.Instance.GrandpaHouseCinematicIndex++;
        }

        if (_currentCinematicIsFinished && ShouldLoadNextScene())
        {
            SceneManager.LoadScene(SceneIds.WarScene);
        }
    }

    private bool ShouldLoadNextScene() => _inputHandler.IsAnyButtonPressed();

    private bool HasCurrentCinematicFinished() => _currentCinematic == null || _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex].IsFinished();
}