using UnityEngine;
using Zenject;

public class SpawnInstaller : MonoInstaller
{
    [SerializeField]
    private EnemySpawner enemySpawner;

    public override void InstallBindings()
    {
        Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle().NonLazy();
    }
}
