using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class WarScene : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private int _numberOfCards;

        private int _cardsPickedCount;

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

        public void PickCard()
        {
            _cardsPickedCount++;
            if (_cardsPickedCount >= _numberOfCards)
            {
                OpenDoor();
            }
        }

        public void OpenDoor()
        {
            Debug.Log("Opening door");
        }
    }
}