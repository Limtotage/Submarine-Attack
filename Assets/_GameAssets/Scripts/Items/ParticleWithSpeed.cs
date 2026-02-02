using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var emission=particleSystem1.emission;
        emission.rateOverTime = rb.velocity.magnitude * 10f;
    }
}
