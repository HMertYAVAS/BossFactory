using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffAreaController : MonoBehaviour
{
    public int takeOffAreaBoxesLine;

    public List<GameObject> takeOffAreaBoxesList;
    public List<Vector3> takeOffAreaBoxesListMainPosition;

    BoxesController boxesController;

    public bool startTimer;
    private void Start()
    {
        takeOffAreaBoxesLine = -1;
        for (int i = 0; i < takeOffAreaBoxesList.Count; i++)
        {
            takeOffAreaBoxesListMainPosition.Add(takeOffAreaBoxesList[i].transform.localPosition);
        }

    }
    public bool canWork;

    public bool canTakeOff
    {
        get
        {
            return takeOffAreaBoxesLine < takeOffAreaBoxesList.Count && boxesController.BoxesListLine > 0;
        }
    }
    private void Update()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BoxesController>().BoxesListLine == -1)
        {
            canWork = true;
        }
        else
        {
            canWork = false;
        }
        boxesController = other.gameObject.GetComponent<BoxesController>();
        if (other.gameObject.CompareTag("HaveBox") && canTakeOff)
        {
            boxesController.BoxesListLine--;
            //kutunun yere hareketi
            boxesController.GetBoxesObject().transform.DOMove(GetTakeOffAreaLinePosition(), 0.15f).OnComplete(() => SetActiveObject());
            startTimer = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HaveBox") || other.gameObject.CompareTag("Worker") || other.gameObject.CompareTag("Player"))
        {
            boxesController.ComeBackMainPosition();
            canWork = true;
        }
    }

    Vector3 GetTakeOffAreaLinePosition()
    {
        if (takeOffAreaBoxesLine < 0)
        {
            takeOffAreaBoxesLine++;
        }
        return takeOffAreaBoxesList[takeOffAreaBoxesLine].transform.position;
    }

    void SetActiveObject()
    {

        takeOffAreaBoxesList[takeOffAreaBoxesLine].gameObject.SetActive(true);
        takeOffAreaBoxesLine++;
        boxesController.BoxesList[boxesController.BoxesListLine].transform.gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void CalltoMainPosition()
    {
        takeOffAreaBoxesList[takeOffAreaBoxesLine - 1].transform.localPosition = takeOffAreaBoxesListMainPosition[takeOffAreaBoxesLine];
        takeOffAreaBoxesLine--;
        if (takeOffAreaBoxesLine == 0)
        {
            takeOffAreaBoxesLine = -1;
        }
    }
}
