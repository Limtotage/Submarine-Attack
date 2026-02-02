using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAttack : MonoBehaviour
{
    [SerializeField] private Transform firepoint; 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float attackDelay;
    private float _timer;
    void Start()
    {
        _timer=attackDelay;
    }

    void Update()
    {
        _timer-=Time.deltaTime;
        if (_timer <= 0)
        {
            BasicAttack();
            _timer=attackDelay;
        }
    }
    void BasicAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed;
        Destroy(bullet, 3f);
    }
    
}
