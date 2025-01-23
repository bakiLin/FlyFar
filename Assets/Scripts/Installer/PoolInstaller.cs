using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField]
    private ObjectPooler objectPooler;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPooler>().FromInstance(objectPooler).AsSingle().NonLazy();
    }
}
