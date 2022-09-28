using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTutorial : MonoBehaviour
{
    public Animator anim;
    public KillTutorial kill;

    private void Start()
    {
        anim = GetComponent<Animator>();
        kill = GetComponentInParent<KillTutorial>();
    }

    private void Update()
    {
        if (kill.click)
        {
            anim.SetTrigger("Click");
        }
    }
}
