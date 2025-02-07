using UnityEngine;
using Zenject;

public class PlayerPower : MonoBehaviour
{
    [Inject]
    private UITextManager uiTextManager;

    [SerializeField]
    private GameObject leftWing, rightWing;

    [SerializeField]
    private float powerForce;

    [SerializeField]
    private int powerNumber;

    private void Awake()
    {
        uiTextManager.SetPower(powerNumber);
    }

    public void FlyPower()
    {
        if (powerNumber > 0)
        {
            leftWing.SetActive(true);
            Vector3 position = new Vector3(0f, 0f, 40f);
            leftWing.GetComponent<WingBehaviour>().Power(position, powerForce);

            rightWing.SetActive(true);
            position = new Vector3(0f, 0f, -40f);
            rightWing.GetComponent<WingBehaviour>().Power(position, powerForce);

            powerNumber--;
            uiTextManager.SetPower(powerNumber);
        }
    }
}
