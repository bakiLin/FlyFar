using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBar powerBar;

    [SerializeField]
    private TextManager textManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBar>().FromInstance(powerBar).AsSingle().NonLazy();

        Container.Bind<TextManager>().FromInstance(textManager).AsSingle().NonLazy();
    }
}
