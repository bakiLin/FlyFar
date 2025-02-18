using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerGravity playerGravity;

    [SerializeField]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private FlyPower flyPower;

    public override void InstallBindings()
    {
        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();

        Container.Bind<PlayerSpeed>().FromInstance(playerSpeed).AsSingle().NonLazy();

        Container.Bind<FlyPower>().FromInstance(flyPower).AsSingle().NonLazy();
    }
}
