using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float movespeed = 10;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, movespeed* -2, 0f);
        transform.Translate(movement * Time.deltaTime);
        
        
    }

    
}
