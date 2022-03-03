using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffMarket : MonoBehaviour
{
    public int takeOffMarketBoxesLine;

    public List<GameObject> takeOffMarketBoxesList;
    public List<Vector3> takeOffMarketBoxesListMainPosition;

    BoxesController boxesController;

    private void Start()
    {
        takeOffMarketBoxesLine = -1;
        for (int i = 0; i < takeOffMarketBoxesList.Count; i++)
        {
            takeOffMarketBoxesListMainPosition.Add(takeOffMarketBoxesList[i].transform.localPosition);
        }
    }
    public bool canTakeOff
    {
        get
        {
            return takeOffMarketBoxesLine < takeOffMarketBoxesList.Count && boxesController.BoxesListLine > 0;
        }
    }
    private void Update()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        boxesController = other.gameObject.GetComponent<BoxesController>();
        if (other.gameObject.CompareTag("HaveProduct") && canTakeOff)
        {
            //kutunun yere hareketi
                    boxesController.BoxesListLine--;

            boxesController.GetBoxesObject().transform.DOMove(GetTakeOffAreaLinePosition(), 0.15f).OnComplete(() => SetActiveObject());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Worker") || other.gameObject.CompareTag("HaveProduct"))
        {
           // boxesController.ComeBackMainPosition();
        }
    }

    Vector3 GetTakeOffAreaLinePosition()
    {
        if (takeOffMarketBoxesLine < 0)
        {
            takeOffMarketBoxesLine++;
        }
        return takeOffMarketBoxesList[takeOffMarketBoxesLine].transform.position;
    }

    void SetActiveObject()
    {
        takeOffMarketBoxesList[takeOffMarketBoxesLine].gameObject.SetActive(true);
        takeOffMarketBoxesLine++;
        boxesController.SetDeactivatedProductObject();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void CalltoMainPosition()
    {
        takeOffMarketBoxesList[takeOffMarketBoxesLine - 1].transform.localPosition = takeOffMarketBoxesListMainPosition[takeOffMarketBoxesLine];
        takeOffMarketBoxesLine--;
    }
}
