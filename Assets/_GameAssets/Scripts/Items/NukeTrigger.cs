using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NukeTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnNukeCollected;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnNukeCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
