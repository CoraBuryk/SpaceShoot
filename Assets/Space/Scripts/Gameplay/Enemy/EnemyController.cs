using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameplayController _gameplayController;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _enemy;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PlayerBullet")
        {
            PlayExplosion();
            _gameplayController.EnemyKilled();
            Destroy(_enemy);
        }
    }

    private void PlayExplosion()
    { 
        GameObject explosion = Instantiate(_explosion);
        explosion.transform.position = transform.position;
    }
}
