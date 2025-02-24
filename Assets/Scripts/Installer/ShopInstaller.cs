using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField]
    private SelectManager selectManager;

    [SerializeField]
    private EnemyDataManager enemyDataManager;

    [SerializeField]
    private CoinManager coinManager;

    [SerializeField]
    private ShopButtonManager shopButtonManager;

    public override void InstallBindings()
    {
        Container.Bind<SelectManager>().FromInstance(selectManager).AsSingle().NonLazy();

        Container.Bind<EnemyDataManager>().FromInstance(enemyDataManager).AsSingle().NonLazy();

        Container.Bind<CoinManager>().FromInstance(coinManager).AsSingle().NonLazy();

        Container.Bind<ShopButtonManager>().FromInstance(shopButtonManager).AsSingle().NonLazy();
    }
}
