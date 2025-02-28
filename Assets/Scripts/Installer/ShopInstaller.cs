using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField]
    private SpriteManager spriteManager;

    [SerializeField]
    private CoinManager coinManager;

    public override void InstallBindings()
    {
        Container.Bind<SpriteManager>().FromInstance(spriteManager).AsSingle().NonLazy();

        Container.Bind<CoinManager>().FromInstance(coinManager).AsSingle().NonLazy();
    }
}
