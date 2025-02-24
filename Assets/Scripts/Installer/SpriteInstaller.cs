using UnityEngine;
using Zenject;

public class SpriteInstaller : MonoInstaller
{
    [SerializeField]
    private SpriteManager spriteManager;

    public override void InstallBindings()
    {
        Container.Bind<SpriteManager>().FromInstance(spriteManager).AsSingle().NonLazy();
    }
}
