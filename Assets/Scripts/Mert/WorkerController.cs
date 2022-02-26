using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerController : MonoBehaviour
{
    public float moveTime;
    public float workTime;
    float workTimeTemp;


    Sequence seq;



    bool playerInTrigger;

    public int workerPrice;

    public Transform WorkStation;
    public Transform TakeOffAreaTransform;

    private void Start()
    {
        DOTween.Init();
        workTimeTemp = workTime;
    }

    public void BuyToWorkerCoroutine()
    {
        StartCoroutine(BuyToWorker());
    }


    IEnumerator BuyToWorker()
    {
        yield return new WaitForSeconds(1f);
        if (workerPrice <= MoneyController.instance.money)
        {
            MoneyController.instance.money -= workerPrice;
            movingWorker();

        }
    }

    void movingWorker()
    {
        if (workTime > 0)
        {
            seq = DOTween.Sequence();

            seq.Append(transform.DOMove(WorkStation.transform.position, moveTime));
            // TODO: OnComplete içinde func deðiþtirilecek. Uygun tracking noktalarý eklendiðinde.
            seq.Append(transform.DOMove(TakeOffAreaTransform.position, moveTime).OnComplete(movingWorker));
            workTime --;
        }
        else
        {
            // TODO Burasý uyku noktasý
            //this.gameObject.SetActive(false);
            StartCoroutine(SleepWorker());
            
        }
    }

    IEnumerator SleepWorker()
    {
        yield return new WaitForSeconds(4);
        workTime = workTimeTemp;
        movingWorker();
    }
}
