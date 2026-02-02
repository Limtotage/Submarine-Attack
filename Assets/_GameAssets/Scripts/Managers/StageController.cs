using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public static StageController Instance;
    [SerializeField] private GameObject Mines;
    [SerializeField] private Animator Stage2;


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
            Mines.SetActive(true);
        }

        if (currentStage == 2)
        {
            Stage2.Play("Attack2");
        }
    }
}
