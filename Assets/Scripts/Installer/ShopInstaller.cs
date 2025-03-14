using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField]
    private SpriteManager spriteManager;

    [SerializeField]
    private CoinManager coinManager;

    [SerializeField]
    private AudioManager audioManager;

    public override void InstallBindings()
    {
        Container.Bind<SpriteManager>().FromInstance(spriteManager).AsSingle().NonLazy();

        Container.Bind<CoinManager>().FromInstance(coinManager).AsSingle().NonLazy();

        Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle().NonLazy();
    }
}
