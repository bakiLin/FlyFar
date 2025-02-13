using UnityEngine;
using Zenject;

public class SpawnInstaller : MonoInstaller
{
    [SerializeField]
    private SkySpawner skySpawner;

    [SerializeField]
    private GroundSpawner groundSpawner;

    public override void InstallBindings()
    {
        Container.Bind<SkySpawner>().FromInstance(skySpawner).AsSingle().NonLazy();

        Container.Bind<GroundSpawner>().FromInstance(groundSpawner).AsSingle().NonLazy();
    }
}
