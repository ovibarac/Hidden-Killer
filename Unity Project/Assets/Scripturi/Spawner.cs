using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fata;
    public GameObject baiat;

    public float offset;

    float timpIntrePersoane;
    float maxTIntreP = 6;//sa scada in timp ce merge jocu

    public Kill kill;
    int care;

    private void Start()
    {
        maxTIntreP = Random.Range(3,5);
        Instantiate(fata, transform.position, transform.rotation);
        timpIntrePersoane = maxTIntreP + offset;
        kill = GameObject.Find("blob").GetComponent<Kill>();
        
    }

    private void Update()
    {
        timpIntrePersoane -= Time.deltaTime;
        maxTIntreP -= 0.0002f;
        //Debug.Log(maxTIntreP);

        care = Random.Range(1, 3);

        if (timpIntrePersoane <= 0 && !kill.gameOver) //niste reguli mai complexe ar fi bune 
        {
            if(care == 1)
                Instantiate(fata, transform.position, transform.rotation);
            else if(care == 2)
                Instantiate(baiat, transform.position, transform.rotation);//cu random chestii vad io cum cu constructor
            timpIntrePersoane = maxTIntreP;
        }
    }
}
