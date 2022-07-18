using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameplayController _gameplayController;
    [SerializeField] private GameObject _explosion;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "EnemyBullet")
        {
            PlayExplosion();
            _gameplayController.PlayerKilled();
            Destroy(gameObject);
        }
    }

    private void PlayExplosion()
    {
        GameObject explosion = Instantiate(_explosion);
        explosion.transform.position = transform.position;
    }
}
