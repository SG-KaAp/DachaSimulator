using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerInput
{
    private Player _player;
    private Input.PlayerActions _playerActions => InputHandler.PlayerActions;


    public PlayerInput(Player player)
    {
        _player = player;
        SubscribePlayer();
    }

    public void SubscribePlayer()
    {
        _playerActions.RotateCamera.performed += OnRotateCamera;
        _playerActions.Do.started += OnDo;
        _playerActions.Move.performed += OnStartMove;
        _playerActions.Move.canceled += OnStopMove;
        MonoBehaviour.print("Player subscribed");
    }

    public void UnsubscribePlayer()
    {
        _playerActions.RotateCamera.performed -= OnRotateCamera;
        _playerActions.Do.started += OnDo;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStopMove;
        MonoBehaviour.print("Player unsubscribed");
    }

    private void OnStartMove(InputAction.CallbackContext context)
    {
        _player.Movement.StartMove(context.ReadValue<Vector2>());
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
        _player.Movement.StopMove();
    }

    private void OnRotateCamera(InputAction.CallbackContext context)
    {
        _player.Camera.Rotate(context.ReadValue<Vector2>());
    }

    private void OnDo(InputAction.CallbackContext context)
    {
        _player.Interact.Interact();
    }


    private void Click(InputAction.CallbackContext context)
    {
    }

    public void Enable()
    {
        _playerActions.Enable();
    }

    public void Disable()
    {
        _playerActions.Disable();
    }
}
