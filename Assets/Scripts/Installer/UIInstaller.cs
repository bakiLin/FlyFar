using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBarArrow powerBarArrow;

    [SerializeField]
    private ScoreManager scoreManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBarArrow>().FromInstance(powerBarArrow).AsSingle().NonLazy();

        Container.Bind<ScoreManager>().FromInstance(scoreManager).AsSingle().NonLazy();
    }
}
