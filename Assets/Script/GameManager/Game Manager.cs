using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:Assets/Script/GameManager/Game Manager.cs
public class GameManager : MonoBehaviour
{
    public static bool gameEnd;

    private void Awake()
    {
        gameEnd = false;
========
public class gamemaneger : MonoBehaviour
{
    private int PlayerHP = 3;
    private float Time = 120f;
    public GameObject  play1;
    public GameObject  play2;
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.name =="play1")
        {
            Destroy(play1);
        }
>>>>>>>> move:Assets/Script/gamemaneger.cs
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
