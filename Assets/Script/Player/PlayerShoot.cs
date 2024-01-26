using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 2000f;

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            var shootBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed;
        }
    }
}
