using UnityEngine;
using Zenject;

public class SpawnInstaller : MonoInstaller
{
    [SerializeField]
    private SkyEnemySpawner skyEnemySpawner;

    [SerializeField]
    private GroundEnemySpawner groundEnemySpawner;

    public override void InstallBindings()
    {
        Container.Bind<SkyEnemySpawner>().FromInstance(skyEnemySpawner).AsSingle().NonLazy();

        Container.Bind<GroundEnemySpawner>().FromInstance(groundEnemySpawner).AsSingle().NonLazy();
    }
}
