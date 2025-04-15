using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    enum State
    {
        Idle,
        Running,
    }

    [Header("References")] [SerializeField]
    private PlayerAnimation playerAnimation;

    [Header("Movement")] [SerializeField] private float moveSpeed = 5f;

    private State state;

    private void Start()
    {
        Application.targetFrameRate = 60;

        state = State.Idle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRunning();
        }
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Running:
                MovePlayer();
                break;
        }
    }

    private void MovePlayer()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        StartRunning();
    }

    private void StartRunning()
    {
        playerAnimation.StartRunningAnimation();
        state = State.Running;
    }
}