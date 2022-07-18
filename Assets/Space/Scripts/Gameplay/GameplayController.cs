using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameSpawner _spawner;

    public void EnemyKilled()
    {
        ScoreCounter.ChangeScore(ScoreCounter.Counter += 1);
    }

    public void PlayerKilled()
    {
        if (HealthController.NumOfLives <= 5 && HealthController.NumOfLives > 0)
        {
            HealthController.HealthDecreased();
            _spawner.PlayerSpawn();

        }
        else if (HealthController.NumOfLives == 0)
        {
            //game over
        }
    }

}
