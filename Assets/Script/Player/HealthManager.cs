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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hp)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            hp[i].sprite = fullHeart;
        }
        foreach (Image img2 in hp2)
        {
            img2.sprite = emptyHeart;
        }

        for (int i = 0; i < health2; i++)
        {
            hp2[i].sprite = fullHeart;
        }
    }
}
