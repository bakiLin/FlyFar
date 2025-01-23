using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBarArrow powerBarArrow;

    public override void InstallBindings()
    {
        Container.Bind<PowerBarArrow>().FromInstance(powerBarArrow).AsSingle().NonLazy();
    }
}
