using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackHandler : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject multiMissilePrefab;
    [SerializeField] private GameObject nukeMissilePrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float _attackDelay = 1f;
    [SerializeField] private float _multiDelay = 2.5f;
    [SerializeField] private int _multiGap = 1;
    private bool _canFire = true;
    private bool _canNuke = false;
    private Enums.MissileTypes currentMissile;
    void Start()
    {
        currentMissile = Enums.MissileTypes.Normal;
    }
    public void SetNuke()
    {
        _canNuke = true;
    }

    void Update()
    {
        HandleAttack();
        SwitchWeapon();
    }
    void HandleAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _canFire)
        {
            _canFire = false;
            switch (currentMissile)
            {
                case Enums.MissileTypes.Normal:
                    Attack(missilePrefab);
                    StartCoroutine(ResetFire(_attackDelay));
                    break;
                case Enums.MissileTypes.Multi:
                    multiAttack(multiMissilePrefab);
                    StartCoroutine(ResetFire(_multiDelay));
                    break;
                case Enums.MissileTypes.Nuke:
                    NukeAttack(nukeMissilePrefab);
                    currentMissile = Enums.MissileTypes.Normal;
                    StartCoroutine(ResetFire(_attackDelay));
                    break;
            }

        }
    }
    void NukeAttack(GameObject prefab)
    {
        Vector3 attackpoint = new Vector3(firepoint.position.x , firepoint.position.y+0.3f, firepoint.position.z);
        GameObject bullet = Instantiate(prefab, attackpoint, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
        Destroy(bullet, 3f);
    }
    void Attack(GameObject prefab)
    {
        GameObject bullet = Instantiate(prefab, firepoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
        Destroy(bullet, 3f);
    }
    void multiAttack(GameObject prefab)
    {
        for (int i = -_multiGap; i <= _multiGap; i += _multiGap)
        {
            Vector3 attackpoint = new Vector3(firepoint.position.x + i, firepoint.position.y, firepoint.position.z);
            GameObject bullet = Instantiate(prefab, attackpoint, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.up * bulletSpeed;
            Destroy(bullet, 3f);
        }
    }
    private IEnumerator ResetFire(float val)
    {
        yield return new WaitForSeconds(val);
        _canFire = true;
    }
    void SwitchWeapon()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 2) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentMissile =
                currentMissile == Enums.MissileTypes.Multi ?
                Enums.MissileTypes.Normal : Enums.MissileTypes.Multi;
        }
        if (Input.GetKeyDown(KeyCode.Q) && _canNuke)
        {
            _canNuke = false;
            currentMissile = Enums.MissileTypes.Nuke;
        }
    }
}
