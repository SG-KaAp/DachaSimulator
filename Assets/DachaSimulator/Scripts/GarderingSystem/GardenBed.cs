using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private Flowerbed _flowerbedPrefab;

    [SerializeField] private int _width;
    [SerializeField] private int _length;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _offset;


    private List<Flowerbed> _flowerbeds = new List<Flowerbed>();

    public void Initialize()
    {
        Vector3 spawnPoint = _startPoint.position;

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                Flowerbed flowerbed = Instantiate(_flowerbedPrefab, spawnPoint, Quaternion.identity, transform);
                flowerbed.Initialize(FlowerbedState.Flat);
                _flowerbeds.Add(flowerbed);
                spawnPoint.x += _offset;
            }
            spawnPoint.x = _startPoint.position.x;
            spawnPoint.z += _offset;
        }
    }
}