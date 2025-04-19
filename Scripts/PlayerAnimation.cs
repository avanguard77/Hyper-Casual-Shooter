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
        PlayAnimation("Run");
    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }
    public void PlayAnimation(string animation,float animationSpeed)
    {
        animator.speed = animationSpeed;
        animator.Play(animation);
    }
}