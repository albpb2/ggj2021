﻿using Input;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaHouseScene : MonoBehaviour
{
    private InputHandler _inputHandler;

    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        if (ShouldLoadNextScene())
            SceneManager.LoadScene(SceneIds.MovementTest);
    }

    private bool ShouldLoadNextScene() => _inputHandler.IsAnyButtonPressed();
}