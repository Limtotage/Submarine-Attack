using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerLevel4 : MonoBehaviour
{
    public static EnemyManagerLevel4 Instance;
    private int _enemyCount = 0;
    private bool once = true;
    private bool second = true;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()//71
    {
        _enemyCount = EnemyManager.Instance.GetEnemyCount();
        if (_enemyCount == 31 && once)
        {
            once = false;
            Debug.Log("Stage Clear");
            FinalLevelStageController.Instance.OnStageCleared();
        }
        if (_enemyCount == 1 && second)
        {
            second = false;
            Debug.Log("Stage Clear");
            FinalLevelStageController.Instance.OnStageCleared();
        }
    }
}
