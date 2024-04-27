using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource hurtEffect;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hurtEffect.Play();
            if (other.gameObject.name == "Player 1")
            {
                HealthManager.health--;
                Debug.Log("Hit");
                if (HealthManager.health <= 0)
                {
                    GameManager.gameEnd = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(GetHurt());
                }
            }
            if (other.gameObject.name == "Player 2")
            {
                HealthManager.health2--;
                Debug.Log("Hit");
                if (HealthManager.health2 <= 0)
                {
                    GameManager.gameEnd = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(GetHurt());
                }
            }
        }

        if (other.gameObject.CompareTag("Car"))
        {
            hurtEffect.Play();
        }
        
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3,6);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(3,6, false);
    }
    
}
