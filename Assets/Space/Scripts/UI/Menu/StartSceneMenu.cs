using Assets.Space.Scripts.UI.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Space.Scripts.UI.Menu
{
    public class StartSceneMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private GameObject _optionsPanel;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private AudioSource _background;
        [SerializeField] private AudioSource _buttonClick;
        [SerializeField] private AudioEffects _audioEffects;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _quitButton.onClick.AddListener(ExitGame);
            _optionsButton.onClick.AddListener(Options);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _quitButton.onClick.RemoveListener(ExitGame);
            _optionsButton.onClick.RemoveListener(Options);
        }

        private void StartGame()
        {
            _audioEffects.PlayButttonClick();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }

        private void Options()
        {
            _audioEffects.PlayButttonClick();
            _optionsPanel.SetActive(!_isOpened);
            _startPanel.SetActive(_isOpened);
        }

        private void ExitGame()
        {
            _audioEffects.PlayButttonClick();
            Application.Quit();
        }
    }
}