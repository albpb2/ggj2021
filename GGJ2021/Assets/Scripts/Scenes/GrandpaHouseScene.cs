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
    private PausePanel _pausePanel;

    private bool _isCinematicFinished;
    
    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _pausePanel = FindObjectOfType<PausePanel>(true);
        
        if (GlobalGameState.Instance.GrandpaHouseCinematicIndex <= _cinematics.Length)
            _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex].Play();
    }

    private void Update()
    {
        if (ShouldPause())
        {
            Pause();
            return;
        }
        
        if (!_isCinematicFinished && _cinematics[GlobalGameState.Instance.GrandpaHouseCinematicIndex].IsFinished())
        {
            _isCinematicFinished = true;
            GlobalGameState.Instance.GrandpaHouseCinematicIndex++;
        }

        if (_isCinematicFinished && ShouldLoadNextScene())
        {
            SceneManager.LoadScene(SceneIds.MovementTest);
        }
    }

    private bool ShouldPause() => _inputHandler.IsPauseButtonPressed();

    private bool ShouldLoadNextScene() => _inputHandler.IsAnyButtonPressed();

    private void Pause()
    {
        _pausePanel.Enable(Unpause);
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
    }
}