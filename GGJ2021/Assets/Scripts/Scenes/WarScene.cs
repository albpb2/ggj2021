using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class WarScene : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private void OnEnable()
        {
            _playerController.OnPlayerDied += ResetScene;
        }

        private void OnDisable()
        {
            _playerController.OnPlayerDied -= ResetScene;
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneIds.WarScene);
        }
    }
}