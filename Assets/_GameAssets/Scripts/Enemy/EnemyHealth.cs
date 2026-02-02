using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int _scoreAmount = 10;
    [SerializeField] private GameObject explotionFX;

    private int currentHealth;
    void Start()
    {
        EnemyManager.Instance.IncreaseEnemy();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(explotionFX, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayDestroySFX();
            Destroy(gameObject);
            UIManagers.Instance.AddScore(_scoreAmount);
            EnemyManager.Instance.DecreaseEnemy();
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
