using Assets.Space.Scripts.Gameplay;
using TMPro;
using UnityEngine;

namespace Assets.Space.Scripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _health;

        private void OnEnable()
        {
            HealthController.HealthChange += LivesCounter;
        }
        private void OnDisable()
        {
            HealthController.HealthChange -= LivesCounter;
        }

        private void Start()
        {
            LivesCounter();
        }

        public void LivesCounter()
        {
            _health.text = HealthController.NumOfLives.ToString();
        }
    }
}
