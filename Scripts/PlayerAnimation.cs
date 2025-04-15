using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    bool isRunning;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartRunningAnimation()
    {
        animator.Play("Run");
    }
}