using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KillTutorial : MonoBehaviour
{


    public float cooldown;
    public float maxCooldown = 1;
    public bool omorInSecundaAsta;
    float timpMaxAnimatie = 0.05f;
    public float timpAnimatie;
    public int kills;

    public bool fugitau;
    public bool click;

    public bool gameOver;

    public TMP_Text killsUI;
    public GameObject GataFra;
    public GameObject varf;
    int ct;

    private void Start()
    {
        omorInSecundaAsta = false;
        gameOver = false;
        fugitau = false;
        click = false;
        timpMaxAnimatie = 0.05f;
        timpAnimatie = timpMaxAnimatie;
        kills = 0;
        ct = 0;
        varf = GameObject.Find("Varf");
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (omorInSecundaAsta)
        {
            timpAnimatie -= Time.deltaTime;
        }

        if (timpAnimatie <= 0)
        {
            omorInSecundaAsta = false;
            timpAnimatie = timpMaxAnimatie;
        }

        if (gameOver)
        {
            GataFra.SetActive(true);
            GameOver();
        }
        attacc();
        killsUI.text = "Kills: " + kills;
        if (Input.GetMouseButton(0))
        {
            AnimatieOmorat();
        }
    }

    void AnimatieOmorat()//nu vrea
    {
        //desfac capacu
        /*if (ct == 0)
        {*/
        varf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*    Debug.Log("ar trb stea" + ct);
        }else
        {
            Vector3 poz = new Vector3(-0.01030473f, 3.127547f, 0);
            varf.transform.position = Vector3.MoveTowards(varf.transform.position, poz, 200 * Time.deltaTime);
            Debug.Log("ar trb sa se miste" + ct);
        }
            ct++;*/
    }

    void attacc()
    {
        //animatie
        if (Input.GetMouseButton(0) && cooldown <= 0)
        {
            click = true;
            //AnimatieOmorat();
            omorInSecundaAsta = true;
            cooldown = maxCooldown;
        }
        if (!omorInSecundaAsta)
        {
            click = false;
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            click = false;
        }*/
    }

    public void GameOver()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(2);
    }
}
