using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private CharacterController _controller;
    private PlayerInput _playerInput;
    private Vector3 _playerVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerInput = new PlayerInput();
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
