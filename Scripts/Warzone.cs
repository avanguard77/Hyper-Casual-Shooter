using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private string animation;
    [SerializeField] private float animationSpeed;
    [FormerlySerializedAs("spline")] [SerializeField] SplineContainer playerSpline;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Spline GetPlayerSpline()
    {
        return playerSpline.Spline;
    }

    public float GetDuration()
    {
        return duration;
    }

    public string GetAnimation()
    {
        return animation;
    }

    public float GetAnimationSpeed()
    {
        return animationSpeed;
    }
}
