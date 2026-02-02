using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayDamageTaken()
    {
        animator.Play("Hurt");
    }

    void Update()
    {
        
    }
}
