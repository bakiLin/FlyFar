using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBar powerBar;

    [SerializeField]
    private TextManager textManager;

    [SerializeField]
    private ButtonManager buttonManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBar>().FromInstance(powerBar).AsSingle().NonLazy();

        Container.Bind<TextManager>().FromInstance(textManager).AsSingle().NonLazy();

        Container.Bind<ButtonManager>().FromInstance(buttonManager).AsSingle().NonLazy();
    }
}
