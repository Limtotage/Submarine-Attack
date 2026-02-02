using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount=1;
    [SerializeField] private GameObject missileFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IHealth>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IHealth>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
        }
        SoundManager.Instance.PlayMissileSFX();
        Vector3 targetPos= collision.gameObject.transform.position;
        GameObject fX= Instantiate(missileFX,targetPos,Quaternion.identity);
        Destroy(fX,2f);
    }
}
