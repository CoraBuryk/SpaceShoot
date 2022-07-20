using Assets.Space.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Space.Scripts.UI.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private PlayerPreferences _playerAudioPref;
        [SerializeField] private AudioMixerGroup _masterGroup;
        [SerializeField] private Toggle _muteToggle;
        public Slider volumeSlider;

        private void OnEnable()
        {
            _muteToggle.onValueChanged.AddListener(ToggleMute);
            volumeSlider.onValueChanged.AddListener(_playerAudioPref.ChangeVolume);
        }

        private void OnDisable()
        {
            _muteToggle.onValueChanged.RemoveListener(ToggleMute);
            volumeSlider.onValueChanged.RemoveListener(_playerAudioPref.ChangeVolume);
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("MasterVolume"))
            {
                PlayerPrefs.SetFloat("MasterVolume", 1);
                _playerAudioPref.LoadAudio();
            }
            else
            {
                _playerAudioPref.LoadAudio();
            }
        }

        private void ToggleMute(bool mute)
        {
            mute = _muteToggle.isOn;
            if (mute == true)
                _masterGroup.audioMixer.SetFloat("MasterVolume", -80);
            else
                _masterGroup.audioMixer.SetFloat("MasterVolume", 0);
        }
    }
}