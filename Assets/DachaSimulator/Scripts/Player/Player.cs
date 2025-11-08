using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Action OnUpdate;

    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private PlayerInteract _interact;

    private PlayerInput _input;

    public PlayerMotor Movement => _movement;
    public PlayerCamera Camera => _camera;
    public PlayerInteract Interact => _interact;

    public void Initialize()
    {
        _input = new PlayerInput(this);
        _movement.Initialize(this);
        _camera.Initialize(this);
        _interact.Initialize(this);
    }

    private void Update()
    {
        OnUpdate.Invoke();
    }
}
