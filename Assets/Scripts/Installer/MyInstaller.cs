using UnityEngine;
using Zenject;

public class MyInstaller : MonoInstaller
{
    [SerializeField]
    private Pooler pooler;

    [SerializeField]
    private Launcher launcher;

    [SerializeField]
    private PlayerGravity playerGravity;

    public override void InstallBindings()
    {
        Container.Bind<Pooler>().FromInstance(pooler).AsSingle().NonLazy();
        Container.Bind<Launcher>().FromInstance(launcher).AsSingle().NonLazy();
        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();
    }
}