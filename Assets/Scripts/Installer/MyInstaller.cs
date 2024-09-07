using UnityEngine;
using Zenject;

public class MyInstaller : MonoInstaller
{
    [SerializeField]
    private Pooler pooler;

    [SerializeField]
    private PlayerGravity playerGravity;

    [SerializeField]
    private PlatformSpeed platformSpeed;

    public override void InstallBindings()
    {
        Container.Bind<Pooler>().FromInstance(pooler).AsSingle().NonLazy();

        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();

        Container.Bind<PlatformSpeed>().FromInstance(platformSpeed).AsSingle().NonLazy();
    }
}