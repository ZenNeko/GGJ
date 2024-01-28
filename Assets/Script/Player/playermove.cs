using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private int powerMode;
    public float movespeed = 5;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;
    
    private SpriteRenderer rend;
    public Color powerMode0Color;
    public Color powerMode1Color;
    
    public Transform ballSpawnPoint;
    public Transform ballSpawnPoint2;
    public Transform ballSpawnPoint3;
    public GameObject ballPrefab;
    public GameObject ballFastPrefab;
    public float ballSpeed = 50f;
    
    public float shootCooldown = 0.5f; 
    private float shootCooldownTimer = 0f;
    
    
    [SerializeField] private AudioSource shootBallSound;
    [SerializeField] private AudioSource walkSound;

    void Move()
    {
        {
            // Get input values for W, A, S, D keys
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.S))
            {
                walkSound.Play();
            }
            
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ||
                Input.GetKeyUp(KeyCode.S))
            {
                walkSound.Stop();
            }

            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                horizontalInput = -1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontalInput = 1f;
            }

            // Calculate the movement direction
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

            // Normalize the movement vector to ensure consistent speed in all directions
            movement.Normalize();

            // Update the player's position based on input and speed
            transform.Translate(movement * movespeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.V))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (powerMode == 0)
            {
                shootBallSound.Play();
                var shootBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
                shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed;
            }

            if (powerMode == 1)
            {
                shootBallSound.Play();
                var shootBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
                var shootBall2 = Instantiate(ballPrefab, ballSpawnPoint2.position, ballSpawnPoint2.rotation);
                var shootBall3 = Instantiate(ballPrefab, ballSpawnPoint3.position, ballSpawnPoint3.rotation);
                shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed;
                shootBall2.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint2.up * ballSpeed;
                shootBall3.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint3.up * ballSpeed;
                powerMode = 0;
            }

            if (powerMode == 2)
            {
                shootBallSound.Play();
                var shootBall = Instantiate(ballFastPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
                shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed * 5;
                powerMode = 0;
            }
        }
    }
    void ChangeColor()
    {
        if (powerMode == 0)
        {
            rend.color = powerMode0Color;
            ballSpawnPoint2.gameObject.SetActive(false);
            ballSpawnPoint3.gameObject.SetActive(false);
        }
        if (powerMode == 1)
        {
            rend.color = powerMode1Color;
            ballSpawnPoint2.gameObject.SetActive(true);
            ballSpawnPoint3.gameObject.SetActive(true);
        }
        if (powerMode == 2)
        {
            rend.color = Color.yellow;
            ballSpawnPoint2.gameObject.SetActive(false);
            ballSpawnPoint3.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            powerMode = 1;
            Destroy(other.gameObject);
         
        }

        if (other.gameObject.CompareTag("Speed"))
        {
            powerMode = 2;
            Destroy(other.gameObject);
     
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        powerMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && shootCooldownTimer <= 0f)
        {
            Shoot();
            // Reset the cooldown timer
            shootCooldownTimer = shootCooldown;
        }

        // Update the cooldown timer
        if (shootCooldownTimer > 0f)
        {
            shootCooldownTimer -= Time.deltaTime;
        }
        Move(); Rotate();
        ChangeColor();
        
        
        
    }
}
