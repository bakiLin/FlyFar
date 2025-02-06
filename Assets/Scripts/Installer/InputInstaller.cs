using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField]
    private InputScript inputScript;

    public override void InstallBindings()
    {
        Container.Bind<InputScript>().FromInstance(inputScript).AsSingle().NonLazy();
    }
}
