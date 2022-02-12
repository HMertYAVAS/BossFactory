using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffAreaController : MonoBehaviour
{
    public int takeOffAreaBoxesLine;

    public List<GameObject> takeOffAreaBoxesList;

    BoxesController boxesController;

    public bool canTakeOff
    {
        get
        {
            return takeOffAreaBoxesLine < takeOffAreaBoxesList.Count  && boxesController.BoxesListLine >= 0;
        }
    }
    private void Update()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        boxesController = other.gameObject.GetComponent<BoxesController>();
        if (other.gameObject.CompareTag("Player") && canTakeOff || other.gameObject.CompareTag("Worker") && canTakeOff)
        {
            //kutunun yere hareketi
            boxesController.GetBoxesObject().transform.DOMove(GetTakeOffAreaLinePosition(), 0.15f).OnComplete(() => SetActiveObject());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Worker"))
        {
            boxesController.ComeBackMainPosition();
        }
    }

    Vector3 GetTakeOffAreaLinePosition()
    {
        return takeOffAreaBoxesList[takeOffAreaBoxesLine].transform.position;
    }

    void SetActiveObject()
    {
        takeOffAreaBoxesList[takeOffAreaBoxesLine].gameObject.SetActive(true);
        takeOffAreaBoxesLine++;
        boxesController.SetDeactivatedBoxesObject();
        //boxesController.ComeBackMainPosition();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
