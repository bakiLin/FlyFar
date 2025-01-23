using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerGravity playerGravity;

    [SerializeField]
    private PlayerSpeed playerSpeed;

    public override void InstallBindings()
    {
        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();

        Container.Bind<PlayerSpeed>().FromInstance(playerSpeed).AsSingle().NonLazy();
    }
}
