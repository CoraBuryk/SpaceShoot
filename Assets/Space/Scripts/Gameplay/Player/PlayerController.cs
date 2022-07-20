using UnityEngine;

namespace Assets.Space.Scripts.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameplayController _gameplayController;
        [SerializeField] private GameObject _explosion;
        [SerializeField] private GameSpawner _spawner;

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "EnemyBullet" || col.tag == "Enemy")
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
}
