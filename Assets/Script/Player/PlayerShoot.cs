using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 20f;
    [SerializeField] private AudioSource shootBallSound;
    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            shootBallSound.Play();
            var shootBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed;
        }
    }
}
