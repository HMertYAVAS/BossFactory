using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBandController : MonoBehaviour
{
    public TakeOffAreaController takeOffAreaController;
    public List<GameObject> boxesList;
    int boxesListLine;
    public float bandPeriodTime;

    public float timer;
    public Transform startPoint;

    public bool canWork
    {
        get
        {
            return takeOffAreaController.takeOffAreaBoxesLine > 0 && timer <= 0;
        }
    }
    private void Start()
    {
        boxesListLine = 0;
        timer = bandPeriodTime;
    }

    private void Update()
    {

        if (timer >= 0 && takeOffAreaController.startTimer)
        {
            timer -= Time.deltaTime;
        }

        if (canWork)
        {
            timer = bandPeriodTime;
            MoveToStartPoint();
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MoveToStartPoint();
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.SetActive(false);
        }
    }
    public void MoveToStartPoint()
    {
        takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine - 1].transform.DOMove(startPoint.position, 1f).OnComplete(() => takeOffAreaController.CalltoMainPosition());
        SetActiveBoxes();
    }
    public void SetActiveBoxes()
    {
        boxesList[boxesListLine].transform.gameObject.SetActive(true);
        boxesListLine++;
        //listenin sonuna gelirse baþa sarsmasý için yazýldý
        if (boxesListLine >= boxesList.Count)
        {
            boxesListLine = 0;
        }
    }
    public void SetDeActiveTakeOffAreaBoxes()
    {
        takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine - 1].SetActive(false);
    }
    void SetTakeOffAreaLine()
    {
        takeOffAreaController.takeOffAreaBoxesLine--;
    }
    public void SetActiveBoxesForRobots()
    {
        //içinde tekrardan kontrol etmem robot kollarý için
        if (canWork)
        {
            boxesList[takeOffAreaController.takeOffAreaBoxesLine].gameObject.SetActive(true);
        }
    }
    public void SetDeActiveTakeOffAreaBoxesForRobot()
    {
        if (canWork)
        {
            takeOffAreaController.takeOffAreaBoxesLine--;
            takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine].SetActive(false);
        }
    }
}
