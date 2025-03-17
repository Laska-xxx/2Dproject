using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) animator.SetBool("RunningToUp", true);
        else animator.SetBool("RunningToUp", false);

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) animator.SetBool("RunningToRight", true);
        else animator.SetBool("RunningToRight", false);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) animator.SetBool("RunningToLeft", true);
        else animator.SetBool("RunningToLeft", false);

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) animator.SetBool("RunningToDown", true);
        else animator.SetBool("RunningToDown", false);
    }
}
