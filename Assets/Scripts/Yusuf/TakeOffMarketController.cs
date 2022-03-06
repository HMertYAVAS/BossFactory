using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffMarketController : MonoBehaviour
{
    public int takeOffAreaBoxesLine;

    public List<GameObject> takeOffAreaBoxesList;
    public List<Vector3> takeOffAreaBoxesListMainPosition;

    BoxesController boxesController;

    public bool startTimer;

    SoundManager soundManager;
    private void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        takeOffAreaBoxesLine = -1;
        for (int i = 0; i < takeOffAreaBoxesList.Count; i++)
        {
            takeOffAreaBoxesListMainPosition.Add(takeOffAreaBoxesList[i].transform.localPosition);
        }
    }

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
        boxesController = other.gameObject.GetComponent<BoxesController>();
        if (other.gameObject.CompareTag("HaveProduct") && canTakeOff)
        {
            boxesController.BoxesListLine--;
            //kutunun yere hareketi
            boxesController.GetBoxesObject().transform.DOMove(GetTakeOffAreaLinePosition(), 0.15f).OnComplete(() => SetActiveObject());
            startTimer = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HaveProduct") || other.gameObject.CompareTag("Worker") || other.gameObject.CompareTag("Player"))
        {
            boxesController.ComeBackMainPosition();
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
        soundManager.PlayerCashSound();
        takeOffAreaBoxesList[takeOffAreaBoxesLine].gameObject.SetActive(true);
        takeOffAreaBoxesLine++;
        boxesController.ProductList[boxesController.BoxesListLine].transform.gameObject.SetActive(false);
        MoneyController.instance.SellItem(10);
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
