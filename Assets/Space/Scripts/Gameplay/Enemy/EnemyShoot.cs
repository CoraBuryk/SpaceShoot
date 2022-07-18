using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _enemyShootingRange;
    [SerializeField] private GameObject _enemyBulletPref;
    [SerializeField] private GameObject _enemyBulletParent;
    [SerializeField] private float _enemyFireRate = 1f;
    private float _nextFireTime;
    private Transform _player;

    private void Awake()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_player == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);
            if (distanceFromPlayer < _enemyShootingRange && _nextFireTime < Time.time)
            {
                Instantiate(_enemyBulletPref, _enemyBulletParent.transform.position, Quaternion.identity);
                _nextFireTime = Time.time + _enemyFireRate;
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _enemyShootingRange);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
