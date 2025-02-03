using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private GameManage gameManage;

    public override void InstallBindings()
    {
        Container.Bind<GameManage>().FromInstance(gameManage).AsSingle().NonLazy();
    }
}
