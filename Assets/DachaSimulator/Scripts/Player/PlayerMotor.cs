using System;
using UnityEngine;

[Serializable]
public class PlayerMotor
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravityMultiplier;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Vector3 _direction;
    private MonoBehaviour _context;

    public void Initialize(Player player)
    {
        _context = player;
        player.OnUpdate += OnUpdate;
        _controller = _context.GetComponent<CharacterController>();
    }

    private void OnUpdate()
    {
        _controller.Move(_context.transform.TransformDirection(_direction) * _moveSpeed * Time.deltaTime);
        _playerVelocity.y += Physics.gravity.y * Time.deltaTime * _gravityMultiplier;
        if (_controller.isGrounded)
        {
            if (_playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

        }
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void StartMove(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
    }

    public void StopMove()
    {
        _direction = Vector3.zero;
    }
}