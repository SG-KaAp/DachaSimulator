using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GardenBed[] _gardenBeds;

    private void Start()
    {
        InputHandler.Initialize();
        _player.Initialize();
        foreach(GardenBed gardenBed in _gardenBeds)
        {
            gardenBed.Initialize();
        }
    } 
}