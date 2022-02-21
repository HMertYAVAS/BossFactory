using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBandBoxesController : MonoBehaviour
{
    public GameObject firstStep;
    public GameObject startPoint;
    public float playTime;


    void Update()
    {
        transform.DOMove(firstStep.transform.position, playTime).OnComplete(() => SetDeactiveBoxes());
    }
    void SetDeactiveBoxes()
    {
        transform.gameObject.SetActive(false);
        transform.position = startPoint.transform.position;
    }
}
