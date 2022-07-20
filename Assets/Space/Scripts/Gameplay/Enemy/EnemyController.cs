using UnityEngine;

namespace Assets.Space.Scripts.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private GameObject _explosion;
        [SerializeField] private GameObject _enemy;

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "PlayerBullet" || col.tag == "Player")
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
}
