using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackHandler : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float attackDelay;
    [SerializeField] private float _multiGap=0.1f;
    [SerializeField] private float _multiTimeGap=0.25f;
    private float _timer;
    void Start()
    {
        _timer = attackDelay;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            StartCoroutine(multiAttack());
            _timer = attackDelay;
        }
    }

    IEnumerator multiAttack()
    {
        for (float i = -_multiGap*5; i <= _multiGap*5; i += _multiGap)
        {
            Vector3 attackpoint = new Vector3(firepoint.position.x + i, firepoint.position.y, firepoint.position.z);
            GameObject bullet = Instantiate(bulletPrefab, attackpoint, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * bulletSpeed;
            Destroy(bullet, 3f);
            yield return new WaitForSeconds(_multiTimeGap);
        }
    }
}
