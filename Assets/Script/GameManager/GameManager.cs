using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd;
    private Time time;
    public GameObject overScreen;
    public GameObject powerUp1prefab;
    public GameObject player1Win;
    public GameObject player2Win;
    
    private void Awake()
    {
        gameEnd = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            overScreen.SetActive(true);
            if (HealthManager.health <= 0)
            {
                player2Win.SetActive(true);
                player1Win.SetActive(false);
            }
            if (HealthManager.health2 <= 0)
            {
                player1Win.SetActive(true);
                player2Win.SetActive(false);
            }
            Time.timeScale = 0;
        }
        

    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthManager.health = 3;
        HealthManager.health2 = 3;
    }
}
