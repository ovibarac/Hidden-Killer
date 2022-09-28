using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    public Kill kill;

    private void Start()
    {
        anim = GetComponent<Animator>();
        kill = GetComponentInParent<Kill>();
    }

    private void Update()
    {
        if (kill.click)
        {
            anim.SetTrigger("Click");
        }
    }
}
