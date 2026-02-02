using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthManager : MonoBehaviour, IHealth
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    [SerializeField] private UnityEvent OnDamageTaken;
    [SerializeField] private BoolEvent OnDead;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject destroyVFX;
    public CinemachineImpulseSource impulseSource;
    private int currentHealth;
    private bool _isDead = false;
    private bool _canHurt = true;
    private float _damageDelay = 1f;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        UIManagers.Instance.Heal(amount);
    }
    public bool GetIsDead()
    {
        return _isDead;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        impulseSource.GenerateImpulse();
        if (!_canHurt) return;
        _canHurt = false;
        OnDamageTaken?.Invoke();
        StartCoroutine(ResetDamage());
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDead?.Invoke(_isDead);
            _isDead = true;
            currentHealth = 0;
            StartCoroutine(Death());
        }
        UIManagers.Instance.TakeDamage(damage);
    }
    private IEnumerator Death()
    {
        SoundManager.Instance.PlayDestroySFX();
        Instantiate(destroyVFX,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.GameOver();
    }
    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(_damageDelay);
        _canHurt = true;
    }
}
