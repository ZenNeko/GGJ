using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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
    }
    
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3,6);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(3,6, false);
    }
}
