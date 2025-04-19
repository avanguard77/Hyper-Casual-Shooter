using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class PlayerMoving : MonoBehaviour
{
    enum State
    {
        Idle,
        Running,
        Warzone
    }

    [Header("References")] [SerializeField]
    private PlayerAnimation playerAnimation;

    [Header("Movement")] [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float slowScaleTime = 1f;

    private float warzoneTimer;

    private Warzone thisWarzone;
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
            case State.Warzone:
                ManageStateWarzone();
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

    public void EnteredWarzoneCallBack(Warzone warzone)
    {
        if (thisWarzone != null)
            return;

        state = State.Warzone;
        thisWarzone = warzone;

        Time.timeScale = slowScaleTime;

        warzoneTimer = 0;
        playerAnimation.PlayAnimation(thisWarzone.GetAnimation(), thisWarzone.GetAnimationSpeed());
    }

    private void ManageStateWarzone()
    {
        warzoneTimer += Time.deltaTime / thisWarzone.GetDuration();

        transform.position = thisWarzone.GetPlayerSpline().EvaluatePosition(warzoneTimer);

        if (warzoneTimer >= 1)
        {
            ExitWarzone();
        }
    }

    private void ExitWarzone()
    {
        state = State.Running;
        playerAnimation.PlayAnimation("Run", 1);
        thisWarzone = null;
        Time.timeScale = 1;
    }
}