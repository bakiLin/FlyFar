using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField]
    private SelectManager selectManager;

    [SerializeField]
    private LevelItemDataManager levelItemDataManager;

    [SerializeField]
    private CoinManager coinManager;

    [SerializeField]
    private ShopButtonManager shopButtonManager;

    public override void InstallBindings()
    {
        Container.Bind<SelectManager>().FromInstance(selectManager).AsSingle().NonLazy();

        Container.Bind<LevelItemDataManager>().FromInstance(levelItemDataManager).AsSingle().NonLazy();

        Container.Bind<CoinManager>().FromInstance(coinManager).AsSingle().NonLazy();

        Container.Bind<ShopButtonManager>().FromInstance(shopButtonManager).AsSingle().NonLazy();
    }
}
