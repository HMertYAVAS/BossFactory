using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBandBoxeController : MonoBehaviour
{
    public GameObject secondPoint;

    public EndCollectAreaController EndCollectAreaController;

    private void Update()
    {
        if (EndCollectAreaController.canWorktoBand)
        {
            transform.DOMove(EndCollectAreaController.GetActiveLinePosition(), 1f).OnComplete(() => CallBackPoint());
        }
    }

    public void CallBackPoint()
    {
        if (transform.gameObject.activeInHierarchy)
        {
            EndCollectAreaController.AddBoxe();
        }
        gameObject.SetActive(false);
        transform.position = secondPoint.transform.position;
    }
}
