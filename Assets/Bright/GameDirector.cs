using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static int hp = 3;

    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    
    void Start()
    {
        HP1.GetComponent<Image>().enabled = true;
        HP2.GetComponent<Image>().enabled = true;
        HP3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 2:
                HP3.GetComponent<Image>().enabled = false;
                break;
            case 1:
                HP2.GetComponent<Image>().enabled = false;
                break;
            case 0:
                HP1.GetComponent<Image>().enabled = false;
                //game over
                break;
        }
    }
}
