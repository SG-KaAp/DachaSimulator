using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private Canvas _canvas;

    public override void InstallBindings()
    {
        InstallCanvas();
    }

    private void InstallCanvas()
    {
        Container.Bind<Canvas>().FromInstance(_canvas).AsSingle().NonLazy();
    }
}