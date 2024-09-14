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

    [SerializeField]
    private ActionHolder actionHolder;

    [SerializeField]
    private PlayerAbility playerAbility;

    public override void InstallBindings()
    {
        Container.Bind<Pooler>().FromInstance(pooler).AsSingle().NonLazy();

        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();

        Container.Bind<PlatformSpeed>().FromInstance(platformSpeed).AsSingle().NonLazy();

        Container.Bind<ActionHolder>().FromInstance(actionHolder).AsSingle().NonLazy();

        Container.Bind<PlayerAbility>().FromInstance(playerAbility).AsSingle().NonLazy();
    }
}