using System;
using UnityEngine;

[Serializable]
public class PlayerCamera
{
    [SerializeField] private float _sensivity;
    [SerializeField] private float _yRotateLimit;
    [SerializeField] private Transform _viewTransform;
    public float digDepth = 0.05f;
    public int brushSize = 20; 

    private float _xRotate;
    private MonoBehaviour _context;

    public void Initialize(MonoBehaviour context)
    {
        _context = context;
    }

    public void Rotate(Vector2 mousePosition)
    {
        _context.transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sensivity);
        _xRotate -= mousePosition.y * Time.deltaTime * _sensivity;
        _xRotate = Mathf.Clamp(_xRotate, -_yRotateLimit, _yRotateLimit);
        Quaternion fpsRigRotation = Quaternion.Euler(_xRotate, 0, 0);
        _viewTransform.localRotation = fpsRigRotation;
    }
}