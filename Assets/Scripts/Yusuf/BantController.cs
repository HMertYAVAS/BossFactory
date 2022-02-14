using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BantController : MonoBehaviour
{
    public TakeOffAreaController takeOffAreaController;
    public List<GameObject> boxesList;
    public float bantPeriodTime;

    public float timer;
    public Transform startPoint;

    private void Start()
    {
        timer = 0;
    }
    public bool canWork
    {
        get
        {
            return takeOffAreaController.takeOffAreaBoxesLine >= 0 && timer <= 0;
        }
    }

    private void Update()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (canWork)
        {
            timer = bantPeriodTime;
            MoveToStartPoint();
        }
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
        takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine].transform.DOMove(startPoint.position, 1f).OnComplete(()=>SetActiveBoxes());
    }
    public void SetActiveBoxes()
    {
        boxesList[takeOffAreaController.takeOffAreaBoxesLine].gameObject.SetActive(true);
        takeOffAreaController.takeOffAreaBoxesLine--;
    }
    public void SetDeActiveTakeOffAreaBoxes()
    {
        takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine].SetActive(false);
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
