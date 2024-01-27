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
        if (Time.deltaTime % 10 == 0)
        {
            var spawnPower1 = Instantiate(powerUp1prefab,)
        }
        if (gameEnd)
        {
            overScreen.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthManager.health = 3;
        HealthManager.health2 = 3;
    }
}
