using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private GameObject _targetPlayer;
    private Rigidbody _enemyBulletRB;

    private void Start()
    {
        _enemyBulletRB = GetComponent<Rigidbody>();
        _targetPlayer = GameObject.FindGameObjectWithTag("Player");
        if (_targetPlayer != null)
        {
            Vector3 moveDir = (_targetPlayer.transform.position - transform.position).normalized * _bulletSpeed;
            _enemyBulletRB.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z);
            Destroy(this.gameObject, 2);
        }
        else
        {
            Destroy(this.gameObject, 1);
        }
    }
}
