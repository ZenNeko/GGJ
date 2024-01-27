using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play2move : MonoBehaviour
{
    public float movespeed = 5;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            // Get input values for W, A, S, D keys
            float horizontalInput = 0f;
            float verticalInput = 0f;

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
            transform.Translate(movement * movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }


    }
}
