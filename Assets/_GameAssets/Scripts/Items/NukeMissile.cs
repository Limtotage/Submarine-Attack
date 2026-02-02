using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NukeMissile : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private GameObject missileFX;
    [SerializeField] private LayerMask damageLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Missile"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,5f,damageLayer);
            foreach (Collider2D hit in hits)
            {
                IHealth health = hit.GetComponent<IHealth>();
                if (health != null)
                {
                    health.TakeDamage(damageAmount);
                }
            }
            Destroy(gameObject);
        }
        Vector3 targetPos = collision.gameObject.transform.position;
        GameObject fX = Instantiate(missileFX, targetPos, Quaternion.identity);
        SoundManager.Instance.PlayNukeMissileSFX();
        Destroy(fX, 2f);
    }
}