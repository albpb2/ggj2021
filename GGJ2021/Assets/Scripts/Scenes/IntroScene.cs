﻿using Input;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    private InputHandler _inputHandler;

    private bool _transitionToNextSceneIsEnabled;
    
    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _transitionToNextSceneIsEnabled = true;
    }

    private void Update()
    {
        if (ShouldLoadNextScene())
            SceneManager.LoadScene(SceneIds.Intro);
    }

    public void EnableTransitionToNextScene()
    {
        _transitionToNextSceneIsEnabled = true;
    }

    private bool ShouldLoadNextScene() => _transitionToNextSceneIsEnabled && _inputHandler.IsAnyButtonPressed();
}