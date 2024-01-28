using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play2move : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;   
    
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource shootBallSound;

    public Color powerMode1Color;
    private SpriteRenderer rend;
    public Transform ballSpawnPoint;
    public Transform ballSpawnPoint2;
    public Transform ballSpawnPoint3;
    public GameObject ballPrefab;
    public GameObject ballFastPrefab;
    public float ballSpeed = 50f;
    private int powerMode;
    
    public float shootCooldown = 0.5f; 
    private float shootCooldownTimer = 0f;
    
    // Start is called before the first frame update
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
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
                shootBall.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.up * ballSpeed* 2;
                shootBall2.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint2.up * ballSpeed* 2;
                shootBall3.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint3.up * ballSpeed* 2;
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
            rend.color = Color.white;
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

    void Move()
    {
        {
            // Get input values for W, A, S, D keys
            float horizontalInput = 0f;
            float verticalInput = 0f;
            
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                walkSound.Play();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow))
            {
                walkSound.Stop();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                verticalInput = 1f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontalInput = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                verticalInput = -1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontalInput = -1f;
            }

            // Calculate the movement direction
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

            // Normalize the movement vector to ensure consistent speed in all directions
            movement.Normalize();

            // Update the player's position based on input and speed
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        powerMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && shootCooldownTimer <= 0f)
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
        Move(); Rotate(); 
        ChangeColor();
    }
}
