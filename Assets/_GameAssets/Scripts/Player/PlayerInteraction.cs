using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerHealthManager health;
    [SerializeField] private GameObject explotionFX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            health.TakeDamage(1);
        }
        if (collision.CompareTag("LevelWon"))
        {
            LevelManager.Instance.LevelWon();
        }
        if (collision.CompareTag("Mine"))
        {
            Instantiate(explotionFX,collision.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            health.TakeDamage(3);
        }
        if (collision.CompareTag("Enemy"))
        {
            health.TakeDamage(1);
        }
    }
}
