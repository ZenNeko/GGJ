using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                GameManager.gameEnd = true;
                gameObject.SetActive(false);
            }
        }
    }
    
}
