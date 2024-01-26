using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            ball.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed;
        }
    }
}
