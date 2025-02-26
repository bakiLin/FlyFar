using UnityEngine;
using YG;
using Zenject;

public class FlyManager : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private FlyPower flyPower;

    [Inject]
    private TextManager textManager;

    [SerializeField]
    private GameObject powerUI;

    [SerializeField]
    private int[] powerNumber;

    private void Awake()
    {
        int level = YandexGame.savesData.playerLevel[0];

        if (level > 0)
        {
            inputScript.powerOn = true;
            flyPower.num = powerNumber[level - 1];
            textManager.SetPower(flyPower.num);
            powerUI.SetActive(true);
        }
    }
}
