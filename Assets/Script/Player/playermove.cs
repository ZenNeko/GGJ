using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float movespeed;
    private float speedX, speedY;
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

            if (Input.GetKey(KeyCode.W))
            {
                speedY = 1 * movespeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                speedY = -1 * movespeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                speedX = 1 * movespeed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                speedX = -1 * movespeed;
            }
            else
            {
                speedY = 0 * movespeed;
                speedX = 0 * movespeed;
            }
        }
        {
            
            
        }
        rb.velocity = new Vector2(speedX, speedY);
        
        
        
    }
    
}
