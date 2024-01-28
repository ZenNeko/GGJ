using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lVelo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lVelo = rb.velocity;
        Destroy(gameObject,15f);
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var speed = lVelo.magnitude;
        var direction = Vector3.Reflect(lVelo.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0f);
    }
}
