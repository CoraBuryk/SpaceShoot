using Assets.Space.Scripts.Gameplay;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Space.Scripts.UI.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private AudioSource _buttonClick;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        private async void RestartGame()
        {
            _buttonClick.Play();
            await Task.Delay(250);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
            _gameplayController.Restart();
        }

        private async void ExitGame()
        {
            _buttonClick.Play();
            await Task.Delay(250);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2, LoadSceneMode.Single);
        }
    }
}