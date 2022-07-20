using UnityEngine;
using UnityEngine.UI;

namespace Assets.Space.Scripts.UI.Menu
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _optionsPanel;
        [SerializeField] private Button _back;
        [SerializeField] private AudioSource _buttonClick;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _back.onClick.AddListener(BackInStart);
        }

        private void OnDisable()
        {
            _back.onClick.RemoveListener(BackInStart);
        }

        public void BackInStart()
        {
            _buttonClick.Play();
            _startPanel.SetActive(!_isOpened);
            _optionsPanel.SetActive(_isOpened);
        }
    }
}