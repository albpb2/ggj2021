﻿using System;
using Input;
using Pause;
using TMPro;
using UnityEngine;

namespace Cinematics
{
    [RequireComponent(typeof(TMP_Text))]
    public class DialogBox : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private PauseManager _pauseManager;
        
        private TMP_Text _textBox;
        
        private string[] _lines;
        private int _currentLine;
        private bool _buttonPressedOnce;
        private bool _shouldFinishDialog;

        public bool Finished { get; private set; }

        private bool HasMoreText => _lines != null && _currentLine < _lines.Length;

        private void Awake()
        {
            _textBox = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _pauseManager = FindObjectOfType<PauseManager>();
        }

        private void Update()
        {
            if (_pauseManager.IsPaused())
                return;
            
            if (!Finished && _inputHandler.IsAnyButtonPressed())
            {
                if (HasMoreText)
                {
                    if (_buttonPressedOnce)
                        PlayNextSentence();
                    _buttonPressedOnce = !_buttonPressedOnce;
                }
                else
                {
                    ClearText();
                    Finished = true;
                }
            }
        }

        public void StartDialog(DialogText text)
        {
            const string lineSeparator = "\n";
            _lines = text.text.Split(new []{lineSeparator}, StringSplitOptions.None);
            _buttonPressedOnce = false;
            Finished = false;
            PlayNextSentence();
        }

        private bool ShouldPlayNextSentence() => _inputHandler.IsAnyButtonPressed() && _buttonPressedOnce;

        private void PlayNextSentence()
        {
            _textBox.text = _lines[_currentLine];
            _currentLine++;
        }

        private void ClearText()
        {
            _textBox.text = null;
        }
    }
}