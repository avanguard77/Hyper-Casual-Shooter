using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private PlayerMoving playerMoving;

    [Header("Player Detection")] [SerializeField]
    private float detectionRadius;

    private void Start()
    {
    }

    private void Update()
    {
        DetectStuff();
    }

    private void DetectStuff()
    {
        Collider[] detectedObject = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider hit in detectedObject)
        {
            if (hit.CompareTag("WarzoneEnter"))
            {
                EnterWarzoneCallBack(hit);
            }
        }
    }

    private void EnterWarzoneCallBack(Collider warzoneTriggerCollider)
    {
        Warzone warzone = warzoneTriggerCollider.GetComponentInParent<Warzone>();
        playerMoving.EnteredWarzoneCallBack(warzone);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}