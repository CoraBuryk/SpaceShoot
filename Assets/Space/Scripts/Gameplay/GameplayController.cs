using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Space.Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private GameSpawner _spawner;

        public void EnemyKilled()
        {
            ScoreCounter.ChangeScore(ScoreCounter.Counter += 1);
        }

        public async void PlayerKilled()
        {
            if (HealthController.NumOfLives <= 5 && HealthController.NumOfLives > 0)
            {
                HealthController.HealthDecreased();
                _spawner.PlayerSpawn();

            }
            else if (HealthController.NumOfLives == 0)
            {
                await Task.Delay(250);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
        }

        public void Restart()
        {
            HealthController.ResetHealth();
            ScoreCounter.ChangeScore(0);
        }
    }
}