using System;

namespace Assets.Space.Scripts.Gameplay
{
    public static class HealthController
    {
        private static int _maxHealth = 5;
        public static int NumOfLives { get; set; } = 5;

        public static event Action HealthChange;

        public static void HealthDecreased()
        {
            _maxHealth -= 1;
            NumOfLives = _maxHealth;

            HealthChange?.Invoke();
        }

        public static void ResetHealth()
        {
            _maxHealth = 5;
            NumOfLives = _maxHealth;

            HealthChange?.Invoke();
        }
    }
}