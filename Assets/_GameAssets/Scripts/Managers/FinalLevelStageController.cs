using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelStageController : MonoBehaviour
{
    public static FinalLevelStageController Instance;
    [SerializeField] private GameObject Mines;
    [SerializeField] private GameObject Parkur;
    [SerializeField] private Animator LastAttack;
    [SerializeField] private Animator BossAttack;


    private int currentStage = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void OnStageCleared()
    {
        currentStage++;
        if (currentStage == 1)
        {
            Parkur.SetActive(true);
        }

        if (currentStage == 2)
        {
            Parkur.SetActive(false);
            Mines.SetActive(true);
        }
        if (currentStage == 3)
        {
            Mines.SetActive(false);
            LastAttack.Play("filo2Attack");
            
        }
        if (currentStage == 4)
        {
            BossAttack.Play("BossAttack");
        }
    }
}