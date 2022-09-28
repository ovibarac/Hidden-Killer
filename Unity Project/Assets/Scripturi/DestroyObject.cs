using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float timpPanaDistruge = 2f;

    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
