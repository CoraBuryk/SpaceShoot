using UnityEngine;

namespace Assets.Space.Scripts.UI.Audio
{
    public class AudioEffects : MonoBehaviour
    {
        [SerializeField] private AudioSource _background;
        [SerializeField] private AudioSource _buttonClick;
        [SerializeField] private AudioController audioController;

        public void PlayButttonClick()
        {
            _buttonClick.Play();
        }

        public void PlayBackground()
        {
            _background.Play();
        }
    }
}