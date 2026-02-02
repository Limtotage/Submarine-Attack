using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    private int _enemyCount=0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetEnemyCount()
    {
        return _enemyCount;
    }
    public void SetEnemyCount(int killCount)
    {
        _enemyCount-=killCount;
    }
    public void IncreaseEnemy()
    {
        _enemyCount+=1;
    }
    public void DecreaseEnemy()
    {
        _enemyCount-=1;
    }

    void Update()
    {
        if (_enemyCount <= 0)
        {
            Debug.Log("YouWin");
            LevelManager.Instance.LevelWon();
            //TriggerLevelEnd;
        }
    }
}
