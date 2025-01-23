using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerGravity playerGravity;

    public override void InstallBindings()
    {
        Container.Bind<PlayerGravity>().FromInstance(playerGravity).AsSingle().NonLazy();
    }
}
