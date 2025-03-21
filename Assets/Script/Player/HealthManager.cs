using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public static int health2 = 3;

    public Image[] hp;
    public Image[] hp2;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void ShowHpP1()
    {
        foreach (Image img in hp)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            hp[i].sprite = fullHeart;
        }
    }

    void ShowHpP2()
    {
        foreach (Image img2 in hp2)
        {
            img2.sprite = emptyHeart;
        }

        for (int i = 0; i < health2; i++)
        {
            hp2[i].sprite = fullHeart;
        }
    }

    public void regaeme()
    {   
        health = 3;
        health2 = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        regaeme();
    }

    // Update is called once per frame
    void Update()
    {
        
        ShowHpP1();
        ShowHpP2();
    }
}
