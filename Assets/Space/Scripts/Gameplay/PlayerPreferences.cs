using Assets.Space.Scripts.UI.Audio;
using UnityEngine;

namespace Assets.Space.Scripts.Gameplay
{
    public class PlayerPreferences : MonoBehaviour
    {
        [SerializeField] private AudioController _audioController;

        public void LoadAudio()
        {
            _audioController.volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        public void SaveAudio()
        {
            PlayerPrefs.SetFloat("MasterVolume", _audioController.volumeSlider.value);
        }

        public void ChangeVolume(float volume)
        {
            AudioListener.volume = _audioController.volumeSlider.value;
            SaveAudio();
        }
    }
}
