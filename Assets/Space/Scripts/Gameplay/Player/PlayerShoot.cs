using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameplayController _gameplayController;
    [SerializeField] private GameObject _playerBulletPref;
    [SerializeField] private GameObject _playerBulletParent;
    [SerializeField] private float _playerFireRate = 0.2f;
    private float _nextFireTime;

    private void Update()
    {
        if(_nextFireTime < Time.time)
        {
            Instantiate(_playerBulletPref, _playerBulletParent.transform.position, _playerBulletParent.transform.rotation);
            _nextFireTime = Time.time + _playerFireRate;
        }        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            _gameplayController.PlayerKilled();
        }
    }
}
