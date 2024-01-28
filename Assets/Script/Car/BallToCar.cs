using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToCar : MonoBehaviour
{
    [SerializeField] private AudioSource hurtEffect;

    // Start is called before the first frame update
    void Start()
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                hurtEffect.Play();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
