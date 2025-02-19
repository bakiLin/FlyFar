using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField]
    private SpriteManager spriteManager;

    public override void InstallBindings()
    {
        Container.Bind<SpriteManager>().FromInstance(spriteManager).AsSingle().NonLazy();
    }
}
