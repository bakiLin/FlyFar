using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerGravity playerGravity;

    [SerializeField]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private PlayerCollision playerCollision;

    [SerializeField]
    private PlayerPower playerPower;

    public override void InstallBindings()
    {
        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();

        Container.Bind<PlayerSpeed>().FromInstance(playerSpeed).AsSingle().NonLazy();

        Container.Bind<PlayerCollision>().FromInstance(playerCollision).AsSingle().NonLazy();

        Container.Bind<PlayerPower>().FromInstance(playerPower).AsSingle().NonLazy();
    }
}
