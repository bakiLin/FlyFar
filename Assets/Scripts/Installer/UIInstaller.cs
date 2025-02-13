using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBar powerBarArrow;

    [SerializeField]
    private UITextManager uiTextManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBar>().FromInstance(powerBarArrow).AsSingle().NonLazy();

        Container.Bind<UITextManager>().FromInstance(uiTextManager).AsSingle().NonLazy();
    }
}
