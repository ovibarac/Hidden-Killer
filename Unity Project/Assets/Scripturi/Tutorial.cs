using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject[] text;
    public GameObject textMoarte;
    public GameObject spawner;
    public GameObject spawner2;

    public Kill kill;

    int i;

    void Start()
    {
        i = 0;
    }

    void Update()
    {

        text[i].SetActive(true);

        if (i == 2)
        {
            spawner.SetActive(true);
        }
        if (i == 3)
        {
            spawner2.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            text[i].SetActive(false);
            if(i<3)
                i++;
            else
            {
                if(kill.kills == 5)
                    SceneManager.LoadScene(1);
            }
        }

        if (kill.gameOver)
        {
            text[3].SetActive(false);
            textMoarte.SetActive(true);
        }
    }
}
