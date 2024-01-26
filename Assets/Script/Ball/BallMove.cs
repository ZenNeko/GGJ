using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 400f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(20f * Time.deltaTime *speed , 20f * Time.deltaTime *speed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
