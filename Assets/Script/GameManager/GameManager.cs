using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd;
    private int PlayerHP = 3;
    private float Time = 120f;
    public GameObject  play1;
    public GameObject  play2;
    public GameObject overScreen;
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
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
