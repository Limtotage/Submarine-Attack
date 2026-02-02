using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerLevel3 : MonoBehaviour
{
    public static EnemyManagerLevel3 Instance;
    private int _enemyCount = 0;
    private bool once = true;
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

    void Update()
    {
        _enemyCount = EnemyManager.Instance.GetEnemyCount();
        if (_enemyCount == 30 && once)
        {
            once = false;
            Debug.Log("Stage Clear");
            StageController.Instance.OnStageCleared();
            //TriggerLevelEnd;
        }
    }
}
