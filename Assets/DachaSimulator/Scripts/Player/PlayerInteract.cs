using System;
using UnityEngine;

[Serializable]
public class PlayerInteract
{
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _distance;

    private Interactable _currentTarget;


    public void Initialize(Player player)
    {
        player.OnUpdate += Update;
    }

    public void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_raycastPoint.position, _raycastPoint.TransformDirection(Vector3.forward), out hit, _distance))
        {
            if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if (interactable != _currentTarget)
                {
                    _currentTarget?.OnEndHover();
                    _currentTarget = interactable;
                    _currentTarget?.OnStartHover();
                    return;
                }

                _currentTarget?.OnHover();
            }
            else if (_currentTarget != null)
            {
                _currentTarget?.OnEndHover();
                _currentTarget = null;
            }
        }
        else if (_currentTarget != null)
        {
            _currentTarget?.OnEndHover();
            _currentTarget = null;
        }
    }

    public void Interact()
    {
        _currentTarget?.OnInteract();
        _currentTarget = null;
    }
}