using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class EnemySpeedChange : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private List<EnemyMovement> enemyList = new List<EnemyMovement>();

    public CompositeDisposable disposable = new CompositeDisposable();

    private void Start() => StartCoroutine(GetEnemyCoroutine());

    private IEnumerator GetEnemyCoroutine()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            EnemyMovement enemy = transform.GetChild(i)?.GetComponent<EnemyMovement>();
            if (enemy != null) enemyList.Add(enemy);
            yield return null;
        }
    }

    private void OnEnable()
    {
        playerSpeed.onChange += () => StartCoroutine(MoveCoroutine(playerSpeed.speed.Value));
        playerSpeed.onStop += () => StartCoroutine(StopCoroutine());
    }

    private IEnumerator MoveCoroutine(float speed)
    {
        if (speed > 5f)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Move(-25f, Mathf.Clamp(speed, 5f, 25f));
                yield return null;
            }
        }
    }

    private IEnumerator StopCoroutine()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].Move(25f, 5f);
            yield return null;
        }
    }
}
