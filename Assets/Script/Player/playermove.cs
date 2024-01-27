using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float movespeed = 5;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;
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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); Rotate();
    }
}
