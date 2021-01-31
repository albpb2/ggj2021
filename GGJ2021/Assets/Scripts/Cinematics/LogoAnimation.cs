using TMPro;
using UnityEngine;

namespace Cinematics
{
    public class LogoAnimation : MonoBehaviour
    {
        [SerializeField] TMP_Text _pressAnyButtonText;

        private IntroScene _introScene;

        private void Start()
        {
            _introScene = FindObjectOfType<IntroScene>();
        }

        public void HandleAnimationFinished()
        {
            _pressAnyButtonText.gameObject.SetActive(true);
            _introScene.EnableTransitionToNextScene();
        }
    }
}