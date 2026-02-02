using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float exitY = 12f;
    [SerializeField] private float delayBeforeNext = 0.5f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    public void LevelWon()
    {
        StartCoroutine(LevelWonRoutine());
    }

    IEnumerator LevelWonRoutine()
    {
        player.GetComponent<PlayerMovement>()._canMove = false;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        while (player.position.y < exitY)
        {
            player.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(delayBeforeNext);
        Debug.Log("NextLevel");
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            UIManagers.Instance.ThanksForPlay();
        }
        else {
            StopAllCoroutines(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }
}
