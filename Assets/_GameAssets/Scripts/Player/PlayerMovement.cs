using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    public bool _isDead;
    public bool _canMove=true;
    private Rigidbody2D rb;
    void Start()
    {
        _isDead=false;
        rb = GetComponent<Rigidbody2D>();
    }
    public void Death(bool isDead)
    {
        _isDead = isDead;
    }

    void Update()
    {
        if(_isDead) return;
        HandleMovement();
        UpdateState();
    }
    void UpdateState()
    {
        float horizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        if (horizontal > 0)
        {
            bool running = Input.GetKey(KeyCode.LeftShift);
            PlayerStateManager.Instance.SetState(
                running ? Enums.PlayerStates.Running : Enums.PlayerStates.Walking
            );
        }
        else
        {
            PlayerStateManager.Instance.SetState(Enums.PlayerStates.Idle);
        }
    }
    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = running ? runSpeed : walkSpeed;

        Vector3 destination = new Vector3(horizontal, vertical, 0);
        transform.Translate(destination * speed * Time.deltaTime);
    }
}
