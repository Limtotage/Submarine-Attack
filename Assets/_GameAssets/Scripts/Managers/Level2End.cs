using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachine;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachine.Follow = null;
            LevelManager.Instance.LevelWon();
        }
    }
}
