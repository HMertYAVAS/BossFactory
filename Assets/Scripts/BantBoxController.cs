using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BantBoxController : MonoBehaviour
{
    public float boxTime;

    public Transform endPoint;
    void Update()
    {
        transform.DOMove(endPoint.position, boxTime);
    }
}
