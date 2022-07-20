using UnityEngine;

namespace Assets.Space.Scripts.Gameplay.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;

        private CharacterController _controller;
        private PlayerInput _playerInput;
        private Vector3 _playerVelocity;
        private Vector3 _screenSize;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _playerInput = new PlayerInput();
            _screenSize = new Vector3(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize, Camera.main.orthographicSize);
        }

        private void Update()
        {
            Vector2 movement = _playerInput.Player.Move.ReadValue<Vector2>();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            _controller.Move(move * Time.deltaTime * _playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            _controller.Move(_playerVelocity * Time.deltaTime);

            if (transform.position.x < -_screenSize.x)
            {
                transform.position = new Vector3(-_screenSize.x, transform.position.y, transform.position.z);

            }
            else if (transform.position.x > _screenSize.x)
            {
                transform.position = new Vector3(_screenSize.x, transform.position.y, transform.position.z);
            }

            if (transform.position.z < -_screenSize.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -_screenSize.z);

            }
            else if (transform.position.z > _screenSize.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _screenSize.z);
            }

        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}
