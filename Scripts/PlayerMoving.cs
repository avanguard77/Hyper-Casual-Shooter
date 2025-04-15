using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public event EventHandler PlayerMoved;
    
    [Header("Movement")] [SerializeField] private float moveSpeed = 5f;

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        PlayerMoved?.Invoke(this, EventArgs.Empty);
    }
}