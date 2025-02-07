using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBarArrow powerBarArrow;

    [SerializeField]
    private UITextManager uiTextManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBarArrow>().FromInstance(powerBarArrow).AsSingle().NonLazy();

        Container.Bind<UITextManager>().FromInstance(uiTextManager).AsSingle().NonLazy();
    }
}
