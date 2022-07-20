using UnityEngine;

namespace Assets.Space.Scripts.Gameplay.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        private Rigidbody _playerBulletRB;

        private void Start()
        {
            _playerBulletRB = GetComponent<Rigidbody>();
            Vector3 moveDir = _playerBulletRB.transform.forward * _bulletSpeed;
            _playerBulletRB.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z);
            Destroy(this.gameObject, 4);
        }
    }
}
