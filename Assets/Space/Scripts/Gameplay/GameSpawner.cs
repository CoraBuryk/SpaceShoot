using System.Threading.Tasks;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private GameObject[] _enemyPref;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerSpawnPoint;

    private int _randomSpawnPoint;
    private int _randomEnemy;

    private void Start()
    {
        PlayerSpawn();
        InvokeRepeating("SpawnEnemy", 5f, Random.Range(1f, 10f)); 
    }

    private void SpawnEnemy()
    {
        _randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
        _randomEnemy = Random.Range(0, _enemyPref.Length);
        Instantiate(_enemyPref[_randomEnemy],_enemySpawnPoints[_randomSpawnPoint].position, Quaternion.identity);
    }

    public async void PlayerSpawn()
    {
        await Task.Delay(5);
        Instantiate(_player, _playerSpawnPoint.position, Quaternion.identity);
    }
}
