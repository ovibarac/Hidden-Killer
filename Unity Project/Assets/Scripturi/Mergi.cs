using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mergi : MonoBehaviour
{
    public AudioClip[] suneteMoarte;

    public AudioSource sursaAudio;
    public AudioSource sursaFugit;
    public AudioSource moare;

    private int stanga;
    private float viteza;
    private Rigidbody2D rb;

    public Kill kill;
    public GameObject bloodSplash;

    public bool triggerabil;
    bool fugeAsta;
    int ct = 0;
    int oara;

    public GameObject varf;

    private void Start()
    {
        sursaAudio = GameObject.Find("Pumpkin animatie").GetComponent<AudioSource>();
        moare = GameObject.Find("blob").GetComponent<AudioSource>();

        suneteMoarte = new AudioClip[4];

        suneteMoarte[0] = Resources.Load<AudioClip>("headchop");
        suneteMoarte[1] = Resources.Load<AudioClip>("HeadPop");
        suneteMoarte[2] = Resources.Load<AudioClip>("SPLAT2");
        suneteMoarte[3] = Resources.Load<AudioClip>("SQUISH11");

        bloodSplash = Resources.Load<GameObject>("BloodSplash");

        viteza = Random.Range(1.5f, 3.5f);
        triggerabil = false;
        fugeAsta = false;

        oara = 0;

        kill = GameObject.Find("blob").GetComponent<Kill>();

        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        if (transform.position.x < 0)
        {
            stanga = 1;
        }
        else
        {
            stanga = -1;
        }

        transform.localScale = new Vector3(stanga * transform.localScale.x, Random.Range(0.16f, 0.23f), transform.localScale.z);

        rb = GetComponent<Rigidbody2D>();

        varf = GameObject.Find("Varf");
    }
    //Eventual fac sa se mai si opreasca sa se uite si din alea
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(stanga * viteza * Time.fixedDeltaTime, 0.0f, 0.0f));
    }

    private void Update()
    {
        float offset = 0;//0.420f;
        float cameraEdgeSt = 3.583f;
        float cameraEdgeDr = 3.583f;

        if ((transform.position.x < offset && transform.position.x > -cameraEdgeSt && stanga == 1) || (transform.position.x > -offset && transform.position.x < cameraEdgeDr && stanga == -1))
        {
            //ANIMATIE SAU SHADER HIGHLIGHT CEVA SA ARATE CA TE VEDE
            if (kill.omorInSecundaAsta)
            {
                kill.gameOver = true;
                kill.fugitau = true;
            }
        }

        if (kill.fugitau && ct == 0)
        {
            fugeAsta = true;
        }

        if (transform.position.x > 25 || transform.position.x < -25)
        {
            Destroy(gameObject);
        }

        if (fugeAsta)
        {
            sursaFugit.Play();

            if (transform.position.x >= 0 && stanga == -1)
            {
                transform.localScale = new Vector3(stanga * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                stanga *= -1;
                
            }else if(transform.position.x < 0 && stanga == 1)
            {
                stanga *= -1;
                transform.localScale = new Vector3(stanga * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
               
            viteza *= 4;
            
            fugeAsta = false;

        }
        if(kill.fugitau)
            ct++;
    }

    private void OnMouseOver()
    {
        if (triggerabil)
        {
            //highlight
            if (Input.GetMouseButton(0) && kill.cooldown <= 0)//SE POATE SA NU FIE BINE PENTRU CA ATACA SI IN KILL SI AICI
            {
                kill.click = true;
                AnimatieOmorat();
                kill.omorInSecundaAsta = true;
                kill.cooldown = kill.maxCooldown;
                kill.kills++;
                die();
            }
        }
    }

    void AnimatieOmorat()
    {
        //desfac capacu
        if (oara == 0)
        {
            varf.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("ar trb stea");
        }

        else
        {
            Vector3 poz = new Vector3(-0.01030473f, 3.127547f, 0);
            varf.transform.position = Vector3.MoveTowards(varf.transform.position, poz, Time.deltaTime);
            Debug.Log("ar trb sa se miste");
        }
        oara++;
    }

    void die()
    {
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        int i = Random.Range(0, suneteMoarte.Length);
        Debug.Log(i);
        sursaAudio.clip = suneteMoarte[i];
        sursaAudio.Play();
        //moare.Play();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "blob")
        {
            triggerabil = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "blob")
        {
            triggerabil = false;
        }
    }
}
