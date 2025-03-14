using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private PowerBar powerBar;

    [SerializeField]
    private TextManager textManager;

    [SerializeField]
    private FlyBar flyBar;

    [SerializeField]
    private GameOver gameOver;

    [SerializeField]
    private AudioManager audioManager;

    public override void InstallBindings()
    {
        Container.Bind<PowerBar>().FromInstance(powerBar).AsSingle().NonLazy();

        Container.Bind<TextManager>().FromInstance(textManager).AsSingle().NonLazy();

        Container.Bind<FlyBar>().FromInstance(flyBar).AsSingle().NonLazy();

        Container.Bind<GameOver>().FromInstance(gameOver).AsSingle().NonLazy();

        Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle().NonLazy();
    }
}
